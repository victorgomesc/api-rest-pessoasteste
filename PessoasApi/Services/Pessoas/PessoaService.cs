using PessoasApi.Dtos.v1;
using PessoasApi.Dtos.v2;
using PessoasApi.Models;
using PessoasApi.Repositories;

namespace PessoasApi.Services
{
    public class PessoaService(IPessoaRepository repository) : IPessoaService
    {
        private readonly IPessoaRepository _repository = repository;

        public async Task<PessoaResponseDtoV1?> ObterPorIdV1Async(int id)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);
            return pessoa is null ? null : MapToV1(pessoa);
        }

        public async Task<IEnumerable<PessoaResponseDtoV1>> ObterTodosV1Async()
        {
            var pessoas = await _repository.ObterTodosAsync();
            return pessoas.Select(MapToV1);
        }

        public async Task<PessoaResponseDtoV1?> ObterPorNomeV1Async(string nome)
        {
            var pessoas = await _repository.ObterPorNomeAsync(nome);
            var pessoa = pessoas.FirstOrDefault();
            return pessoa is null ? null : MapToV1(pessoa);
        }

        public async Task<PessoaResponseDtoV1?> ObterPorCpfV1Async(string cpf)
        {
            var pessoa = await _repository.ObterPorCpfAsync(cpf);
            return pessoa is null ? null : MapToV1(pessoa);
        }

        public async Task<PessoaResponseDtoV1> CriarV1Async(PessoaCreateDtoV1 dto)
        {
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Sexo = dto.Sexo,
                Email = dto.Email,
                DataNascimento = dto.DataNascimento,
                Naturalidade = dto.Naturalidade,
                Nacionalidade = dto.Nacionalidade,
                Cpf = dto.Cpf,
                Endereco = dto.Endereco,
                DataCadastro = DateTime.UtcNow
            };

            var novaPessoa = await _repository.CriarAsync(pessoa);
            return MapToV1(novaPessoa);
        }

        public async Task<PessoaResponseDtoV1?> AtualizarV1Async(int id, PessoaUpdateDtoV1 dto)
        {
            var pessoa = new Pessoa
            {
                Id = id,
                Nome = dto.Nome,
                Sexo = dto.Sexo,
                Email = dto.Email,
                DataNascimento = dto.DataNascimento,
                Naturalidade = dto.Naturalidade,
                Nacionalidade = dto.Nacionalidade,
                Cpf = dto.Cpf,
                Endereco = dto.Endereco,
                DataAtualizacao = DateTime.UtcNow
            };

            var atualizada = await _repository.AtualizarAsync(pessoa);
            return atualizada is null ? null : MapToV1(atualizada);
        }

        public async Task<PessoaResponseDtoV2?> ObterPorIdV2Async(int id)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);
            return pessoa is null ? null : MapToV2(pessoa);
        }

        public async Task<IEnumerable<PessoaResponseDtoV2>> ObterTodosV2Async()
        {
            var pessoas = await _repository.ObterTodosAsync();
            return pessoas.Select(MapToV2);
        }

        public async Task<PessoaResponseDtoV2?> ObterPorNomeV2Async(string nome)
        {
            var pessoas = await _repository.ObterPorNomeAsync(nome);
            var pessoa = pessoas.FirstOrDefault();
            return pessoa is null ? null : MapToV2(pessoa);
        }

        public async Task<PessoaResponseDtoV2?> ObterPorCpfV2Async(string cpf)
        {
            var pessoa = await _repository.ObterPorCpfAsync(cpf);
            return pessoa is null ? null : MapToV2(pessoa);
        }

        public async Task<PessoaResponseDtoV2> CriarV2Async(PessoaCreateDtoV2 dto)
        {
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Sexo = dto.Sexo,
                Email = dto.Email,
                DataNascimento = dto.DataNascimento,
                Naturalidade = dto.Naturalidade,
                Nacionalidade = dto.Nacionalidade,
                Cpf = dto.Cpf,
                Endereco = dto.Endereco,
                DataCadastro = DateTime.UtcNow
            };

            var novaPessoa = await _repository.CriarAsync(pessoa);
            return MapToV2(novaPessoa);
        }

        public async Task<PessoaResponseDtoV2?> AtualizarV2Async(int id, PessoaUpdateDtoV2 dto)
        {
            var pessoa = new Pessoa
            {
                Id = id,
                Nome = dto.Nome,
                Sexo = dto.Sexo,
                Email = dto.Email,
                DataNascimento = dto.DataNascimento,
                Naturalidade = dto.Naturalidade,
                Nacionalidade = dto.Nacionalidade,
                Cpf = dto.Cpf,
                Endereco = dto.Endereco,
                DataAtualizacao = DateTime.UtcNow
            };

            var atualizada = await _repository.AtualizarAsync(pessoa);
            return atualizada is null ? null : MapToV2(atualizada);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _repository.DeletarAsync(id);
        }

        private static PessoaResponseDtoV1 MapToV1(Pessoa p) => new()
        {
            Id = p.Id,
            Nome = p.Nome,
            Sexo = p.Sexo,
            Email = p.Email,
            DataNascimento = p.DataNascimento,
            Naturalidade = p.Naturalidade,
            Nacionalidade = p.Nacionalidade,
            Cpf = p.Cpf,
            Endereco = p.Endereco,
            DataCadastro = p.DataCadastro,
            DataAtualizacao = p.DataAtualizacao
        };

        private static PessoaResponseDtoV2 MapToV2(Pessoa p) => new()
        {
            Id = p.Id,
            Nome = p.Nome,
            Sexo = p.Sexo,
            Email = p.Email,
            DataNascimento = p.DataNascimento,
            Naturalidade = p.Naturalidade,
            Nacionalidade = p.Nacionalidade,
            Cpf = p.Cpf,
            Endereco = p.Endereco!,
            DataCadastro = p.DataCadastro,
            DataAtualizacao = p.DataAtualizacao
        };
    }
}
