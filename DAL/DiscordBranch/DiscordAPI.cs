using System.Text;
using Newtonsoft.Json;
namespace DAL.DiscordBranch

{
    public class DiscordAPI : DAL, IDiscordAPI
    {

        public async Task DM(string discordId, string content)
        {
            var query = "https://discord.com/api/users/@me/channels";

            using (var client = new HttpClient())
            {
                // set header for authorization
                client.DefaultRequestHeaders.Add("Authorization", "Bot discord-token"); // token removed

                // Set the request content
                var requestContent = new StringContent(JsonConvert.SerializeObject(new
                {
                    recipient_id = discordId
                }), Encoding.UTF8, "application/json");

                // Make the API request
                var response = await client.PostAsync(query, requestContent);
                response.EnsureSuccessStatusCode();

                // Read the response content
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the response content into a dynamic object
                dynamic responseData = JsonConvert.DeserializeObject(responseContent);

                // Access the "id" property from the response data
                var channelId = responseData.id;

                var dmquery = "https://discord.com/api/channels/" + channelId + "/messages";

                // Set the request content
                var requestMessage = new StringContent(JsonConvert.SerializeObject(new
                {
                    content = content
                }), Encoding.UTF8, "application/json"); ;

                await client.PostAsync(dmquery, requestMessage);
            }
        }
    }
}
