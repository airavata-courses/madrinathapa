using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SgaApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SgaController : Controller
    {
        // GET: api/values
        [HttpGet("/message")]
        public IEnumerable<string> Get()
        {
            string stringData = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri
        ("http://localhost:3000/api/first/goodbye?name=Maya");
                MediaTypeWithQualityHeaderValue contentType =
        new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync
        ("/api/customerservice").Result;
                stringData = response.Content.
       ReadAsStringAsync().Result;
            }
            Console.Write(stringData);
            return new string[] { "hello: msg starts after -> ", stringData };
        }

        [HttpGet]
        public IEnumerable<string> getMessage()
        {
            string stringData = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri
        ("http://localhost:3000/api/first/goodbye?name=Maya");
                MediaTypeWithQualityHeaderValue contentType =
        new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync
        ("/api/customerservice").Result;
                 stringData = response.Content.
        ReadAsStringAsync().Result;
            }
            Console.Write(stringData);
            return new string[] { "hello: msg starts after -> ", stringData };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<IEnumerable<string>> GetAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("http://localhost:3000/api/first/goodbye?name=Maya");

            var msg = await stringTask;
            var obj = JsonConvert.DeserializeObject(msg);
            Console.Write(msg);
            return new string[] { "hello: msg starts after -> ", msg };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
