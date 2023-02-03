using System;
using System.Collections.Generic;

namespace Kolokwium.Model
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Deadline { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
