using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Models;
using Shared.Models;

namespace Blazor.Services
{
    public class ConferenceMemoryService: IConferenceService
    {
        private readonly List<Conference> conferences = new List<Conference>();

        public ConferenceMemoryService()
        {
            conferences.Add(new Conference { Id = 1, Name = "Pluralsight Live!", Location = "Salt Lake City", StartDate = new DateTime(2017, 8, 12), AttendeeTotal = 2132 });
            conferences.Add(new Conference { Id = 2, Name = "GeekConf", Location = "San Francisco", StartDate = new DateTime(2017, 10, 18), AttendeeTotal = 3210 });
        }
        public Task Add(Conference model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Conference>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<Conference> GetById(int id)
        {
            return Task.Run(() => conferences.First(c => c.Id == id));
        }

        public Task<Statistics> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new Statistics
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
                };
            });
        }
    }
}
