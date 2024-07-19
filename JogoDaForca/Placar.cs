using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public class Placar
    {
        public Placar() {
            this.Jogador = string.Empty;
            this.Pontos = 0;
        }

        public string Jogador { get; set; }
        public int Pontos { get; private set; }

        public int CalculaPontuacao(bool acertouLetra)
        {
            if (acertouLetra)
            {
                Pontos += 10;
                return Pontos;
            }

            Pontos -= 5;
            return Pontos;
        }

    }
}
