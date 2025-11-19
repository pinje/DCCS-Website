using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DiscordBranch
{
    public interface IDiscordAPI
    {
        Task DM(string discordId, string content);
    }
}
