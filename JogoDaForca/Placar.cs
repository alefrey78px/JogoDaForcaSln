using System;

namespace JogoDaForca
{
    public class Placar
    {
        private const int PontosPorAcerto = 10;
        private const int PontosPorErro = 5;

        private string _jogador;
        private int _pontos;


        public Placar()
        {
            _jogador = string.Empty;
            _pontos = 0;
        }


        public string ObterNomeDoJogador() => _jogador;
        public int ObterPontuacao() => _pontos;

        public void DefinirNomeDoJogador(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do jogador não pode ser vazio ou somente espaços em branco.");

            _jogador = nome;
        }

        public int CalculaPontuacao(bool acertouLetra)
        {
            if (acertouLetra)
            {
                _pontos += PontosPorAcerto;
                return _pontos;
            }
            else
            {
                _pontos -= PontosPorErro;
                return _pontos;
            }
        }

    }

}
