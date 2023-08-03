using Microsoft.AspNetCore.Http;
using System;

namespace Core.Utilities.Uploaders
{
    public class FileUploaderManager : IFileUploader
    {
        public string Upload(IFormFile file, string root)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Dosya yüklenmedi");
            }

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string extension = Path.GetExtension(file.FileName);
            string guid = Guid.NewGuid().ToString();
            string fileName = guid + extension;

            string filePath = Path.Combine(root, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }
        
        public string Update(IFormFile file, string filePath, string root)
        {

            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }
    }
}

