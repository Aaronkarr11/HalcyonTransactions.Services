using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HalcyonTransactions.Services.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServices _services;
        public ServicesController(IServices services)
        {
            _services = services;
        }


        [Route("/web-api/GetDashBoardData")]
        [HttpPost]
        public Task<string> GetData()
        {
            try
            {
                return _services.ReturnDashboardData();
            }
            catch
            {
                throw;
            }
        }


    }
}
