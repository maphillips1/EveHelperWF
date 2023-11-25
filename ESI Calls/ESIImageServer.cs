using EveHelperWF.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIImageServer
    {
        
        private static byte[] GetImageFromLocal(int typeId, string modifier)
        {
            byte[] imageBytes = null;

            string fileName = string.Format("eveImage_{0}_{1}.png", typeId, modifier);

            string imagePath = Path.Combine(Enums.Enums.ImagesDirectory, fileName);

            if (File.Exists(imagePath))
            {
                imageBytes = File.ReadAllBytes(imagePath);
            }

            return imageBytes;
        }

        private static void StoreImageLocally(byte[] imageBytes, int typeId, string modifier)
        {
            if (imageBytes != null) 
            {
                //Images are given to us as PNG

                string fileName = string.Format("eveImage_{0}_{1}.png", typeId, modifier);
                string imagesFolder = Enums.Enums.ImagesDirectory;

                string imagePath = Path.Combine(imagesFolder, fileName);

                if (!File.Exists(imagePath))
                {
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }
                    File.Create(imagePath).Close();
                    File.WriteAllBytes(imagePath, imageBytes);
                }
            }
        }

        public static byte[] GetImageForType(int typeId, string modifier)
        {
            byte[] imageBytes = GetImageFromLocal(typeId, modifier);

            //We have not gotten this image before. Get it from Eve Image Server
            if (imageBytes == null && modifier != null)
            {
                string url = "https://images.evetech.net/types/" + typeId.ToString() + "/" + modifier;
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(url).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                     imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                    StoreImageLocally (imageBytes, typeId, modifier);
                }
            }


            return imageBytes;
        }
    }
}
