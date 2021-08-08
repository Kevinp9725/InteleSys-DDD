using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PiezasModel
    {
        //Properties
        private IPiezasRepository piezasRepository;
        public EntityState State { private get; set; }

        [Required]
        public int articuloId { get; set; }
        [Required]
        public string serialNo { get; set; }
        [Required]
        //[RegularExpression("([0-9]+\\.[0-9]+|[0-9]+)")]
        //[StringLength(maximumLength:10, MinimumLength =2)]
        public float precioCosto { get; set; }
        public float isv { get; set; }
        public float iva { get; set; }
        public string descripcion { get; set; }
        public int modeloId { get; set; }



        //Constructor
        public PiezasModel()
        {
            piezasRepository = new PiezasRepository();
        }

        public string SaveChanges()
        {
            string message = null;
            try
            {
                var piezasDataModel = new Piezas();
                piezasDataModel.articuloId = articuloId;
                piezasDataModel.serialNo = serialNo;
                piezasDataModel.precioCosto = precioCosto;
                piezasDataModel.isv = isv;
                piezasDataModel.iva = iva;
                piezasDataModel.descripcion = descripcion;
                piezasDataModel.modeloId = modeloId;

                switch (State)
                {
                    case EntityState.Added:
                       piezasRepository.Add(piezasDataModel);
                        message = "Registro Añadido";
                        break;
                    case EntityState.Deleted:
                        piezasRepository.Remove(articuloId);
                        message = "Registro Eliminado";
                        break;
                    case EntityState.Modified:
                        piezasRepository.Edit(piezasDataModel);
                        message = "Registro Modificado";
                        break;

                }

            }
            catch (Exception exception)
            {
                //Capturar Excepcion ejemplo
                //System.Data.SqlClient.SqlException sqlException = exception as System.Data.SqlClient.SqlException;
                //if (sqlException != null && sqlException.Number == 2627)
                //    message = "Registro Duplicado";
                //else
                //    message = exception.ToString();
                message = exception.ToString();
            }
            return message;
        }

        public List<PiezasModel> GetAll()
        {
            var piezasDataModel = piezasRepository.GetAll();
            var listPiezas = new List<PiezasModel>();
            foreach (Piezas item in piezasDataModel)
            {
                listPiezas.Add(new PiezasModel
                {
                    articuloId = item.articuloId,
                    serialNo = item.serialNo,
                    precioCosto= item.precioCosto,
                    isv= item.isv,
                    iva= item.iva,
                    descripcion= item.descripcion,
                    modeloId= item.modeloId
                    
                });
                
            }

            return listPiezas;
        }


    }
}
