using Microsoft.AspNetCore.Http;
using MovieCatalog.Dao;
using MovieCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieCatalog.Helpers
{
    public class FileHelper
    {

        private const string MovieCoversFolderName = "/movie-covers/";

        public async static Task<Exception> UploadFile(IFormFile file, string absolutePath)
        {
            if (file != null)
            {
                string path = $"{absolutePath}/{MovieCoversFolderName}/{GenerateFileName(absolutePath)}";
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return null;
            }
            return new Exception("Ошибка при загрузке файла");
        }

        public static IEnumerable<CoverFile> GetFiles(string absolutePath)
        {
            string fullPath = $"{absolutePath}/{MovieCoversFolderName}";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            IEnumerable<CoverFile> files = Directory.EnumerateFiles(fullPath)
                .Select(file => new CoverFile() {
                    Name = file,
                    Url = $"{MovieCoversFolderName}{file.Split("/").Last()}"
                });
            return files;
        }

        private static string GenerateFileName(string absolutePath)
        {
            string fullPath = $"{absolutePath}/{MovieCoversFolderName}";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            int max = 0, value;
            string numberInString;
            foreach (string fileName in Directory.EnumerateFiles(fullPath))
            {
                numberInString = Regex.Match(fileName, @"\d+").Value;
                value = Int32.Parse(numberInString);
                if (max < value)
                    max = value;
            }
            return $"cover{max+1}.jpg";
        }

    }
}
