using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class ProveedorRegisterExceptionSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new ProveedorRegisterDTO()
                {
                    nombreLocal = ""
                }
            };
            yield return new object[] {
                new ProveedorRegisterDTO()
                {
                    nombreLocal = "String"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}