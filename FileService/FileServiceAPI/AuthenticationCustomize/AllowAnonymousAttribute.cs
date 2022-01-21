using System;
using System.Collections.Generic;
using System.Text;

namespace FileServiceAPI.AuthenticationCustomize
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}
