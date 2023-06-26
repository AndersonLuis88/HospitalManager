using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    [Table("Paciente")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
 
    }
}
