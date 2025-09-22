using System.ComponentModel.DataAnnotations;

namespace PessoasApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        public string? Sexo { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ter 11 dígitos numéricos")]
        public string Cpf { get; set; } = string.Empty;

        public string? Endereco { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
    }
}