using Microsoft.Extensions.Configuration;

namespace API.PET.Utilitarios
{
    internal class Configuracao
    {
        private readonly IConfiguration configuracaoDoArquivoAppSettings;

        public IConfiguration ConfiguracaoDoArquivoAppSettings
        {
            get { return this.configuracaoDoArquivoAppSettings; }
        }

        internal Configuracao()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(env))
                throw new ArgumentNullException("A variável de ambiente ASPNETCORE_ENVIRONMENT não está configurada");

            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: false).AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false).AddEnvironmentVariables();
                this.configuracaoDoArquivoAppSettings = builder.Build();
            }
            catch (FormatException e)
            {
                throw new FormatException("Arquivos de configuração não configurados corretamente! Verifique o formato do arquivo .json", e);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar arquivos de configuração", e);
            }
        }
    }
}
