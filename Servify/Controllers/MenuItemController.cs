using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servify.DataProvider;
using Servify.Models;

namespace Servify.Controllers
{
    [Produces("application/json")]
    [Route("api/MenuItem")]
    public class MenuItemController : Controller
    {
        private readonly MenuItemRepository productRepository;
        public MenuItemController()
        {
            productRepository = new MenuItemRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return productRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return productRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]MenuItem prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MenuItem prod)
        {
            prod.Id = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}