using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Blazor.Extensions;
using Blazor.Models;

namespace Blazor.Services
{  
    public class ProposalApiService : IProposalService
    {
        private readonly HttpClient client;

        public ProposalApiService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("GlobomanticsApi");
        }

        public async Task<IEnumerable<Proposal>> GetAll(int conferenceId)
        {
            var result = new List<Proposal>();
            var response = await client.GetAsync($"/v1/Proposal/{conferenceId}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<Proposal>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }

        public async Task Add(Proposal model)
        {
            await client.PostAsJsonAsync("/v1/Proposal", model);
        }

        public async Task<Proposal> Approve(int proposalId)
        {
            var response = await client.PutAsync($"/v1/Proposal/{proposalId}", 
                null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Proposal>();
            }
            throw new ArgumentException($"Error retrieving proposal {proposalId}"+
                $" Response: {response.ReasonPhrase}");
        }
    }
}
