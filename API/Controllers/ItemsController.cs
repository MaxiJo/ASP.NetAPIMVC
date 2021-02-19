﻿using API.Models;
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
    public class ItemsController : ApiController
    {
        ItemRepository itemRepository = new ItemRepository();
        public IHttpActionResult Post(Item item)
        {
            var CreateItem = itemRepository.Create(item);
            if(CreateItem == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var DeleteItem = itemRepository.Delete( id);
            if (DeleteItem == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Patch(Item item, int id)
        {
            var UpdateItem = itemRepository.Update(item, id);
            if (UpdateItem == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        //public IEnumerable<Item> Get()
        //{

        //    return itemRepository.Get();
        //}
        public IHttpActionResult Get()
        {
            var getAll = itemRepository.Get();
            if(getAll != null)
            {
                return Ok(itemRepository.Get());
            }
            return NotFound();
        }
        //public  Task<IEnumerable<Item>> Get(int id)
        //{
        //    return  itemRepository.Get(id);
        //}
        public IHttpActionResult Get(int id)
        {
            var getAll = itemRepository.Get(id);
            if (getAll != null)
            {
                return Ok(itemRepository.Get(id));
            }
            return NotFound();
        }
    }
}