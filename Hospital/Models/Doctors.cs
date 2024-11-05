using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Doctors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }   
        [StringLength(50)]
        public string Specialty { get; set; }

        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public List<DoctorPatients> DoctorPatients { get; set; }


    }
}
