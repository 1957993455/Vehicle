using FileManagement.Application.Contracts.File;
using FileManagement.Application.Contracts.File.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace Vehicle.App.FileManagement.HttpApi.Controllers;

[Route("api/email")]
[RemoteService(Name = "FileManagement")]
public class FileController: FileManagementController
{

    protected IFileAppService FileAppService { get; }

    public FileController(IFileAppService fileAppService)
    {
        FileAppService = fileAppService;
    }

    /// <summary>
    /// 文件上传接口
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    /// <exception cref="UserFriendlyException"></exception>
    [HttpPost("upload")]
    [AllowAnonymous]
    [RequestSizeLimit(5 * 1024 * 1024)] // 5MB 限制
    public async Task<BlobDto> UploadAsync([Required] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new UserFriendlyException("文件不能为空");
        }

        using var ms = new MemoryStream();

        await file.CopyToAsync(ms);

        var result = await FileAppService.SaveAsync(new SaveBlobInput
        {
            Name = file.FileName,
            ContentType = file.ContentType,
            Content = ms.ToArray()
        });
        return result;
    }

    /// <summary>
    /// 文件下载接口
    /// </summary>
    /// <param name="filePath">文件相对路径（支持URL编码）</param>
    /// <response code="200">返回文件流</response>
    /// <response code="400">无效的文件路径</response>
    /// <response code="404">文件不存在</response>
    [AllowAnonymous]
    [HttpGet("download/{*filePath}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DownloadFile(
     string filePath,
     CancellationToken cancellationToken = default)
    {
        try
        {
            // 验证输入有效性
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest("File path cannot be empty");
            }

            // 解码文件路径
            string name = Uri.UnescapeDataString(filePath);

            filePath = filePath.Split('/').Last();

            // 获取文件流
            Stream blobStream = await FileAppService.GetBlobStreamAsync(filePath, cancellationToken);

            if (blobStream == null)
            {
                return NotFound("File not found");
            }

            // 推断内容类型
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            // 提取文件名
            string fileName = Path.GetFileName(filePath);
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "download";
            }

            // 设置下载头
            var cd = new ContentDispositionHeaderValue("attachment")
            {
                FileNameStar = fileName // 处理特殊字符（UTF-8编码）
            };
            Response.Headers.Append("Content-Disposition", cd.ToString());

            // 流式返回文件
            return File(blobStream, contentType);
        }
        catch (OperationCanceledException)
        {
            // 处理请求取消
            return StatusCode(499); // Client Closed Request
        }
        catch (Exception ex)
        {
            // 记录日志
            Logger.LogError(ex, "Error downloading file: {FilePath}", filePath);
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    /// <summary>
    /// 文件下载接口
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("{name}")]
    public async Task<IActionResult> GetAsync(string name)
    {
        byte[] blob = await FileAppService.GetBlobAsync(name);
        return Ok(blob);
    }

    [HttpDelete("{name}")]
    public Task DeleteAsync(string name)
    {
        return FileAppService.DeleteAsync(name);
    }

    [AllowAnonymous]
    [HttpPost("upload-multiple")]
    [RequestSizeLimit(20 * 1024 * 1024)] // 20MB 总限制
    public async Task<SaveBlobsResult> UploadMultipleAsync(IFormFileCollection files)
    {
        if (files == null || !files.Any())
        {
            throw new UserFriendlyException("文件不能为空");
        }

        var input = new SaveBlobsInput
        {
            Files = new List<SaveBlobInput>()
        };

        foreach (var file in files)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            input.Files.Add(new SaveBlobInput
            {
                Name = file.FileName,
                ContentType = file.ContentType,
                Content = ms.ToArray()
            });
        }

        return await FileAppService.SaveMultipleAsync(input);
    }

    [AllowAnonymous]
    [HttpGet("upload-progress/{id}")]
    public async Task<IActionResult> GetUploadProgressAsync(string id)
    {
        return Ok(new { progress = 100 });
    }
}
