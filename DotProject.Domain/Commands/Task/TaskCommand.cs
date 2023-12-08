using DotProject.Domain.Models;
using NetDevPack.Messaging;

namespace DotProject.Domain.Commands.Task
{
    public class TaskCommand : Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Priority Priority { get; set; }
        public int Status { get; set; }
        public Guid ProjectId { get; set; } 
    }
}
