using NetDevPack.Domain;

namespace DotProject.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {
        public User(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
