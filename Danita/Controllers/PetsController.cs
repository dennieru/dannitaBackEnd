using System;
using System.Web.Http;
using System.Collections.Generic;

namespace Danita
{
	public class PetsController : ApiController
	{
		// Get api/pets
		public IEnumerable<string> Get ()
		{
			return new string[] { "Colitas", "Tomboy"};
		}

		// Get api/pets/{id}
		public string Get (int id)
		{
			return "Colitas";
		}

		// POST api/pets
		public void Post([FromBody]string value)
		{
		}

		// PUT api/pets/{id}
		public void Put(int id, [FromBody]string value)
		{
		}
		// DELETE api/pets/{id}
		public void Delete(int id)
		{
		}
	}
}

