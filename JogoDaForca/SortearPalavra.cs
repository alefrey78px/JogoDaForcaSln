using System;
using System.IO;
using System.Linq;


namespace JogoDaForca
{
    internal static class SortearPalavra
    {
        private static string _palavra;
        private static string _dica;
        private const string CaminhoArquivo = "db/palavras.txt";
        private static readonly Random gerarNumeroAleatorio = new Random();

        public static string Palavra => _palavra;

        public static string Dica => _dica;

        private static int ContarLinhas()
        {
            try
            {
                string[] linhas = File.ReadAllLines(CaminhoArquivo);
                return linhas.Length;
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Arquivo não encontrado: {CaminhoArquivo}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
        }


        private static int GerarNumeroAleatorio(int maximo)
        {
            return gerarNumeroAleatorio.Next(maximo);         
        }


        // Le a linha sorteada do arquivo palavras.txt e separa onde tem o ;
        // atribuindo a array conteudoLinha o que foi lido
        // Exemplo:
        // linha: abacate;fruta verde
        // conteudoLinha = abacate, fruta verde
        private static string[] LerLinhaSepararPorPontoEVirgula(string caminhoArquivo, int numeroLinha)
        {
            string[] conteudoLinha = null;

            try
            {
                // Lê a linha específica do arquivo
                string linha = File.ReadLines(CaminhoArquivo).Skip(numeroLinha - 1).FirstOrDefault();

                if (linha != null)
                {
                    // Divide a linha usando ponto e vírgula como delimitador
                    conteudoLinha = linha.Split(';');
                }
                // Verifica se a linha possui exatamente dois elementos
                if (conteudoLinha.Length != 2)
                {
                    throw new Exception($"A linha {numeroLinha} não contém o formato esperado.");
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Arquivo não encontrado: {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }

            return conteudoLinha;
        }


        // Faz o sorteio da palavra
        public static void Sortear()
        {

            // Conta quantas linhas tem o arquivo
            int numeroLinhas = ContarLinhas();

            // Gera um numero aleatorio de 0 ao numero de linhas do arquivo
            int numeroLinhaDesejada = GerarNumeroAleatorio(numeroLinhas);

            string[] conteudoLinha = LerLinhaSepararPorPontoEVirgula(CaminhoArquivo, numeroLinhaDesejada);

            if (conteudoLinha != null && conteudoLinha.Length == 2)
            {
                _palavra = conteudoLinha[0].ToUpper();
                _dica = conteudoLinha[1].ToUpper();
            }
            else
            {
                throw new Exception($"A linha {numeroLinhaDesejada} não pôde ser lida ou não contém o formato esperado.");
            }
 
        }

    }
}
