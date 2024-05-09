using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Repositories
{
    public interface IContaRepository
    {
        int Add(Conta conta);
        void Update(Conta conta);
        void Delete(Conta conta);
        Conta? GetById(int id);
    }
}
