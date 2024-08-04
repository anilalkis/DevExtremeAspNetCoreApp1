using DevExpress.Data.Browsing;
using DevExtremeAspNetCoreApp1.Context;
using DevExtremeAspNetCoreApp1.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Web;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class FileController : Controller
    {
        private readonly Context1 _context;
        private readonly string _uploadFolderPath;



        public FileController(Context1 context)
        {
            _context = context;
            _uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file, int id)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya seçilmedi.");
            }

            var filePath = Path.Combine(_uploadFolderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var entity = new FilePath()
            {
                Path = filePath,
                KararId = id
            };

            await _context.AddAsync(entity);
            _context.SaveChanges();

            return Ok();
        }

        public async Task<IActionResult> Download(int id)
        {

            var fileRecord = await _context.filePaths
                .Where(i => i.FilePathId == id)
                .FirstOrDefaultAsync();
            if (fileRecord == null || !System.IO.File.Exists(fileRecord.Path))
            {
                return NotFound();
            }

            string fileName = Path.GetFileName(fileRecord.Path);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileRecord.Path, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            return PhysicalFile(fileRecord.Path, contentType, fileName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Retrieve the file record from the database
            var fileRecord = await _context.filePaths
                .Where(i => i.FilePathId == id)
                .FirstOrDefaultAsync();

            if (fileRecord == null)
            {
                return NotFound();
            }

            // Remove the file from the physical file system
            if (System.IO.File.Exists(fileRecord.Path))
            {
                try
                {
                    System.IO.File.Delete(fileRecord.Path);
                }
                catch (Exception ex)
                {
                    // Log the exception (if needed)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting file: {ex.Message}");
                }
            }

            // Remove the file record from the database
            _context.filePaths.Remove(fileRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
