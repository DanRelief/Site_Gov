using Projeto.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Projeto.Logical
{
    public class Registrador
    {
        private RegisterService service = new RegisterService();


        public void Registrar(
                    string usuario,
                    string documento,
                    string email,
                    string senha,
                    string confirmarSenha)
        {
            // valida email
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, padraoEmail))
                throw new Exception("E-mail inválido");

            // valida senha
            if (senha != confirmarSenha)
                throw new Exception("As senhas não coincidem");

            // verifica usuário
            if (service.UsuarioExiste(usuario))
                throw new Exception("Usuário já existe");

            // valida CPF / CNPJ
            if (!Validador.ValidarDocumento(documento))
                throw new Exception("Documento inválido");

            // cria usuário
            service.CriarUsuario(usuario, senha, email, documento);
        }

    }
}
