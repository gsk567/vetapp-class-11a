namespace Data;

public class DoctorRepository : IDoctorRepository
{
    private Guid _id = Guid.NewGuid();
    
    public IEnumerable<Doctor> FetchDoctors()
    {
        return new List<Doctor>
        {
            new Doctor { Id = Guid.NewGuid(), FirstName = "Pesho", LastName = "Peshev", Note = _id.ToString() },
            new Doctor { Id = Guid.NewGuid(), FirstName = "Ivan", LastName = "Ivanov", Note = _id.ToString() },
        };
    }
}