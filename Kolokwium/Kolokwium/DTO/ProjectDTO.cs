namespace Kolokwium.DTO
{
    public class ProjectDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}
