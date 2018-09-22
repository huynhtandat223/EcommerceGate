using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Infrastructures.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceGate.Core.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<T> : ODataController where T : IEntityWithTypedId<int>
    {
        protected readonly IRepository<T> _repo;
        public GenericController(IRepository<T> repo)
        {
            _repo = repo;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_repo.Query());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_repo.GetById(key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody]T entity)
        {
            _repo.Add(entity);
            _repo.SaveChanges();
            return Created(entity);
        }

    }
}
