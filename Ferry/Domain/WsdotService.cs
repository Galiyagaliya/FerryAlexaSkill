using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ferry.Model;
using Newtonsoft.Json;
using NLog;

namespace Ferry.Domain
{
    public class WsdotService
    {
        private readonly string key;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string Uri = "http://www.wsdot.wa.gov/ferries/api/{0}/rest/{1}/{2}?apiaccesscode={3}";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public WsdotService()
        {
            this.key = "2d1dbff1-4218-4e8b-b832-e6599db7919b";
        }

        public WsdotService(string key)
        {
            this.key = key;
        }

        public async Task<T> GetAsync<T>(string id)
        {
            var attrs = Attribute.GetCustomAttributes(typeof(T));
            var result = "";
            foreach (var attr in attrs)
            {
                if (!(attr is WsdotModelAttribute)) continue;
                var wsdotModelAttribute = attr as WsdotModelAttribute;
                result = await this.GetJsonAsync(wsdotModelAttribute.Path, wsdotModelAttribute.Method, id);
            }

            return JsonConvert.DeserializeObject<T>(result);
        }

        protected async Task<string> GetJsonAsync(string path, string method, string id)
        {
            var json = "";
            var request = string.Format(this.Uri, path, method, id, this.key);
            for (var i = 0; i < 10; i++)
                try
                {

                    var response = await this.httpClient.GetAsync(request);
                    json = await response.Content.ReadAsStringAsync();
                    break;
                }
                catch (IOException io)
                {
                    Logger.Debug(io, $"Error while getting suggestions for \"{request}\"");
                    Thread.Sleep(1000);
                }
            return json;
        }
    }
}