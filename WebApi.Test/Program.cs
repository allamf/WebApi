using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApi.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test method confidentials
            string url1 = "http://localhost:50838/api/confidentials/dupont";
            getConfidentialsValue(url1).Wait();

            // Test method authenticate
            string url2 = "http://localhost:50838/api/Authenticate/jean/dupont";
            getAuthenticatesValue(url2).Wait();

            Console.ReadKey();
        }      

        public static async Task getAuthenticatesValue(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                string result = string.Empty;
                Task<HttpResponseMessage> response = client.GetAsync(url);

                if (response.Result.IsSuccessStatusCode)
                {
                    string responseString = await response.Result.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", responseString);
                    Console.WriteLine("Status: {0}, Reason {1}.", response.Result.StatusCode, response.Result.ReasonPhrase);
                }
                else
                {
                    Console.WriteLine("Error to call the web api. Status: {0}, Reason {1}", response.Result.StatusCode, response.Result.ReasonPhrase);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception is raised in Program.getAuthenticatesValue", ex);
            }           

        }
        public static async Task getConfidentialsValue(string url)
        {
            try
            {
                HMACDelegatingHandler customDelegatingHandler = new HMACDelegatingHandler();
                HttpClient client = HttpClientFactory.Create(customDelegatingHandler);
                Task<HttpResponseMessage> response = client.GetAsync(url);

                if (response.Result.IsSuccessStatusCode)
                {
                    string responseString = await response.Result.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", responseString);
                    Console.WriteLine("Status: {0}, Reason {1}.", response.Result.StatusCode, response.Result.ReasonPhrase);
                }
                else
                {
                    Console.WriteLine("Error to call the web api. Status: {0}, Reason {1}", response.Result.StatusCode, response.Result.ReasonPhrase);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception is raised in Program.getConfidentialsValue", ex);                    
            }                 

        }

    }

    public class HMACDelegatingHandler : DelegatingHandler
    {        
        private string APPId = "4d53bce03ec34c0a911182d4c228ee6c";
        private string APIKey = "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;          
            string requestUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());
            string requestHttpMethod = request.Method.Method;            
            DateTime timeStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - timeStart;
            string requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();       
            string nonce = Guid.NewGuid().ToString("N");     
            string signatureRawData = String.Format("{0}{1}{2}{3}{4}", APPId, requestHttpMethod, requestUri, requestTimeStamp, nonce);
            var secretKeyByteArray = Convert.FromBase64String(APIKey);
            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                //Setting the values in the Authorization header 
                request.Headers.Authorization = new AuthenticationHeaderValue("hmac", string.Format("{0}:{1}:{2}:{3}", APPId, requestSignatureBase64String, nonce, requestTimeStamp));
            }
            response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
   
}





