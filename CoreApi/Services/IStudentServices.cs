using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Dto;

namespace CoreApi.Services
{
    public  interface IStudentServices
    {
        List<Student> GetStudent();
        Student GetStudentById(int id);
        List<Student> SaveStudent(Student student);

    }
}
