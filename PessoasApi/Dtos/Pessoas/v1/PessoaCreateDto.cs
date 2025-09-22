using System.ComponentModel.DataAnnotations;

namespace PessoasApi.Dtos.v1
{
    public class PessoaCreateDtoV1
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = null!;

        public string? Sexo { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres numéricos")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números")]
        public string Cpf { get; set; } = null!;

        public string? Endereco { get; set; }
    }
}
