using Microsoft.EntityFrameworkCore;
using administracion.DataAccess.Database;
using administracion.DataAccess.Entities;
using administracion.Exceptions;
using administracion.BussinesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using administracion.DataAccess.Enums;

namespace  administracion.DataAccess.DAOs
{
    public class ProveedorDAO : IProveedorDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();

        private IAdminDBContext _context = desing.CreateDbContext(null);

        /// <summary>
        /// Registra un proveedor nuevo en la base de datos
        /// </summary>
        /// <param name="proveedor">DTO de regsitro con la informacion del proveedor</param>
        /// <returns>Guid con el Id del proveedor</returns>
        public Guid RegisterProveedor(Proveedor proveedor)
        {
            try
            {
                _context.Proveedores.Add(proveedor);
                _context.DbContext.SaveChanges();
                return proveedor.Id;
            }
            catch (DbUpdateException)
            {
                throw new RCVException("Error al guardar, llave duplicada");
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al crear el asegurado", ex);

            }
        }
        
        /// <summary>
        /// Obtiene un proveedor según su Id
        /// </summary>
        /// <param name="id">Id del proveedor</param>
        /// <returns>DTO con la informacion del proveedor</returns>
        public ProveedorDTO GetProveedorByGuid(Guid proveedorId)
        {
            try
            {
                var data = _context.Proveedores
                .Where(t => t.Id == proveedorId)
                .Include(t => t.marcas)
                .Select(t => new ProveedorDTO
                {
                    Id = t.Id,
                    nombreLocal = t.nombreLocal,
                    marcas = t.marcas!
                    .Select(m => new MarcaDTO
                    {
                        nombreMarca = m.manejaTodas ? "TodasLasMarcas" : m.marcaName.ToString()!
                    }
                    ).ToList(),
                }).SingleOrDefault();
                if (data == null)
                {
                    throw new Exception("No se encontre algun Proveedor con ese nombre y apellido Error 404");
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar obtener el asegurado:", ex.Message, ex);
            }

        }

        /// <summary>
        /// Obtiene todos los proveedores registrados en  el sistema
        /// </summary>
        /// <returns>Lista de DTOs con la informacion de los proveedores</returns>
        public List<ProveedorDTO> GetProveedores()
        {
            try
            {
                var data = _context.Proveedores
                .Include(t => t.marcas)
                .Select(t => new ProveedorDTO
                {
                    Id = t.Id,
                    nombreLocal = t.nombreLocal,
                    marcas = t.marcas!.Select(m => new MarcaDTO
                    {
                        nombreMarca = m.manejaTodas ? "TodasLasMarcas" : m.marcaName.ToString()!
                    }
                    ).ToList(),
                });
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ocurrio un error al trata de obtener los Proveedores:", ex, ex.Message, "500");
            }
        }
        
        /// <summary>
        /// Revisa si la marca existe como especializacion en el taller
        /// </summary>
        /// <param name="tallerId">Id del taller</param>
        /// <param name="marca">Marca a revisar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool IsMarcaExistsOnProveedor(Guid proveedorId, MarcaName marca)
        {
            try
            {
                var data = _context.MarcasProveedor
                .Where(m => m.proveedorId == proveedorId 
                    && (m.marcaName == marca || m.manejaTodas == true))
                .FirstOrDefault();
                return data != null? true : false;
            }
            catch(ArgumentNullException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene los Proveedores que coincidan con la marca suministrada
        /// </summary>
        /// <param name="marca">Marca a buscar</param>
        /// <returns>Lista de Proveedores que coinciden con la marca</returns>
        public List<ProveedorDTO> GetProveedoresByMarca(MarcaName marca)
        {
            try
            {
                var data = _context.MarcasProveedor
                .Join(_context.Proveedores, m => m.proveedorId, t => t.Id, (m, t) => new { m, t })
                .Where(query => query.m.marcaName == marca || query.m.manejaTodas == true)
                .Select( query => new ProveedorDTO
                {
                    Id = query.t.Id, 
                    nombreLocal = query.t.nombreLocal,
                    marcas = query.t.marcas!.Select(marca => new MarcaDTO
                    {
                        nombreMarca = marca.manejaTodas ? "TodasLasMarcas" : marca.marcaName.ToString()!
                    }
                    ).ToList(),
                })
                .ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al intentar obtener las marcas del taller", ex);
            }
        }

        /// <summary>
        /// Agrega una marca a un taller existente o indica todas las marcas
        /// al indicar todas se borran los registros y se deja uno con el todasLasMarcas= true
        /// </summary>
        /// <param name="proveedorId">Id del proveedor</param>
        /// <param name="marca">DTO con la informacion de la marca</param>
        /// <param name="todasLasMarcas"> true si se manejan todas las marcas</param>
        /// <returns>Booleano True si se realizo bien</returns>
        public Guid AddMarca(MarcaProveedor marca)
        {
            try
            {
                _context.MarcasProveedor.Add(marca);
                _context.DbContext.SaveChanges();
                return marca.Id;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al crear el asegurado", ex);
            }
        }
        
        /// <summary>
        /// Elimina todas las marcas de un proveedor
        /// </summary>
        /// <param name="proveedorId">Id del proveedor</param>
        /// <returns>Void</returns>
        public int DeleteMarcasFromProveedor(Guid proveedorId)
        {
            try
            {
                var data = _context.MarcasProveedor
                    .Where(v => v.proveedorId == proveedorId);

                _context.MarcasProveedor
                    .RemoveRange(data.ToList());
                return _context.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RCVException("Fallo al intenta borrar las marcas",ex);
            }
        }
    }
}