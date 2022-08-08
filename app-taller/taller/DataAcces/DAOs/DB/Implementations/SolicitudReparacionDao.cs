using Microsoft.EntityFrameworkCore;
using taller.DataAcces.Database;
using taller.DataAcces.Entities;
using taller.Exceptions;
using taller.BussinesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace taller.DataAcces.DAOs
{
    public class SolcitudReparacionDAO : ISolicitudReparacionDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();

        private ITallerDBContext _context = desing.CreateDbContext(null);
        
        //muestra todas las solicitudes en el sistema
        public List<SolicitudesReparacionDTO> GetAll()
        {
            try
            {
                return _context.SolicitudReparacions
                .Include(s => s.requerimientos)
                .Select(s => new SolicitudesReparacionDTO
                {
                    Id = s.Id,
                    tallerId = s.tallerId,
                    
                    taller = new TallerDTO
                    {
                        TallerId = s.tallerId,
                        
                    },
                    
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener la solicitud", ex);
            }
        }

        //Muestra todas las solicitudes que les falte asignar el taller
      /*  public List<SolicitudesReparacionDTO> GetSolicitudWithoutTaller()
        {
            try
            {
                return _context.SolicitudesReparacion
                .Include(s => s.requerimientos)
                .Where(s => s.tallerId == Guid.Empty)
                .Select(s => new SolicitudesReparacionDTO
                {
                    Id = s.Id,
                    incidenteId = s.incidenteId,
                    incidente = new IncidenteDTO
                    {
                        Id = s.incidenteId,
                        polizaId = s.incidente!.polizaId,
                    },
                    vehiculoId = s.vehiculoId,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener la solicitud", ex);
            }
        }*/
        
        /// Busca una solicitud por su id 
        public SolicitudesReparacionDTO GetSolicitudById(Guid solicitudId)
        {
            try
            {
                return _context.SolicitudReparacions
                .Include(s => s.requerimientos)
                .Where(s => s.Id == solicitudId)
                .Select(s => new SolicitudesReparacionDTO
                {
                    Id = s.Id,
                    //incidenteId = s.incidenteId,
                    //vehiculoId = s.vehiculoId,
                    tallerId = s.tallerId,
                    requerimientos = _context.Requerimientos
                    .Where(r => r.solicitudRepId == s.Id)
                    .Select(r => new RequerimientoDTO
                    {
                        Id = r.requerimientoId,
                        solicitudId = r.solicitudRepId,
                        
                        tipoRequerimiento = r.tipoRequerimiento.ToString(),
                        cantidad = r.cantidad,
                        parte = new ParteDTO{
                            Id = r.parteId,
                            nombre = r.parte!.nombre,
                        }
                    }).ToList()
                }).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener la solicitud", ex);
            }
        }

        /// Busca las solicitudes segun el id del incidente
    /*    public List<SolicitudesReparacionDTO> GetSolicitudByIncidenteId(Guid incidenteId)
        {
            try
            {
                return _context.SolicitudReparacions
                .Include(s => s.requerimientos)
                .Where(s => s. == incidenteId)
                .Select(s => new SolicitudesReparacionDTO
                {
                    Id = s.Id,
                    incidenteId = s.incidenteId,
                    vehiculoId = s.vehiculoId,
                    tallerId = s.tallerId,
                    requerimientos = _context.Requerimientos
                    .Where(r => r.solicitudReparacionId == s.Id)
                    .Select(r => new RequerimientoDTO
                    {
                        Id = r.Id,
                        solicitudId = r.solicitudReparacionId,
                        descripcion = r.descripcion,
                        tipoRequerimiento = r.tipoRequerimiento.ToString(),
                        cantidad = r.cantidad,
                        parte = new ParteDTO{
                            Id = r.parteId,
                            nombre = r.parte!.nombre,
                        }
                    }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener la solicitud", ex);
            }
        }*/

        ///<summary>
        ///actualiza la lista de solicitud desde el sistema de taller
        ///</summary>
        ///<param name="solicitud">solicitud a registrar</param>
        ///<returns>true si se registro correctamente, false si no</returns>
        /// Registra una solicitud con los datos basicos, aun no incluye taller ni los requerimientos
        public Guid RegisterSolicitud(SolicitudReparacion solicitud)
        {
            try
            {
                _context.SolicitudReparacions.Add(solicitud);
                _context.DbContext.SaveChanges();
                return solicitud.Id;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al registrar la solicitud", ex);
            }
        }

    }
}