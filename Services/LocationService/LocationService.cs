using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiWithAuth.Context;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Services.LocationService;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;
    public LocationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<Location>> CreateLocation(Location location)
    {
        ServiceResponse<Location> serviceResponse = new ServiceResponse<Location>();

        try
        {
            if (location == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Informe os dados.";
                serviceResponse.Success = false;

                return serviceResponse;
            }

            Location? newLocation = await _context.Locations.FindAsync(location.Id);

            if (newLocation != null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Uma localidade com o mesmo ID já existe no banco de dados.";
                serviceResponse.Success = false;

                return serviceResponse;
            }

            await _context.AddAsync(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Locations.FindAsync(location.Id);
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Location>>> GetAllLocations()
    {
        ServiceResponse<List<Location>> serviceResponse = new ServiceResponse<List<Location>>();

        try
        {
            serviceResponse.Data = await _context.Locations
                .OrderBy(x => x.City)
                .ToListAsync();

            if (serviceResponse.Data.Count == 0)
            {
                serviceResponse.Message = "Nenhum localidade cadastrada.";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Location>> GetLocationById(string id)
    {
        ServiceResponse<Location> serviceResponse = new ServiceResponse<Location>();

        try
        {
            Location? location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Localização não foi encontrada, verifique se o código IBGE está correto.";
                serviceResponse.Success = false;
            }

            serviceResponse.Data = location;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Location>>> GetLocationByState(string state)
    {
        ServiceResponse<List<Location>> serviceResponse = new ServiceResponse<List<Location>>();

        try
        {
            if (state.Length != 2)
            {
                serviceResponse.Message = "Sigla inválida, não contém dois caracteres Ex: SC.";
                return serviceResponse;
            }

            bool stateExists = _context.Locations.Any(x => x.State == state);
            if (!stateExists)
            {
                serviceResponse.Message = $"A sigla do estado '{state}' não existe, verifique se a sigla desejada está correta.";
                return serviceResponse;
            }

            serviceResponse.Data = await _context.Locations
                .Where(x => x.State == state)
                .OrderBy(x => x.State)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Location>>> GetLocationByCity(string city)
    {
        ServiceResponse<List<Location>> serviceResponse = new ServiceResponse<List<Location>>();

        try
        {
            bool stateExists = _context.Locations.Any(x => x.City == city);
            if (!stateExists)
            {
                serviceResponse.Message = $"A cidade '{city}' não existe, verifique se o nome da cidade desejada está correto.";
                return serviceResponse;
            }
            serviceResponse.Data = await _context.Locations
                .Where(x => x.City == city)
                .OrderBy(x => x.City)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Location>> UpdateLocation(Location location)
    {
        ServiceResponse<Location> serviceResponse = new ServiceResponse<Location>();

        try
        {
            Location? locationUpdate = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == location.Id);

            if (locationUpdate == null)
            {
                serviceResponse.Message = $"O código IBGE '{location.Id}' não existe, verifique o código que deseja atualizar.";

                return serviceResponse;
            }

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Locations.FindAsync(location.Id);
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Location>>> DeleteLocation(string id)
    {
        ServiceResponse<List<Location>> serviceResponse = new ServiceResponse<List<Location>>();

        try
        {
            Location? location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location == null)
            {
                serviceResponse.Message = $"O código IBGE '{id}' não existe, verifique o código que deseja remover.";
                return serviceResponse;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Locations.ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}
