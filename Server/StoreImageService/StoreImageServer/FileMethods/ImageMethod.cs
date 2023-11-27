using FIleStoreServer.Model;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;

namespace FileStoreServer.FileMethods
{
    public class ImageMethod : GenericFileMethod
    {
        private readonly IOptions<Address> link;
        public ImageMethod(IWebHostEnvironment env, IOptions<Address> link) : base(env)
        {
            this.link = link;
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

        public Tuple<string, string>? SaveImage(string folder, string imgStringBase64, string imgName)
        {
            try
            {
                var contentPath = environment.ContentRootPath;
                var path = $"{Path.Combine(contentPath, folder)}\\{imgName}.png";
                string base64String = imgStringBase64;
                byte[] imageBytes = Convert.FromBase64String(base64String);
                File.WriteAllBytes(path, imageBytes);
                var linkServer = $"{link.Value.ThisServiceAddress}";
                var imageName = $"{imgName}.png";
                var result = new Tuple<string, string>(linkServer, imageName);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
