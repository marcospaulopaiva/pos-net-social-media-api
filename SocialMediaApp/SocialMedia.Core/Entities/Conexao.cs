namespace SocialMedia.Core.Entities
{
    public class Conexao : BaseEntity
    {
        public Conexao(int idPerfil, int idPerfilSeguido, DateTime dataConexao)
            : base()
        {
            IdPerfil = idPerfil;
            IdPerfilSeguido = idPerfilSeguido;
            DataConexao = dataConexao;
        }

        public int IdPerfil { get; private set; }
        public Perfil Perfil { get; private set; }

        public int IdPerfilSeguido { get; private set; }

        public DateTime DataConexao { get; private set; }
    }
}
