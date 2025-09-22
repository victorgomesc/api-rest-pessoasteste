namespace PessoasApi.Dtos.v1
{
    public class PessoaResponseDtoV1
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public string Cpf { get; set; } = null!;
        public string? Endereco { get; set; } 
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
