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
        public static string GetFileContent(string directoryName, string filename)
        {
            string fileContent = "";

            if (Directory.Exists(directoryName))
            {
                if (File.Exists(filename))
                {
                    fileContent = File.ReadAllText(filename);
                }
            }

            return fileContent;
        }

        public static void SaveFileContent(string directory, string filename, string content)
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

        public static void SaveFileContent(string directory, string filename, byte[] content)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            File.WriteAllBytes(filename, content);

        }
    }
}
