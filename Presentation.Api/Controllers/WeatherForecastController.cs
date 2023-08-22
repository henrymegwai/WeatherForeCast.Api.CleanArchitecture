using Application.Commands;
using Application.Dtos;
using Application.Queries;
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
    }
}