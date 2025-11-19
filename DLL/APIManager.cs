using DAL.APIBranch;
using DAL.DiscordBranch;
using DAL.SeasonBranch;
using Models;

namespace DLL
{
    public class APIManager
    {
        IFaceitAPI api;
        IDiscordAPI discordAPI;

        public APIManager(IFaceitAPI api)
        {
            this.api = api;
        }

        public APIManager(IDiscordAPI api)
        {
            this.discordAPI = api;
        }

        public Task<string> GetFaceit(string url)
        {
            return this.api.GetFaceit(url);
        }

        public Task DM(string id, string content)
        {
            return this.discordAPI.DM(id, content);
        }
    }
}
