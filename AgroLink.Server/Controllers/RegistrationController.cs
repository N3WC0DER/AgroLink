using Microsoft.EntityFrameworkCore;
using AgroLink.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Server.Controllers
{
    
    [Route("api/registration")]
    [ApiController]
    [EnableCors("AllowLocalhostOrigin")]
    public class RegistrationController : ControllerBase
    {

        private ILogger<RegistrationController> logger;
        private ApplicationContext database;

        public RegistrationController(ILogger<RegistrationController> logger, ApplicationContext database)
        {
            this.logger = logger;
            this.database = database;
        }

        // GET: api/<RegistrationController>/requests
        [HttpGet("requests")]
        public async Task<List<RegistrationRequest>> Get(int? id)
        {
            return await (from request in database.RegistrationRequests
                   select request).ToListAsync();
        }

        // GET: api/<RegistrationController>/{guid}
        [HttpGet("{guid}")]
        public IResult Get(String guid)
        {
            // todo: view registration page
            return Results.Json(guid);
        }

        // POST api/<RegistrationController>/requests
        [HttpPost("requests")]
        public async Task<IResult> Post([FromBody] RegistrationRequest request)
        {
            request.LinkEndpoint = Guid.NewGuid().ToString();
            database.RegistrationRequests.Add(request);
            await database.SaveChangesAsync();
            return Results.Ok();
        }

        // PUT api/<RegistrationController>/requests/{id}
        [HttpPut("requests/{id}")]
        public IResult Put(int id, [FromBody] RegistrationRequest request)
        {
            // todo: update it
            return Results.Ok();
        }

        // DELETE api/<RegistrationController>/requests/{id}
        [HttpDelete("requests/{id}")]
        public IResult Delete(int id)
        {
            // todo: delete
            return Results.Ok();
        }
    }
}
