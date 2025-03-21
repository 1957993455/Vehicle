using FileManagement.Application.Contracts.File;
using FileManagement.Application.Contracts.File.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.App.FileManagement.Domain.Shared.File;
using Volo.Abp;
using Volo.Abp.BlobStoring;

namespace Vehicle.App.FileManagement.Application.File;

public class FileAppService : IFileAppService
{
    protected IBlobContainer BlobContainer { get; }

    public FileAppService(IBlobContainer blobContainer)
    {
        BlobContainer = blobContainer;
    }

    private static void ValidateFile(SaveBlobInput input)
    {
        // 验证文件大小
        if (input.Content.Length > FileValidationConsts.MaxFileSize)
        {
            throw new UserFriendlyException($"文件大小不能超过 {FileValidationConsts.MaxFileSize / 1024 / 1024}MB");
        }

        // 验证文件类型
        string extension = Path.GetExtension(input.Name).ToLower();
        if (!FileValidationConsts.AllowedImageExtensions.Contains(extension) &&
            !FileValidationConsts.AllowedDocumentExtensions.Contains(extension))
        {
            throw new UserFriendlyException($"不支持的文件类型: {extension}");
        }

        // 验证 MIME 类型
        if (input.ContentType != null &&
            !FileValidationConsts.AllowedImageMimeTypes.Contains(input.ContentType.ToLower()))
        {
            if (!input.ContentType.StartsWith("application/"))  // 对于文档类型的特殊处理
            {
                throw new UserFriendlyException($"不支持的文件类型: {input.ContentType}");
            }
        }
    }

    /// <summary>
    /// 保存图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<BlobDto> SaveAsync(SaveBlobInput input)
    {
        ValidateFile(input);

        // 生成唯一文件名
        string extension = Path.GetExtension(input.Name);
        string fileName = $"{Guid.NewGuid()}{extension}";

        await BlobContainer.SaveAsync(fileName, input.Content, overrideExisting: true);

        return new BlobDto
        {
            Name = fileName,
            ContentType = input.ContentType,
            Size = input.Content.Length,
            Url = $"https://localhost:44330/files/host/default/{fileName}"
        };
    }

    public virtual async Task<byte[]> GetBlobAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            byte[] flie = await BlobContainer.GetAllBytesAsync(path, cancellationToken);

            return flie;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<BlobDto> GetAsync(string name)
    {
        try
        {
            byte[] blob = await BlobContainer.GetAllBytesAsync(name);
            string contentType = GetContentType(name);

            return new BlobDto
            {
                Name = Path.GetFileName(name),
                ContentType = contentType,
                Size = blob.Length,
            };
        }
        catch (Exception)
        {
            throw new UserFriendlyException($"找不到文件: {name}");
        }
    }

    private static string GetContentType(string fileName)
    {
        string extension = Path.GetExtension(fileName).ToLower();
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".pdf" => "application/pdf",
            _ => "application/octet-stream"
        };
    }

    public async Task DeleteAsync(string name)
    {
        await BlobContainer.DeleteAsync(name);
    }

    public async Task<SaveBlobsResult> SaveMultipleAsync(SaveBlobsInput input)
    {
        var result = new SaveBlobsResult();

        foreach (SaveBlobInput file in input.Files)
        {
            try
            {
                ValidateFile(file);
                BlobDto savedFile = await SaveAsync(file);
                result.SuccessFiles.Add(savedFile);
            }
            catch (Exception ex)
            {
                result.FailedFiles.Add(new FailedFileInfo
                {
                    FileName = file.Name,
                    Error = ex.Message
                });
            }
        }

        return result;
    }

    public async Task<Stream> GetBlobStreamAsync(string path, CancellationToken cancellationToken = default)
    {
        Stream res = await BlobContainer.GetAsync(path, cancellationToken);

        return res ?? throw new UserFriendlyException($"找不到文件: {path}");
    }
}
