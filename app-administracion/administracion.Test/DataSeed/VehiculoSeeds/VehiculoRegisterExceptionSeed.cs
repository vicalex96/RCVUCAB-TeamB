using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class VehiculoRegisterExceptionSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new VehiculoRegisterDTO()
                {
                    anioModelo = 2019,
                    fechaCompra = new System.DateTime(2019, 6, 1),
                    color = "Verde",
                    placa = "A1B2C3D4E5",
                    marca = MarcaName.Renault.ToString(),
                }
            };
            yield return new object[] {
                new VehiculoRegisterDTO()
                {
                    anioModelo = 2019,
                    fechaCompra = new System.DateTime(2019, 6, 1),
                    color = "Blanquito",
                    placa = "A1B2C3D",
                    marca = MarcaName.Renault.ToString(),
                }
            };
            yield return new object[] {
                new VehiculoRegisterDTO()
                {
                    anioModelo = 2019,
                    fechaCompra = new System.DateTime(2019, 6, 1),
                    color = "Verde",
                    placa = "A1B2C3D",
                    marca = "Apple",
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}