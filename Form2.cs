using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Projeto
{
    public partial class Form2 : Form
    {
        string stringConexao = "server=localhost;database=Registro;uid=root;pwd=thayna;";
        public Form2()
        {
            InitializeComponent();

            //O sistema deve entender que o campo cpf/cnpj começa como cpf 
            textBox2.MaxLength = 11; //Limitar a quantidade de caracteres

            //O label do cpf/cnpj deve começar como cpf 
            label3.Text = "CPF: ";

            //Entende-se que o formulário 2 se inicia com o checkbox de instituição desativado 
            checkBox1.Checked = false;
        }

        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();

        private void label2_Click(object sender, EventArgs e)
        {
            //Não é necessário
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Não é necessário
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validação de E-mail simples usando Regex
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(textBox3.Text, padraoEmail)) // textBox3 é o campo para o e-mail
            {
                MessageBox.Show("Por favor, insira um e-mail válido!", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Verificando se senha (textBox4) e confirmação de senha (textBox5) são iguais
            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("As senhas não coincidem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection con = new MySqlConnection(stringConexao))
            {
                try
                {
                    con.Open();

                    // 3. Verificar se o usuário já existe
                    string queryVerificar = "SELECT COUNT(*) FROM user_tb WHERE usuario = @user";
                    MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, con);
                    cmdVerificar.Parameters.AddWithValue("@user", textBox1.Text.Trim());

                    int usuarioExiste = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (usuarioExiste > 0)
                    {
                        MessageBox.Show("Este usuário já está cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 4. Se estiver tudo certinho, realiza o INSERT no banco de dados 
                    string queryInsert = "INSERT INTO user_tb (usuario, senha, email, documento) VALUES (@user, @pass, @email, @doc)";
                    MySqlCommand cmdInsert = new MySqlCommand(queryInsert, con);
                    cmdInsert.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@pass", textBox4.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@email", textBox3.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@doc", textBox2.Text.Trim()); //doc para verificar o cfp/cnpj inserido

                    cmdInsert.ExecuteNonQuery();

                    //Se estiver tudo certo, apresentar mensagem
                    MessageBox.Show("Usuário criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Form1().Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao processar: " + ex.Message);
                }
            }
        }

        //Habilitando checkbox para visualizar ou não a senha inserida
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //Se o checkbox estiver marcado, deve mostrar o texto
                textBox4.UseSystemPasswordChar = false;
                textBox5.UseSystemPasswordChar = false;
            }
            //Se estiver desmarcado, não mostra o texto
            else
            {
                textBox4.UseSystemPasswordChar = true;
                textBox5.UseSystemPasswordChar = true;
            }
        }

        //Checkbox para verificar se é uma instituição ou usuário comum
        private void checkBox1_CheckedChange(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label3.Text = "CNPJ:";
                textBox2.MaxLength = 14; //Limitar a quantidade de caracteres
            }
            else
            {
                label3.Text = "CPF: ";
                textBox2.MaxLength = 11; //Limitar a quantidade de caracteres   
            }
            textBox2.Clear();
        }
    }
}

