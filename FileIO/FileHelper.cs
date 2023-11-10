using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;

namespace FileIO
{
    public static class FileHelper
    {
        public static string GetCachedFileContent(string filename)
        {
            string fileContent = "";

            if (File.Exists(filename))
            {
                fileContent = File.ReadAllText(filename);
            }

            return fileContent;
        }

        public static void SaveCachedFile(string directory, string filename, string content)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            File.WriteAllText(filename, content);
            
        }
    }
}
