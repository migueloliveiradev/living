﻿using System.ComponentModel.DataAnnotations.Schema;

namespace living_backend.Models.Users;

public class UserFollow
{
    public int Id { get; set; }
    [ForeignKey("Follower")]
    public int FollowerId { get; set; }
    [ForeignKey("Following")]
    public int FollowingId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
    public virtual User Follower { get; set; }
    public virtual User Following { get; set; }
}