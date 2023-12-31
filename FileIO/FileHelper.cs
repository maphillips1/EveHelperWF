﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;
using System.Reflection.Metadata;

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

        public static void SaveFileContent(string directoryName, string fileName, string content)
        {
            if (!System.IO.Directory.Exists(directoryName))
            {
                System.IO.Directory.CreateDirectory(directoryName);
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllText(fileName, content);

        }

        public static void SaveFileContent(string directoryName, string fileName, byte[] content)
        {
            if (!System.IO.Directory.Exists(directoryName))
            {
                System.IO.Directory.CreateDirectory(directoryName);
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllBytes(fileName, content);

        }

        public static string[] GetFileNamesInDirectory(string directoryName)
        {
            string[] fileNames = null;
            if (Directory.Exists(directoryName))
            {
                fileNames =  Directory.GetFiles(directoryName);
            }
            else
            {
                System.IO.Directory.CreateDirectory(directoryName);
            }
            if (fileNames == null)
            {
                fileNames = new string[0];
            }
            return fileNames;
        }

        public static void DeleteFile(string directoryName, string fileName)
        {
            if (!System.IO.Directory.Exists(directoryName))
            {
                System.IO.Directory.CreateDirectory(directoryName);
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.Delete(fileName);
        }

        public static string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
