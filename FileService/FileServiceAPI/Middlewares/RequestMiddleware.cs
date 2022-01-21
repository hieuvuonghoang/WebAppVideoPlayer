using FileServiceAPI.Models;
using FileServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileServiceAPI.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService authenticationService, IOptions<AppSettings> appSetting)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(!string.IsNullOrEmpty(token))
            {
                var nguoiDung = await authenticationService.GetNguoiDung(token);
                if (nguoiDung != null)
                {
                    context.Items[appSetting.Value.KeyNameNguoiDung] = nguoiDung;
                }
            }
            await _next(context);
        } 

    }
}
