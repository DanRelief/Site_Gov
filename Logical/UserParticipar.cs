namespace Projeto.Logical
{
    using Projeto.Models;

    public class UserParticiparService
    {
        public UserParticipar CriarParticipacao(int userId, int pontoId, string tipo, string descricao, DateTime dataEvento)
        {
            DateTime agora = DateTime.Now;
            DateTime prazo;

            if (tipo == "dinheiro")
            {
                prazo = agora.AddHours(24);
            }
            else // mantimento
            {
                prazo = dataEvento.AddHours(-24);
            }

            return new UserParticipar
            {
                UserId = userId,
                PontoDoacaoId = pontoId,
                Tipo = tipo,
                Descricao = descricao,
                DataParticipacao = agora,
                PrazoEnvio = prazo,
                Enviado = false
            };
        }
    }
}