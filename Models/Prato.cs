namespace Desafio_180907.Models
{
    public class Prato
    {
        private string _comida;
        public string comida { get { return _comida; } }

        private string _alias;
        public string alias { get { return _alias; } }

        public Prato(string comida){
            this._comida = comida;
        }

        public Prato(string comida, string alias){
            this._comida = comida;
            this._alias = alias;
        }
    }
}