using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Windows.Forms;
using test_system.Models;
#pragma warning disable 618

namespace test_system.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            return View();
        }

        public ActionResult Statistic()
        {
            DataManager DB = new DataManager();
            ViewBag.Items = DB.GetStatistic();
            ViewBag.COUNT = DB.GetCountStat();

            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;

            return View();
        }

        [Authorize]
        public ActionResult CleanStatistic()
        {
            DataManager DB = new DataManager();
            DB.DeleteStatistic();
            return RedirectToAction("Statistic", "Home");
        }

        public ActionResult DeleteGlava(Guid id)
        {
            DataManager DB = new DataManager();
            DB.DeleteGlava(id);
            return RedirectToAction("EditGlav", "Home");
        }

        [Authorize]
        public ActionResult EditGlav()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            DataManager DB = new DataManager();
            ViewBag.Items = DB.GetGlavs();
            ViewBag.COUNT = DB.GetCountGlavs();

            return View();
        }

        public ActionResult Glava(Guid id)
        {
            //Response.ContentType = "application/pdf";
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            DataManager DB = new DataManager();
            ViewBag.Items = DB.GetOneGlav(id);
            ViewBag.Item = DB.GetVoprForGlav(id);
            ViewBag.COUNT = DB.CountVorForGlav(id);

            return View();
        }

        public ActionResult GlavaView(Guid id)
        {
            Response.ContentType = "Application/pdf";
            DataManager DB = new DataManager();
            string PDFFile = (string)DB.GetOneGlav(id).name_file;
            Response.WriteFile(PDFFile);
            Response.End();
            return View();
        }

        public ActionResult Tren(Guid id)
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;
            
            DataManager DB = new DataManager();
            ViewBag.Items = DB.GetGlavs();
            ViewBag.COUNT = DB.GetCountGlavs();

            if (id != Guid.Empty)
            {                     
                ViewBag.Item = DB.GetOneGlav(id);
            }
            else
            {
                foreach (var item in ViewBag.Items)
                {
                    ViewBag.Item = item;
                    break;
                }
            }

            return View();
        }
        public ActionResult ConTest(Guid id)
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            DataManager DB = new DataManager();
            ViewBag.Items = DB.GetGlavs();
            ViewBag.COUNT = DB.GetCountGlavs();

            if (id != Guid.Empty)
            {
                ViewBag.Item = DB.GetOneGlav(id);
            }
            else
            {
                foreach (var item in ViewBag.Items)
                {
                    ViewBag.Item = item;
                    break;
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult VoprScript()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            DataManager DB = new DataManager();
            ViewBag.Item = DB.GetGlavs();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var ITEM in ViewBag.Item)
            {
                Guid temp = ITEM.ID_glav;
                items.Add(new SelectListItem { Text = ITEM.name_glav, Value = temp.ToString() });
            }
            ViewBag.Items = items;
            ViewBag.COUNT = DB.GetCountGlavs();

            return View();
        }

        [HttpPost]
        public ActionResult VoprScript(TempScript elem)
        {
            DataManager DB = new DataManager();
            int res = DB.Parser(elem.ID_glav, elem.SCRIPT);
            if (res == 1)
                return RedirectToAction("Error", "Home");
            else return RedirectToAction("Glava", "Home", new { id = elem.ID_glav});
        }

        public ActionResult Error()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            return View();
        }

        public ActionResult Vopr(Guid id)
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            DataManager DB = new DataManager();
            ViewBag.Item = DB.GetOneVopr(id);
            ViewBag.Items = DB.GetOtvet(id);
            ViewBag.Item2 = DB.GetOneGlav(ViewBag.Item.ID_glav);

            return View();
        }

        public ActionResult DeleteVopros(Guid id)
        {
            DataManager DB = new DataManager();
            Vopr vopr = DB.GetOneVopr(id);
            Guid ID = (Guid)vopr.ID_glav;
            DB.DeleteVopr(id);
            return RedirectToAction("Glava", "Home", new { id = ID });
        }

        [HttpGet]
        public ActionResult UploadGlav()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            return View();
        }

        [HttpGet]
        public ActionResult UploadGlavError()
        {
            ViewBag.NAME = Dns.GetHostName();
            ViewBag.IP = System.Net.Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ViewBag.USER = SystemInformation.UserName;
            DatabaseSilverlightService.dnsInfo.Computer = ViewBag.NAME;
            DatabaseSilverlightService.dnsInfo.IP_address = ViewBag.IP;

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string glav = file.FileName;
                string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                if (ext == ".pdf")
                {
                    string Name = glav.Substring(0, glav.IndexOf('.'));
                    DataManager DB = new DataManager();
                    string fileName = DB.Translit(Name);
                    string Path = "D:/" + fileName + ext;
                    DB.AddGlav(Path, Name);
                    file.SaveAs(Path);
                    return RedirectToAction("EditGlav", "Home");
                }
                else return RedirectToAction("UploadGlavError", "Home");
            }
            else return RedirectToAction("UploadGlavError", "Home");
        }
    }
}
