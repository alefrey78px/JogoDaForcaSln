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
            foreach (Control control in groupBoxTeclado.Controls)
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
                ContinuaJogando();
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
            //labelPalavra.Text = palavraMascarada;

            // Atualizando a animação de enforcamento
            pictureBoxForca.Image = _forca.VerificarSeGanhou()
                ? Image.FromFile("Imagens/trofeu.png")
                : Image.FromFile($"Imagens/forca{tentativasRestantes}.png");

            CriarLabelsParaPalavra(palavraMascarada);
        }

        private void HabilitarTeclado(bool estado)
        {
            foreach (Control control in groupBoxTeclado.Controls)
            {
                if (control is Button botao)
                {
                    botao.Enabled = estado;
                    botao.BackColor = SystemColors.Control;
                }
            }
        }

        private void CriarLabelsParaPalavra(string palavraOculta)
        {
            groupBoxPalavraOculta.Controls.Clear(); // Remove todos os Labels existentes
            groupBoxPalavraOculta.AutoSize = true;

            int xPosition = 10; // Posição inicial X dentro do groupBox3
            int yPosition = 20; // Posição inicial Y dentro do groupBox3
            int padding = 10;   // Espaço entre os labels

            int labelWidth = 60; // Largura fixa para todos os Labels
            int labelHeight = 60; // Altura fixa para todos os Labels

            foreach (char letra in palavraOculta)
            {
                Label lbl = new Label();
                lbl.Text = letra.ToString();
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lbl.Font = new System.Drawing.Font("Arial", 30);
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // Centraliza o texto no Label
                lbl.Size = new System.Drawing.Size(labelWidth, labelHeight); // Define o tamanho fixo do Label
                lbl.Location = new System.Drawing.Point(xPosition, yPosition);

                groupBoxPalavraOculta.Controls.Add(lbl);

                xPosition += labelWidth + padding;
            }
        }

        private void BtnNovoJogo_Click(object sender, EventArgs e)
        {
            NovoJogo();

            ArmazenaNomeDoJogador();

            AtualizaInterfaceDoJogo();
        }

        private void ContinuaJogando()
        {
            _forca.IniciarNovoJogo();

            HabilitarTeclado(true);

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
