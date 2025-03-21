using FileManagement.Application.Contracts.File.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace FileManagement.Application.Contracts.File;

/// <summary>
/// 文件服务接口
/// </summary>
public interface IFileAppService: IApplicationService,ITransientDependency
{
    Task<BlobDto> SaveAsync(SaveBlobInput input);

    Task<byte[]> GetBlobAsync(string path, CancellationToken cancellationToken = default);

    Task DeleteAsync(string name);

    Task<SaveBlobsResult> SaveMultipleAsync(SaveBlobsInput input);

    Task<Stream> GetBlobStreamAsync(string path, CancellationToken cancellationToken = default);
}
