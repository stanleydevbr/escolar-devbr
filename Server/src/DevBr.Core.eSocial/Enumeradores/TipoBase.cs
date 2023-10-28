namespace DevBr.Core.eSocial.Enumeradores
{
    public abstract class TipoBase<T> where T : class
    {
        public uint Codigo { get; set; }
        public string? Descricao { get; set; }
        public TipoBase(uint codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Descricao}";
        }
    }
    public abstract class TipoBase<T, TKeyType> where T : TipoBase<T, TKeyType>
    {
        public TKeyType Codigo { get; set; }
        public string? Descricao { get; set; }
        public TipoBase(TKeyType codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Descricao}";
        }
    }
}
