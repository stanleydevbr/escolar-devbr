using System.Collections.Generic;

namespace DevBr.Core.Dominio.Entidades
{
    public class ResultList<TEntity>
    {
        public int? TotalRegistro { get; set; }
        public ICollection<TEntity> Dados { get; set; }
    }
}
