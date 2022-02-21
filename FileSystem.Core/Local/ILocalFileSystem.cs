using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Core.Local
{
    public interface ILocalFileSystem : IFileSystem
    {
        string RootDirectoryPath { get; }
        bool Exists();
        void CreateIfNotExists();
    }
}
