using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysProgLab3.Models
{
    public class MyUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long IdUser { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
