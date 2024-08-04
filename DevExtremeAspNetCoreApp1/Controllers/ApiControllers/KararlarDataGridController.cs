using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeAspNetCoreApp1.Context;
using DevExtremeAspNetCoreApp1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace DevExtremeAspNetCoreApp1.Controllers.ApiControllers
{
    public class KararlarDataGridController : Controller
    {
        private readonly Context1 context1;

        public KararlarDataGridController(Context1 context1)
        {
            this.context1 = context1;
        }

        public async Task<object> Get()
        {

            var items = await context1.kararlar
                .ToListAsync();
            return Json(items);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            using (var context = new Context1())
            {
                var newKarar = new Karar();
                JsonConvert.PopulateObject(values, newKarar);
                newKarar.Id = 0;
                if (!TryValidateModel(newKarar))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.kararlar.Add(newKarar);
                context.SaveChanges();
                return Ok();

            }

        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            using (var context = new Context1())
            {
                var karar = context.kararlar.First(a => a.Id == key);
                JsonConvert.PopulateObject(values, karar);

                if (!TryValidateModel(karar))
                    return BadRequest(ModelState.GetFullErrorMessage());

                context.SaveChanges();
                return Ok();

            }
        }

        [HttpDelete]
        public void Delete(int key)
        {
            using (var context = new Context1())
            {
                var karar = context.kararlar.First(a => a.Id == key);
                context.kararlar.Remove(karar);
                context.SaveChanges();

            }

        }

        [HttpDelete]
        public void DeleteFile(int key)
        {
            using (var context = new Context1())
            {
                var file = context.filePaths.First(a => a.FilePathId == key);
                context.filePaths.Remove(file);
                DeleteDosya(key);

                // Remove the file record from the database
                context.filePaths.Remove(file);
                context.SaveChanges();

            }

        }

        [HttpGet]
        public object FileDetails(int KararId, DataSourceLoadOptions loadOptions)
        {
            var items = context1.filePaths.Where(i=>i.KararId == KararId).ToList();

            
            return Json(items);
        }

        public async Task<object> DeleteDosya(int id)
        {
            var fileRecord = await context1.filePaths
                .Where(i => i.FilePathId == id)
                .FirstOrDefaultAsync();

            if (fileRecord == null)
            {
                return NotFound();
            }

            if (System.IO.File.Exists(fileRecord.Path))
            {
                try
                {
                    System.IO.File.Delete(fileRecord.Path);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting file: {ex.Message}");
                }
            }

            

            return Ok();
        }
    }
}
