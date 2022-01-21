using FileServiceAPI.AuthenticationCustomize;
using FileServiceAPI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileServiceAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly LinkAPI _linkAPI;

        public AuthenticationService(IOptions<LinkAPI> linkAPI)
        {
            _linkAPI = linkAPI.Value;
        }

        public async Task<HT_NGUOIDUNG> GetNguoiDung(string accessToken)
        {
            var client = new RestClient(_linkAPI.AuthenticationLinAPI);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            var response = await client.ExecuteAsync(request);
            var nguoiDung = JsonConvert.DeserializeObject<HT_NGUOIDUNG>(response.Content);
            return nguoiDung;
        }
    }
}
