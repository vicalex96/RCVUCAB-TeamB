using Microsoft.EntityFrameworkCore;
using taller.DataAcces.Database;
using taller.DataAcces.Entities;
using taller.Exceptions;
using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace taller.DataAcces.DAOs
{
    public class RequerimientoDAO : IRequerimientoDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private ITallerDBContext _context = desing.CreateDbContext(null);
        //public readonly ITallerDBContext _context;



        /*public TallerDAO(ITallerDBContext context)
        {
            _context = context;
        }*/

        /// <summary>
        /// Registra un taller en el sistema
        /// </summary>
        /// <param name="requerimiento">DTO de registro con la informacion del taller</param>
        /// <returns>Guid con el Id del taller</returns>
        public Guid RegisterRequerimiento(Requerimiento requerimiento)
        {
            try
            {
                _context.Requerimientos.Add(requerimiento);
                _context.DbContext.SaveChanges();
                return requerimiento.requerimientoId;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al crear el requerimiento", ex);

            }
        }
    
        /// <summary>
        /// Obtiene un Taller según su Id
        /// </summary>
        /// <param name="id">Id del Taller</param>
        /// <returns>DTO con la informacion del Taller</returns>
        public RequerimientoDTO GetRequerimientoByGuid(Guid requerimientoId)
        {
            try
            {

               return _context.Requerimientos
                .Include(p => p.parte)
                .Select(r => new RequerimientoDTO
                {
                    Id = r.requerimientoId,
                    partes = _context.partes
                    .Include(requerimiento => requerimiento.parteId)
                    .Select(partes => new ParteDTO
                    {
                       
                            Id = partes.parteId,
                            nombre = r.parte!.nombre,
                      
                    }).ToList(),
                }).FirstOrDefault()!;

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al Requerimiento:", ex.Message, ex);
            }

        }
      
        /// <summary>
        /// Obtiene todos los taller registrados
        /// </summary>
        /// <returns>Lista de DTOs con la informacion de los talleres</returns>

        public ICollection<RequerimientoToShowDTO> GetAll()
        {
            try
            {
               return _context.Requerimientos
                .Include(p => p.parte)
                .Select(r => new RequerimientoToShowDTO
                {
                    
                    partes = _context.partes
                    .Include(requerimiento => requerimiento.parteId)
                    .Select(partes => new ParteDTO
                    {
                       
                            Id = partes.parteId,
                            nombre = r.parte!.nombre,
                      
                    }).ToList(),
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al obtener los requerimiento", ex);
            }
        }


       /* public List<TallerDTO> GetTalleres()
        {
            try
            {
                var data = _context.Talleres
                .Include(taller => taller.marcas)
                .Select(taller => new TallerDTO
                {
                    TallerId = taller.tallerId,
                    nombreLocal = taller.nombreLocal,
                    marcas = taller.marcas
                    .Select(marcas => new MarcaDTO
                    {
                        nombreMarca = marcas.manejaTodas ? "TodasLasMarcas" : marcas.marca.ToString()
                    }
                    ).ToList(),
                });
                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ocurrio un error al trata de obtener los Talleres:", ex, ex.Message, "500");
            }
        }*/

       /* public List<TallerDTO> GetTalleresCantidadesEntrega()
        {
            try
            {
                var data = _context.Talleres
                .Include(taller => taller.marcas)
                
                .Select(taller => new TallerDTO
                {
                    TallerId = taller.tallerId,
                    nombreLocal = taller.nombreLocal,
                    marcas = taller.marcas
                    //.Select(CotizacionReparacion => new CotizacionRepDTO
                  //  )
                    .Select(marca => new MarcaDTO
                    {
                        nombreMarca = marca.manejaTodas ? "TodasLasMarcas" : marca.marca.ToString()
                    }
                    ).ToList(),
                
                }).ToList();
                if (data.Any() == false)
                {
                    throw new Exception("No se encontro ningun taller, Error 404");
                }
                return data;
            }
            catch (Exception exception)
            {
                throw new RCVException("Ocurrio un error al trata de obtener los Talleres:", exception, exception.Message, "500");
            }
        }*/

       /* public string RegisterMarcasPorAPI(Guid tallerId, List<MarcaDTO> marcas)
        {
            return "";
        }*/
   /* public string RegisterTallerPorAPI(TallerSimpleDTO taller)
    {
        try
        {
            Taller tallerEntity = new Taller
            {
                tallerId = taller.TallerId,
                nombreLocal = taller.nombreLocal,
            };
            _context.Talleres.Add(tallerEntity);
            _context.DbContext.SaveChanges();
            return "Taller registrado";
        }
        catch (Exception ex)
        {
            throw new RCVException("Error al crear el asegurado", ex);

        }
    }*/

    /*
    public TallerDTO GetTallerByGuid (Guid tallerId)
    {
        try
        {
            var data = _context.Talleres
            .Where(t => t.tallerId == tallerId)
            .Include(t => t.marcas)
            .Select(t => new TallerDTO
            {
                Id = t.tallerId,
                nombreLocal = t.nombreLocal,
                marcas = t.marcas
                .Select(m => new MarcaDTO{
                    nombreMarca = m.manejaTodas ? "TodasLasMarcas": m.marca.ToString()
                    }
                ).ToList(),
            }).SingleOrDefault(); 
            if(data == null){
                throw new Exception("No se encontre algun taller con ese nombre y apellido Error 404");
            }
            return data;
        }            
        catch (Exception ex) {
            throw new RCVException("Ha ocurrido un error al intentar obtener el asegurado:", ex.Message, ex);
        }

    }
    public List<TallerDTO> GetTalleres()
    {
        try
        {
            var data = _context.Talleres
            .Include(t => t.marcas)
            .Select(t => new TallerDTO
            {
                Id = t.tallerId,
                nombreLocal = t.nombreLocal,
                marcas = t.marcas
                .Select(m => new MarcaDTO{
                    nombreMarca = m.manejaTodas ? "TodasLasMarcas": m.marca.ToString()
                    }
                ).ToList(),
            }).ToList(); 
            if(data.Any() == false){
                throw new Exception("No se encontro ningun taller, Error 404");
            }
            return data;
        }            
        catch (Exception ex) {
            throw new RCVException("Ocurrio un error al trata de obtener los Talleres:",ex, ex.Message, "500");
        }
    }

    public string AddMarca(Guid tallerId,string marca, bool todas = false)
    {

        try
        {
            var taller = _context.Talleres
            .Where(v => v.tallerId == tallerId)
            .Single();

            var marcas = _context.MarcasTaller
            .Where(v => v.tallerId == tallerId 
            && (v.manejaTodas == true 
            || v.marca == (Marca)Enum.Parse(typeof(Marca), marca)))
            .ToList();
            if(marcas.Count() != 0 )
            {
                throw new RCVException("La marca que intentas registrar al taller ya lo esta");
            }

            MarcaTaller marcaEntity;
            if(todas == false)
            {
                marcaEntity = new MarcaTaller
                {
                    marcaId = Guid.NewGuid(),
                    tallerId = tallerId, 
                    manejaTodas = false,
                    marca = (Marca)Enum.Parse(typeof(Marca), marca)
                };
            }
            else
            {
                marcaEntity = new MarcaTaller
                {
                    marcaId = Guid.NewGuid(),
                    tallerId = tallerId, 
                    manejaTodas = todas,
                };
            }

            _context.MarcasTaller.Add(marcaEntity);
            _context.DbContext.SaveChanges();
            return "Marca registrada registrado";
        }
        catch(RCVException ex){
            throw new RCVException("El taller ya cuanta con todo el listado de marcas", ex,"ya se agregó antes", "500");
        }
        catch(ArgumentNullException ex){
            throw new RCVException("Error no se encontró ningun taller con el Guid indicado", ex, ex.Message, "404");
        }
        catch(Exception ex){
            throw new RCVException("Error al crear el asegurado", ex);

        }
    }
*/
    }
}
    
