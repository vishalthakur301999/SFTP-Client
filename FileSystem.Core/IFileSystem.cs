using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Core
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
        bool DirectoryExists(string directoryPath);
        void CreateDirectoryIfNotExists(string directoryPath);
        void DeleteFileIfExists(string filePath);
    }
}
