using SocialMedia.Application.Models;
using SocialMedia.Application.Models.Feeds;
using SocialMedia.Core.Repositories;

namespace SocialMedia.Application.Services.Feeds
{
    public class FeedService : IFeedService
    {
        private readonly IConexaoRepository _conexaoRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public FeedService(IConexaoRepository conexaoRepository, IPerfilRepository perfilRepository, IPublicacaoRepository publicacaoRepository)
        {
            _conexaoRepository = conexaoRepository;
            _perfilRepository = perfilRepository;
            _publicacaoRepository = publicacaoRepository;
        }

        public ResultViewModel<List<FeedViewModel>> GetAll(int idPerfil)
        {
            List<FeedViewModel> listaFeedViewModel = [];
            
            var listaConexoes = _conexaoRepository.GetAll(idPerfil);

            foreach (var conexao in listaConexoes)
            {
                var perfil = _perfilRepository.GetById(conexao.IdPerfilSeguido);

                var listaPublicacoes = _publicacaoRepository.GetAll(conexao.IdPerfilSeguido);

                foreach (var publicacao in listaPublicacoes)
                {
                    listaFeedViewModel.Add(FeedViewModel.FromEntitys(perfil, publicacao));
                }

            }

            return ResultViewModel<List<FeedViewModel>>.Success(listaFeedViewModel.OrderByDescending(p => p.DataPublicacao).ToList());
        }
    }
}
