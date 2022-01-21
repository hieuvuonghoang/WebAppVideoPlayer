using System;
using System.Collections.Generic;
using System.Text;

namespace FileServiceAPI.Services
{
    public interface IFileService
    {
        public Tuple<bool, string> MergeFile(string fileName);
    }
}
