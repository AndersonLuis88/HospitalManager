using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HospitalManager.Models
{
    [Table("Medico")]
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PhotoUrl { get; set; }
        public string Content { get; set; }

        public Patient Patient { get; set; }
    }
}
