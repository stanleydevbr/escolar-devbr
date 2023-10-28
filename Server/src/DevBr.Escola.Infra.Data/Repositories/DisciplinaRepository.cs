﻿using DevBr.Escola.Dominio.Entidades.Cursos;
using DevBr.Escola.Dominio.Interfaces.Repositories.Cursos;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Escola.Infra.Data.Repositories.Base;

namespace DevBr.Escola.Infra.Data.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EscolaContext context) : base(context)
        {

        }
    }
}
