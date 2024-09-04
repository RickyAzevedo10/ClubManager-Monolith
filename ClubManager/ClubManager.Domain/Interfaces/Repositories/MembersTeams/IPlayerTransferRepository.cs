﻿using ClubManager.Domain.Entities.MembersTeams;

namespace ClubManager.Domain.Interfaces.Repositories.Identity
{
    public interface IPlayerTransferRepository : IBaseRepository<PlayerTransfer>
    {
        Task<PlayerTransfer?> GetByIdAsync(long id);
        Task<List<PlayerTransfer>?> GetAllPlayerTransferAsync(long playerId);
    }
}