
namespace ClassServer.FileMethods
{
    public class DocumentFileMethod : GenericFileMethod
    {
        public DocumentFileMethod(IWebHostEnvironment env) : base(env)
        {

        }
        public string GenerateToString(IFormFile formFile) => GenerateToString(formFile);
        
    }
}
