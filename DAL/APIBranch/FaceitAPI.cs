using DAL.APIBranch;
using System.Net.Http.Headers;

namespace DAL.FaceitAPI
{
    public class FaceitAPI : DAL, IFaceitAPI
    {
        private static string baseAddress = "https://open.faceit.com";
        private static string apiKey = ""; // api key removed


        public async Task<string> GetFaceit(string uri)
        {
            // string url = "https://open.faceit.com/data/v4/championships/658ad800-4841-4b2b-ae75-06a6e2a57828/matches";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var charset = new MediaTypeWithQualityHeaderValue("utf-8");
                client.DefaultRequestHeaders.Accept.Add(charset);
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var response = await client.GetAsync(baseAddress + uri);

                if (response.IsSuccessStatusCode)
                {
                    dynamic stringData = await response.Content.ReadAsStringAsync();
                    return stringData;
                } else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}