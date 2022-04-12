using CicekSepeti.Core;
using CicekSepeti.Api.Const;
using CicekSepeti.Data.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CicekSepeti.Data.Models.RequestModel;

namespace CicekSepeti.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public CartController(IMediator mediator, ILogger<CartController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation(nameof(CartController) + CartException.GetAllProductList);

                GetAllCartQuery queryModel = new GetAllCartQuery();

                List<Cart> allProducts = await _mediator.Send(queryModel);
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CartController) + CartException.GetAllProductList + ex);

                return BadRequest(CartException.GetAllProductList);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddToCartRequest commandModel)
        {
            try
            {
                Cart cart = await _mediator.Send(commandModel);

                return Ok(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CartController) + CartException.CheckStockAmount + ex.Message);

                return BadRequest(CartException.CheckStockAmount);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveFromCartCommand commandModel)
        {
            try
            {
                int result = await _mediator.Send(commandModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CartController) + CartException.Delete + ex.Message);

                return BadRequest(CartException.Delete);
            }

        }

    }
}
