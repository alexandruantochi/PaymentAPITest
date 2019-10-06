using Filed.API.Models;
using Filed.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Filed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public HttpResponseMessage ProcessPayment([FromBody] PaymentModel paymentRequest)
        {
            _paymentService.PerformPayment(paymentRequest);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
