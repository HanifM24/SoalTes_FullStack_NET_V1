using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoalTes_FullStack_NET_V1.Model;
using System.Data;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoalTes_FullStack_NET_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        // GET: api/<usersController>
        [HttpGet]
        public string Get()
        {


            // expected result
            //string jsonstring = @"{
            //                      ""status"": ""success"",
            //                      ""data"": [
            //                        {
            //                          ""id"": 1,
            //                          ""name"": ""John Doe"",
            //                          ""email"": ""john@example.com"",
            //                          ""created_at"": ""2024-01-01 12:00:00""
            //                        }
            //                      ]
            //                    }";


            users userdata = new users() { };
            userdata.status = "success";

            Data data = new Data();
            
            data.Id = 1;
            data.Name= "John Doe";
            data.email = "john@example.com";


            //this will get output 2024-01-01T12:00:00 if use datetime format
            //the expected is 2024-01-01 12:00:00
            //so i use string
            //data.created_at = DateTime.ParseExact("2024-01-01 12:00:00", "yyyy-MM-dd HH:mm:ss",
            //                           System.Globalization.CultureInfo.InvariantCulture);


            data.created_at = "2024-01-01 12:00:00";

            userdata.data = new List<Data>();
            userdata.data.Add(data);

            // if want to add more data
            //Data data2 = new Data();
            //data2.Id = 2;
            //data2.Name = "John Doe2";
            //data2.email = "john2@example.com";
            //userdata.data.Add(data2);




            string result = JsonConvert.SerializeObject(userdata);

            return result;
        }

        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<usersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<usersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
