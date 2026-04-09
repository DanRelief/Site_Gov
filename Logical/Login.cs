using Projeto.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Logical
{
    public class Login
    {
        public class LoginApplicationService
        {
            private readonly LoginService _service = new LoginService();

            public LoginResult Entrar(string usuario, string senha)
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
                    return LoginResult.Falha("Usuário e senha são obrigatórios.");

                bool valido = _service.ValidarLogin(usuario.Trim(), senha);


                if (valido)
                    return LoginResult.Sucesso();
                else
                    return LoginResult.Falha("Login inválido.");

            }

            public record LoginResult(bool Ok, string? Mensagem)
            {
                public static LoginResult Sucesso() => new(true, null);
                public static LoginResult Falha(string msg) => new(false, msg);


            }
        }
    }
}
