using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApp.Models
{
    [Table("Emp")]
    public class Emp
    {
        [Key]
        public int no { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
