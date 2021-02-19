using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierRepository supplierRepository = new SupplierRepository();
        public IHttpActionResult Post(Supplier supplier)
        {
            supplierRepository.Create(supplier);
            return Ok();
        }
        public IHttpActionResult Delete( int id)
        {
            supplierRepository.Delete(id);
            return Ok();
        }
        public IHttpActionResult Put(Supplier supplier, int id)
        {
            supplierRepository.Update(supplier, id);
            return Ok();
        }
        
        public IEnumerable<Supplier> Get()
        {
            return supplierRepository.Get();
        }
        public Task<IEnumerable<Supplier>> Get( int id)
        {
            return supplierRepository.Get(id);
        }
    }
}
