using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCQ_EmployeeService.Models;

namespace TCQ_EmployeeService.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentV1Controller : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){ Id=1,Name="Tom"},
            new Student(){ Id=2,Name="Jerry"},
            new Student(){ Id=3,Name="John"}
        };

        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "Student Not Found");
            }
            else
            {
                return Ok(student);
            }
        }

        //[Route("~/api/teachers")]//override routePrefix
        //public IEnumerable<Teacher> GetTeachers()
        //{
        //    List<Teacher> teachers = new List<Teacher>()
        //    {
        //        new Teacher() { Id = 1, Name = "Rob" },
        //        new Teacher() { Id = 2, Name = "Mike" },
        //        new Teacher() { Id = 3, Name = "Mary" }
        //    };

        //    return teachers;
        //}

        //public IEnumerable<Student> Get()
        //{
        //    return students;

        //}
        //[Route("{id:int:min(1)}",Name = "GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(s=>s.Id==id);

        //}

        //public HttpResponseMessage Post(Student student)
        //{
        //    students.Add(student);
        //    var response = Request.CreateResponse(HttpStatusCode.Created);
        //    response.Headers.Location = new Uri(Url.Link("GetStudentById",new { id=student.Id}));
        //    return response;
        //}


        //[Route("{name:alpha}")]
        //public Student Get(string name)
        //{
        //    return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());

        //}

        //[Route("{id}/courses")]
        //public IEnumerable<string> GetStudentCourses(int id)
        //{
        //    if (id == 1)
        //        return new List<string>() { "C#", "ASP.NET", "SQL Server" };
        //    else if (id == 2)
        //        return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
        //    else
        //        return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        //}

    }
}
