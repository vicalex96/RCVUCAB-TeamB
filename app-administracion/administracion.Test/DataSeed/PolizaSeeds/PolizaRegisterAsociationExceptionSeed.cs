using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class PolizaRegisterAsociationExceptionSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new PolizaRegisterDTO()
                {
                    fechaRegistro = DateTime.Now.AddDays(-30),
                    fechaVencimiento = DateTime.Now.AddDays(-1),
                    tipoPoliza = TipoPoliza.CoberturaCompleta.ToString(),
                    vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-0002-000000000005")
                }
            };
            yield return new object[] {
                new PolizaRegisterDTO()
                {
                    fechaRegistro = DateTime.Now.AddDays(-30),
                    fechaVencimiento = DateTime.Now.AddDays(-1),
                    tipoPoliza = TipoPoliza.CoberturaCompleta.ToString(),
                    vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-0002-000000000003")
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}