using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UncleProductTracking.Common.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    try
        //    {
        //        //var token = context.ActionArguments["value"] as string;
        //        //var key = context.ActionArguments["key"] as string;
        //        StringValues token, key;
        //        context.HttpContext.Request.Headers.TryGetValue("token", out token);
        //        context.HttpContext.Request.Headers.TryGetValue("key", out key);

        //        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(key))
        //        {
        //            context.Result = new ContentResult
        //            {
        //                Content = "Giriş bilgileri bulunamadı.",
        //                StatusCode = 300
        //            };
        //            return;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
    }
}
