using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class VehiculoRegisterSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new VehiculoRegisterDTO()
                {
                    anioModelo = 2019,
                    fechaCompra = new System.DateTime(2019, 6, 1),
                    color = "Verde",
                    placa = "A1B2C3D",
                    marca = MarcaName.Renault.ToString(),
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}