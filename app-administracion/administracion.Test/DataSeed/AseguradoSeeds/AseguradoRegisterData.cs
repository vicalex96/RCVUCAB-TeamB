using System.Collections;
using administracion.BussinesLogic.DTOs;

namespace administracion.Test.DataSeed
{
    public class AseguradoRegisterData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new AseguradoRegisterDTO()
                {
                    nombre = "Pepito",
                    apellido = "Perez",
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}