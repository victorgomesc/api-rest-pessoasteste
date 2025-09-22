using PessoasApi.Dtos.v1;
using PessoasApi.Dtos.v2;

namespace PessoasApi.Services
{
    public interface IPessoaService
    {
        // V1
        Task<PessoaResponseDtoV1?> ObterPorIdV1Async(int id);
        Task<PessoaResponseDtoV1?> ObterPorNomeV1Async(string nome);
        Task<PessoaResponseDtoV1?> ObterPorCpfV1Async(string cpf);
        Task<IEnumerable<PessoaResponseDtoV1>> ObterTodosV1Async();
        Task<PessoaResponseDtoV1> CriarV1Async(PessoaCreateDtoV1 dto);
        Task<PessoaResponseDtoV1?> AtualizarV1Async(int id, PessoaUpdateDtoV1 dto);

        // V2
        Task<PessoaResponseDtoV2?> ObterPorIdV2Async(int id);
        Task<IEnumerable<PessoaResponseDtoV2>> ObterTodosV2Async();
        Task<PessoaResponseDtoV2?> ObterPorNomeV2Async(string nome);
        Task<PessoaResponseDtoV2?> ObterPorCpfV2Async(string cpf);
        Task<PessoaResponseDtoV2> CriarV2Async(PessoaCreateDtoV2 dto);
        Task<PessoaResponseDtoV2?> AtualizarV2Async(int id, PessoaUpdateDtoV2 dto);

        // Compartilhado
        Task<bool> DeletarAsync(int id);
    }
}