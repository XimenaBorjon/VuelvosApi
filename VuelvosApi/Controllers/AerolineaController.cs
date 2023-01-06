using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuelvosApi.DTOs;
using VuelvosApi.Models;
using VuelvosApi.Repositories;

namespace VuelvosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineaController : ControllerBase
    {
        private readonly sistem21_aeropuertoximenaContext context;
        Repository<Vuelo> repository;

        public AerolineaController(sistem21_aeropuertoximenaContext context)
        {
            this.context = context;
            repository = new(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vuelos = repository.Get()
                .OrderBy(x => x.Status)
                .Select(x => new VueloDTO
                {
                    Hora = x.Hora,
                    Destino = x.Destino,
                    ClaveVuelo = x.ClaveVuelo,
                    Status = x.Status,
                    IdVuelo = x.IdVuelo
                });
            return Ok(vuelos);
        }


        [HttpPost]
        public IActionResult Post(VueloDTO aero)
        {
            Vuelo entidad = new()
            {
                Hora = aero.Hora,
                Destino = aero.Destino,
                ClaveVuelo = aero.ClaveVuelo,
                Status = aero.Status,
            };
            repository.Insert(entidad);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entidad = repository.Get(id);
            if (entidad == null)
            {
                return NotFound();
            }
            repository.Delete(entidad);
            return Ok();
        }
    }
}
