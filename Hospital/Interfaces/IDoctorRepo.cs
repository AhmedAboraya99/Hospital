using Hospital.DTOs;

namespace Hospital.Interfaces
{
    public interface IDoctorRepo
    {
        public DoctorDto GetDoctorById(int id);
        public DoctorDto GetDoctorByName(string name);
        public void AddDoctor(DoctorDto doctordto);


    }
}
