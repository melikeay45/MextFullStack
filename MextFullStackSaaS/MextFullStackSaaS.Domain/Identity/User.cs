﻿using MextFullStackSaaS.Domain.Common;
using MextFullStackSaaS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MextFullStackSaaS.Domain.Identity
{
    // AppUser / ApplicationUser
    public class User : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public UserBalance Balance { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
