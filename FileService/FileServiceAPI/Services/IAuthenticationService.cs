using FileServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceAPI.Services
{
    public interface IAuthenticationService
    {
        Task<HT_NGUOIDUNG> GetNguoiDung(string accessToken);
    }
}
