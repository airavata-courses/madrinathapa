using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SgaApi.Business;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace SgaApi.Controllers
{
    [Route("api/[controller]")]
    public class CircleController : Controller
    {
		// GET: api/values
		[HttpGet]
		[EnableCors("MyPolicy")]
        public IEnumerable<string> Get()
        {
            return new string[] { "val", "value2" };
        }

		// GET api/values/5
		[HttpGet("{radius}")]
		[EnableCors("MyPolicy")]
        public async Task<string> Get(float radius)
        {
			HttpCall objHttp = new HttpCall();
			return await objHttp.GetCircleArea(radius);
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
