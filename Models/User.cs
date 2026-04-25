namespace Projeto.Models
{
    public class UserParticipar
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int PontoDoacaoId { get; set; }

        public string Tipo { get; set; } = "";
        // "dinheiro" ou "mantimento"

        public string Descricao { get; set; } = "";
        // Ex: "5kg arroz" ou "R$50"

        public DateTime DataParticipacao { get; set; }

        public DateTime PrazoEnvio { get; set; }

        public bool Enviado { get; set; }
    }
}