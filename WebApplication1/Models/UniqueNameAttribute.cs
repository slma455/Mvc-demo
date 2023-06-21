using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        public int xyz { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            String name = value.ToString();
            ITIEntity context = new ITIEntity();
            Course courseFromReq = validationContext.ObjectInstance as Course;
            Course courseFromDb = context.courses.FirstOrDefault(c => c.Name == name);
            if(courseFromDb == null)
            {
                return ValidationResult.Success;
            }
            else if(courseFromDb.Id == courseFromReq.Id)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name already found !");

            }
        }
    }
}
