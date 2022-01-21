using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceAPI.Services
{
    public interface IMimeService
    {
        string GetMimeType(string extension);
    }
}
