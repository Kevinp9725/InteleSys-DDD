using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Contracts
{
    public interface IPiezasRepository : IGenericRepository<Piezas>
    {
       //Si se nesecitan mas funciones que las tipicas de CRUD generales
    }
}
