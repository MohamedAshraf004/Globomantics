using Blazor.Extensions;
using Blazor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly HttpClient client;

        public ConferenceApiService(IHttpClientFactory httpClientFactory)
        {
            //httpClient.BaseAddress = new Uri("http://localhost:5000");
            client = httpClientFactory.CreateClient("GlobomanticsApi");
        }
        public async Task<IEnumerable<Conference>> GetAll()
        {
            List<Conference> result;
            var response = await client.GetAsync("/v1/Conference");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<Conference>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);

            return result;
        }

        public async Task<Conference> GetById(int id)
        {
            var result = new Conference();
            var response = await client.GetAsync($"/v1/Conference/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<Conference>();

            return result;
        }

        public async Task<Statistics> GetStatistics()
        {
            var result = new Statistics();
            var response = await client.GetAsync($"/v1/Statistics");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<Statistics>();

            return result;
        }

        public async Task Add(Conference model)
        {
            await client.PostAsJsonAsync("/v1/Conference", model);
        }
    }
}
