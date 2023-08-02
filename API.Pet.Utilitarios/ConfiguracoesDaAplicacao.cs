
namespace API.PET.Utilitarios
{
    public static class ConfiguracoesDaAplicacao
    {
        public static string ObterStringDeConexaoMongoDB()
        {
            Configuracao configuracao = new Configuracao();
            return configuracao.ConfiguracaoDoArquivoAppSettings["ConnectionStringMongoDB"];

        }

        public static string ObterStringDeConexaoRedis()
        {
            Configuracao configuracao = new Configuracao();
            return configuracao.ConfiguracaoDoArquivoAppSettings["ConexaoRedis"];

        }

    }
}
