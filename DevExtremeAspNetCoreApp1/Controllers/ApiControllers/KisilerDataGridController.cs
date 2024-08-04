using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeAspNetCoreApp1.Context;
using DevExtremeAspNetCoreApp1.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

namespace DevExtremeAspNetCoreApp1.Controllers.ApiControllers
{
    public class KisilerDataGridController : Controller
    {
        [HttpGet]
        public object GetAll(DataSourceLoadOptions loadOptions)
        {
            var c = new Context1();
            var items = c.kisiler
            .ToList();
            return DataSourceLoader.Load(items, loadOptions);

        }

        [HttpPost]
        public IActionResult InsertKisi(string values)
        {
            using (var context = new Context1())
            {
                var newKisi = new Kisi();
                JsonConvert.PopulateObject(values, newKisi);

                if (!TryValidateModel(newKisi))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.kisiler.Add(newKisi);
                context.SaveChanges();
                return Ok();

            }

        }

        [HttpPut]
        public IActionResult UpdateKisi(int key, string values)
        {
            using (var context = new Context1())
            {
                var kisi = context.kisiler.First(a => a.KisiId == key);
                JsonConvert.PopulateObject(values, kisi);

                if (!TryValidateModel(kisi))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.SaveChanges();
                return Ok();

            }
        }

        [HttpDelete]
        public void DeleteKisi(int key)
        {
            using (var context = new Context1())
            {
                var kisi = context.kisiler.First(a => a.KisiId == key);
                context.kisiler.Remove(kisi);
                context.SaveChanges();

            }

        }

        [HttpGet]
        public object GetTanimlar(DataSourceLoadOptions loadOptions)
        {
            var z = new Context1();
            var items = z.tanimlar
            .ToList();
            return DataSourceLoader.Load(items, loadOptions);

        }


    }
}
