using Janison.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Janison.Controllers
{
    [RoutePrefix("api/layout")]
    public class LayoutController : ApiController
    {
        [HttpGet, Route("getTotalCourseCount")]
        public async Task<IHttpActionResult> GetTotalCourseCount()
        {
            try
            {
                using (var _context = new JanisonContext())
                {
                    var numberOfCourses = await _context.Courses.CountAsync();
                    return Ok(numberOfCourses);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
