using Challenge.External.Interfaces;
using Challenge.External.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Challenge.External.Implementations
{
    public class ExternalProxy : IExternalProxy
    {
        private readonly string Url;

        public ExternalProxy(IConfiguration configuration)
        {
            Url = configuration["ExternalUrl"];
        }

        public ExternalProduct GetExternalProductById(int productId)
        {
            ExternalProduct result = null;
            var endpoint = Url + "ProductInfo?productId=" + productId.ToString();

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.Encoding = System.Text.Encoding.UTF8;

                string response = webClient.DownloadString(endpoint);

                result = JsonConvert.DeserializeObject<ExternalProduct>(response);
            }

            return result;
        }
    }
}
