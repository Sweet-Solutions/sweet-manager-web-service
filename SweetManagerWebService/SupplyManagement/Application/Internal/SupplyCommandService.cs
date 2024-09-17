using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Model.Aggregates;
using SweetManagerWebService.SupplyManagement.Domain.Model.Commands;
using SweetManagerWebService.SupplyManagement.Domain.Repositories;
using SweetManagerWebService.SupplyManagement.Domain.Services;

namespace SweetManagerWebService.SupplyManagement.Application.Internal;

public class SupplyCommandService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork) : ISupplyCommandService
{
    ISupplyRepository _supplyRepository = supplyRepository;
    IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(CreateSupplyCommand command)
    {
        try
        {
            await _supplyRepository.AddAsync(new(command));
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        } 
    }

    public async Task<bool> Handle(UpdateSupplyCommand command)
    {
        try
        {
            await _supplyRepository.Update(new(command));
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Handle(DeleteSupplyCommand command)
    {
        try
        {
            await _supplyRepository.Delete(new(command));
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}