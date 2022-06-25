using Microsoft.EntityFrameworkCore;
using proveedor.Persistence.Database;
using proveedor.Persistence.Entities;
using proveedor.Persistence.DAOs.Interfaces;
using proveedor.Persistence.DAOs.Implementations;
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
                CotPtEntity.RequerimientoId = cotPt.RequerimientoId;
                CotPtEntity.PrecioParteUnidad = cotPt.PrecioParteUnidad;
                CotPtEntity.FechaEntrega = cotPt.FechaEntrega;
                CotPtEntity.estado = (EstadoCotPt)Enum.Parse(typeof(EstadoCotPt), cotPt.estado);
                
                _context.CotizacionPartes.Add(CotPtEntity);
                _context.DbContext.SaveChanges();
                return "Cotizacion de Parte se ha registrado correctamente";

                }
                catch(Exception ex){
                throw new ProveedorException("Error al registrar la cotizacion de", ex);
            }
            }
            
        
        
        public List<CotizacionParteDTO> GetCotizacionPartes()
        {
            try
            {
                var cotpts = _context.CotizacionPartes
                
                .Select( cotpt=> new CotizacionParteDTO{
                    CotizacionParteId = cotpt.CotizacionParteId,
                    RequerimientoId = cotpt.RequerimientoId,
                    PrecioParteUnidad = cotpt.PrecioParteUnidad,
                    FechaEntrega = cotpt.FechaEntrega,
                    estado = cotpt.estado.ToString(),

                });
                
                return cotpts.ToList();

            }
            catch(Exception ex)
            {
                throw new ProveedorException("Ha ocurrido un error al intentar consultar la lista de Cotizacion de parte", ex.Message, ex);
            }
        }

        public List<CotizacionParteDTO> GetCotizacionPartesByestado(EstadoCotPt estado)
        {
                        try
            {
                var data = _context.CotizacionPartes.Where(p => p.estado == estado).Select( b=> new CotizacionParteDTO{
                    CotizacionParteId = b.CotizacionParteId,
                    RequerimientoId = b.RequerimientoId,
                    PrecioParteUnidad = b.PrecioParteUnidad,
                    FechaEntrega = b.FechaEntrega,
                    estado = b.estado.ToString(),
                });
                
                return data.ToList();
            }
            catch(Exception ex)
            {

                throw new ProveedorException("Ha ocurrido un error al intentar obtener la lista de Cotizacion de Parte", ex.Message, ex);
            }
        }
        

        public string actualizarCotizacionParte(Guid CotizacionParteID, EstadoCotPt estado)
        {
            try
            {
                var CotizacionParte = _context.CotizacionPartes
                    .Where(cotid => cotid.CotizacionParteId == CotizacionParteID)
                    .FirstOrDefault();
                CotizacionParte.estado = estado;
                _context.DbContext.SaveChanges();
                return "Estado de Cotizacion de parte ha sido actualizado";
            }
            catch (Exception ex)
            {
                throw new ProveedorException("Ha ocurrido un error al intentar actualizar el estado de cotizacion de parte", ex.Message, ex);
            }
        }

    }
}


