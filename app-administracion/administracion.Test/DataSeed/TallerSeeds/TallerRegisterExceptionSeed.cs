using System.Collections;
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.Enums;

namespace administracion.Test.DataSeed
{
    public class TallerRegisterExceptionSeed : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new TallerRegisterDTO()
                {
                    nombreLocal = ""
                }
            };
            yield return new object[] {
                new TallerRegisterDTO()
                {
                    nombreLocal = "string"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}