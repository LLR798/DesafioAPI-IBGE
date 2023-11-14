using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Services.LocationService;

public interface ILocationService
{
    Task<ServiceResponse<Location>> CreateLocation(Location location);
    Task<ServiceResponse<List<Location>>> GetAllLocations();
    Task<ServiceResponse<Location>> GetLocationById(string id);
    Task<ServiceResponse<List<Location>>> GetLocationByState(string state);
    Task<ServiceResponse<List<Location>>> GetLocationByCity(string city);
    Task<ServiceResponse<Location>> UpdateLocation(Location location);
    Task<ServiceResponse<List<Location>>> DeleteLocation(string id);
}
