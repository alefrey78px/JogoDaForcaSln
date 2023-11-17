using System;
using System.Linq;
using System.Text;
using System.Globalization;


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
            SortearPalavra.Sortear(); // faz o sorteio da palavra e dica
            _palavra = SortearPalavra.Palavra; // recebe a palavra
            _dica = SortearPalavra.Dica; // recebe a dica

            _quantidadeDeLetras = _palavra.Count(char.IsLetter); // conta as letras da palavra

            // essa variavel é uma cópia "mascarada" com "-" da _palavra
            // serve para exibição na tela
            _palavraMascarada = new string('-', _palavra.Length);
        }


        public bool Venceu()
        {
            // quando a palavra mascaracada for igual a palavra
            // o jogador venceu
            if (string.Equals(_palavra, _palavraMascarada))
                return true;

            return false;
        }

        
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
                        novaStringMascarada[i] = letraChutada;
                }

                _palavraMascarada = novaStringMascarada.ToString();

                return true;
            }
            else
            {
                _tentativas -= 1;
                return false;
            }

        }
        

    }
}
