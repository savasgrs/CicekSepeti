using CicekSepeti.Core;
using CicekSepetiCaseStudy.Api.Const;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiCaseStudy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private string className;
        public CartController(IMediator mediator, ILogger<CartController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            className = this.GetType().Name + " ";
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogError(className + CartException.GetAllProductList);

                GetAllProductsQuery queryModel = new GetAllProductsQuery();

                IEnumerable<BasketProduct> allProducts = await _mediator.Send(queryModel);
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(className + CartException.GetAllProductList + ex);

                throw new Exception(CartException.GetAllProductList + ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                GetProductByIdQuery queryModel = new GetProductByIdQuery
                {
                    id = id
                };

                Cart product = await _mediator.Send(queryModel);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(className + CartException.GetProductList + ex);

                throw new Exception(className + CartException.GetProductList + ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddToCartCommand commandModel)
        {
            try
            {

                int stockAmount = await _stockService.CheckStockAmount(commandModel.productId);

                if (stockAmount == 0)
                    return BadRequest("No exist stock");
                if (stockAmount < commandModel.amount)
                    return BadRequest("Max Product amount" + stockAmount);
                if (commandModel.amount <= 0)
                    return BadRequest("An error occured.");

                Cart product = await _mediator.Send(commandModel);

                if (product == null)
                    return BadRequest("Product amount in your cart cannot exceed " + stockAmount);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(className + CartException.CheckStockAmount + ex);

                throw new Exception(className + CartException.CheckStockAmount + ex);
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
                _logger.LogError(className + CartException.Delete + ex);

                throw new Exception(className + CartException.Delete + ex);
            }

        }

    }
}
