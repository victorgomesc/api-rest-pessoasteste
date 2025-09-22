namespace PessoasApi.Dtos.v2
{
    public class PessoaResponseDtoV2
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public string Cpf { get; set; } = null!;
        public string Endereco { get; set; } = null!; 
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
