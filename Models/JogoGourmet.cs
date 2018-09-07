using System.Collections.Generic;
using System.Linq;

namespace Desafio_180907.Models
{
    public class JogoGourmet
    {
        private List<Prato> _pratos;
        public List<Prato> pratos { get { return _pratos; } }

        public JogoGourmet(Prato prato = null){
            _pratos = new List<Prato>();

            _pratos.Add(new Prato("Massa"));
            AddPrato(prato);
        }

        private void AddPrato(Prato prato = null){
            if(prato == null){
                _pratos.Add(new Prato("Bolo de Chocolate"));
            }
            else{
                _pratos.Add(new Prato(prato.comida, prato.alias));
            }
        }

        public void AddPrato(string comida, string alias){
            _pratos.Add(new Prato(comida, alias));
        }

        public bool IsValidComida(string comida){
            return _pratos.Any(x => x.comida.Equals(comida));
        }

        public bool IsValidAlias(string alias){
            return _pratos.Any(x => x.alias.Equals(alias));
        }

        public string UltimoPrato(){
            return pratos.Last().comida;
        }
    }
}