using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class Forca
    {

        private String palavraSecreta;
        private String palavraMascarada;
        int tentativas = 7;

        public int Tentativas {
            get { return tentativas; }


            }


        public Forca() { }

        public String SorteiaPalavra()
        {
            palavraSecreta = "ABACAXI";
            palavraMascarada = new string('_', palavraSecreta.Length);
            return palavraMascarada;

        }

        public String Exibe()
        {
            return palavraMascarada;
        }

        public bool Venceu()
        {
            if (string.Equals(palavraSecreta, palavraMascarada) && (tentativas != 0))
            {
                return true;
            }
            else if (tentativas == 0) {
                GameOver();
            }

            return false;
        }

        public bool GameOver()
        {
            return true;
        }

        public void VerificaChute(char letra)
        {
           bool temALetra = palavraSecreta.Contains(letra);

            if (temALetra)
            {

                char letraChutada = letra;

                StringBuilder novaStringMascarada = new StringBuilder(palavraMascarada);

                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (palavraSecreta[i] == letraChutada)
                    {
                        // Atualiza a letra mascarada na mesma posição que está na string original
                        novaStringMascarada[i] = letraChutada;
                    }
                }

                palavraMascarada = novaStringMascarada.ToString();

            }
            if (!temALetra)
            {
                tentativas -= 1;

            }

        }

        public void MarcaLetrasAcertadas()
        {

        }

        
    }
}
