using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    public class User
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
