using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStock.DAL;
using ControlStock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlStock.Controllers
{
    [Produces("application/json")]
    [Route("api/MarcasAPI")]
    public class MarcasAPIController : Controller
    {
        protected readonly IMarcaRepository repo;

        public MarcasAPIController(IMarcaRepository _repo)
        {
            this.repo = _repo;

        }
        // GET: api/MarcasAPI
        [HttpGet]
        public IEnumerable<Marca> Get()
        {
            return repo.GetAll();
        }

        // GET: api/MarcasAPI/5
        [HttpGet("{id}", Name = "UnPais")]
        public IActionResult Get(int id)
        {
            var marca = repo.GetID(id);

            if (marca == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(marca);
            }
        }
        
        // POST: api/MarcasAPI
        [HttpPost]
        public IActionResult Post([FromBody] Marca marca)
        {
            if (ModelState.IsValid)
            {
                repo.Add(marca);
                repo.save();
                return new CreatedAtRouteResult("UnPais", new { id = marca.MarcaID }, marca);

            }
            return BadRequest(ModelState);
           
        }
        
        // PUT: api/MarcasAPI/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Marca marca, int id)
        {
            if (marca.MarcaID!=id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                repo.Update(marca);
                repo.save();
                return new CreatedAtRouteResult("UnPais", new { id = marca.MarcaID }, marca);

            }
            return BadRequest(ModelState);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var marca = repo.GetID(id);
            if (marca == null)
            {
                return NotFound();
            }
            repo.Del(id);
            repo.save();
            return Ok(marca);
        }
    }
}
