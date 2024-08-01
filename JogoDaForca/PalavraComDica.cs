using System;
using System.Linq;
using System.Text;

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

        public String Dica { get; private set; } = string.Empty;
        public String Palavra { get; private set; } = string.Empty;
        public int Tamanho { get; private set; }
        public String PalavraMascarada { get; private set; } = string.Empty;
        public String PalavraNormalizada { get; private set; } = string.Empty;


        public bool ChecarPresencaDaLetraNaPalavra(char letra)
        {
            // Normaliza a letra digitada para remover acentos
            string letraNormalizada = letra.ToString().Normalize(NormalizationForm.FormD);

            // Normaliza a palavra e verifica se ela contém a letra normalizada
            bool temALetra = Palavra.Normalize(NormalizationForm.FormD).Contains(letraNormalizada);

            if (temALetra)
            {
                // Atualiza a palavra mascarada considerando a normalização
                PalavraMascarada = AtualizarPalavraMascarada(letra);
                return true;
            }

            return false;
        }


        private string AtualizarPalavraMascarada(char letra)
        {
            char letraChutada = letra;
            StringBuilder novaStringMascarada = new StringBuilder(PalavraMascarada);

            for (int i = 0; i < Tamanho; i++)
            {
                // Normaliza a letra atual da palavra antes de comparar
                char letraAtualNormalizada = Palavra[i].ToString().Normalize(NormalizationForm.FormD)[0];

                if (letraAtualNormalizada == letraChutada)
                {
                    // Atualiza a letra mascarada na mesma posição que está na string original
                    novaStringMascarada[i] = Palavra[i];
                }
            }

            return novaStringMascarada.ToString();
        }


        public override string ToString() => $"Palavra: {Palavra}";
       
    }

}
