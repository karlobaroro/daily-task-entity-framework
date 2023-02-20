using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        HRContext context;
        public StudentController()
        {
            context = new HRContext();
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public List<Student> GetStudents()
        {
            return context.Students.ToList<Student>();
        }

        [HttpPost]
        [Route("AddStudent")]
        public ActionResult AddStudent(Student student)
        {
            try
            {
                context.Students.Add(student);
                context.SaveChanges();

                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("RemoveStudent")]
        public bool UpdateStudent(Student request)
        {
            var student = context.Students.SingleOrDefault(x => x.Id == request.Id);
            if (student != null)
            {
                student.Name = request.Name;
                student.Course = request.Course;
                context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        [HttpDelete]
        [Route("RemoveStudent")]
        public bool DeleteStudent(int id)
        {
            var student = context.Students.SingleOrDefault(x => x.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }
            else
                return false;

        }

    }
}
