using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace SgaApi.Business
{
    public class HttpCall
    {
        public async System.Threading.Tasks.Task<string> GetGreetingAsync(string name)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var stringTask = client.GetStringAsync("http://localhost:3000/api/first/hello?name=" + name);

                var response = await stringTask;
				JToken objGreet = JToken.Parse(response);
				string greet = objGreet["result"].Value<string>();
                return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public async System.Threading.Tasks.Task<string> GetCircleArea(float radius)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var stringTask = client.GetStringAsync("http://localhost:8080/getCircleArea?radius=" + radius);

				var response = await stringTask;
                return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public async System.Threading.Tasks.Task<string> GetSquareArea(float side)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var stringTask = client.GetStringAsync("http://localhost:5000/api/square/" + side);

                var response = await stringTask;
                return response;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
