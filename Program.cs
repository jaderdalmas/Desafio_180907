using System;
using Desafio_180907.Models;

namespace Desafio_180907
{
    class Program
    {
        static void Main(string[] args)
        {
            NovoJogo();
        }

        private static void NovoJogo(){
            Prato result = null;

            bool continua = true;
            while(continua){
                result = JogoRodada(new JogoGourmet(result));

                Console.WriteLine("Continua (Y/N)?");
                continua = Console.ReadKey().Key.Equals(ConsoleKey.Y);
                Console.WriteLine();
            }
        }

        private static Prato JogoRodada(JogoGourmet jogo){
            Console.WriteLine("Pense em um prato que gosta (pressione enter)");
            var item = Console.ReadKey();

            bool acertei = false;
            foreach(var prato in jogo.pratos){
                acertei = ConfirmaPrato(prato);
                if(acertei) { break; }
            }

            if(!acertei){
                return PerguntaPrato(jogo.UltimoPrato());
            }

            return null;
        }

        private static bool ConfirmaPrato(Prato prato){
            if(!string.IsNullOrWhiteSpace(prato.alias)){
                Console.WriteLine(string.Format("O prato que você pensou é {0} (Y/N)?", prato.alias));
                var keyAlias = Console.ReadKey().Key;
                Console.WriteLine();
                if(!keyAlias.Equals(ConsoleKey.Y)){
                    return false;
                }
            }

            Console.WriteLine(string.Format("O prato que você pensou é {0} (Y/N)?", prato.comida));
            var keyComida = Console.ReadKey().Key;
            Console.WriteLine();
            if(keyComida.Equals(ConsoleKey.Y)){
                Console.WriteLine("Acertei denovo!");
                return true;
            }

            return false;
        }

        private static Prato PerguntaPrato(string ultimoPrato){
            string comida = "";
            while(string.IsNullOrWhiteSpace(comida)){
                Console.WriteLine("Qual prato você pensou?");
                comida = Console.ReadLine();
            }
            
            string alias = "";
            while(string.IsNullOrWhiteSpace(alias)){
                Console.WriteLine("{0} é ___ mas {1} não", comida, ultimoPrato);
                alias = Console.ReadLine();
            }

            return new Prato(comida, alias);
        } 
    }
}
