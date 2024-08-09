using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace JogoDaForca
{
    public partial class FormMain : Form
    {
        private Forca _forca;

        public FormMain()
        {
            InitializeComponent();

            HabilitarTeclado(false);

            AtribuiMetodoAsTeclasDoTeclado();
        }

        private void ArmazenaNomeDoJogador()
        {
            string nomeJogador = Interaction.InputBox("Informe seu nome:", "Jogo da Forca", "Jogador");
            _forca.DefinirNomeJogador(nomeJogador);
        }

        private void AtribuiMetodoAsTeclasDoTeclado()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Button botao)
                    botao.Click += Letra_Click;
            }
        }

        private void Letra_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                ProcessarLetraClicada(btn);

                AtualizaInterfaceDoJogo();

                VerificarFimDeJogo();

            }

        }

        private void ProcessarLetraClicada(Button btn)
        {
            char letra = btn.Text[0];
            bool acertou = _forca.ProcessarChute(letra);

            AtualizarBotao(btn, acertou);
        }

        private void AtualizarBotao(Button btn, bool acertou)
        {
            btn.Enabled = false;
            btn.BackColor = acertou ? Color.Blue : Color.Red;
        }

        private void VerificarFimDeJogo()
        {
            if (_forca.EstadoAtual == Forca.EstadoJogo.Ganhou)
                PerguntarSeContinua("Parabéns! Você ganhou!");
            else if (_forca.EstadoAtual == Forca.EstadoJogo.Perdeu)
                PerguntarSeContinua("Que pena! Você perdeu.");
        }

        void PerguntarSeContinua(string mensagem)
        {
            DialogResult resultado = MessageBox.Show(
                    "Deseja continuar jogando?",
                    mensagem,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

            if (resultado == DialogResult.Yes)
            {
                NovoJogo();
            }
            else
            {
                HabilitarTeclado(false);
                _forca = null;
            }
        }

        private void AtualizaInterfaceDoJogo()
        {
            // Obtendo os valores dos métodos da classe _forca
            string dica = _forca.ObterDica();
            int tamanhoDaPalavra = _forca.TamanhoDaPalavra();
            int tentativasRestantes = _forca.ObterTentativasRestantes();
            string nomeDoJogador = _forca.ObterNomeDoJogador();
            int pontuacao = _forca.ObterPontuacao();
            string palavraMascarada = _forca.ObterPalavraMascarada();

            // Atribuindo os valores às labels
            labelDica.Text = $"Dica: {dica}";
            labelQuantasLetras.Text = $"Letras: {tamanhoDaPalavra}";
            labelTentativasRestantes.Text = $"Tentativas: {tentativasRestantes}";
            labelJogador.Text = $"Jogador: {nomeDoJogador}";
            labelPontos.Text = $"Pontos: {pontuacao}";
            labelPalavra.Text = palavraMascarada;

            // Atualizando a animação de enforcamento
            pictureBox1.Image = _forca.VerificarSeGanhou()
                ? Image.FromFile("Imagens/trofeu.png")
                : Image.FromFile($"Imagens/forca{tentativasRestantes}.png");
        }


        private void HabilitarTeclado(bool estado)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Button botao)
                {
                    botao.Enabled = estado;
                    botao.BackColor = SystemColors.Control;
                }
            }
        }


        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            NovoJogo();

            ArmazenaNomeDoJogador();

            AtualizaInterfaceDoJogo();
        }


        private void NovoJogo()
        {
            _forca = new Forca();

            _forca.IniciarNovoJogo();

            HabilitarTeclado(true);

            AtualizaInterfaceDoJogo();
        }


        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
                Close();
        }
    }

}

