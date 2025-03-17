using AgroLink.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Server.Controllers
{
    [Route("api/export")]
    [ApiController]
    public class ExportController : ControllerBase
    {

        [HttpGet(Name = "GetExports")]
        public IResult Get(ApplicationContext db)
        {
            //Console.WriteLine(db.Products);
            //var results = from request in db.ExportRequests
            //              join details in db.ExportRequestDetails on request.Id equals details.RequestId
            //              select new
            //              {
            //                  request.Id,
            //                  request.UserId,
            //                  request.DateTime,
            //                  request.Status,
            //                  Products = from products in db.Products where products.Id == details.ProductId select products
            //              };
            //return Results.Json(results);
            return Results.Json(db.Roles);
        }
    }
}
