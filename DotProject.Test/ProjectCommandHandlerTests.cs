using DotProject.Domain.Commands.Project;
using DotProject.Domain.Interfaces;
using DotProject.Domain.Models;
using Moq;
using NetDevPack.Data;

namespace DotProject.Test
{
    public class ProjectCommandHandlerTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly Mock<IRepository<Project>> _repositoryProject;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        
        public ProjectCommandHandlerTests()
        {
            _projectRepositoryMock = new();
            _unitOfWorkMock = new();
            _repositoryProject = new();            
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnOkResult_WhenCreateProject()
        {
            var project = new Project(Guid.NewGuid(), "Projeto AAA", Guid.NewGuid())
            {
                Tasks = new List<Domain.Models.Task>()
            };

            _unitOfWorkMock.Setup(x => x.Commit()).Returns(System.Threading.Tasks.Task.FromResult(true));
            _projectRepositoryMock.Setup(x => x.UnitOfWork).Returns(_unitOfWorkMock.Object);

            var createProjectCommand = new RegisterNewProjectCommand("Project AAA", Guid.NewGuid());

            var projectCommandHandler = new ProjectCommandHandler(_projectRepositoryMock.Object);

            var validationResult = await projectCommandHandler.Handle(createProjectCommand, default);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnOkResult_WhenDeleteProject()
        {
            var project = new Project(Guid.NewGuid(), "Projeto AAA", Guid.NewGuid())
            {
                Tasks = new List<Domain.Models.Task>()
            };

            _unitOfWorkMock.Setup(x=> x.Commit()).Returns(System.Threading.Tasks.Task.FromResult(true));
            _projectRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(project);
            _projectRepositoryMock.Setup(x => x.UnitOfWork).Returns(_unitOfWorkMock.Object);

            var removeProjectCommand = new RemoveProjectCommand(project.Id);

            var projectCommandHandler = new ProjectCommandHandler(_projectRepositoryMock.Object);

            var validationResult = await projectCommandHandler.Handle(removeProjectCommand, default);

            Assert.True(validationResult.IsValid);            
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnFailureResult_WhenDeleteProjectThereAssociatedTask()
        {
            var project = new Project(Guid.NewGuid(), "Projeto AAA", Guid.NewGuid());
            project.Tasks = new List<Domain.Models.Task>
            {
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id)
            };

            _projectRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(project);

            var removeProjectCommand = new RemoveProjectCommand(project.Id);

            var projectCommandHandler = new ProjectCommandHandler(_projectRepositoryMock.Object);

            var validationResult = await projectCommandHandler.Handle(removeProjectCommand, default);
                  
            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Count != 0);
            Assert.Contains("Não é possível remover esse projeto, existem tarefas pendentes.", 
                validationResult?.Errors?.FirstOrDefault()?.ErrorMessage);

        }
        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnFailureResult_WhenDeleteProjectNotExists()
        {
            var removeProjectCommand = new RemoveProjectCommand(Guid.NewGuid());

            var projectCommandHandler = new ProjectCommandHandler(_projectRepositoryMock.Object);

            var validationResult = await projectCommandHandler.Handle(removeProjectCommand, default);

            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Count != 0);
            Assert.Contains("O Projeto não existe.", 
                validationResult?.Errors?.FirstOrDefault()?.ErrorMessage);
        }
    }
}
