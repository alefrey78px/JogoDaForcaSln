using System;
using System.Linq;

namespace JogoDaForca
{
    // Essa classe é utilizada para modelar os dados necessários ao programa.
    // Nela temos os atributos para armazenar a Palavra, Dica, PalavraMascarada e
    // o Tamanho da Palavra.
    
    public class PalavraComDica
    {
        public PalavraComDica(String dica, String palavra)
        {
            this.Dica = dica;
            this.Palavra = palavra.ToUpper();
            this.Tamanho = palavra.Count(char.IsLetter);
            this.PalavraMascarada = new string('?', Tamanho);
        }

        public String Dica { get; set; } = string.Empty;
        public String Palavra { get; set; } = string.Empty;
        public int Tamanho { get; private set; }
        public String PalavraMascarada { get; set; } = string.Empty;


        public override string ToString()
        {
            return $"Palavra: {Palavra}";
        }

    }

}
