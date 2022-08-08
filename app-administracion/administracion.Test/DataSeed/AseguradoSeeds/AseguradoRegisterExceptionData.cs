using System.Collections;
using administracion.BussinesLogic.DTOs;

namespace administracion.Test.DataSeed
{
    public class AseguradoRegisterExceptionData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new AseguradoRegisterDTO()
                {
                    nombre = "",
                    apellido = "Perez",
                }
            };
            yield return new object[] {
                new AseguradoRegisterDTO()
                {
                    nombre = "Pepito",
                    apellido = "",
                }
            };
            yield return new object[] {
                new AseguradoRegisterDTO()
                {
                    nombre = "string",
                    apellido = "",
                }
            };
            yield return new object[] {
                new AseguradoRegisterDTO()
                {
                    nombre = "",
                    apellido = "string",
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}