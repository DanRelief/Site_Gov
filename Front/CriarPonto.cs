using Projeto.Models;
using Projeto.Logical;

namespace Projeto.Front
{
    public partial class CriarPonto : Form
    {
        private PontoDoacaoService service = new PontoDoacaoService();

        public CriarPonto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRua.Text))
            {
                MessageBox.Show("Preencha a rua!");
                return;
            }

            PontoDoacao ponto = new PontoDoacao
            {
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                CEP = txtCEP.Text,
                Itens = txtItens.Text,
                Quantidades = txtQtd.Text
            };

            service.Criar(ponto);

            MessageBox.Show("Ponto criado com sucesso!");

            this.Close();
        }
    }
}