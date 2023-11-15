using System;
using System.Drawing;
using System.Windows.Forms;



namespace JogoDaForca
{
    public partial class FormMain : Form
    {
        Forca forca = new Forca();


        public FormMain()
        {
            InitializeComponent();

            HabilitarBotoes(false);

            groupBox1.Visible = false;
            groupBox2.Visible = false;

            AtribuiLetras();
        }

        private void AtribuiLetras()
        {
            btnA.Click += Letra_Click;
            btnB.Click += Letra_Click;
            btnC.Click += Letra_Click;
            btnCedilha.Click += Letra_Click;
            btnD.Click += Letra_Click;
            btnE.Click += Letra_Click;
            btnF.Click += Letra_Click;
            btnG.Click += Letra_Click;
            btnH.Click += Letra_Click;
            btnI.Click += Letra_Click;
            btnJ.Click += Letra_Click;
            btnK.Click += Letra_Click;
            btnL.Click += Letra_Click;
            btnM.Click += Letra_Click;
            btnN.Click += Letra_Click;
            btnO.Click += Letra_Click;
            btnP.Click += Letra_Click;
            btnQ.Click += Letra_Click;
            btnR.Click += Letra_Click;
            btnS.Click += Letra_Click;
            btnT.Click += Letra_Click;
            btnU.Click += Letra_Click;
            btnV.Click += Letra_Click;
            btnW.Click += Letra_Click;
            btnX.Click += Letra_Click;
            btnY.Click += Letra_Click;
            btnZ.Click += Letra_Click;
        }

        private void Letra_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Chamar a função e passar a letra como parâmetro
                bool acertou = forca.VerificaChute(btn.Text[0]);

                // Desabilitar o botão
                btn.Enabled = false;

                if (acertou)
                    btn.BackColor = Color.Blue;
                else
                    btn.BackColor = Color.Red;

            }

            labelPalavra.Text = forca.PalavraMascarada;

            lblTentativasRestantes.Text = "Tentativas: "
                + forca.Tentativas.ToString();

            if (forca.Venceu())
            {
                MessageBox.Show("A palavra secreta era: "
                    + forca.Palavra, "VENCEDOR!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HabilitarBotoes(false);
            }

            if (forca.Tentativas == 0)
            {
                HabilitarBotoes(false);

                MessageBox.Show("A palavra secreta era: "
                    + forca.Palavra, "GAME OVER!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void HabilitarBotoes(bool estado)
        {
            foreach (Control control in this.groupBox1.Controls)
            {
                if (control is Button)
                {
                    Button botao = (Button)control;
                    botao.Enabled = estado;
                    botao.BackColor = SystemColors.Control;
                }
            }
        }

        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            forca.SortearPalavra();

            groupBox1.Visible = true;
            groupBox2.Visible = true;

            labelPalavra.Text = forca.SortearPalavra();

            lblDica.Text = "Dica: " + forca.Dica;

            lblQtdLetras.Text = "A palavra tem "
                + forca.QuantidadeLetras
                + " letra(s).";

            forca.Tentativas = 7;

            lblTentativasRestantes.Text = "Tentativas: "
                + forca.Tentativas.ToString();

            HabilitarBotoes(true);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
