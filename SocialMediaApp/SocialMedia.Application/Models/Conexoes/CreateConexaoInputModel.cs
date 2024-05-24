namespace SocialMedia.Application.Models.Conexoes
{
    public class CreateConexaoInputModel
    {
        public int IdPerfil { get; set; }

        public int IdPerfilSeguido { get; set; }

        public DateTime DataConexao { get; set; }
    }
}
