using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    interface IGenericRepository<Entity> where Entity:class
    {
        int Add(Entity entity);
        int Edit(Entity entity);
        int Remove(int id); 
        IEnumerable<Entity> GetAll();
    }
}
