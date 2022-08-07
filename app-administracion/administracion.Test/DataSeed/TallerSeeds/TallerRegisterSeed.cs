using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class TallerRegisterSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new TallerRegisterDTO()
                {
                    nombreLocal = "Taller 1"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}