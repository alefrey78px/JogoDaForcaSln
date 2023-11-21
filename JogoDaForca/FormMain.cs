using System;
using System.Drawing;
using System.Windows.Forms;



namespace JogoDaForca
{
    public partial class FormMain : Form
    {
        readonly Forca forca = new Forca();


        public FormMain()
        {
            InitializeComponent();

            HabilitarControles(false);

            AtribuiLetras();
        }


        private void AtribuiLetras()
        {

            foreach (Control control in this.groupBox1.Controls)
            {
                if (control is Button botao)
                    botao.Click += Letra_Click;
            }

        }

        private void Letra_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
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

            labelTentativasRestantes.Text = "Tentativas: "
                + forca.Tentativas.ToString();

            if (forca.Venceu())
            {
                MessageBox.Show("A palavra secreta era: "
                    + forca.Palavra, "VENCEDOR!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HabilitarControles(false);
            }

            if (forca.Tentativas == 0)
            {
                MessageBox.Show("A palavra secreta era: "
                    + forca.Palavra, "GAME OVER!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HabilitarControles(false);
            }

        }

        private void HabilitarControles(bool estado)
        {
            foreach (Control control in this.groupBox1.Controls)
            {
                if (control is Button botao)
                {
                    botao.Enabled = estado;
                    botao.BackColor = SystemColors.Control;
                }
            }

            labelPalavra.Visible = estado;
            groupBox1.Visible = estado;
            groupBox2.Visible = estado;
        }

        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            forca.InicioDoJogo();

            groupBox1.Visible = true;
            groupBox2.Visible = true;

            labelPalavra.Text = forca.PalavraMascarada;

            labelDica.Text = "Dica: " + forca.Dica;

            labelQuantasLetras.Text = "A palavra tem "
                + forca.QuantidadeLetras
                + " letra(s).";

            forca.Tentativas = 7;

            labelTentativasRestantes.Text = "Tentativas: "
                + forca.Tentativas.ToString();

            HabilitarControles(true);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
