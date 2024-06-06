namespace Services;

public interface IDoctorService
{
    IEnumerable<DoctorModel> FetchDoctorsByLastName(string lastName);
}