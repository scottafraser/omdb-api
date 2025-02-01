using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/movies")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly string _omdbApiKey;
    private readonly string _omdbApiUrl;

    public SearchController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _omdbApiKey = configuration["OMDbApi:Key"] ?? throw new System.Exception("OMDb API Key not found in appsettings.json");
        _omdbApiUrl = configuration["OMDbApi:Url"] ?? throw new System.Exception("OMDb API Url not found in appsettings.json");
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies(
        [FromQuery] string title,
        [FromQuery] string? year = null,
        [FromQuery] string? type = null,
        [FromQuery] int page = 1)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Title parameter is required.");
        }

        var query = $"?apikey={_omdbApiKey}&s={title}&page={page}";

        if (!string.IsNullOrWhiteSpace(year))
            query += $"&y={year}";

        if (!string.IsNullOrWhiteSpace(type))
            query += $"&type={type}";

        var response = await _httpClient.GetAsync(_omdbApiUrl + query);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Error fetching data from OMDb API.");
        }

        var content = await response.Content.ReadAsStringAsync();
        return Ok(content);
    }

    [HttpGet("detail")]
    public async Task<IActionResult> GetMovieDetail([FromQuery] string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return BadRequest("Movie ID is required.");
        }

        var query = $"?apikey={_omdbApiKey}&i={id}&plot=full"; // Fetch full plot
        var response = await _httpClient.GetAsync(_omdbApiUrl + query);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Error fetching movie details from OMDb API.");
        }

        var content = await response.Content.ReadAsStringAsync();
        return Ok(content);
    }

}
