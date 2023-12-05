using System.ComponentModel.DataAnnotations;

namespace DotProject.ViewModels
{
    public class ProjectViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        //public User User { get; set; }
        //public ICollection<Task> Tasks { get; } = new List<Task>();
    }
}
