using DotProject.Domain.Commands.Task;
using DotProject.Domain.Interfaces;
using DotProject.Domain.Models;
using Moq;
using NetDevPack.Data;

namespace DotProject.Test
{
    public class TaskCommandHandlerTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly Mock<IRepository<Domain.Models.Task>> _repositoryTaskMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public TaskCommandHandlerTests()
        {
            _repositoryTaskMock = new();
            _unitOfWorkMock = new();
            _taskRepositoryMock = new();
            _projectRepositoryMock = new();
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnOkResult_WhenCreateTask()
        {
            var project = new Project(Guid.NewGuid(), "Projeto AAA", Guid.NewGuid());
            project.Tasks = new List<Domain.Models.Task>
            {
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id)
            };

            _projectRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(project);
            _unitOfWorkMock.Setup(x => x.Commit()).Returns(System.Threading.Tasks.Task.FromResult(true));
            _taskRepositoryMock.Setup(x => x.UnitOfWork).Returns(_unitOfWorkMock.Object);

            var createTaskCommand = new RegisterNewTaskCommand("Task", "Descrição da tarefa", DateTime.Now, Priority.Alta, 0, Guid.NewGuid());

            var taskCommandHandler = new TaskCommandHandler(_taskRepositoryMock.Object, _projectRepositoryMock.Object);

            var validationResult = await taskCommandHandler.Handle(createTaskCommand, default);

            Assert.True(validationResult.IsValid);
        }


        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnFailureResult_WhenCreateTaskMaximumNumber20Reached()
        {
            var project = new Project(Guid.NewGuid(), "Projeto AAA", Guid.NewGuid());
            project.Tasks = new List<Domain.Models.Task>
            {
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id),
                new(Guid.NewGuid(), "Task 1", "Descrição teste", DateTime.Now, Priority.Alta, 0, project.Id)
            };

            _projectRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(project);
            _unitOfWorkMock.Setup(x => x.Commit()).Returns(System.Threading.Tasks.Task.FromResult(true));
            _taskRepositoryMock.Setup(x => x.UnitOfWork).Returns(_unitOfWorkMock.Object);

            var createTaskCommand = new RegisterNewTaskCommand("Task", "Descrição da tarefa", DateTime.Now, Priority.Alta, 0, Guid.NewGuid());

            var taskCommandHandler = new TaskCommandHandler(_taskRepositoryMock.Object, _projectRepositoryMock.Object);

            var validationResult = await taskCommandHandler.Handle(createTaskCommand, default);

            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Count != 0);
            Assert.Contains("Número máximo de 20 tarefas por projeto foi atingido.",
                validationResult?.Errors?.FirstOrDefault()?.ErrorMessage);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_ReturnFailureResult_WhenCreateTaskWithProjectNotExists()
        {
            Project project = null;

            _unitOfWorkMock.Setup(x => x.Commit()).Returns(System.Threading.Tasks.Task.FromResult(true));
            _taskRepositoryMock.Setup(x => x.UnitOfWork).Returns(_unitOfWorkMock.Object);

            var createTaskCommand = new RegisterNewTaskCommand("Task", "Descrição da tarefa", DateTime.Now, Priority.Alta, 0, Guid.NewGuid());

            var taskCommandHandler = new TaskCommandHandler(_taskRepositoryMock.Object, _projectRepositoryMock.Object);

            var validationResult = await taskCommandHandler.Handle(createTaskCommand, default);

            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Count != 0);
            Assert.Contains("O Projeto não existe.",
                validationResult?.Errors?.FirstOrDefault()?.ErrorMessage);
        }

    }
}
