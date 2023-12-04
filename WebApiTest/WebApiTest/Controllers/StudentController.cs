using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApiTest.Models;


namespace WebApiTest.Controllers
{
  
       
        [Route("api/[controller]")]
        [ApiController]
        public class StudentsController : ControllerBase
        {
            private readonly MainDBContext _context;

            public StudentsController(MainDBContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
            {
                return await _context.Students.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Student>> GetStudent(int id)
            {
                var student = await _context.Students.FindAsync(id)
    ;

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
            [HttpGet("GetByFirstName")]
            public IActionResult GetByFirstName([FromQuery] string firstName)
            {
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    return BadRequest("FirstName cannot be empty or null.");
                }

                var enrollments = _context.Enrollments
                    .Where(e => e.Student.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (enrollments == null || !enrollments.Any())
                {
                    return NotFound("No enrollments found for the given FirstName.");
                }

                return Ok(enrollments);
            }

            [HttpPost]
            public async Task<ActionResult<Student>> PostStudent(Student student)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutStudent(int id, Student student)
            {
                if (id != student.StudentId)
                {
                    return BadRequest();
                }

                _context.Entry(student).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(id))
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

            private bool StudentExists(int id)
            {
                throw new NotImplementedException();
            }



            [HttpGet("StudentByFirstName")]
            public IActionResult GetEnrollmentsByStudentFirstName(string firstName)
            {
                var enrollments = _context.Enrollments
                    .Include(e => e.Student)
                    .Include(e => e.Course) .Where(e => e.Student.FirstName.ToLower() == firstName.ToLower()) .ToList();

                return Ok(enrollments);
            }
           


        }
    }
