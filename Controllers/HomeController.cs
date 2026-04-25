using Microsoft.AspNetCore.Mvc;
using MCMV.Data;
using MCMV.Logical;
using System.Text.RegularExpressions;

public class HomeController : Controller
{
    // Variáveis privadas para armazenar os serviços de Login e Registro (Injeção de Dependência).
    private readonly LoginService _loginService;
    private readonly RegisterService _registerService;


    public HomeController(LoginService loginService, RegisterService registerService)
    {
        _loginService = loginService;
        _registerService = registerService;
    }

    // --- LOGIN ---

    // Carrega a página de Login
    public IActionResult Login() => View();

    // Recebe os dados do formulário de login (documento e senha) via método POST.
    [HttpPost]
    public IActionResult Login(string documento, string senha)
    {
        // Verifica se os dados inseridos são os mesmos do banco de dados 
        bool valido = _loginService.ValidarLogin(documento, senha);

        if (valido)
        {
            // Se o login for válido, identifica se o documento é um CPF (usuário) ou CNPJ (instituição).
            string tipo = _loginService.ObterTipoUsuario(documento);

            // Redireciona para a tela correta dependendo do perfil do usuário logado.
            if (tipo == "CPF")
            {
                return RedirectToAction("IndexUsuario");
            }
            else if (tipo == "CNPJ")
            {
                return RedirectToAction("IndexInstituicao");
            }
        }

        //Caso alguma das informações esteja incorret, exibe mensagem de erro
        ViewBag.Erro = "CPF/CNPJ ou senha inválidos";
        return View();
    }

    // --- CADASTRO ---

    // Carrega a página de Cadastro.
    public IActionResult Cadastro() => View();

    // Para inserir os dados recebidos do cadastro 
    [HttpPost]
    public IActionResult Cadastro(string user, string identific, bool isInstit, string email, string senha, string confirmarSenha)
    {
        // Validação de E-mail
        string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email ?? "", padraoEmail))
        {
            ViewBag.Erro = "E-mail inválido!";
            return View();
        }

        // Validação de Senha
        if (senha != confirmarSenha)
        {
            ViewBag.Erro = "As senhas não coincidem!";
            return View();
        }

        // Validação de CPF ou CNPJ
        if (!Validador.ValidarDocumento(identific))
        {
            ViewBag.Erro = "CPF ou CNPJ inválido!";
            return View();
        }

        // Verifica se o nome de usuário escolhido já existe no banco de dados para evitar duplicidade.
        if (_registerService.UsuarioExiste(user))
        {
            ViewBag.Erro = "Este nome de usuário já está em uso.";
            return View();
        }

        // Se todas as validações passaram, cria o novo usuário no banco de dados.
        _registerService.CriarUsuario(user, senha, email, identific);

        //  mensagem de sucesso para o usuário após o cadastro, informando que ele pode fazer login.            
        TempData["MensagemSucesso"] = "Usuário criado com sucesso! Faça login para continuar.";

        // Após cadastrar, manda o usuário para a tela de Login.
        return RedirectToAction("Login");
    }

    // --- TELAS PÓS-LOGIN ---

    // Action que chama a View da página inicial do Usuário Comum 
    public IActionResult IndexUsuario() => View();

    // Action que chama a View da página inicial da Instituição
    public IActionResult IndexInstituicao() => View();

    // Action para a tela onde o usuário inicia o processo de doação.
    public IActionResult FacaUmaDoacao() => View();

    // Action para a tela onde alguém solicita o recebimento de uma doação.
    public IActionResult PrecisaDeDoacao() => View();
}