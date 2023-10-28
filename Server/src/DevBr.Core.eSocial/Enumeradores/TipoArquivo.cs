namespace DevBr.Core.eSocial.Enumeradores
{
    public class TipoArquivo : TipoBase<TipoArquivo>
    {
        public static TipoArquivo Original = new TipoArquivo(1, "Original");
        public static TipoArquivo Retificacao = new TipoArquivo(2, "Retificação");
        public TipoArquivo(uint codigo, string descricao) : base(codigo, descricao)
        {
        }
    }
}
