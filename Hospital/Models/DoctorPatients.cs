using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class DoctorPatients
    {
        [ForeignKey(nameof(Doctors.Id))]
        public int DoctorId { get; set; }
        public Doctors Doctors { get; set; }

        [ForeignKey(nameof(Patients.Id))]
        public int PatientId { get; set; }
        public Patients Patients { get; set; }

        public string Description { get; set; }
    }
}
