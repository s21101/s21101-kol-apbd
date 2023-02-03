using System;
using System.Collections.Generic;

namespace Kolokwium.Model
{
    public partial class TeamMember
    {
        public TeamMember()
        {
            TaskIdAssignedToNavigations = new HashSet<Task>();
            TaskIdCreatorNavigations = new HashSet<Task>();
        }

        public int IdTeamMember { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Task> TaskIdAssignedToNavigations { get; set; }
        public virtual ICollection<Task> TaskIdCreatorNavigations { get; set; }
    }
}
