﻿namespace BackendSiteVendas.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    Task<bool> UserHasEmail(string email);
    Task<Entities.User> RetrieveByEmailAndPassword(string email, string password);
    Task<Entities.User> RetrieveByEmail(string email);
}
