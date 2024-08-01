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
            AtribuiLetras();
        }

        private void ArmazenaNomeDoJogador()
        {
            string nomeJogador = Interaction.InputBox("Informe seu nome:", "Jogo da Forca", "Jogador");
            _forca.DefinirNomeJogador(nomeJogador);
        }

        private void AtribuiLetras()
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
                bool acertou = _forca.ProcessarChute(btn.Text[0]);
                btn.Enabled = false;
                btn.BackColor = acertou ? Color.Blue : Color.Red;

                AtualizaInterfaceDoJogo();

                AnimacaoEnforcamento(_forca.ObterTentativasRestantes());

                bool acertouPalavra = _forca.VerificarSeGanhou();
                int tentativasRestantes = _forca.ObterTentativasRestantes();

                if ( acertouPalavra || tentativasRestantes == 0)
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
            LblPontos.Text = _forca.ObterPontuacao().ToString();
            labelPalavra.Text = _forca.ObterPalavraMascarada();
            labelTentativasRestantes.Text = "Tentativas: " + _forca.ObterTentativasRestantes();
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
                ? Image.FromFile("db/trofeu.png")
                : Image.FromFile("db/forca" + chances + ".png");
        }


        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            _forca = new Forca();
            ArmazenaNomeDoJogador();
            NovoJogo();
        }


        private void NovoJogo()
        {
            _forca.IniciarNovoJogo();

            labelPalavra.Text = _forca.ObterPalavraMascarada();
            labelDica.Text = $"Dica: {_forca.ObterDica()}";
            labelQuantasLetras.Text = $"Letras: {_forca.TamanhoDaPalavra().ToString()}";
            labelTentativasRestantes.Text = $"Tentativas: {_forca.ObterTentativasRestantes()}";
            pictureBox1.Image = Image.FromFile("db/forca7.png");

            LblJogador.Text = _forca.ObterNomeDoJogador();
            LblPontos.Text = _forca.ObterPontuacao().ToString();

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

