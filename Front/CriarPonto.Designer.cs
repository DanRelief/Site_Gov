namespace Projeto.Front
{
    partial class CriarPonto
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtRua;
        private TextBox txtNumero;
        private TextBox txtCEP;
        private TextBox txtItens;
        private TextBox txtQtd;
        private Button btnSalvar;

        private void InitializeComponent()
        {
            this.txtRua = new TextBox();
            this.txtNumero = new TextBox();
            this.txtCEP = new TextBox();
            this.txtItens = new TextBox();
            this.txtQtd = new TextBox();
            this.btnSalvar = new Button();

            this.SuspendLayout();

            txtRua.Location = new Point(50, 30);
            txtRua.PlaceholderText = "Rua";

            txtNumero.Location = new Point(50, 70);
            txtNumero.PlaceholderText = "Número";

            txtCEP.Location = new Point(50, 110);
            txtCEP.PlaceholderText = "CEP";

            txtItens.Location = new Point(50, 150);
            txtItens.PlaceholderText = "Itens";

            txtQtd.Location = new Point(50, 190);
            txtQtd.PlaceholderText = "Quantidade";

            btnSalvar.Text = "Salvar";
            btnSalvar.Location = new Point(50, 240);
            btnSalvar.Click += btnSalvar_Click;

            this.Controls.Add(txtRua);
            this.Controls.Add(txtNumero);
            this.Controls.Add(txtCEP);
            this.Controls.Add(txtItens);
            this.Controls.Add(txtQtd);
            this.Controls.Add(btnSalvar);

            this.ClientSize = new Size(300, 320);
            this.Text = "Criar Ponto";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }
    }
}