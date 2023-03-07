using OMS_Web.Models;

namespace LibraryManagmetSystemWeb.Tools
{
    public class FileOperations
    {


        public static FileUploadResult UploadFile(string rootPath, string folderName, IFormFile file)
        {
            FileUploadResult fileUploadResult;

            try
            {
                string uploadFolder = $"Uploads\\{folderName}";
                string uploadPath = Path.Combine(rootPath, uploadFolder);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string extension = Path.GetExtension(file.FileName); // test.pdf
                string newFileName = $"DOC_{DateTime.Now.ToString("yyyyMMdd_HHmmssfff")}{extension}";
                string dbPath = $"\\{Path.Combine(uploadFolder, newFileName)}";

                using (var fileStream = new FileStream(Path.Combine(uploadPath, newFileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                fileUploadResult = new FileUploadResult { FileName = file.FileName, FilePath = dbPath };
                return fileUploadResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<FileUploadResult> UploadMultipleFiles(string rootPath, string folderName, List<IFormFile> files)
        {
            List<FileUploadResult> results = new List<FileUploadResult>();

            foreach (IFormFile formFile in files)
            {
                var result = UploadFile(rootPath, folderName, formFile);
                results.Add(result);
            }

            return results;
        }




    }
}



