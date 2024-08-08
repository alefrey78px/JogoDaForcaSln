using System;

namespace JogoDaForca
{
    public class Placar
    {
        private int _pontos;
        private IEstrategiaPontuacao _estrategiaPontuacao;
        private string _jogador;

        public Placar(IEstrategiaPontuacao estrategiaPontuacao)
        {
            _estrategiaPontuacao = estrategiaPontuacao;
            _pontos = 0;
        }
        public int CalculaPontuacao(bool acertouLetra)
        {
            _pontos = _estrategiaPontuacao.CalcularPontos(acertouLetra, _pontos);
            return _pontos;
        }


        public string ObterNomeDoJogador() => _jogador;
        public int ObterPontuacao() => _pontos;

        public void DefinirNomeDoJogador(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do jogador não pode ser vazio ou somente espaços em branco.");

            _jogador = nome;
        }

    }

}
