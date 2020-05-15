using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;


namespace Blazor.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<Conference>> GetAll();
        Task<Conference> GetById(int id);
        Task<Statistics> GetStatistics();
        Task Add(Conference model);
    }
}