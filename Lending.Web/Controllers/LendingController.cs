using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using Lending.Services.Interface;

namespace Lending.Web.Controllers
{
    public class LendingController : Controller
    {
        private readonly ILendingService _lendingService;

        public LendingController(ILendingService lendingService)
        {
            this._lendingService = lendingService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendRequest(string phone)
        {
            try
            {
                var result = await _lendingService.SendRequest(phone);

                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}