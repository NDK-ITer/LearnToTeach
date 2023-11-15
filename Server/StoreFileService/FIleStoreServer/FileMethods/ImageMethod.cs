
namespace FileStoreServer.FileMethods
{
    public class ImageMethod : GenericFileMethod
    {
        public ImageMethod(IWebHostEnvironment env) : base(env)
        {
        }
        public string GenerateToString(IFormFile formFile)
        {
            try
            {
                var ext = Path.GetExtension(formFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (allowedExtensions.Contains(ext))
                {
                    var fileToByte = ConvertIFormFileToByteArray(formFile);
                    string fileString = Convert.ToBase64String(fileToByte);
                    return fileString;
                }
                return string.Empty;
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }

        public void SaveImage(string folder, string imgString, string imgName)
        {
            try
            {
                var contentPath = environment.ContentRootPath;
                var path = $"{Path.Combine(contentPath, folder)}\\{imgName}.png";
                string base64String = imgString;
                byte[] imageBytes = Convert.FromBase64String(base64String);
                File.WriteAllBytes(path, imageBytes);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
