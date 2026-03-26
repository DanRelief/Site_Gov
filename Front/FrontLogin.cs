using Projeto.Logical;

namespace Projeto.Front
{
    public partial class FrontLogin : Form
    {
        private LoginService service = new LoginService();

        public FrontLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valido = service.ValidarLogin(
                textBox1.Text,
                textBox2.Text
            );

            if (valido)
            {
                new FrontPrincipal().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login inválido");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrontRegistro().Show();
            this.Hide();
        }
    }
}