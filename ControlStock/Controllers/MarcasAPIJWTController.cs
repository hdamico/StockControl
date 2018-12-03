using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStock.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlStock.Controllers
{

    [Produces("application/json")]
    [Route("api/MarcasAPIJWT")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MarcasAPIJWTController : Controller
    {
        protected readonly IMarcaRepository repo;

        public MarcasAPIJWTController(IMarcaRepository _repo)
        {
            this.repo = _repo;

        }
        // GET: api/MarcasAPI
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET: api/MarcasAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MarcasAPI
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MarcasAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}