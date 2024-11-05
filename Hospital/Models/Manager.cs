namespace Hospital.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public List<Doctors> Doctors { get; set; }
    }
}
