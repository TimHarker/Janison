using Janison.Data;
using Janison.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Janison.Controllers
{
    [RoutePrefix("api/module")]
    public class ModuleController : ApiController
    {
        [HttpGet, Route("GetModules/{courseId}")]
        public async Task<IHttpActionResult> GetModules(int courseId)
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    var course = await _context.Courses
                        .Include(c => c.Modules)
                        .Where(c => c.CourseID == courseId)
                        .FirstOrDefaultAsync();
                    course.Modules = course.Modules.OrderByDescending(m => m.DateCreated).ToList();
                    return Ok(course);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("SaveModule")]
        public async Task<IHttpActionResult> SaveModule(Module module)
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    DateTime utcNow = DateTime.UtcNow;

                    // ADD Module
                    module.DateCreated = utcNow;
                    _context.Modules.Add(module);

                    // UPDATE Course - date modified
                    var course = await _context.Courses.FindAsync(module.CourseID);
                    course.DateModified = utcNow;
                    _context.Entry(course).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    return Ok(module);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
