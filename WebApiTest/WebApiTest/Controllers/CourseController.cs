using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;


namespace WebApiTest.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class CoursesController : ControllerBase
        {
            private readonly MainDBContext _context;

            public CoursesController(MainDBContext context)
            {
                _context = context;
            }


            [HttpGet("GetAllCourse")]
            public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
            {
                return await _context.Courses.ToListAsync();
            }


            [HttpGet("GetCourse")]
            public async Task<ActionResult<Course>> GetCourse(int id)
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }

            [HttpGet("GetCourseByName")]
            public IActionResult GetEnrollmentsByStudentFirstName(string course)
            {
                var enrollments = _context.Enrollments.Include(e => e.Student)
                    .Include(e => e.Course).Where(e => e.Student.FirstName.ToLower() == course.ToLower()).ToList();

                return Ok(enrollments);
            }



            [HttpPost("AddCourse")]
            public async Task<ActionResult<Course>> InsertsCourse(Course course)
            {
            
               if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
            }

            // PUT: api/Courses/5
            [HttpPut("EditCourse")]
            public async Task<IActionResult> EditCourse(int id, Course course)
            {
                if (id != course.CourseId)
                {
                    return BadRequest();
                }

                _context.Entry(course).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }


            [HttpDelete("DeleteCourse")]
            public async Task<IActionResult> DeleteCourse(int id)
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CourseExists(int id)
            {
                return _context.Courses.Any(e => e.CourseId == id);
            }
        }

    }



