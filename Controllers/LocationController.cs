using Microsoft.AspNetCore.Mvc;
using WebApiWithAuth.Models;
using WebApiWithAuth.Services.LocationService;

namespace WebApiWithAuth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    /// <summary>
    /// Cadastrar uma nova localidade
    /// </summary>
    /// <returns>Retorna os atributos de localidade criados</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Location>>> CreateLocation(Location location)
    {
        if (location.Id.Length != 7)
            return BadRequest("Código IBGE inválido, ele precisa ter 7 dígitos.");

        var result = await _locationService.CreateLocation(location);

        if (!result.Success)
        {
            return Conflict(result.Message);
        }

        return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
    }

    /// <summary>
    /// Retorna todas as localidades que estão cadastradas 
    /// </summary>
    /// <returns>Retorna os atributos de todas as localidades cadastradas</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpGet("locations")]
    public async Task<ActionResult<ServiceResponse<List<Location>>>> GetAllLocations()
    {
        return Ok(await _locationService.GetAllLocations());
    }

    /// <summary>
    /// Retorna a localidade informada com base no Id
    /// </summary>
    /// <returns>Retorna os atributos da localidade que foi informada</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpGet("locations/{id}")]
    public async Task<ActionResult<ServiceResponse<Location>>> GetLocationById(string id)
    {
        ServiceResponse<Location> serviceResponse = await _locationService.GetLocationById(id);
        return Ok(serviceResponse);
    }

    /// <summary>
    /// Retorna a localidade com base na silga do estado informada
    /// </summary>
    /// <returns>Retorna os atributos do estado que foi informado</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpGet("locations/state/{state}")]
    public async Task<ActionResult<ServiceResponse<List<Location>>>> GetLocationByState(string state)
    {
        ServiceResponse<List<Location>> serviceResponse = await _locationService.GetLocationByState(state);
        return Ok(serviceResponse);
    }

    /// <summary>
    /// Retorna a localidade com base na cidade informada
    /// </summary>
    /// <returns>Retorna os atributos da cidade que foi informada</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpGet("locations/city/{city}")]
    public async Task<ActionResult<ServiceResponse<List<Location>>>> GetLocationByCity(string city)
    {
        ServiceResponse<List<Location>> serviceResponse = await _locationService.GetLocationByCity(city);
        return Ok(serviceResponse);
    }

    /// <summary>
    /// Atualiza uma localidade existente com base no Id
    /// </summary>
    /// <returns>Retorna os atributos da localidade que foi informada atualizados</returns>
    /// <response code="200">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpPut("locations/{id}")]
    public async Task<ActionResult<ServiceResponse<Location>>> UpdateLocation(Location location)
    {
        if (location.Id.Length != 7)
            return BadRequest("Código IBGE inválido, ele precisa ter 7 dígitos.");

        var result = await _locationService.UpdateLocation(location);

        if (!result.Success)
        {
            return Conflict(result.Message); 
        }

        return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
    }

    /// <summary>
    /// Excluir uma localidade existente com base no Id
    /// </summary>
    /// <returns>Retorna NoContent</returns>
    /// <response code="204">Localidade excluida com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente</response>
    [HttpDelete("locations/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Location>>>> DeleteLocation(string id)
        {
            ServiceResponse<List<Location>> serviceResponse = await _locationService.DeleteLocation(id);
            return Ok(serviceResponse);
        }
}