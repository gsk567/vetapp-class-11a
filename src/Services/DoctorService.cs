using Data;

namespace Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    public IEnumerable<DoctorModel> FetchDoctorsByLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return _doctorRepository
                .FetchDoctors()
                .Select(x => new DoctorModel
                {
                    Id = x.Id,
                    Name = $"{x.FirstName} {x.LastName}",
                    Note = x.Note
                })
                .ToList();;
        }
        
        return _doctorRepository
            .FetchDoctors()
            .Where(x => x.LastName.Contains(lastName, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => new DoctorModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}",
                Note = x.Note
            })
            .ToList();
    }
}