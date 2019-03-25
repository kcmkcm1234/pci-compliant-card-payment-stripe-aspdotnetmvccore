using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimonGilbert.Blog.Models;
using SimonGilbert.Blog.Services;
using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardPaymentService _cardPaymentService;

        public HomeController(ICardPaymentService cardPaymentService)
        {
            this._cardPaymentService = cardPaymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CardPaymentViewModel viewModel)
        {
            var receiptViewModel = _cardPaymentService.Create(viewModel);

            return RedirectToAction("Receipt", "Home", receiptViewModel);
        }

        [HttpGet]
        public IActionResult Receipt(CardPaymentReceiptViewModel viewModel)
        {
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
