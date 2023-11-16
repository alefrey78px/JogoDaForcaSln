using System;
using System.Linq;
using System.Text;

namespace JogoDaForca
{
    class Forca
    {
        private String _palavra;
        private String _palavraMascarada;
        private int _tentativas;
        private String _dica;
        private int _quantidadeDeLetras;
        


        public int Tentativas
        {
            get { return _tentativas; }
            set { _tentativas = value; }

        }

        public String Palavra
        {
            get { return _palavra; }
        }

        public String Dica
        {
            get { return _dica; }
        }

        public int QuantidadeLetras
        {
            get { return _quantidadeDeLetras; }
        }

        public string PalavraMascarada
        {
            get { return _palavraMascarada; }
        }

        public Forca() { }

        public void InicioDoJogo()
        {
            SortearPalavra.Sortear();
            _palavra = SortearPalavra.Palavra;
            _dica = SortearPalavra.Dica;

            ContarLetras(_palavra);

            // Atribui um caractere - em palavraMascarada para representar
            // cada letra da palavraSecreta, ex.:
            // palavraSecreta   = ABACATE
            // palavraMascarada = -------
            _palavraMascarada = new string('-', _palavra.Length);
        }

        // Conta as letras da palavra sorteada
        private void ContarLetras(string texto)
        {
            _quantidadeDeLetras = 0;
            _quantidadeDeLetras = texto.Count(char.IsLetter);


            //foreach (char caractere in texto)
            //{
//                if (char.IsLetter(caractere))
  //                  _quantidadeDeLetras++;
    //        }
           
        }


        public bool Venceu()
        {
            if (string.Equals(_palavra, _palavraMascarada))
            {
                return true;
            }
            /*else if (_tentativas == 0)
            {
                GameOver();
            }*/

            return false;
        }

        /*public bool GameOver()
        {
            return true;
        }
        */

        public bool VerificaChute(char letra)
        {
            bool temALetra = _palavra.Contains(letra);

            if (temALetra)
            {

                char letraChutada = letra;

                StringBuilder novaStringMascarada = new StringBuilder(_palavraMascarada);

                for (int i = 0; i < _palavra.Length; i++)
                {
                    if (_palavra[i] == letraChutada)
                    {
                        // Atualiza a letra mascarada na mesma posição que está na string original
                        novaStringMascarada[i] = letraChutada;
                    }
                }

                _palavraMascarada = novaStringMascarada.ToString();
                return true;


            }
            //if (!temALetra)
            else
            {
                _tentativas -= 1;
                return false;
            }

        }

    }
}
