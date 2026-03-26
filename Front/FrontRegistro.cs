using Projeto.Logical;
using System.Text.RegularExpressions;

namespace Projeto.Front
{
    public partial class FrontRegistro : Form
    {
        private RegisterService service = new RegisterService();

        public FrontRegistro()
        {
            InitializeComponent();

            // configuração inicial
            textBox2.MaxLength = 11;
            label3.Text = "CPF:";
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string documento = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string senha = textBox4.Text.Trim();
            string confirmarSenha = textBox5.Text.Trim();

            // valida email
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, padraoEmail))
            {
                MessageBox.Show("E-mail inválido!");
                return;
            }

            // valida senha
            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem!");
                return;
            }

            // verifica usuário
            if (service.UsuarioExiste(usuario))
            {
                MessageBox.Show("Usuário já existe!");
                return;
            }

            // cria usuário
            service.CriarUsuario(usuario, senha, email, documento);

            MessageBox.Show("Usuário criado com sucesso!");

            new FrontLogin().Show();
            this.Hide();
        }

        // Mostrar senha
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = checkBox2.Checked;

            textBox4.UseSystemPasswordChar = !mostrar;
            textBox5.UseSystemPasswordChar = !mostrar;
        }

        // CPF / CNPJ
        private void checkBox1_CheckedChange(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label3.Text = "CNPJ:";
                textBox2.MaxLength = 14;
            }
            else
            {
                label3.Text = "CPF:";
                textBox2.MaxLength = 11;
            }

            textBox2.Clear();
        }
    }
}