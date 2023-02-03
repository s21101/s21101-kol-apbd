namespace Kolokwium.Entities
{
    public class Task
    {
        public int IdTask { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int IdTeam { get; set; }
        public int IdtaskType { get; set; }
        public int MyProperty { get; set; }
    }
}
