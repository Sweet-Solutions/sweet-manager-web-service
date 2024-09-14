using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;

namespace SweetManagerWebService.SupplyManagement.Domain.Repositories;

public interface ISupplyRepository : IBaseRepository<Supply>
{
    Task<bool> GetSupplyById(int id);
    
    //TODO tengo que añadir el metodo para obtener los suministros por id del hotel
    //o del dueño o quien sea, porque sino se van a imprimir todos los suministros de todos los hoteles
}