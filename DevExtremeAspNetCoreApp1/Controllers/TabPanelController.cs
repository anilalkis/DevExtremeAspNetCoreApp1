using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class TabPanelController : Controller {
        public ActionResult Overview() {
            return View();
        }

        public ActionResult Templates() {
            return View();
        }

        //[HttpGet]
        //public ActionResult GetCompanies(DataSourceLoadOptions loadOptions) {
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TabPanelData.Companies, loadOptions)), "application/json");
        //}

        //[HttpGet]
        //public ActionResult GetTabPanelItems(DataSourceLoadOptions loadOptions) {
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TabPanelData.TabPanelItems, loadOptions)), "application/json");
        //}

        public class TabPanelItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public object Content { get; set; }
        }
    }
}
