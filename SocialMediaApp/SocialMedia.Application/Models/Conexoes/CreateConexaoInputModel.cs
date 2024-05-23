namespace SocialMedia.Application.Models.Conexoes
{
    public class CreateConexaoInputModel
    {
        public int IdSeguidor { get; set; }

        public int IdSeguido { get; set; }

        public DateTime DataConexao { get; set; }
    }
}
