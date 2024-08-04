using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using DevExtremeAspNetCoreApp1.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DevExtremeAspNetCoreApp1.Entities;
using Newtonsoft.Json.Linq;

namespace DevExtremeAspNetCoreApp1.Controllers.ApiControllers
{

    [Route("api/[controller]")]
    public class DataGridMasterDetailAPIController : Controller {

        //private readonly Context1 _context;

        //public DataGridMasterDetailAPIController(Context1 context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public object Get() {

            var c = new Context1();
            
            var item = c.personelGorevler
                .Include(i => i.Kisi)
                .Include(i => i.Tanim)
                .ToList();
            return Json(item);
            
        }

        [HttpPost]
        public IActionResult InsertGorev(string values)
        {
            using (var context = new Context1())
            {
                var newEmployee = new PersonelGorev();
                JsonConvert.PopulateObject(values, newEmployee);

                if (!TryValidateModel(newEmployee))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.personelGorevler.Add(newEmployee);
                context.SaveChanges();
                return Ok();

            }


        }

        [HttpPut]
        public IActionResult UpdateGorev(int key, string values)
        {
            using (var context = new Context1())
            {
                var employee = context.personelGorevler.First(a => a.PGID == key);
                JsonConvert.PopulateObject(values, employee);

                if (!TryValidateModel(employee))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.SaveChanges();
                return Ok();

            }
        }

        [HttpDelete]
        public void DeleteGorev(int key)
        {
            using (var context = new Context1())
            {
                var employee = context.personelGorevler.First(a => a.PGID == key);
                context.personelGorevler.Remove(employee);
                context.SaveChanges();

            }
            
        }

    }
}
