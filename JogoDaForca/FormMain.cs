using System;
using System.Drawing;
using System.Windows.Forms;


namespace JogoDaForca
{
    public partial class FormMain : Form
    {
        private readonly Forca _forca = new Forca();


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
                //bool acertou = _forca.VerificaChute(btn.Text[0]);
                var acertou = _forca.VerificaChute(btn.Text[0]);

                // Desabilitar o botão
                btn.Enabled = false;

                btn.BackColor = acertou ? Color.Blue : Color.Red;
                /*
                if (acertou)
                    btn.BackColor = Color.Blue;
                else
                    btn.BackColor = Color.Red;*/

            }

            labelPalavra.Text = _forca.Palavra.PalavraMascarada;

            labelTentativasRestantes.Text = "Tentativas: "
                + _forca.Tentativas.ToString();

            AnimacaoEnforcamento(_forca.Tentativas);

            if (_forca.Venceu())
            {
                MessageBox.Show("A palavra secreta era: "
                    + _forca.Palavra.Palavra, "VENCEDOR!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HabilitarControles(false);
            }

            if (_forca.Tentativas != 0)
                return;
            
            MessageBox.Show("A palavra secreta era: "
                    + _forca.Palavra.Palavra, "GAME OVER!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            HabilitarControles(false);

        }

        private void HabilitarControles(bool estado)
        {
            foreach (Control control in this.groupBox1.Controls)
            {
                if (!(control is Button botao))
                    continue;

                botao.Enabled = estado;
                botao.BackColor = SystemColors.Control;
            }

            pictureBox1.Visible = estado;
            labelPalavra.Visible = estado;
            groupBox1.Visible = estado;
            groupBox2.Visible = estado;
        }

        private void AnimacaoEnforcamento(int chances)
        {
            // Sugestão do ReSharper
            // achei mais confuso...
            pictureBox1.Image = _forca.Venceu()
                ? Image.FromFile("db/trofeu.png")
                : Image.FromFile("db/forca" + chances + ".png");
            /*
            if (_forca.Venceu())
                pictureBox1.Image = Image.FromFile("db/trofeu.png");
            else
                pictureBox1.Image = Image.FromFile("db/forca"+chances+".png");
            */
        }


        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            _forca.InicioDoJogo();

            labelPalavra.Text = _forca.Palavra.PalavraMascarada;

            //labelDica.Text = "Dica: " + _forca.Palavra.Dica;
            labelDica.Text = $"Dica: {_forca.Palavra.Dica}";

            labelQuantasLetras.Text = "Letras: "
                + _forca.Palavra.Tamanho;

            labelTentativasRestantes.Text = "Tentativas: "
                + _forca.Tentativas.ToString();

            pictureBox1.Image = Image.FromFile("db/forca7.png");

            HabilitarControles(true);
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem de confirmação
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica a escolha do usuário
            if (resultado == DialogResult.Yes)
            {
                // Fecha o formulário se o usuário escolheu "Sim"
                Close();
            }
            // Se o usuário escolheu "Não", não faz nada
        }

    }
}
