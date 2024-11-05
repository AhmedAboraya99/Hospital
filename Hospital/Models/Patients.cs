using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateOnly Appointment {  get; set; }

        public List<DoctorPatients> DoctorPatients { get; set; }
    }
}
