using Microsoft.AspNetCore.Http;
using RepositoryFile.Repository.Interfaces;
//using Microsoft.AspNetCore.Hosting;

namespace RepositoryFile.Repository.ClassDefines
{
    public class FileService : IFileService
    {
        public FileService(/*IWebHostEnvironment evn*/)
        {
            
        }
        public bool DeleteImage(string imageFileName)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
