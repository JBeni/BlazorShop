namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class InvoicesController : ApiControllerBase
    {
        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("invoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("invoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await Mediator.Send(new DeleteInvoiceCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var result = await Mediator.Send(new GetInvoiceByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await Mediator.Send(new GetInvoicesQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
