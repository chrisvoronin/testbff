using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServices.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
		// GET: api/[controller]
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

		// GET api/[controller]/5
		[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

		// POST api/[controller]
		[HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.LoginRequest request)
        {
            // init client
            using (var client = new System.Net.Http.HttpClient()) {

                // setup base
                client.BaseAddress = new Uri("http://pds.costar.com");
				// add proper headers
				client.DefaultRequestHeaders.Add("User-Agent", "Listing Manager Mobile BFF");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				// serialize data
				string jsonPostString = Newtonsoft.Json.JsonConvert.SerializeObject(request);

                System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK;

                try {

					// post and get response
					var response = await client.PostAsync("/someserviceendpoint", new System.Net.Http.StringContent(jsonPostString, System.Text.Encoding.UTF8, "application/json"));

                    statusCode = response.StatusCode;

                    // this method will send it to try catch if http is not success.
                    response.EnsureSuccessStatusCode();

                    //if (!response.IsSuccessStatusCode) {
                    //    return Unauthorized();
                    //}
                        
                    // read response
                    var respString = await response.Content.ReadAsStringAsync();
					Models.LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.LoginResponse>(respString);

                    // return OK (http 200)
                    return Ok(loginResponse);

                } catch(System.Net.Http.HttpRequestException ex) {

                    // can do various logic for statusCodes here since we stored it into a variable {statusCode}

					// return http error 400
					return BadRequest($"Error: {ex.Message}");
                }
				
				

				
            }
        }
    }
}
