using DotProject.EventSourceNormalizers.Task;
using DotProject.Interfaces;
using DotProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotProject.Services.Api.Controllers
{
    [Authorize]
    public class TaskController : ApiController
    {
        private readonly ITaskAppService _taskAppService;

        public TaskController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [AllowAnonymous]
        [HttpGet("task-management")]
        public async Task<IEnumerable<TaskViewModel>> Get()
        {
            return await _taskAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("task-management/{id:guid}")]
        public async Task<TaskViewModel> Get(Guid id)
        {
            return await _taskAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("task-management/user/{taskId:guid}")]
        public async Task<IEnumerable<TaskViewModel>> GetByProjectId(Guid taskId)
        {
            return await _taskAppService.GetByProjectId(taskId);
        }

        [AllowAnonymous]
        [HttpPost("task-management")]
        public async Task<IActionResult> Post([FromBody] TaskViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _taskAppService.Register(customerViewModel));
        }

        [AllowAnonymous]
        [HttpPut("task-management")]
        public async Task<IActionResult> Put([FromBody] TaskViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _taskAppService.Update(customerViewModel));
        }

        [AllowAnonymous]
        [HttpDelete("task-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _taskAppService.Remove(id));
        }

        [AllowAnonymous]
        [HttpGet("task-management/history/{id:guid}")]
        public async Task<IList<TaskHistoryData>> History(Guid id)
        {
            return await _taskAppService.GetAllHistory(id);
        }
    }
}
