using Microsoft.Build.Execution;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Account
    {
        public int id { get; set; }
        public string username { get; set; }

        [DataType(DataType.Password)]   
        public string password { get; set; }
    }
}
