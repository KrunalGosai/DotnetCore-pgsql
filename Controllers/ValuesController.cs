using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Library;
using System.Data;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Values clsValues = new Values();

        // GET api/values
        [HttpGet]
        [Route("list")]
        public DataTable Get()
        {
            var data = clsValues.GetAllRecords();
            if(data != null)
            return data;
            else
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("addcontact")]
        public string Post([FromForm] contact data)
        {
            var body =  Request;
            var fname = data;
            var res = clsValues.InsertContact(data,(body.Form.Files != null ? body.Form.Files[0] : null));
            if(res > 0) return "Insert Done";
            else return "Insert Fail";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class contact{
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string designation { get; set; } 
        public string mobile { get; set; }
    }
}
