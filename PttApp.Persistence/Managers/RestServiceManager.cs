using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace PttApp.Persistence.Managers
{
    public class RestServiceManager<T> where T : class
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public RestServiceManager()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public T GetServiceResponse(string url)
        {
            using (var client = new WebClient())
            {
                string response = client.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonSerializer.Deserialize<T>(response, _serializerOptions);
                }
                return null;
            }
        }
    }
}
