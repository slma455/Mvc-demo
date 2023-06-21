using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "max length is 25")]
        [MinLength(2 , ErrorMessage ="Min length is 2")]
        [UniqueName ]
        public String Name { get; set; }
        [Range(50,100)]
        public int Degree { get; set; }
        [Remote("TestDegree", "Course"
            , ErrorMessage = "Min Degree Must be less than The actual degree",
            AdditionalFields = "Degree")]
        public int minDegree { get; set; }

        [ForeignKey("Department")]

        public int Dept_id { get; set; }
        public virtual Department? Department {get;set;}
        public  virtual  List<Instructor>? instructors { get; set; }
        public virtual List<crsCourse>? crs { get; set; }



    }


}
