using LRSP_Parallel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LRSP_Parallel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<SiteModel> model = new List<SiteModel>();
            model.Add(new SiteModel()
            {
                Title = "My MSDN Profile",
                Url = "https://social.msdn.microsoft.com/profile/lucio%20rogerio%20sp/"
            });

            model.Add(new SiteModel()
            {
                Title = "TechNet",
                Url = "https://technet.microsoft.com/pt-br/"
            });

            model.Add(new SiteModel()
            {
                Title = "MSDN Code",
                Url = "https://code.msdn.microsoft.com/"
            });

            model.Add(new SiteModel()
            {
                Title = "How To Use Parallel",
                Url = "http://www.howtouseparallel.com.br"
            });

            Parallel.ForEach(model,
                (item) =>
                {
                    item.Online = VerifySiteIsOnline(item.Url);
                });

            watch.Stop();
            ViewBag.TotalTime = watch.ElapsedMilliseconds;
            ViewBag.IsUsingParallel = true;

            return View(model);
        }

        public ActionResult WithoutParallel()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<SiteModel> model = new List<SiteModel>();
            model.Add(new SiteModel()
            {
                Title = "My MSDN Profile",
                Url = "https://social.msdn.microsoft.com/profile/lucio%20rogerio%20sp/"
            });

            model.Add(new SiteModel()
            {
                Title = "TechNet",
                Url = "https://technet.microsoft.com/pt-br/"
            });

            model.Add(new SiteModel()
            {
                Title = "MSDN Code",
                Url = "https://code.msdn.microsoft.com/"
            });

            model.Add(new SiteModel()
            {
                Title = "How To Use Parallel",
                Url = "http://www.howtouseparallel.com.br"
            });

            foreach (var item in model)
            {
                item.Online = VerifySiteIsOnline(item.Url);
            }

            watch.Stop();
            ViewBag.TotalTime = watch.ElapsedMilliseconds;
            ViewBag.IsUsingParallel = false;
            return View("Index", model);
        }

        private bool VerifySiteIsOnline(string url)
        {
            bool IsOnline = false;

            try
            {
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(url);
                if (!string.IsNullOrEmpty(downloadString))
                {
                    IsOnline = true;
                }
            }
            catch
            {

            }

            return IsOnline;
        }
    }
}