using System.Collections.Generic;

namespace FileManagement.Application.Contracts.File.Dtos;

public class SaveBlobsInput
{
    public required List<SaveBlobInput> Files { get; set; }
}
