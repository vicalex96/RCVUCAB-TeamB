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
    public class SolicitudDAO : ISolicitudDAO
    {
        public readonly ITallerDBContext _context;

        public SolicitudDAO(ITallerDBContext context)
        {
            _context = context;
        }
        public List<SolicitudDTO> GetSolicitudes()
        {
            List<SolicitudDTO> solicitudes = new List<SolicitudDTO>();
            try
            {
                solicitudes = _context.SolicitudReparacions
                .Select(s => new SolicitudDTO
                {
                    solicitudRepId = s.solicitudRepId,
                    incidenteId = s.incidenteId,
                    vehiculoId = s.vehiculoId,
                    tallerId = s.tallerId,
                }
                )
                .ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener las solicitudes", ex);
            }
            return solicitudes;
        }
    }
} 
