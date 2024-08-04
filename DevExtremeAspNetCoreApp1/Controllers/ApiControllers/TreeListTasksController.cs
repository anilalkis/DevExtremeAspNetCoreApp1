using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using DevExtremeAspNetCoreApp1.Context;
using Newtonsoft.Json.Linq;
using DevExtremeAspNetCoreApp1.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DevExtremeAspNetCoreApp1.Controllers.ApiControllers
{

    [Route("api/[controller]/[action]")]
    public class TreeListTasksController : Controller {

        [HttpGet]
        public object Tasks(DataSourceLoadOptions loadOptions) {
            using (var context = new Context1())
            {
                var tasks = new List<object>();
                tasks = context.birim.Cast<object>().ToList();
                return DataSourceLoader.Load(tasks, loadOptions);
            }

        }

        [HttpPost]
        public IActionResult InsertTask(string values)
        {
            using (var context = new Context1()) 
            {
                var newItem = new Birim();
                JsonConvert.PopulateObject(values, newItem);

                if (!TryValidateModel(newItem))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.birim.Add(newItem);
                context.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateTask(int key, string values)
        {
            using(var context = new Context1()) 
            {
                var item = context.birim.First(e => e.YoksisId == key);
                JsonConvert.PopulateObject(values, item);
                
                if (!TryValidateModel(item))
                    return BadRequest(ModelState.GetFullErrorMessage());

                
                context.SaveChanges();

                return Ok();
            }

            
        }

        [HttpDelete]
        public void DeleteTask(int key)
        {
            using (var context = new Context1())
            {
                var item = context.birim.First(e => e.YoksisId == key);
                context.birim.Remove(item);
                context.SaveChanges();
            }
            
        }
    }
}
