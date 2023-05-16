namespace PMS.WebUI.Areas.ManagementPanel.Helpers
{
    public class İmageUpload
    {
        public static async Task<string> UploadImageAsync(IWebHostEnvironment hostEnvironment, IFormFile img)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = FileNameControl(Path.GetFileNameWithoutExtension(img.FileName));
            string extension = Path.GetExtension(img.FileName);
            fileName = fileName + DateTime.Now.ToString("yyyMMddss") + extension;

            string path = Path.Combine(wwwRootPath + "/image/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            return "/image/" + fileName;
        }

        private static string FileNameControl(string filename)
        {
            filename.Replace("ş", "s");
            filename.Replace("ç", "c");
            filename.Replace("ı", "i");
            filename.Replace("ö", "o");
            filename.Replace("ü", "u");
            filename.Replace("ğ", "g");
            filename.Replace("Ş", "S");
            filename.Replace("Ç", "C");
            filename.Replace("I", "İ");
            filename.Replace("Ö", "O");
            filename.Replace("Ü", "U");
            filename.Replace("Ğ", "G");

            filename.Replace("-", "");
            filename.Replace("_", "");
            filename.Replace("?", "");

            return filename;
        }
    }
}
