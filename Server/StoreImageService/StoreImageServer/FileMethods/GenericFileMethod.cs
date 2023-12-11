using XAct;
namespace FileStoreServer.FileMethods
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
        protected void SaveFile(string folder, IFormFile file)
        {
            var contentPath = this.environment.ContentRootPath;
            var path = Path.Combine(contentPath, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var newFileName = file.FileName;
            var fileWithPath = Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
        }

        public void DeleteFile(string folder, string fileName)
        {
            if (folder.IsNullOrEmpty() || fileName.IsNullOrEmpty()) return;
            var contentPath = this.environment.ContentRootPath;
            var path = Path.Combine(contentPath, folder);
            var fileWithPath = Path.Combine(path, fileName);
            File.Delete(fileWithPath);
        }
    }
}
