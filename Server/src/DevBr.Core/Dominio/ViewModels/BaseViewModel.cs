using System;
using System.Collections.Generic;

namespace DevBr.Core.Dominio.ViewModels
{
    public abstract class BaseViewModel
    {
        public IEnumerable<string> Inconsistencias { get; set; }

        public virtual void AtualizeContexto(object context)
        {
            throw new NotImplementedException();
        }
    }
}
