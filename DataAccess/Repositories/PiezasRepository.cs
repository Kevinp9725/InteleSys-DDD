using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Contracts;
using DataAccess.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class PiezasRepository : MasterRepository, IPiezasRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public PiezasRepository()
        {
            selectAll = "SELECT * FROM PIEZAS;";
            insert = "INSERT INTO PIEZAS VALUES(@articuloId, @serialno, @precioCosto, @isv, @iva, @descripcion, @modeloId)";
            update = "UPDATE PIEZAS SET serialno=@serialno, precio_costo=@precioCosto, isv=@isv, iva=@iva, descripcion=@descripcion WHERE articulo_id=@articuloId";
            delete = "DELETE FROM PIEZAS WHERE articulo_id=@articulo_id";
        }

        public int Add(Piezas entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@articuloId", entity.articuloId));
            parameters.Add(new SqlParameter("@serialno", entity.serialNo));
            parameters.Add(new SqlParameter("@precioCosto", entity.precioCosto));
            parameters.Add(new SqlParameter("@isv", entity.isv));
            parameters.Add(new SqlParameter("@iva", entity.iva));
            parameters.Add(new SqlParameter("descripcion", entity.descripcion));

            return ExecuteNonQuery(insert);
        }

        public int Edit(Piezas entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@articuloId", entity.articuloId));
            parameters.Add(new SqlParameter("@serialno", entity.serialNo));
            parameters.Add(new SqlParameter("@precioCosto", entity.precioCosto));
            parameters.Add(new SqlParameter("@isv", entity.isv));
            parameters.Add(new SqlParameter("@iva", entity.iva));
            parameters.Add(new SqlParameter("descripcion", entity.descripcion));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Piezas> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listPiezas = new List<Piezas>();
            foreach (DataRow item in tableResult.Rows)
            {
                listPiezas.Add(new Piezas
                {
                    articuloId= Convert.ToInt32(item[0]),
                    serialNo=item[1].ToString(),
                    precioCosto=(float)(item[2]),
                    isv=(float)(item[3]),
                    iva=(float)(item[4]),
                    descripcion=item[5].ToString()
                    
                });
            }
            return listPiezas;
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
