namespace JogoDaForca
{
    public class Forca
    {
        private PalavraComDica _palavra;
        private RepositorioPalavras _repositorioPalavras;
        private Placar _placar;
        private int _tentativas;

        public Forca()
        {
            _repositorioPalavras = new RepositorioPalavras();
            _placar = new Placar(new EstrategiaPontuacaoPadrao());
        }

        public void IniciarNovoJogo()
        {
            _palavra = _repositorioPalavras.Sorteia(); // sorteia nova palavra
            _tentativas = 7; // reseta número de tentativas
        }


        // Método para processar a letra "chutada" pelo jogador.
        // Basicamente ele verifica se a letra chutada existe na palavra.
        public bool ProcessarChute(char letra)
        {
            bool acertou = _palavra.ChecarPresencaDaLetraNaPalavra(letra);
            
            if (acertou)
            {
                _placar.CalculaPontuacao(true);
                return true;
            }
            else
            {
                _tentativas--;
                _placar.CalculaPontuacao(false);
            }
            
            return false;
        }


        public bool VerificarSeGanhou() =>
            string.Equals(_palavra.Palavra, _palavra.PalavraMascarada);
        public int ObterPontuacao() => _placar.ObterPontuacao();
        public string ObterNomeDoJogador() => _placar.ObterNomeDoJogador();
        public int ObterTentativasRestantes() => _tentativas;
        public string ObterPalavraMascarada() => _palavra.PalavraMascarada;
        public int TamanhoDaPalavra() => _palavra.Tamanho;
        public string ObterDica() => _palavra.Dica;
        public void DefinirNomeJogador(string nome) => _placar.DefinirNomeDoJogador(nome);
    }

}
