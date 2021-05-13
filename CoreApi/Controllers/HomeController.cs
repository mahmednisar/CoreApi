using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Dto;
using CoreApi.Services;

namespace CoreApi.Controllers
{
   
    public class HomeController : BaseController
    {
        public HomeController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        private readonly IStudentServices _studentServices;

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return _studentServices.GetStudent();
        }

        [HttpGet]
        public Student GeStudentById(int id)
        {
            return _studentServices.GetStudentById(id);
        }

        [HttpPost]
        public List<Student> SaveStudents(Student student)
        {
            return _studentServices.SaveStudent(student);
        }


        [HttpGet]
        public Student CurrStudent()
        {
            return CurrentStudent;
        }


    }
}
