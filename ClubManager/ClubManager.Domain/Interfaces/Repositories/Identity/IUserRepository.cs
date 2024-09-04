﻿using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByIdAsync(long userId);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>?> GetAllUsersFromInstitution(long idInstitution);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
    }
}