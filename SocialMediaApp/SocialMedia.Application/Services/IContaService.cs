using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Contas;
using SocialMedia.Core.Entities;

namespace SocialMedia.Application.Services
{
    public interface IContaService
    {
        ResultViewModel<int> Insert(CreateContaInputModel model);
        ResultViewModel Update(int id, UpdateContaInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<Conta?> GetById(int id);
    }
}
