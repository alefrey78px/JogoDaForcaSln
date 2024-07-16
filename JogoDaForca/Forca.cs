using System;
using System.Text;


namespace JogoDaForca
{
    internal class Forca
    {
        private PalavraComDica _palavraSorteada;
        private RepositorioPalavras _sortearPalavra = new RepositorioPalavras();

        private int _tentativas;

        public int Tentativas
        {
            get { return _tentativas; }
        }
        
        public PalavraComDica Palavra
        {
            get { return _palavraSorteada; }
        }

        public void InicioDoJogo()
        {
            _palavraSorteada = _sortearPalavra.Sorteia();
            _tentativas = 7;
        }

        public bool Venceu()
        {
            // quando a palavra mascaracada for igual a palavra
            // o jogador venceu
            /*if (string.Equals(_palavra, _palavraMascarada))
                return true;

            return false;*/
            return string.Equals(_palavraSorteada.Palavra, _palavraSorteada.PalavraMascarada);
        }


        public bool VerificaChute(char letra)
        {
            // Normaliza a letra digitada para remover acentos
            string letraNormalizada = letra.ToString().Normalize(NormalizationForm.FormD);

            // Normaliza a palavra e verifica se ela contém a letra normalizada
            bool temALetra = _palavraSorteada.Palavra.Normalize(NormalizationForm.FormD).Contains(letraNormalizada);

            if (temALetra)
            {
                // Atualiza a palavra mascarada considerando a normalização
                _palavraSorteada.PalavraMascarada = AtualizarPalavraMascarada(letra);

                return true;
            }
            else
            {
                // diminui as tentativas e retorna false
                _tentativas -= 1;
                return false;
            }
        }

        private string AtualizarPalavraMascarada(char letra)
        {
            char letraChutada = letra;
            StringBuilder novaStringMascarada = new StringBuilder(_palavraSorteada.PalavraMascarada);

            for (int i = 0; i < _palavraSorteada.Palavra.Length; i++)
            {
                // Normaliza a letra atual da palavra antes de comparar
                char letraAtualNormalizada = _palavraSorteada.Palavra[i].ToString().Normalize(NormalizationForm.FormD)[0];

                if (letraAtualNormalizada == letraChutada)
                {
                    // Atualiza a letra mascarada na mesma posição que está na string original
                    novaStringMascarada[i] = _palavraSorteada.Palavra[i];
                }
            }

            return novaStringMascarada.ToString();
        }

    }
}
