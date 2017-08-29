using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SgaApi.Business;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SgaApi.Controllers
{
    [Route("api/[controller]")]
    public class GreetingController : Controller
    {
        // GET: api/first
        [HttpGet]
		[EnableCors("MyPolicy")]
		public IEnumerable<string> Get()
        {
            return new string[] { "hello", " Hey" };
        }

		// GET api/values/5
		[HttpGet("{name}")]
		[EnableCors("MyPolicy")]
        public async System.Threading.Tasks.Task<string> Get(string name)
        {
			HttpCall objHttp = new HttpCall();
            return await objHttp.GetGreetingAsync(name);
        }

		// POST api/values
		[HttpPost]
		[EnableCors("MyPolicy")]
        public void Post([FromBody]string value)
        {
        }

		// PUT api/values/5
		[HttpPut("{id}")]
		[EnableCors("MyPolicy")]
        public void Put(int id, [FromBody]string value)
        {
        }

		// DELETE api/values/5
		[HttpDelete("{id}")]
		[EnableCors("MyPolicy")]
        public void Delete(int id)
        {
        }
    }
}
