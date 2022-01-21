using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceAPI.Models
{
    public class AppSettings
    {
        public string LinkFileService { get; set; }
        public string StoredFilesPath { get; set; }
        public string PhimAnhStoredFilesPath { get; set; }
        public string BieuMauStoredFilesPath { get; set; }
        public string KeyNameNguoiDung { get; set; }
    }
}
