using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDo.model
{
    public class EntityId
    {
        public int Id 
        {
            get; set;
        }

        public EntityId(int id) 
        {
            Id = id;
        }

        static public EntityId Create(List<int> ids) 
        {
            Random rnd = new Random();
            int newId = rnd.Next(0, 100);

            if (!ids.Contains(newId))
                return new EntityId(newId);

            return Create(ids);
        }
    }
}