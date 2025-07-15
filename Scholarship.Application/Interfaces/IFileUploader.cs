using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Interfaces
{
    public interface IFileUploader
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string subFolder);
    }
}
