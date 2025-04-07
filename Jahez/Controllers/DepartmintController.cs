using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var get = await repository.GetAllAsync<DepartmintSummary>(true);

            if (IsJsonRequest)
            {
                return Ok(get);
            }

            return View(get);
        }
        [HttpGet("GetDepartmintWithCatigory")]
        public async Task<IActionResult> GetDepartmintWithCatigory(string id)
        {
            var result = await repository.GetAllAndList<Departmint>(
                id,
                true,
               c => c.Include(x => x.categories)
               )
                ;

            return IsJsonRequest ?
                 Ok(result)
                 :
                 View("GetDepartmintWithCatigory", result);
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


        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await repository.SoftDeleteAsync(id);
            if (deleted == null)
            {

                return IsJsonRequest ?
                    BadRequest() :
                    RedirectToAction("Index");
            }
            return IsJsonRequest ?
                    NotFound() :
                    RedirectToAction("Index");
        }
    }
}
