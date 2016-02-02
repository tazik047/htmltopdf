using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlToPdf.Filters
{
    public class ConvertToPdfFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.QueryString.GetValues("convert") != null)
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                filterContext.RequestContext.HttpContext.Response.Clear();
                filterContext.RequestContext.HttpContext.Response.ContentType = "application/pdf";
                htmlToPdf.GeneratePdfFromFile(
                    filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri.Split('?')[0], null,
                    filterContext.RequestContext.HttpContext.Response.OutputStream);
            }
            base.OnResultExecuted(filterContext);
        }
    }
}