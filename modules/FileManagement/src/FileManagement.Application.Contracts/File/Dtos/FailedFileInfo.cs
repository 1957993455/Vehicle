namespace FileManagement.Application.Contracts.File.Dtos;

public class FailedFileInfo
{
    public string FileName { get; set; } = null!;
    public string Error { get; set; } = null!;
}
