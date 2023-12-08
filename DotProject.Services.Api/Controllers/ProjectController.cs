using DotProject.Application.ViewModels;
using DotProject.EventSourceNormalizers.Project;
using DotProject.Interfaces;
using DotProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotProject.Services.Api.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [AllowAnonymous]
        [HttpGet("project-management")]
        public async Task<IEnumerable<ProjectViewModel>> Get()
        {
            return await _projectAppService.GetAll();
        }
        [AllowAnonymous]
        [HttpGet("project-management/report")]
        public async Task<IEnumerable<ReportViewModel>> GetReport()
        {
            return await _projectAppService.GetReport();
        }

        [AllowAnonymous]
        [HttpGet("project-management/{id:guid}")]
        public async Task<ProjectViewModel> Get(Guid id)
        {
            return await _projectAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("project-management/user/{userId:guid}")]
        public async Task<IEnumerable<ProjectViewModel>> GetByUserId(Guid userId)
        {
            return await _projectAppService.GetByUserId(userId);
        }

        [AllowAnonymous]
        [HttpPost("project-management")]
        public async Task<IActionResult> Post([FromBody] ProjectViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _projectAppService.Register(customerViewModel));
        }

        [AllowAnonymous]
        [HttpPut("project-management")]
        public async Task<IActionResult> Put([FromBody] ProjectViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _projectAppService.Update(customerViewModel));
        }

        [AllowAnonymous]
        [HttpDelete("project-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _projectAppService.Remove(id));
        }

        [AllowAnonymous]
        [HttpGet("project-management/history/{id:guid}")]
        public async Task<IList<ProjectHistoryData>> History(Guid id)
        {
            return await _projectAppService.GetAllHistory(id);
        }
    }
}
