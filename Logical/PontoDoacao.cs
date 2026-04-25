using Projeto.Data;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Logical
{
    public partial class CriarPonto
    {

        public class PontoDoacaoApplicationService
        {
            private readonly PontoDoacaoService _service = new PontoDoacaoService();

            public ResultadoOperacao CriarPonto(string rua, string numero, string cep, string itens, string quantidades)
            {
                if (string.IsNullOrWhiteSpace(rua))
                    return ResultadoOperacao.Falha("Preencha a rua!");

                var ponto = new PontoDoacao
                {
                    Rua = rua.Trim(),
                    Numero = numero?.Trim(),
                    CEP = cep?.Trim(),
                    Itens = itens?.Trim(),
                    Quantidades = quantidades?.Trim()
                };

                _service.CriarPontoDoacao(ponto);

                return ResultadoOperacao.Sucesso("Ponto criado com sucesso!");
            }
        }

        public record ResultadoOperacao(bool Ok, string Mensagem)
        {
            public static ResultadoOperacao Sucesso(string msg) => new(true, msg);
            public static ResultadoOperacao Falha(string msg) => new(false, msg);
        }

    }
}
