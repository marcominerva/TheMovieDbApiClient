using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TheMovieDbApiClient;
using TheMovieDbApiClient.Models;

namespace WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ITmdbApiClient tmdbApiClient;

    public MoviesController(ITmdbApiClient tmdbApiClient) => this.tmdbApiClient = tmdbApiClient;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([BindRequired, FromQuery(Name = "q")] string query)
    {
        var movies = await tmdbApiClient.GetMoviesAsync(query);
        return Ok(movies);
    }
}
