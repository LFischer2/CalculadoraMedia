using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace CalculadoraMedia
{
    public partial class Form1 : Form
    {
        TextBox txtNP1 = new TextBox();
        TextBox txtNP2 = new TextBox();
        TextBox txtPIM = new TextBox();
        TextBox txtExame = new TextBox();

        Label lblSemestral = new Label();
        Label lblFinal = new Label();
        Label lblStatus = new Label();

        public Form1()
        {
            InitializeComponent();
            CriarInterface();


            txtNP1.KeyPress += ApenasNumerosEVirgula_KeyPress;
    txtNP2.KeyPress += ApenasNumerosEVirgula_KeyPress;
    txtPIM.KeyPress += ApenasNumerosEVirgula_KeyPress;
    txtExame.KeyPress += ApenasNumerosEVirgula_KeyPress;
        }

        private void ApenasNumerosEVirgula_KeyPress(object sender, KeyPressEventArgs e)
{
    TextBox txt = sender as TextBox;

    // Permite números, vírgula e backspace
    if (!char.IsDigit(e.KeyChar) &&
        e.KeyChar != ',' &&
        !char.IsControl(e.KeyChar))
    {
        e.Handled = true;
        return;
    }

    // Impede mais de uma vírgula
    if (e.KeyChar == ',' && txt.Text.Contains(","))
    {
        e.Handled = true;
        return;
    }

    // Simula o texto após digitar
    string novoTexto = txt.Text + e.KeyChar;

    // Validação do valor
    if (double.TryParse(
        novoTexto.Replace(",", "."),
        NumberStyles.Any,
        CultureInfo.InvariantCulture,
        out double valor))
    {
        // Bloqueia maior que 10
        if (valor > 10)
        {
            e.Handled = true;
        }
    }
}

        private void CriarInterface()
        {
            this.Text = "Cálculo de Médias";
            this.Size = new Size(520, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);

            Panel card = new Panel();
            card.Size = new Size(440, 520);
            card.Location = new Point(35, 30);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            Label topo = new Label();
            topo.Text = "Cálculo de Médias e Status | ESWA+POO";
            topo.ForeColor = Color.White;
            topo.BackColor = Color.FromArgb(55, 55, 55);
            topo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            topo.TextAlign = ContentAlignment.MiddleCenter;
            topo.Size = new Size(440, 45);
            topo.Location = new Point(0, 0);

            lblStatus.Text = "STATUS";
            lblStatus.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.BackColor = Color.FromArgb(235, 235, 235);
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Size = new Size(380, 40);
            lblStatus.Location = new Point(30, 70);

            CriarCampo(card, "NP1", txtNP1, 140);
            CriarCampo(card, "NP2", txtNP2, 190);
            CriarCampo(card, "PIM", txtPIM, 240);

            CriarResultado(card, "Semestral", lblSemestral, 290);

            Button btnLimparSemestral = CriarBotao("Limpar", 120, 335);
            btnLimparSemestral.Click += LimparTudo;

            Button btnSemestral = CriarBotao("Semestral", 220, 335);
            btnSemestral.Click += CalcularSemestral;

            CriarCampo(card, "Exame", txtExame, 395);

            CriarResultado(card, "Final", lblFinal, 445);

            Button btnLimparFinal = CriarBotao("Limpar", 125, 485);
            Button btnFinal = CriarBotao("Final", 225, 485);
            btnFinal.Click += CalcularFinal;


            card.Controls.Add(topo);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnLimparSemestral);
            card.Controls.Add(btnSemestral);
            card.Controls.Add(btnLimparFinal);
            card.Controls.Add(btnFinal);

            this.Controls.Add(card);
        }

        private void CriarCampo(Panel card, string texto, TextBox txt, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 11);
            lbl.Location = new Point(30, y);
            lbl.Size = new Size(120, 30);

            txt.Location = new Point(280, y - 5);
            txt.Size = new Size(130, 32);
            txt.Font = new Font("Segoe UI", 11);
            txt.Text = "0";
            txt.TextAlign = HorizontalAlignment.Right;

            card.Controls.Add(lbl);
            card.Controls.Add(txt);

            txt.Enter += (s, e) =>
{
    if (txt.Text == "0")
        txt.Text = "";
};

txt.Leave += (s, e) =>
{
    if (string.IsNullOrWhiteSpace(txt.Text))
        txt.Text = "0";
};
        }

        private void CriarResultado(Panel card, string texto, Label resultado, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 11);
            lbl.Location = new Point(30, y);
            lbl.Size = new Size(130, 30);

            resultado.Text = "0.0";
            resultado.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            resultado.TextAlign = ContentAlignment.MiddleRight;
            resultado.Location = new Point(280, y - 2);
            resultado.Size = new Size(130, 30);

            card.Controls.Add(lbl);
            card.Controls.Add(resultado);
        }

        private Button CriarBotao(string texto, int x, int y)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Font = new Font("Segoe UI", 10);
            btn.Size = new Size(90, 36);
            btn.Location = new Point(x, y);
            btn.BackColor = Color.FromArgb(240, 240, 240);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;

            return btn;
        }

        private void CalcularSemestral(object sender, EventArgs e)
        {
            double np1 = double.Parse(
    txtNP1.Text.Replace(",", "."),
    CultureInfo.InvariantCulture
);
            double np2 = double.Parse(
    txtNP2.Text.Replace(",", "."),
    CultureInfo.InvariantCulture
);
            double pim = double.Parse(
    txtPIM.Text.Replace(",", "."),
    CultureInfo.InvariantCulture
);

            double media = (np1 * 0.4) + (np2 * 0.4) + (pim * 0.2);

            lblSemestral.Text = media.ToString("F1");
            lblStatus.Text = media >= 7 ? "APROVADO" : "EXAME";
        }

        private void CalcularFinal(object sender, EventArgs e)
        {
            double semestral = double.Parse(
    lblSemestral.Text.Replace(",", "."),
    CultureInfo.InvariantCulture
);
            double exame = double.Parse(
    txtExame.Text.Replace(",", "."),
    CultureInfo.InvariantCulture
);

            double final = (semestral + exame) / 2;

            lblFinal.Text = final.ToString("F1");
            lblStatus.Text = final >= 5 ? "APROVADO" : "REPROVADO";
        }

        private void LimparTudo(object sender, EventArgs e)
        {
            txtNP1.Text = "0";
            txtNP2.Text = "0";
            txtPIM.Text = "0";
            txtExame.Text = "0";
            lblSemestral.Text = "0.0";
            lblFinal.Text = "0.0";
            lblStatus.Text = "STATUS";
        }

        private void LimparFinal(object sender, EventArgs e)
        {
            txtExame.Text = "0";
            lblFinal.Text = "0.0";
            lblStatus.Text = "STATUS";
        }
    }
}