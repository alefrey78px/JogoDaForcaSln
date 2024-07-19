﻿using System;
using System.Text;


namespace JogoDaForca
{
    internal class Forca
    {
        // Essa classe contém a mecanica do jogo.
        // Com as modificações introduzidas pelas classes PalavraComDica e RepositorioPalavras
        // pode-se simplificar essa classe, removendo-de inumeras variaveis que se tornaram
        // desnecessarias, pois foram substituidas por um objeto do tipo PalavraComDica.
        // Dessa forma o codigo ficou mais organizado.

        private PalavraComDica _palavraComDicaSorteada;
        private RepositorioPalavras _repositorioPalavras = new RepositorioPalavras();
        private Placar _placar = new Placar();
        private int _tentativas;

        public Placar PlacarAtual
        {
            get { return _placar; }
            set { _placar.Jogador = value.ToString(); }
        }

        public int Tentativas
        {
            get { return _tentativas; }
        }

        public PalavraComDica PalavraComDicaSorteada
        {
            get { return _palavraComDicaSorteada; }
        }

        public void InicioDoJogo()
        {
            _palavraComDicaSorteada = _repositorioPalavras.Sorteia();
            _tentativas = 7;
        }

        public bool Venceu()
        {
            // quando a palavra mascaracada for igual a palavra
            // o jogador venceu
            /*if (string.Equals(_palavra, _palavraMascarada))
                return true;

            return false;*/
            return string.Equals(_palavraComDicaSorteada.Palavra, _palavraComDicaSorteada.PalavraMascarada);
        }

        public bool VerificaChute(char letra)
        {
            // Normaliza a letra digitada para remover acentos
            string letraNormalizada = letra.ToString().Normalize(NormalizationForm.FormD);

            // Normaliza a palavra e verifica se ela contém a letra normalizada
            bool temALetra = _palavraComDicaSorteada.Palavra.Normalize(NormalizationForm.FormD).Contains(letraNormalizada);

            if (temALetra)
            {
                // Atualiza a palavra mascarada considerando a normalização
                _palavraComDicaSorteada.PalavraMascarada = AtualizarPalavraMascarada(letra);
                _placar.CalculaPontuacao(temALetra);

                return true;
            }

            // se chegou aqui diminui as tentativas e retorna false
            _tentativas -= 1;
            _placar.CalculaPontuacao(temALetra);
            return false;
        }

        private string AtualizarPalavraMascarada(char letra)
        {
            char letraChutada = letra;
            StringBuilder novaStringMascarada = new StringBuilder(_palavraComDicaSorteada.PalavraMascarada);

            for (int i = 0; i < _palavraComDicaSorteada.Palavra.Length; i++)
            {
                // Normaliza a letra atual da palavra antes de comparar
                char letraAtualNormalizada = _palavraComDicaSorteada.Palavra[i].ToString().Normalize(NormalizationForm.FormD)[0];

                if (letraAtualNormalizada == letraChutada)
                {
                    // Atualiza a letra mascarada na mesma posição que está na string original
                    novaStringMascarada[i] = _palavraComDicaSorteada.Palavra[i];
                }
            }

            return novaStringMascarada.ToString();
        }

    }
}
