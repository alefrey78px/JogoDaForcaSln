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
                                                
                AtualizaInterfaceDoJogo();

                int tentativasRestantes = _forca.ObterTentativasRestantes();

                AnimacaoEnforcamento(tentativasRestantes);

                bool acertouPalavra = _forca.VerificarSeGanhou();

                if (acertouPalavra || tentativasRestantes == 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        "Deseja continuar jogando?",
                        "Jogo da Forca",
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

            }

        }


        private void AtualizaInterfaceDoJogo()
        {
            labelDica.Text = $"Dica: {_forca.ObterDica()}";
            labelQuantasLetras.Text = $"Letras: {_forca.TamanhoDaPalavra().ToString()}";
            labelTentativasRestantes.Text = $"Tentativas: {_forca.ObterTentativasRestantes()}";
            LblJogador.Text = _forca.ObterNomeDoJogador();
            LblPontos.Text = _forca.ObterPontuacao().ToString();
            labelPalavra.Text = _forca.ObterPalavraMascarada();
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


        private void AnimacaoEnforcamento(int chances)
        {
            pictureBox1.Image = _forca.VerificarSeGanhou()
                ? Image.FromFile("Imagens/trofeu.png")
                : Image.FromFile("Imagens/forca" + chances + ".png");
        }


        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            _forca = new Forca();

            NovoJogo();

            ArmazenaNomeDoJogador();
        }


        private void NovoJogo()
        {
            _forca.IniciarNovoJogo();

            pictureBox1.Image = Image.FromFile("Imagens/forca7.png");

            AtualizaInterfaceDoJogo();

            HabilitarTeclado(true);
        }


        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }
    }

}

