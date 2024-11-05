using Hospital.DTOs;
using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalDbContext _context;
        public DoctorRepo(HospitalDbContext context)
        {
            _context = context;
        }
        public DoctorDto GetDoctorByName(string name)
        {
            var doctor = _context.Doctors.Include(d => d.Manager).FirstOrDefault(d => d.Name == name);
            if (doctor == null)
            {
                return null;
            }

            DoctorDto doctordto = new DoctorDto
            {
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                ManagerName = doctor.Manager.Name
            };

            return doctordto;
        }

        public void AddDoctor(DoctorDto doctordto)
        {

            Doctors doctor = new Doctors()
            {
                Name = doctordto.Name,
                Specialty = doctordto.Specialty,
                Manager = new Manager
                {
                    Name = doctordto.ManagerName
                }
            };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public DoctorDto GetDoctorById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            DoctorDto docdto = new DoctorDto
            {
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                ManagerName = doctor.Manager.Name
            };
            return docdto;
        }
    }
}
