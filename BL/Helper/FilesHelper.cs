using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Helper
{
    public class FilesHelper
    {
        public static string Upload(IFormFile FileUrl,string Folder)
        {
            string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/"+Folder;
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
            string FinalPath = Path.Combine(FolderPath, FileName);
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }

            return FileName;
        }
        public static void Remove(String Folder ,string File)
        {
            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ Folder + File))
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ Folder + File);
            }

        }
    }
}
