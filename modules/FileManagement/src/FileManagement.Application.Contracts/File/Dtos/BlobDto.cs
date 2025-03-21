using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.Contracts.File.Dtos;

public class BlobDto
{
    public string Name { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long Size { get; set; } 
    public byte[] Content { get; set; } = null!;
    public string Url { get; set; } = null!;
}
