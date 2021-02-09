using EH.Assessment.Data;
using EH.Assessment.Models;
using EH.Assessment.Presentation.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EH.Assessment.Presentation.Filters
{
    public class EHExceptionFilter : IExceptionFilter
    {
        readonly IErrorLogRepository _errorLogRepository;

        public EHExceptionFilter(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public void OnException(ExceptionContext context)
        {
            var currentController = string.Empty;
            var currentAction = string.Empty;
            if (context.RouteData != null)
            {
                if (context.RouteData.Values["controller"] != null && !String.IsNullOrEmpty(context.RouteData.Values["controller"].ToString()))
                {
                    currentController = context.RouteData.Values["controller"].ToString();
                }

                if (context.RouteData.Values["action"] != null && !String.IsNullOrEmpty(context.RouteData.Values["action"].ToString()))
                {
                    currentAction = context.RouteData.Values["action"].ToString();
                }
            }

            UserAgent userAgent = null;

            if (context.HttpContext.Request.Headers != null && !string.IsNullOrEmpty(context.HttpContext.Request.Headers["User-Agent"]))
            {
                userAgent = new UserAgent(context.HttpContext.Request.Headers["User-Agent"]);
            }

            var ehErrorViewModel = new ErrorLogModel
            {
                Thread = string.Empty,
                Level = "Error",
                Logger = string.Empty,
                Message = context.Exception.Message,
                Exception = context.Exception.StackTrace,
                UserName = context.HttpContext.User.Identity.Name,
                Controller = currentController,
                Action = currentAction,
                Application = "EH.Assessment",
                EmailSent = false,
            };

            if (userAgent != null)
            {
                ehErrorViewModel.BrowserType = userAgent.Browser.Name;
                ehErrorViewModel.BrowserVersion = userAgent.Browser.Version;
                ehErrorViewModel.ClientOperatingSystem = userAgent.OS.Name + "_" + userAgent.OS.Version;
            }

            if (context.HttpContext.Request.QueryString != null && context.HttpContext.Request.QueryString.HasValue)
            {
                ehErrorViewModel.QueryString = context.HttpContext.Request.QueryString.Value;
            }

            ehErrorViewModel.RequestMethod = context.HttpContext.Request.Method;
            ehErrorViewModel.RemoteHost = context.HttpContext.Request.Host.Value;

            _errorLogRepository.Add(ehErrorViewModel);

            context.Result = new ViewResult()
            {
                ViewName = "Error"
            };

        }
    }
}
