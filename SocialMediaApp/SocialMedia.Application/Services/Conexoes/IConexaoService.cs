using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Conexoes;
using static SocialMedia.Application.Models.Contas.ContaDetailsViewModel;

namespace SocialMedia.Application.Services.Conexoes
{
    public interface IConexaoService
    {
        ResultViewModel<int> Insert(CreateConexaoInputModel model);

        ResultViewModel<ConexaoViewModel?> GetById(int id);

        ResultViewModel Delete(int id);
    }
}
