using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Dto
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string SName { get; set; }
        public string Contact{ get; set; }

      
    }
}
