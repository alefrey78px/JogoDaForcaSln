using System;
using System.IO;
using System.Linq;
using System.Text;

namespace JogoDaForca
{
    class Forca
    {
        private String palavraSecreta;
        private String palavraMascarada;
        private int _tentativas;
        private String _dica;
        private int _quantidadeDeLetras;
        private static string caminhoArquivo = "palavras.txt";


        public int Tentativas
        {
            get { return _tentativas; }
            set { _tentativas = value; }

        }

        public String Palavra
        {
            get { return palavraSecreta; }
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
            get { return palavraMascarada; }
        }

        public Forca() { }

        private static int ContarLinhas(string caminhoArquivo)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                return linhas.Length;
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Arquivo não encontrado: {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
        }


        private int GerarNumeroRandomico(int maximo)
        {
            Random random = new Random();
            return random.Next(maximo);
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
                string linha = File.ReadLines(caminhoArquivo).Skip(numeroLinha - 1).FirstOrDefault();

                if (linha != null)
                {
                    // Divide a linha usando ponto e vírgula como delimitador
                    conteudoLinha = linha.Split(';');
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
        public void Sortear()
        {

            // Conta quantas linhas tem o arquivo
            int numeroLinhas = ContarLinhas(caminhoArquivo);
            
            // Gera um numero aleatorio de 0 ao numero de linhas do arquivo
            int numeroLinhaDesejada = GerarNumeroRandomico(numeroLinhas);

            string[] conteudoLinha = LerLinhaSepararPorPontoEVirgula(caminhoArquivo, numeroLinhaDesejada);


            if (conteudoLinha != null && conteudoLinha.Length == 2)
            {
                palavraSecreta = conteudoLinha[0].ToUpper();
                _dica = conteudoLinha[1].ToUpper();
                _quantidadeDeLetras = ContarLetras(palavraSecreta);
            }
            else
            {
                throw new Exception($"A linha {numeroLinhaDesejada} não pôde ser lida ou não contém o formato esperado.");
            }

            // Atribui um caractere - em palavraMascarada para representar
            // cada letra da palavraSecreta, ex.:
            // palavraSecreta   = ABACATE
            // palavraMascarada = -------
            palavraMascarada = new string('-', palavraSecreta.Length);
        }

        // Conta as letras da palavra sorteada
        private int ContarLetras(string texto)
        {
            int totalLetras = 0;

            foreach (char caractere in texto)
            {
                if (char.IsLetter(caractere))
                {
                    totalLetras++;
                }
            }

            return totalLetras;
        }


        public bool Venceu()
        {
            if (string.Equals(palavraSecreta, palavraMascarada) && (_tentativas != 0))
            {
                return true;
            }
            else if (_tentativas == 0)
            {
                GameOver();
            }

            return false;
        }

        public bool GameOver()
        {
            return true;
        }

        public bool VerificaChute(char letra)
        {
            bool temALetra = palavraSecreta.Contains(letra);

            if (temALetra)
            {

                char letraChutada = letra;

                StringBuilder novaStringMascarada = new StringBuilder(palavraMascarada);

                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (palavraSecreta[i] == letraChutada)
                    {
                        // Atualiza a letra mascarada na mesma posição que está na string original
                        novaStringMascarada[i] = letraChutada;
                    }
                }

                palavraMascarada = novaStringMascarada.ToString();
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
