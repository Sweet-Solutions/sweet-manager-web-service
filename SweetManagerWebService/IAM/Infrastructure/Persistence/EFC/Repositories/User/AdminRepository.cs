﻿using SweetManagerWebService.Communication.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Model.Aggregates;
using SweetManagerWebService.IAM.Domain.Repositories.Users;
using SweetManagerWebService.Profiles.Domain.Model.Entities;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.User;

public class AdminRepository(SweetManagerContext context) : BaseRepository<Admin>(context), IAdminRepository
{
    public async Task<IEnumerable<Admin>> FindAllByHotelId(int hotelId)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            join nt in Context.Set<Notification>().ToList()
                on ad.Id equals nt.AdminsId
            join ow in Context.Set<Owner>().ToList()
                on nt.OwnersId equals ow.Id
            join ho in Context.Set<Hotel>().ToList()
                on ow.Id equals ho.OwnersId
            where ho.Id == hotelId
            select ad
        ).ToList());


    public async Task<Admin?> FindById(int id)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Id == id
            select ad
        ).FirstOrDefault());

    public async Task<Admin?> FindByEmail(string email)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Email == email
            select ad
        ).FirstOrDefault());

    public async Task<int?> FindIdByEmail(string email)
        => await Task.Run(() => (
            from ad in Context.Set<Admin>().ToList()
            where ad.Email == email
                select ad.Id
        ).FirstOrDefault());

}