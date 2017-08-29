using System;
using System.Collections.Generic;
using SgaApi.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SgaApi.Controllers
{
    [Route("api/[controller]")]
    public class SquareController : Controller
    {
		// GET: api/values
		[HttpGet]
		[EnableCors("MyPolicy")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

		// GET api/values/5
		[HttpGet("{side}")]
		[EnableCors("MyPolicy")]
        public async System.Threading.Tasks.Task<string> Get(float side)
        {
            HttpCall objHttp = new HttpCall();
            return await objHttp.GetSquareArea(side);
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
