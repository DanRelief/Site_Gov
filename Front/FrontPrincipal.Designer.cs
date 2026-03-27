namespace Projeto.Front
{
    partial class FrontPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private Button btnCriarPonto;

        private void InitializeComponent()
        {
            this.btnCriarPonto = new Button();

            this.SuspendLayout();

            // botão
            btnCriarPonto.Text = "Criar Ponto de Doação";
            btnCriarPonto.Size = new Size(200, 50);
            btnCriarPonto.Location = new Point(300, 180);
            btnCriarPonto.Click += btnCriarPonto_Click;

            // form
            this.ClientSize = new Size(800, 450);
            this.Text = "Tela Principal";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(btnCriarPonto);

            this.ResumeLayout(false);
        }

        #endregion
    }
}