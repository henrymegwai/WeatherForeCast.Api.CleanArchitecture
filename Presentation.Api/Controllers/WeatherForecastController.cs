using Application.Commands;
using Application.Dtos;
using Application.Queries;
using Application.Utilities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 200, type: typeof(WeatherForecastResponse))]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var queryRequest = new GetWeatherForecastByIdQuery(id);
                var response = await _mediator.Send(queryRequest);
                return Ok(response);
            }
            catch (WeatherForecastNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 200, type: typeof(WeatherForecastResponse))]
        public async Task<IActionResult> Post([FromBody] CreateWeatherForecastCommand commandRequest)
        {
            try
            {
                var response = await _mediator.Send(commandRequest);
                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           

        }

         
        [HttpGet("{filterInWeeks}/{pageNumber}/{pageSize}")]
        [ProducesResponseType(statusCode: 200, type: typeof(PaginatedList<WeatherForecastFilterQueryResponse>))]
        public async Task<IActionResult> Search(Weeks filterInWeeks, int pageNumber = 1, int pageSize =20)
        {

            var filterRequest = new FilterWeatherForecastQuery((int)filterInWeeks,pageNumber, pageSize);
            var filterPaginatedResponse = await _mediator.Send(filterRequest);
            return Ok(filterPaginatedResponse);
        }
    }
}