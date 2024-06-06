namespace Data;

public interface IDoctorRepository
{
    IEnumerable<Doctor> FetchDoctors();
}