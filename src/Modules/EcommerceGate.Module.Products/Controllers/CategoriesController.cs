using AutoMapper;
using EcommerceGate.Core.Controllers;
using EcommerceGate.Core.Dto.Products;
using EcommerceGate.Infrastructures.Data;
using EcommerceGate.Module.Products.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceGate.Module.Products.Controllers
{
    public class CategoriesController : GenericController<Category>
    {
        private readonly IMapper _mapper;
        public CategoriesController(IRepository<Category> repo, IMapper mapper) : base(repo)
        {
            _mapper = mapper;
        }

        [EnableQuery]
        public IEnumerable<CategoryDto> Grouped()
        {
            var categoriesDb = _repo.Query().ToList();
            var allCategories = _mapper.Map<List<CategoryDto>>(categoriesDb);

            var categoriesRoots = allCategories
                .Where(i => i.ParentId == 0)
                .ToList();
            foreach (var categoryRoot in categoriesRoots)
            {
                categoryRoot.Children = allCategories.Where(i => i.ParentId == categoryRoot.Id).ToList();
                foreach (var child2 in categoryRoot.Children)
                {
                    child2.Children = allCategories.Where(i => i.ParentId == child2.Id).ToList();
                }
            }

            return categoriesRoots;
        }
    }
}
