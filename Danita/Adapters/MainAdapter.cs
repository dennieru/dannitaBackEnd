using Danita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danita.Adapters
{
    public class MainAdapter
    {
        #region fields
        private static string instanceId;
        private static MainAdapter instance;
        #endregion

        private static ICollection<object> list = null;
        private static ICollection<object> sons = null;

        public MainAdapter()
        {
            int version = new Random().Next(1, 9);
            Pet pet = new Pet
            {
                Id = Guid.NewGuid(),
                Age = 5,
                Name = $"Colitas{version}",
            };

            ICollection<Pet> pets = new List<Pet>();
            list = new List<Pet>().Cast<object>().ToList();
            list.Add(pet);

            int oversion = new Random().Next(1, 9);
            Owner owner = new Owner
            {
                Id = Guid.NewGuid(),
                Age = 5,
                Name = $"Tommy{oversion}",
            };

            ICollection<Owner> owners = new List<Owner>();
            sons = new List<Owner>().Cast<object>().ToList();
            sons.Add(owner);
        }
        public ICollection<Guid> GetGuids<T>() where T: class
        {
            List<Guid> guids = new List<Guid>();
            foreach (var item in sons)
            {
                guids.Add((Guid)item.GetType().GetProperty("Id").GetValue(item, null));
            }

            return guids;
        }

        public ICollection<T> GetList<T>()
        {
            return list.Cast<T>().ToList();
        }

        public T AddItem<T>(T item) where T: class
        {
            list.Add(item);

            return (T)list.FirstOrDefault( it => it == item);
        }

        public bool RemoveItem<T>(T item) where T : class
        {
            var itemToRemove = (T)list.FirstOrDefault(it => it == item);

            return list.Remove(itemToRemove);
        }
        
        #region properties
        #region Instance
        public static string InstanceId
        {
            get
            {
                if (instanceId == null)
                {
                    instanceId = AppDomain.CurrentDomain.FriendlyName;
                }

                return instanceId;
            }

            set
            {
                instanceId = value;
            }
        }
        
        public static MainAdapter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainAdapter();
                }

                return instance;
            }
        }

        public static ICollection<object> List { get => list; set => list = value; }
        #endregion
        #endregion
    }
}
