using Microsoft.AspNetCore.Http;

namespace RepositoryFile.Repository.Interfaces
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        bool DeleteImage(string imageFileName);
    }
}
