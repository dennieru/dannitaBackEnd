using System;
using System.Web.Http;
using System.Collections.Generic;
using Danita.Models;
using System.Linq;
using Danita.Adapters;

namespace Danita
{
	public class PetsController : ApiController
	{
        public PetsController()
        {
        }

        // Get api/pets
        [Route("pets")]
        public IEnumerable<Pet> Get ()
		{
            return MainAdapter.Instance.GetList<Pet>();
		}

		// Get api/pets/{id}
		public Pet Get (string id)
        {
            Pet pet = new Pet();
            pet = MainAdapter.Instance.GetList<Pet>().FirstOrDefault(x => x.Id == new Guid(id));
            pet.Sons = MainAdapter.Instance.GetGuids<Owner>().ToList();

            return pet;
        }

        // POST api/pets
        [Route("api/pets")]
        public string Post([FromBody]Pet pet)
		{
            Guid guid = pet.Id;
            if (pet.Id == null || pet.Id == Guid.Empty)
            {
                guid = Guid.NewGuid();
                pet.Id = guid;
            }
            pet.Sons = MainAdapter.Instance.GetGuids<Owner>().ToList();
            Pet petAdded = MainAdapter.Instance.AddItem<Pet>(pet);

            return petAdded.Id.ToString();
		}

		// PUT api/pets/{id}
		public void Put(int id, [FromBody]string value)
		{
		}
		// DELETE api/pets/{id}
		public bool Delete(string id)
		{
            Pet pet = MainAdapter.Instance.GetList<Pet>().FirstOrDefault(x => x.Id == new Guid(id));

            return MainAdapter.Instance.RemoveItem(pet);
        }
	}
}

