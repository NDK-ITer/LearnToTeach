namespace ClassServer.FileMethods
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
                if (formFile == null) return string.Empty;
                
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
    }
}
