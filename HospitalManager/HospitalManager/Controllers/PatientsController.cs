using HospitalManager.Data;
using HospitalManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Authorize(Roles = "Patient")]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Ficha>> GetId(int id,
            [FromServices] ApplicationDbContext context)
        {
            var ficha = await context.Ficha.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(ficha);
        }


    }
}
