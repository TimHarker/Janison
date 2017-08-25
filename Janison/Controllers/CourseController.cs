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
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        [HttpGet, Route("GetCourse/{courseId}")]
        public async Task<IHttpActionResult> GetCourse(int courseId)
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    var course = await _context.Courses
                        .Where(c => c.CourseID == courseId)
                        .FirstOrDefaultAsync();
                    return Ok(course);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("GetCourses")]
        public async Task<IHttpActionResult> GetCourses()
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    var courses = await _context.Courses
                        .Where(c => c.Enabled)
                        .OrderByDescending(c => c.CourseID)
                        .ToListAsync();
                    return Ok(courses);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("DeleteCourse/{courseId}")]
        public async Task<IHttpActionResult> DeleteCourse(int courseId)
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    var course = await _context.Courses.FindAsync(courseId);
                    _context.Entry(course).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

                    return Ok(courseId);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("SaveCourse")]
        public async Task<IHttpActionResult> SaveCourse(Course course)
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    DateTime utcNow = DateTime.UtcNow;
                    course.DateModified = utcNow;
                    // ADD
                    if (course.CourseID == 0)
                    {
                        course.DateCreated = utcNow;
                        _context.Courses.Add(course);
                    }
                    // UPDATE
                    else
                    {
                        _context.Entry(course).State = EntityState.Modified;
                    }
                    await _context.SaveChangesAsync();
                    return Ok(course);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
