using ImageMagick;
using Shelly.Abstractions.Helpers;

namespace Shelly.ProviderBlobStorages.Model
{
     public class Files
     {
          #region
          public string Name { get; set; }
          public string OriginalName { get; set; }
          public string RandomName { get; set; }
          public Stream File { get; set; }
          public string ContentType { get; set; }
          public string ContentEncoding { get; set; }
          public string Extension { get; set; }
          #endregion


          private void GetExtension()
          {
               OriginalName = Name;
               if (Name.Contains('.'))
                    Extension = Name.Split('.')[1];
               if (Name.ToLower().Contains($".csv"))
                    ContentType = "text/csv";
               if (Name.ToLower().Contains($".pdf"))
                    ContentType = "application/pdf";
               if (Name.ToLower().Contains($".xls"))
                    ContentType = "application/vnd.ms-excel";
               if (Name.ToLower().Contains($".rtf"))
                    ContentType = "application/rtf";
               if (Name.ToLower().Contains($".doc"))
                    ContentType = "application/msword";
               if (Name.ToLower().Contains($".docx"))
                    ContentType = "application/msword";
               if (Name.ToLower().Contains($".xml"))
                    ContentType = "application/xml";
               if (Name.ToLower().Contains($".zip"))
                    ContentType = "application/zip";
               if (Name.ToLower().Contains($".xlsx"))
                    ContentType = "application/vnd.ms-excel";
               if (Name.ToLower().Contains($".jpg") || Name.ToLower().Contains($".jpeg"))
                    ContentType = "image/jpeg";
               if (Name.ToLower().Contains($".png"))
                    ContentType = "image/png";
               if (Name.ToLower().Contains($".heic") || Name.ToLower().Contains($".heif"))
               {
                    ContentType = "image/jpeg";
                    Extension = "jpeg";
               }
               Name = Name.Substring(0, Name.IndexOf("."));
               Guid myuuid = Guid.NewGuid();
               RandomName = $"{myuuid.ToString().Replace("-", "").ToUpper()}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.{Extension}";
          }

          public Files(string name, Stream stream)
          {
               Name = name;
               if (Name.ToLower().Contains($".heic") || Name.ToLower().Contains($".heif"))
               {
                    using var image = new MagickImage(stream);
                    image.Format = MagickFormat.Jpeg;                    
                    var memStream = new MemoryStream();
                    image.Write(memStream);
                    File = memStream;                    
               }
               else
                    File = stream;
               ContentEncoding = "base64";
               GetExtension();
          }
     }
}

