using System.Text;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace KikisenTalk.Util
{
    public class DiscordService
    {
        private HttpClient Client;
        private JavaScriptSerializer Serializer;

        public DiscordService()
        {
            Client = new HttpClient();
            Serializer = new JavaScriptSerializer();
        }

        public Task<HttpResponseMessage> SendMessageAsync(string webhookUrl, string message)
        {
            StringBuilder json = new StringBuilder()
                .Append("{\"content\":")
                .Append(Serializer.Serialize(message))
                .Append("}");

            StringContent body = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            return Client.PostAsync(webhookUrl, body);
        }

        public bool SendMessageSync(string webhookUrl, string message)
        {
            Task<HttpResponseMessage> task = SendMessageAsync(webhookUrl, message);
            return task.Result.IsSuccessStatusCode;
        }
    }


}
