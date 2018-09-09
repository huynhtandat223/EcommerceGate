using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Infrastructures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceGate.Core.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<T> : Controller where T : IEntityWithTypedId<int>
    {
        private readonly IRepository<T> _repo;
        public GenericController(IRepository<T> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _repo.Query().ToList();
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _repo.GetById(id);
        }
        
    }
}
