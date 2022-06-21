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
    public class VehiculoDAO: IVehiculoDAO
    {
        public readonly IAdminDBContext _context;

        public VehiculoDAO( IAdminDBContext context)
        {
            _context = context;
        }

        public List<VehiculoDTO> GetAllVehiculos()
        {
            try
            {
                var vehiculos = _context.Vehiculos
                //.Include(v => v.asegurado)
                .Include(v => v.polizas)
                .Select( v=> new VehiculoDTO{
                    Id = v.vehiculoId,
                    anioModelo = v.anioModelo,
                    color = v.color.ToString(),
                    marca = v.marca.ToString(),
                    asegurado =  _context.Asegurados
                    .Where(a => a.aseguradoId == v.aseguradoId)
                    .Select(a =>
                    new AseguradoDTO{
                        Id = v.asegurado.aseguradoId,
                        nombre = v.asegurado.nombre,
                        apellido = v.asegurado.apellido
                    }).FirstOrDefault(),
                    polizas = v.polizas.Select( p => new PolizaDTO{
                            Id = p.polizaId,
                            fechaRegistro = p.fechaRegistro,
                            fechaVencimiento = p.fechaVencimiento,
                            tipoPoliza = p.tipoPoliza.ToString(),
                            vehiculoId = v.vehiculoId,
                    }).ToList()
                }).ToList();
                if(vehiculos.ToList().Count == 0){
                    throw new Exception("No se encontraron vehiculos con ese nombre y apellido Error 404");
                }
                return vehiculos.ToList();

            }
            catch(Exception ex)
            {
                throw new RCVException("Error al obtener los vehiculos", ex);
            }
        }

        public VehiculoDTO GetVehiculoByGuid(Guid Id)
        {   
            try
            {
                VehiculoDTO data = _context.Vehiculos
                   .Include(v => v.asegurado)
                   .Where(v => v.vehiculoId == Id)
                   .Select(v => new VehiculoDTO
                   {
                        Id = v.vehiculoId,
                        anioModelo = v.anioModelo,
                        color = v.color.ToString(),
                        marca = v.marca.ToString(),
                        asegurado =  _context.Asegurados
                        .Where(a => a.aseguradoId == v.aseguradoId)
                        .Select(a => new AseguradoDTO{
                            Id = v.asegurado.aseguradoId,
                            nombre = v.asegurado.nombre,
                            apellido = v.asegurado.apellido
                        }).FirstOrDefault(),
                        polizas = v.polizas.Select( p => new PolizaDTO{
                            Id = p.polizaId,
                            fechaRegistro = p.fechaRegistro,
                            fechaVencimiento = p.fechaVencimiento,
                            tipoPoliza = p.tipoPoliza.ToString(),
                            vehiculoId = v.vehiculoId,
                    }).ToList()

                   }).ToList()[0]; 
                return data;
            }
            catch (Exception ex) {
                Console.WriteLine("ocurrio un error al intentar leer la data: " ,ex.Message.ToString());
                throw new RCVException("Ha ocurrido un error al intentar obtener el vehiculo:", ex.Message, ex);
            }
 
        }
        public List<VehiculoDTO> GetVehiculosByAsegurado(Guid aseguradoId)
        {
            try
            {
                var data = _context.Vehiculos
                   .Include(v => v.asegurado)
                   .Include(v => v.polizas)
                   .Where(v => v.aseguradoId == aseguradoId)
                   .Select(v => new VehiculoDTO
                   {
                       Id = v.vehiculoId,
                       anioModelo = v.anioModelo,
                       color = v.color.ToString(),
                       marca = v.marca.ToString(),
                        asegurado =  _context.Asegurados
                        .Where(a => a.aseguradoId == v.aseguradoId)
                        .Select(a => new AseguradoDTO{
                            Id = v.asegurado.aseguradoId,
                            nombre = v.asegurado.nombre,
                            apellido = v.asegurado.apellido
                        }).FirstOrDefault(),
                        polizas = v.polizas.Select( p => new PolizaDTO{
                            Id = p.polizaId,
                            fechaRegistro = p.fechaRegistro,
                            fechaVencimiento = p.fechaVencimiento,
                            tipoPoliza = p.tipoPoliza.ToString(),
                            vehiculoId = v.vehiculoId,
                        }
                       ).ToList()

                   }).ToList();
                if(data.ToList().Count == 0){
                    throw new Exception("No se encontraron vehiculos con ese nombre y apellido Error 404");
                }
                return data.ToList();
            }
            catch (Exception ex) {
                throw new RCVException("Ha ocurrido un error al intentar obtener el vehiculo:", ex.Message, ex);
            }
        }
        public string createVehiculo(VehiculoSimpleDTO auto)
        {
            //get enum Marca value from auto.Marca
            Marca marca = (Marca)Enum.Parse(typeof(Marca), auto.marca);
            try{
                Color _color = (Color)Enum.Parse(typeof(Color), auto.color);
                Marca _marca = (Marca)Enum.Parse(typeof(Marca), auto.marca);
                var vehiculo = new Vehiculo(auto.Id,auto.anioModelo, auto.fechaCompra, _color, auto.placa,_marca);
                _context.Vehiculos.Add(vehiculo);
                _context.DbContext.SaveChanges();
                return "Vehiculo creado";
            }
            catch(Exception ex){
                throw new RCVException("Error al crear el asegurado", ex);
            }
            return "Vehiculo creado";
        }
        public string updateVehiculo(VehiculoSimpleDTO auto)
        {
            try{
                var vehiculo = _context.Vehiculos.Where(v => v.vehiculoId == auto.Id).FirstOrDefault();
                vehiculo.anioModelo = auto.anioModelo;
                vehiculo.color = (Color)Enum.Parse(typeof(Color), auto.color);
                vehiculo.fechaCompra = auto.fechaCompra;
                vehiculo.marca = (Marca)Enum.Parse(typeof(Marca), auto.marca);
                vehiculo.placa = auto.placa;
                _context.DbContext.SaveChanges();
                return "Vehiculo actualizado";
            }
            catch(Exception ex){
                throw new RCVException("Error al actualizar el vehiculo", ex);
            }
        }

//un asegurado no debe de poder cambiarse
        public string addAsegurado(Guid vehiculoId , Guid  aseguradoId)
        {
            try
            {
                var vehiculo = _context.Vehiculos.Where(v => v.vehiculoId == vehiculoId).FirstOrDefault();
                
                
                var asegurado = _context.Asegurados.Where(a => a.aseguradoId == aseguradoId).FirstOrDefault();
                if(asegurado != null && vehiculo != null)
                    vehiculo.aseguradoId = asegurado.aseguradoId;
                    Vehiculo veh = (Vehiculo) vehiculo;
                    _context.Vehiculos.Update(veh);
                    _context.DbContext.SaveChanges();
                return "Asegurado Agregado";
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al agregar el asegurado", ex);
            }
        }
    }
}