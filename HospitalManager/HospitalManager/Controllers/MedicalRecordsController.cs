using HospitalManager.Data;
using HospitalManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HospitalManager.Controllers
{

    [Authorize(Roles = "Doctor")]
    [Route("api/medical-records")]
    public class MedicalRecordsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<List<Ficha>>> Get (
            [FromServices] ApplicationDbContext context)
        {
            var fichas = await context.Ficha.AsNoTracking().ToListAsync();
            return Ok(fichas);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Ficha>> GetId(int id,
            [FromServices] ApplicationDbContext context)
        {
            var ficha = await context.Ficha.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(ficha);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<List<Ficha>>> Post(
            [FromBody]Ficha ficha,
            [FromServices] ApplicationDbContext context
            )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Ficha.Add(ficha);
                await context.SaveChangesAsync();
                return Ok(ficha);
            }
            catch (Exception)
            {

                return BadRequest(new {message = "Não foi possível adicionar a ficha."});
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<List<Ficha>>> Put(
            int id,
            [FromBody] Ficha ficha,
            [FromServices] ApplicationDbContext context
            )
        {
            if (id != ficha.Id)
                return NotFound(new {mdessage = "Ficha não encontrada."});

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                context.Entry<Ficha>(ficha).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(ficha);
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new {message = "Não foi possível atualizar a Ficha."});
            }


        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<List<Ficha>>> Delete(
            int id,
            [FromServices] ApplicationDbContext context)
        {
            var ficha = await context.Ficha.FirstOrDefaultAsync(x => x.Id == id);
            if (ficha == null)
                return NotFound(new { message = "Ficha não encontrada para remoção." });

            try
            {
                context.Ficha.Remove(ficha);
                await context.SaveChangesAsync();
                return Ok(ficha);

            }
            catch (Exception)
            {

                return BadRequest(new { message = "Não foi possível remover a ficha." });
            }

        }

    }
}
