using Tracker.Api.Models;
using Tracker.Data.Models;

namespace Tracker.Api.Interfaces
{
    public interface IPersonManager
    {
        IList<PersonDto> GetAllPeople();
        IList<PersonDto> GetAllPeople(PersonRole personRole, int page = 0, int pageSize = int.MaxValue);
        PersonDto? GetPerson(uint personId);
        PersonDto AddPerson(PersonDto personDto);
        PersonDto? UpdatePerson(uint personId, PersonDto personDto);
        PersonDto? DeletePerson(uint personId);
    }
}