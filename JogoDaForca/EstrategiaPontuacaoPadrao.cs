public class EstrategiaPontuacaoPadrao : IEstrategiaPontuacao
{
    private const int PontosPorAcerto = 10;
    private const int PontosPorErro = 5;
   
    public int CalcularPontos(bool acertou, int pontuacaoAtual)
    {
        return acertou ? pontuacaoAtual + PontosPorAcerto : pontuacaoAtual - PontosPorErro;
    }

}
