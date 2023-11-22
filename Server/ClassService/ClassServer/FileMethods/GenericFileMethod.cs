using Microsoft.IdentityModel.Tokens;
using XAct;

namespace ClassServer.FileMethods
{
    public class GenericFileMethod
    {
        protected IWebHostEnvironment environment;
        public GenericFileMethod(IWebHostEnvironment env)
        {
            this.environment = env;
        }
        protected byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public string? SaveFile(string folder, IFormFile file, string? newName)
        {
            if (folder .IsNullOrEmpty() || file == null) { return null; }
            var contentPath = this.environment.ContentRootPath;
            var path = Path.Combine(contentPath, folder);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var newFileName = file.FileName;
            if (newName != null) newFileName = newName;
            var fileWithPath = Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
            return newFileName;
        }
        protected string GenerateToString(IFormFile formFile)
        {
            try
            {
                var ext = Path.GetExtension(formFile.FileName);
                var fileToByte = ConvertIFormFileToByteArray(formFile);
                string fileString = Convert.ToBase64String(fileToByte);
                return fileString;
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }
    }
}
