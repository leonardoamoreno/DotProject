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

        public TaskController(ITaskAppService projectAppService)
        {
            _taskAppService = projectAppService;
        }

        [AllowAnonymous]
        [HttpGet("project-management")]
        public async Task<IEnumerable<TaskViewModel>> Get()
        {
            return await _taskAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("project-management/{id:guid}")]
        public async Task<TaskViewModel> Get(Guid id)
        {
            return await _taskAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("project-management/user/{projectId:guid}")]
        public async Task<IEnumerable<TaskViewModel>> GetByProjectId(Guid projectId)
        {
            return await _taskAppService.GetByProjectId(projectId);
        }

        [AllowAnonymous]
        [HttpPost("project-management")]
        public async Task<IActionResult> Post([FromBody] TaskViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _taskAppService.Register(customerViewModel));
        }

        [AllowAnonymous]
        [HttpPut("project-management")]
        public async Task<IActionResult> Put([FromBody] TaskViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _taskAppService.Update(customerViewModel));
        }

        [AllowAnonymous]
        [HttpDelete("project-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _taskAppService.Remove(id));
        }

        [AllowAnonymous]
        [HttpGet("project-management/history/{id:guid}")]
        public async Task<IList<TaskHistoryData>> History(Guid id)
        {
            return await _taskAppService.GetAllHistory(id);
        }
    }
}
