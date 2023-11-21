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
            //_palavraMascarada = new string('-', _palavra.Length);
            _palavraMascarada = new string(_palavra.Select(c => c == ' ' ? ' ' : '-').ToArray());
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
            // Normaliza a letra digitada para remover acentos
            string letraNormalizada = letra.ToString().Normalize(NormalizationForm.FormD);

            // Normaliza a palavra e verifica se ela contém a letra normalizada
            bool temALetra = _palavra.Normalize(NormalizationForm.FormD).Contains(letraNormalizada);

            if (temALetra)
            {
                // Atualiza a palavra mascarada considerando a normalização
                _palavraMascarada = AtualizarPalavraMascarada(letra);

                return true;
            }
            else
            {
                _tentativas -= 1;
                return false;
            }
        }

        private string AtualizarPalavraMascarada(char letra)
        {
            char letraChutada = letra;
            StringBuilder novaStringMascarada = new StringBuilder(_palavraMascarada);

            for (int i = 0; i < _palavra.Length; i++)
            {
                // Normaliza a letra atual da palavra antes de comparar
                char letraAtualNormalizada = _palavra[i].ToString().Normalize(NormalizationForm.FormD)[0];

                if (letraAtualNormalizada == letraChutada)
                {
                    // Atualiza a letra mascarada na mesma posição que está na string original
                    novaStringMascarada[i] = _palavra[i];
                }
            }

            return novaStringMascarada.ToString();
        }



    }
}
