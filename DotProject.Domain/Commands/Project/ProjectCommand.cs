using NetDevPack.Messaging;

namespace DotProject.Domain.Commands.Project
{
    public class ProjectCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid UserId { get; protected set; }
    }
}
