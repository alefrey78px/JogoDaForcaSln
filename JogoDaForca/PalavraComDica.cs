using System;
using System.Linq;

namespace JogoDaForca
{
    public class PalavraComDica
    {
        public PalavraComDica(String dica, String palavra)
        {
            this.Dica = dica;
            this.Palavra = palavra;
            this.Tamanho = palavra.Count(char.IsLetter);
            this.PalavraMascarada = new string('?', Tamanho);
        }

        public String Dica { get; set; } = string.Empty;
        public String Palavra { get; set; } = string.Empty;
        public int Tamanho { get; private set; }
        public String PalavraMascarada { get; set; } = string.Empty;
        
    }

}
