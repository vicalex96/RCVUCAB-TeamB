using Microsoft.EntityFrameworkCore;
using proveedor.Persistence.Database;
using proveedor.Persistence.Entities;
using proveedor.Exceptions;
using proveedor.BussinesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proveedor.Persistence.DAOs
{
    public class CotizacionParteDAO: ICotizacionParteDAO
    {
        public readonly IProveedorDbContext _context;

        public CotizacionParteDAO( IProveedorDbContext context)
        {
            _context = context;
        }

        public string createCotizacionParte(CotizacionParteDTO cotPt){
            try{
                CotizacionParteEntity CotPtEntity = new CotizacionParteEntity();
                CotPtEntity.CotizacionParteId = Guid.NewGuid();
                CotPtEntity.ProveedorId = cotPt.ProveedorId;
                CotPtEntity.PrecioParteUnidad = cotPt.PrecioParteUnidad;
                CotPtEntity.FechaEntrega = cotPt.FechaEntrega;
                CotPtEntity.estado = (EstadoCotPt)Enum.Parse(typeof(EstadoCotPt), cotPt.estado);
                CotPtEntity.RequerimientoId = cotPt.RequerimientoId;
                _context.Incidentes.Add(incidenteEntity);
                _context.DbContext.SaveChanges();
                return "Cotizacion de Parte se ha registrado correctamente";

                }
                catch(Exception ex){
                throw new ProveedorException("Error al registrar la cotizacion de", ex);
            }
            }
            
        }
        
        public List<CotizacionParteDAO> GetCotizacionPartes()
        {
            try
            {
                var cotpts = _context.CotizacionParte
                
                .Select( cotpt=> new CotizacionParteDAO{
                    Id = cotpt.CotizacionParteID,
                    RequerimientoId = cotpt.RequerimientoId,
                    PrecioParteUnidad = cotpt.PrecioParteUnidad,
                    FechaEntrega = cotpt.FechaEntrega,
                    estado = cotpt.EstadoCotPt,

                });
                
                return cotpts.ToList();

            }
            catch(Exception ex)
            {
                throw new ProveedorException("Ha ocurrido un error al intentar consultar la lista de Cotizacion de parte", ex.Message, ex);
            }
        }

        public string actualizarCotizacionParte(Guid CotizacionParteID, EstadoCotPt estado)
        {
            try
            {
                var CotizacionParte = _context.CotizacionPartes
                    .Where(cotid => cotid.CotizacionParteID == CotizacionParteID)
                    .FirstOrDefault();
                CotizacionParte.EstadoCotPt = estado;
                _context.DbContext.SaveChanges();
                return "Estado de Cotizacion de parte ha sido actualizado";
            }
            catch (Exception e)
            {
                throw new ProveedorException("Ha ocurrido un error al intentar actualizar el estado de cotizacion de parte", ex.Message, ex);
            }
        }

    }


