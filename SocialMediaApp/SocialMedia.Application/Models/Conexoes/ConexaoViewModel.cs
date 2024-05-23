using SocialMedia.Core.Entities;

namespace SocialMedia.Application.Models.Conexoes
{
    public class ConexaoViewModel
    {
        public ConexaoViewModel(int id, int idSeguidor, int idSeguido, DateTime dataConexao)
        {
            Id = id;
            IdSeguidor = idSeguidor;
            IdSeguido = idSeguido;
            DataConexao = dataConexao;
        }

        public int Id { get; set; }

        public int IdSeguidor { get;  set; }

        public int IdSeguido { get;  set; }

        public DateTime DataConexao { get;  set; }

        public static ConexaoViewModel? FromEntity(Conexao entity)
            => new(
                entity.Id,
                entity.IdSeguidor,
                entity.IdSeguido,
                entity.DataConexao
                );
    }
}
