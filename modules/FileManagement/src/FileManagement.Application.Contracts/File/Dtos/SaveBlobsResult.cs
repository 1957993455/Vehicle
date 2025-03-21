using System.Collections.Generic;

namespace FileManagement.Application.Contracts.File.Dtos;

public class SaveBlobsResult
{
    public List<BlobDto> SuccessFiles { get; set; } = new();
    public List<FailedFileInfo> FailedFiles { get; set; } = new();
}
