using Kolokwium.Model;

namespace Kolokwium.DTO
{
    public class TaskREQDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public int IdTeam { get; set; }
        public int IdAssignedTo { get; set; }
        public int IdCreator { get; set; }
        public TaskTypeDTO TaskType { get; set; }
        //public int IdTaskType { get; set; }
        //public string TaskTypeName { get; set; } = null!;
    }
}
