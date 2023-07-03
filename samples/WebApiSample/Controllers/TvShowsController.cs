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
public class TvShowsController : ControllerBase
{
    private readonly ITmdbApiClient tmdbApiClient;

    public TvShowsController(ITmdbApiClient tmdbApiClient) => this.tmdbApiClient = tmdbApiClient;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TvShow>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([BindRequired, FromQuery(Name = "q")] string query)
    {
        var movies = await tmdbApiClient.GetTvShowsAsync(query);
        return Ok(movies);
    }
}
