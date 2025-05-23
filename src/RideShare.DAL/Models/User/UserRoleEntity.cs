﻿namespace RideShare.DAL.Models;

public class UserRoleEntity : BaseEntity
{
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<UserEntity>? Users { get; set; }
}
