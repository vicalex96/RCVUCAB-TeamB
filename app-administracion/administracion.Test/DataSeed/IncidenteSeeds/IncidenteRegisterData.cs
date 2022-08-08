using System.Collections;
using administracion.BussinesLogic.DTOs;

namespace administracion.Test.DataSeed
{
    public class IncidenteRegisterData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new IncidenteRegisterDTO()
                {
                    polizaId = Guid.Parse("0c5c3262-d5ef-46c7-0003-000000000003")
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
        
}