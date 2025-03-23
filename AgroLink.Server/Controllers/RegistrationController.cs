using Microsoft.EntityFrameworkCore;
using AgroLink.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AgroLink.Server.Services;

namespace AgroLink.Server.Controllers
{
    
    [Route("api/registration")]
    [ApiController]
    [EnableCors("AllowLocalhostOrigin")]
    public class RegistrationController : ControllerBase
    {

        private readonly ILogger logger;
        private ApplicationContext database;
        private EmailService emailService;

        public RegistrationController(
            ILogger<RegistrationController> logger,
            ApplicationContext database,
            EmailService emailService
        )
        {
            this.logger = logger;
            this.database = database;
            this.emailService = emailService;
        }

        // GET: api/<RegistrationController>/requests
        [HttpGet("requests")]
        public async Task<List<RegistrationRequest>> Get(int? id)
        {
            return await database.RegistrationRequests.ToListAsync();
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
        public async Task<IResult> Put(int id, [FromBody] RegistrationRequest request)
        {
            var req = await database.RegistrationRequests.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (req == null) return Results.NotFound(new { message = "Request not found." });

            req.Name = request.Name;
            req.Location = request.Location;
            req.Phone = request.Phone;
            req.Email = request.Email;
            req.Status = RegistrationStatus.Closed;

            await database.SaveChangesAsync();

            await this.emailService.SendEmailAsync(req.Email, "Ссылка для входа на сайт", "https://agrolink.ru/" + req.LinkEndpoint);

            return Results.Json(req);
        }

        // PATCH api/<RegistrationController>/requests/{id}
        [HttpPatch("requests/{id}")]
        public IResult Patch(int id, int status)
        {
            // todo: change status
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
