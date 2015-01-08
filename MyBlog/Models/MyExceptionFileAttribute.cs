using MyBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class MyExceptionFileAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //处理错误消息，将其跳转到一个页面
            LogHelper.WriteLog(filterContext.Exception.ToString());
            //页面跳转到错误页面
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}