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
    public class IncidenteDAO: IIncidenteDAO
    {
        public readonly IAdminDBContext _context;

        public IncidenteDAO( IAdminDBContext context)
        {
            _context = context;
        }


        
        public string registrarIncidente (IncidenteSimpleDTO incidente)
        {
            try
            {
                Incidente incidenteEntity = new Incidente();
                incidenteEntity.incidenteId = Guid.NewGuid();
                incidenteEntity.polizaId = incidente.polizaId;
                incidenteEntity.estadoPoliza = (EstadoPoliza)Enum.Parse(typeof(EstadoPoliza), incidente.estadoPoliza);
                incidenteEntity.fechaRegistrado = DateTime.Now;
                _context.Incidentes.Add(incidenteEntity);
                _context.DbContext.SaveChanges();
                return "Incidente registrado correctamente";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }    
        }
        public IncidenteDTO consultarIncidente(Guid incidenteID)
        {
            try
            {
                var incidente =  _context.Incidentes
                .Include(i => i.poliza)
                .Where( i => i.incidenteId == incidenteID)
                .Select(i => new IncidenteDTO{
                    incidenteId = i.incidenteId,
                    polizaId = i.polizaId,
                    estadoPoliza = i.estadoPoliza.ToString(),
                    poliza = new PolizaDTO{
                        Id = i.poliza.polizaId,
                        fechaRegistro = i.poliza.fechaRegistro,
                        fechaVencimiento = i.poliza.fechaVencimiento,
                        tipoPoliza = i.poliza.tipoPoliza.ToString(),
                        vehiculoId = i.poliza.vehiculoId,   
                    }
                }).FirstOrDefault();

                return incidente;   

            }
            catch(Exception ex)
            {
                throw new RCVException("Error al obtener los vehiculos", ex);
            }
        }
        public List<IncidenteDTO> ConsultarIncidentesActivos()
        {
            try
            {
                var incidentes =  _context.Incidentes
                .Include(i => i.poliza)
                .Where( i => i.estadoPoliza != EstadoPoliza.cerrado)
                .Select(i => new IncidenteDTO{
                    incidenteId = i.incidenteId,
                    polizaId = i.polizaId,
                    estadoPoliza = i.estadoPoliza.ToString(),
                    poliza = new PolizaDTO{
                        Id = i.poliza.polizaId,
                        fechaRegistro = i.poliza.fechaRegistro,
                        fechaVencimiento = i.poliza.fechaVencimiento,
                        tipoPoliza = i.poliza.tipoPoliza.ToString(),
                        vehiculoId = i.poliza.vehiculoId,   
                    }
                }).ToList();

                return incidentes;   

            }
            catch(Exception ex)
            {
                throw new RCVException("Error al obtener los vehiculos", ex);
            }
        }     
        public string actualizarIncidente(Guid incidenteId, EstadoPoliza estado)
        {
            try
            {
                var incidente = _context.Incidentes
                    .Where(i => i.incidenteId == incidenteId)
                    .FirstOrDefault();
                incidente.estadoPoliza = estado;
                _context.DbContext.SaveChanges();
                return "estado del Incidente actualizado";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }

   
}