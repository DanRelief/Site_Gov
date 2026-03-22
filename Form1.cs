using System;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto
{
    public partial class Form1 : Form
    {

        string stringConexao = "server=localhost;database=Registro;uid=root;pwd=thayna;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Usando "using" para garantir que a conexão seja fechada automaticamente
            using (MySqlConnection con = new MySqlConnection(stringConexao))
            {
                try
                {
                    con.Open();
                    // Usando PARÂMETROS (@user, @pass) por segurança
                    string query = "SELECT * FROM user_tb WHERE usuario = @user AND senha = @pass";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows) // Verifica se encontrou o usuário
                    {
                        Form3 telaPrincipal = new Form3();
                        telaPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar: " + ex.Message);
                }
            }
        }

        //Habilitar checkbox visualização de senha 
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               //Se o checkbox estiver marcado, deve mostrar o texto
                textBox2.UseSystemPasswordChar = false;
            }
            //Se estiver desmarcado, não mostra o texto
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }    

        }

        //Quando clicar no link para criar a conta, deve abrir a tela de criação 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 telaRegistro = new Form2();
            telaRegistro.Show();  //Mostra a tela para criar o usuário
            this.Hide(); //Esconde a tela de login
            
        }   
    }
}