using System.Collections;
using administracion.BussinesLogic.DTOs;

namespace administracion.Test.DataSeed
{
    public class IncidenteRegisterExceptionData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new IncidenteRegisterDTO()
                {
                    polizaId = Guid.Empty
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}