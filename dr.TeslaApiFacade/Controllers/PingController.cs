using Microsoft.AspNetCore.Mvc;

namespace dr.TeslaApiFacade.Controllers
{
    [ApiController, Route("api/ping")]
    public class PingController
    {
        public object Get()
        {
            return new { message = "Pong" };
        }
    }
}