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
            var CreateSupplier = supplierRepository.Create(supplier);
            if (CreateSupplier == 0)
            {
                return NotFound();
            }
            return Ok("data has been inputted");
        }
        public IHttpActionResult Delete( int id)
        {
            var DeleteSupplier = supplierRepository.Delete(id);
            if (DeleteSupplier == 0)
            {
                return NotFound();
            }
            return Ok("data has been inputted");
        }
        public IHttpActionResult Put(Supplier supplier, int id)
        {
            var UpdateSupplier = supplierRepository.Update(supplier,id);
            if (UpdateSupplier == 0)
            {
                return NotFound();
            }
            return Ok("data has been inputted");
        }
        
        //public IEnumerable<Supplier> Get()
        //{
        //    return supplierRepository.Get();
        //}
        public IHttpActionResult Get()
        {
            var getAll = supplierRepository.Get();
            if (getAll != null)
            {
                return Ok(supplierRepository.Get());
            }
            return NotFound();
        }
        public Task<IEnumerable<Supplier>> Get(int id)
        {
            return supplierRepository.Get(id);
        }
        //public Task<IEnumerable<Supplier>> Get(int id)
        //{
        //    var getById = supplierRepository.Get(id);
        //    if (getById != null)
        //    {
        //        return supplierRepository.Get(id);
        //    }
        //    return supplierRepository.Get(id);
        //}
    }
}
