using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Interview.Repository;

namespace Interview.Controllers
{

    public class ValuesController : ApiController
    {
        private IDataRepository _dataRepository;
        public ValuesController()
        {
            _dataRepository = new DataRepository();
        }

        // GET api/values/5
        public string Get(string id)
        {
            throw new NotImplementedException();
            var guid = Guid.Parse(id);
            var result = _dataRepository.Get(guid);
            //return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
