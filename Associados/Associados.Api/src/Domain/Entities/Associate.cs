using Associados.Api.src.Domain.Base;

namespace Associados.Api.src.Domain.Entities
{
    public class Associate : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}