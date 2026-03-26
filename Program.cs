using Projeto.Front;

namespace Projeto
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new FrontLogin());
        }
    }
}