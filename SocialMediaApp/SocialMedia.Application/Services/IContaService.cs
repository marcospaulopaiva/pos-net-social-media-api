using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Contas;
using static SocialMedia.Application.Models.Contas.ContaDetailsViewModel;

namespace SocialMedia.Application.Services
{
    public interface IContaService
    {
        ResultViewModel<int> Insert(CreateContaInputModel model);
        ResultViewModel Update(int id, UpdateContaInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<ContaViewModel?> GetById(int id);
        ResultViewModel<ContaViewModel?> GetByEmail(string email);
        public ResultViewModel MudarSenha(string email, UpdateSenhaContaInputModel model);
    }
}
