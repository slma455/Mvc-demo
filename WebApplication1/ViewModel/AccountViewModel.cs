using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class AccountViewModel
    {
        public int id { get; set; }
        public string username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }


        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmPassword { get; set; }
    }
}
