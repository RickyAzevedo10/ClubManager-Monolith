﻿namespace ClubManager.Domain.DTOs.Identity
{
    public class UpdateUserPermissionsDTO
    {
        public int UserId { get; set; }
        public bool Edit { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
        public bool Consult { get; set; }
    }
}
