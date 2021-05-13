using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Dto;

namespace CoreApi.Services
{
    public class StudentServices : IStudentServices
    {
        private List<Student> students;
        public StudentServices()
        {
            students=  new List<Student>();
            students.Add(new Student() { ID = 1, SName = "Nisar Ahmed", Contact = "9876543210" });
            students.Add(new Student() { ID = 2, SName = "Prince Katta", Contact = "9876546455" });
            students.Add(new Student() { ID = 3, SName = "Sahil Sharma", Contact = "9776543210" });
            students.Add(new Student() { ID = 4, SName = "Pragati Parasar", Contact = "9876543255" });
            students.Add(new Student() { ID = 5, SName = "Sunil Jain", Contact = "987654377" });


        }
        public List<Student> GetStudent()
        {
            return students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return students.Find(x => x.ID == id);
        }

        public List<Student> SaveStudent(Student student)
        {
            students.Add(new Student(){SName = student.SName, ID = student.ID, Contact = student.Contact});
            return students.ToList();
        }
    }
}
