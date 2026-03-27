namespace Projeto.Front
{
    public partial class FrontPrincipal : Form
    {
        public FrontPrincipal()
        {
            InitializeComponent();
        }

        private void btnCriarPonto_Click(object sender, EventArgs e)
        {
            new CriarPonto().ShowDialog();
        }
    }
}