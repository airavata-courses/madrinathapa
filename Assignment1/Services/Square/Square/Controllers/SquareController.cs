using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Square.Entities;
using Newtonsoft.Json;

namespace Square.Controllers
{
    [Route("api/[controller]")]
    public class SquareController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{side}")]
        public string Get(float side)
        {
            EnSquare objSq = new EnSquare();
            objSq.Side = side;
            objSq.Area = side * side;
            return JsonConvert.SerializeObject(objSq);
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
