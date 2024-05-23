namespace SocialMedia.Core.Entities
{
    public class Conexao : BaseEntity
    {
        public Conexao(int idSeguidor, int idSeguido, DateTime dataConexao)
            : base()
        {
            IdSeguidor = idSeguidor;
            IdSeguido = idSeguido;
            DataConexao = dataConexao;
        }

        public int IdSeguidor { get; private set; }
        public Conta? Seguidor { get; private set; }

        public int IdSeguido { get; private set; }
        public Conta? Seguindo { get; private set; }

        public DateTime DataConexao { get; private set; }
    }
}
