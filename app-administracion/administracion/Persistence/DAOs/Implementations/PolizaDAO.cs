using Microsoft.EntityFrameworkCore;
using administracion.Persistence.Database;
using administracion.Persistence.Entities;
using administracion.Exceptions;
using administracion.BussinesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace administracion.Persistence.DAOs
{
    public class PolizaDAO: IPolizaDAO
    {
        public readonly IAdminDBContext _context;

        public PolizaDAO( IAdminDBContext context)
        {
            _context = context;
        }


        public string registrarPoliza (PolizaSimpleDTO poliza)
        {
            try
            {
                Poliza polizaEntity = new Poliza();

                polizaEntity.polizaId = Guid.NewGuid();
                polizaEntity.fechaRegistro = poliza.fechaRegistro;
                polizaEntity.fechaVencimiento = poliza.fechaVencimiento;
                polizaEntity.tipoPoliza = (TipoPoliza)Enum.Parse(typeof(TipoPoliza), poliza.tipoPoliza);
                polizaEntity.vehiculoId = poliza.vehiculoId;

                _context.Polizas.Add(polizaEntity);
                _context.DbContext.SaveChanges();
                return "Se registro la poliza correctamente";
            }
            catch(Exception ex){
                throw new RCVException("Error al crear el asegurado", ex);
            }
            return "Se registro la poliza correctamente";
        }
        public PolizaDTO consultarPolizaDeVehiculo(Guid vehiculoID)
        {
            try
            {
                var poliza = _context.Polizas
                .Include(v => v.vehiculo)
                .Include(v => v.vehiculo.asegurado)
                .Where(v => v.vehiculoId == vehiculoID)
                .Select( v=> new PolizaDTO{
                    Id = v.polizaId,
                    fechaRegistro = v.fechaRegistro,
                    fechaVencimiento = v.fechaVencimiento,
                    tipoPoliza = v.tipoPoliza.ToString(),
                    vehiculoId = v.vehiculoId,
                    vehiculo = new VehiculoDTO{
                        Id = v.vehiculo.vehiculoId,
                        anioModelo = v.vehiculo.anioModelo,
                        color = v.vehiculo.color.ToString(),
                        marca = v.vehiculo.marca.ToString(),
                        asegurado =  new AseguradoDTO{
                            Id = v.vehiculo.asegurado.aseguradoId,
                            nombre = v.vehiculo.asegurado.nombre,
                            apellido = v.vehiculo.asegurado.apellido
                        }
                    }
                }).FirstOrDefault();
                if(poliza == null){
                    throw new Exception("No se encontraron vehiculos con ese nombre y apellido Error 404");
                }
                return poliza;

            }
            catch(Exception ex)
            {
                throw new RCVException("Error al obtener los vehiculos", ex);
            }
        }
    }

   
}