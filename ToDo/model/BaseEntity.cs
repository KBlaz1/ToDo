using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDo.model
{
    [JsonDerivedType(typeof(BaseEntity))]
    public class BaseEntity
    {
        public EntityId EntityId { get; set; }

        public BaseEntity(EntityId entityId) 
        {
            EntityId = entityId;
        }
    }
}
