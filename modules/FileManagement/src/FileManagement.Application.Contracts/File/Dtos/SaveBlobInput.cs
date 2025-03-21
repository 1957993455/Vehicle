using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.Contracts.File.Dtos;

public class SaveBlobInput
{
    public string Name { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public byte[] Content { get; set; } = null!;
}
