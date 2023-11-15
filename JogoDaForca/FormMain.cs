using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JogoDaForca
{
    public partial class FormMain : Form
    {
        Forca forca = new Forca();

        public FormMain()
        {
            InitializeComponent();
           
            btnA.Click += Letra_Click;
            btnB.Click += Letra_Click;
            btnC.Click += Letra_Click;
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

            forca.SorteiaPalavra();
            labelPalavra.Text = forca.SorteiaPalavra();

        }

        private void labelPalavra_Click(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            
        }

        private void Letra_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Chamar a função e passar a letra como parâmetro
                forca.VerificaChute(btn.Text[0]);

                // Desabilitar o botão
                btn.Enabled = false;
            }

            labelPalavra.Text = forca.Exibe();
            lblTentativasRestantes.Text = forca.Tentativas.ToString();
            
            if (forca.Venceu())
            {
                labelVenceu.Text = "Venceu!";
                groupBox1.Visible = false;
            }

            if (forca.Tentativas == 0)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                labelVenceu.Text = "Game Over!";
            }

        }



    }
}
