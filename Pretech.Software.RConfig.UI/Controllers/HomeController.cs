using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pretech.Software.RConfig.UI.Models;

namespace Pretech.Software.RConfig.UI.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class HomeController : Controller
    {
        private readonly ProjectModel _project;
        private readonly SectionsModel _sections;

        public HomeController(ProjectModel project, SectionsModel sections)
        {
            _project = project;
            _sections = sections;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _project.CreateModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetSectionOfProject(string projectId)
        {
            var result = await _sections.GetSectionsOfProject(projectId);
            if (result.IsError == false)
            {
                return Ok(result);
            }
            else return BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSection([FromForm] string projectId, [FromForm] string name, [FromForm] string value)
        {
            var created = await _sections.CreateSectionAsync(projectId, name, value);
            if (created)
            {
                return Ok(created);
            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSection(string id)
        {
            var deleted = await _sections.DeleteSectionAsync(id);
            if (deleted) return Ok(deleted);
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> ProjectDetail(string projectId)
        {
            var detail = await _project.FindAsync(projectId);
            if (detail != null)
            {
                return Ok(detail);
            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(string name, string application)
        {
            var created = await _project.CreateProjectAsync(name, application);
            if (created)
            {
                return Ok(created);
            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var deleted = await _project.DeleteProject(id);
            if (deleted) return Ok(deleted);
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAccessIp(string id, string ip)
        {
            var added = await _project.AddAccessIP(id, ip);
            if (added)
            {
                var detail = await _project.FindAsync(id);
                if (detail != null) return Ok(detail);
                else return BadRequest();

            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccessIp(string id, string ip)
        {
            var added = await _project.DeleteAccessIP(id, ip);
            if (added)
            {
                var detail = await _project.FindAsync(id);
                if (detail != null) return Ok(detail);
                else return BadRequest();

            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> StatusChange(string id, int status)
        {
            var added = await _project.StatusChangeAsync(id, status);
            if (added)
            {
                var detail = await _project.FindAsync(id);
                if (detail != null) return Ok(detail);
                else return BadRequest();

            }
            else return BadRequest();
        }
    }
}