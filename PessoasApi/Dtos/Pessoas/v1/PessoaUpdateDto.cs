namespace PessoasApi.Dtos.v1
{
    public class PessoaUpdateDtoV1
    {
        public string Nome { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public string Cpf { get; set; } = null!;
        public string? Endereco { get; set; } 
    }
}
