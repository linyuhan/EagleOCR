using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using E.AppServices.Interface;
using StructureMap;

namespace EagleOCR.Controllers
{
    public class ImgProcessController : Controller
    {



        private IImageServices _imageServices;

        public ImgProcessController()
        {
            _imageServices = ObjectFactory.GetInstance<IImageServices>();
        }


        // GET: ImgProcess
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveImage()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];


                Image Image = Image.FromStream(Request.Files["HelpSectionImages"].InputStream);

                string caminho = _imageServices.SaveImage(Image, pic.FileName.ToString());

                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');


                return baseUrl + caminho;
            }
            return "";
        }

        [HttpPost]
        public string GrayScale()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];


                Image Image = Image.FromStream(Request.Files["HelpSectionImages"].InputStream);

                string caminho = _imageServices.GrayScale(Image, pic.FileName.ToString());

                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');


                return baseUrl + caminho;
            }
            return "";
        }
    }
}