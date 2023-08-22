using Application.Commands;
using Application.Dtos;
using Application.Queries;
using Application.Utilities;
using Domain.Exceptions;
using Domain.WeatherForecasts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{weatherId}")]
        [ProducesResponseType(statusCode: 200, type: typeof(WeatherForecastResponse))]
        public async Task<IActionResult> Get(Guid weatherId)
        {
            try
            {
                var queryRequest = new GetWeatherForecastByIdQuery(weatherId);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("search/{searchquery}/{sortBy}/{pageNumber}/{pageSize}")]
        [ProducesResponseType(statusCode: 200, type: typeof(PaginatedList<WeatherForecastResponse>))]
        public IActionResult SearchV2(string searchquery, string sortBy = "summary", int pageNumber = 1, int pageSize = 20)
        {

            var filterRequest = new FilterWeatherForecastQuery(searchquery, currentFilter: "1week", sortBy, pageNumber, pageSize);
            var rssFeedPaginated = _mediator.Send(filterRequest);
            return Ok(rssFeedPaginated);
        }
    }
}