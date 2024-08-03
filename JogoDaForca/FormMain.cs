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
                char letra = btn.Text[0];
                bool acertou = _forca.ProcessarChute(letra);

                btn.Enabled = false;
                btn.BackColor = acertou ? Color.Blue : Color.Red;
                                                
                int tentativasRestantes = _forca.ObterTentativasRestantes();

                bool acertouPalavra = _forca.VerificarSeGanhou();

                AtualizaInterface();

                if (acertouPalavra || tentativasRestantes == 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        "Deseja continuar jogando?",
                        "Jogo da Forca",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (resultado == DialogResult.Yes)
                        NovoJogo();
                    else
                        FinalizarJogo();
                }

            }

        }

        private void FinalizarJogo()
        {
            HabilitarTeclado(false);
            _forca = null;
        }

        private void AtualizaInterface()
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
            _forca = new Forca();

            NovoJogo();

            ArmazenaNomeDoJogador();

            AtualizaInterface();
        }


        private void NovoJogo()
        {
            _forca.IniciarNovoJogo();

            HabilitarTeclado(true);

            AtualizaInterface();
        }


        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
                Close();
        }
    }

}
