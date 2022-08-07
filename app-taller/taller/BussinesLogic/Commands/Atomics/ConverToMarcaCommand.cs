using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class ConvertToMarcaCommand: Command<MarcaName>
    {
        private MarcaName _result;
        private readonly string _marcaName; 

       public ConvertToMarcaCommand(string color)
        {
            _marcaName = color;
        }
        public override void Execute()
        {
            _result = (MarcaName)Enum.Parse(typeof(MarcaName), _marcaName);
        }

        public override MarcaName GetResult()
        {
            return _result!;
        }
    }
}