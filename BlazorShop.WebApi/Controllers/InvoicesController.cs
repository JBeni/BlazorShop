namespace BlazorShop.WebApi.Controllers
{
    public class InvoicesController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, User, Default")]
        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpPut("invoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpDelete("invoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await Mediator.Send(new DeleteInvoiceCommand { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var result = await Mediator.Send(new GetInvoiceByIdQuery { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await Mediator.Send(new GetInvoicesQuery { });
            return Ok(result);
        }
    }
}
