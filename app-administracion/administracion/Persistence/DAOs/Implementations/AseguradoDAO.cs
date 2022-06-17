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
    public class AseguradoDAO: IAseguradoDAO
    {
        public readonly IAdminDBContext _context;

        public AseguradoDAO( IAdminDBContext context)
        {
            _context = context;
        }

        public string createAsegurado(AseguradoDTO ase){
            try{
                
                var asegurado = new Asegurado(ase.aseguradoId,ase.nombre, ase.apellido);
                _context.Asegurados.Update(asegurado);
                _context.DbContext.SaveChanges();
                return "Asegurado creado";
            }
            catch(Exception ex){
                throw new RCVException("Error al actualizar el asegurado", ex);
            }
        }

        public List<AseguradoDTO> GetAsegurados()
        {
            try
            {
                var data = _context.Asegurados.Select( b=> new AseguradoDTO{
                    aseguradoId = b.aseguradoId,
                    nombre = b.nombre,
                    apellido = b.apellido
                });
                return data.ToList();

            }
            catch(Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de asegurados", ex.Message, ex);
            }
        }
        public AseguradoDTO GetAseguradoByGuid(Guid Id)
        {
                        try
            {
                var data = _context.Asegurados.Where(p => p.aseguradoId == Id).Select( b=> new AseguradoDTO{
                    aseguradoId = b.aseguradoId,
                    nombre = b.nombre,
                    apellido = b.apellido
                });
                if(data.ToList().Count == 0){
                    Console.WriteLine("\n Lanzando error");
                    throw new Exception("No se encontraron asegurados con ese nombre y apellido Error 404");
                }
                return data.ToList()[0];
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n Manejando el error -> fin del error");

                throw new RCVException("Ha ocurrido un error al intentar obtener el asegurado:", ex.Message, ex);
            }
        }
        public List<AseguradoDTO> GetAseguradosPorNombreCompleto(string nombre, string apellido)
        {
            try
            {
                var data = _context.Asegurados.Where(p => p.apellido.Contains(apellido) == true && p.nombre.Contains(nombre) == true).Select( b=> new AseguradoDTO{
                    aseguradoId = b.aseguradoId,
                    nombre = b.nombre,
                    apellido = b.apellido
                });
                if(data.ToList().Count == 0){
                    Console.WriteLine("\n Lanzando error");
                    throw new Exception("No se encontraron asegurados con ese nombre y apellido Error 404");
                }
                return data.ToList();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n Manejando el error -> fin del error");

                throw new RCVException("Ha ocurrido un error al intentar obtener el asegurado:", ex.Message, ex);
            }
        }

        public string updateAsegurado(AseguradoDTO ase)
        {
            try
            {
                var asegurado = new Asegurado(ase.aseguradoId,ase.nombre, ase.apellido);
                _context.Asegurados.Update(asegurado);
                _context.DbContext.SaveChanges();
                return "Asegurado editado";
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar editar el asegurado", ex.Message, ex);
            }
        }

    }
}