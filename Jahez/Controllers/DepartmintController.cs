using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Model;
using Models.VM;

namespace Jahez.Controllers
{
    [Route("[controller]")]
    //[Route("api/[controller]")]
    public class DepartmintController : BaseController
    {
        private readonly DepartmintRepository repository;

        public DepartmintController(
            DepartmintRepository repository
            )
        {
            this.repository = repository;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var get=await repository.GetAllAsync<DepartmintSummary>(true);

            if (IsJsonRequest)
            {
                return Ok(get);
            }
            
            return View(get);
        }

        [HttpGet("AddDepartmint")]
        public IActionResult AddDepartmint()
        {
            return View();
        }

        [HttpPost("AddDepartmint")]
        public async Task<IActionResult> AddDepartmint(DepartmintDTO departmintDTO)
        {
            var query = await repository.UploadImage(departmintDTO);
            if (IsJsonRequest)
            {
                return Ok(query);
            }
            return RedirectToAction("Index");
        }

    }
}
