using Microsoft.EntityFrameworkCore;

namespace DevBr.Escola.Infra.Data.Context.Sequences
{
    internal static class SequenciaContext
    {
        internal static ModelBuilder ConfigureSequencia(this ModelBuilder builder)
        {
            builder.HasSequence<ulong>("SeqAluno", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqDoenca", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqFichaMedica", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqHospital", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqMedicacao", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqMedico", "dbo").StartsAt(1).IncrementsBy(1);

            builder.HasSequence<ulong>("SeqCurso", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqDisciplina", "dbo").StartsAt(1).IncrementsBy(1);

            builder.HasSequence<ulong>("SeqEmpresa", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqRecurso", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqSala", "dbo").StartsAt(1).IncrementsBy(1);

            builder.HasSequence<ulong>("SeqFuncionario", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqCargo", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqAtividade", "dbo").StartsAt(1).IncrementsBy(1);

            builder.HasSequence<ulong>("SeqMatricula", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqPeriodo", "dbo").StartsAt(1).IncrementsBy(1);
            builder.HasSequence<ulong>("SeqTurma", "dbo").StartsAt(1).IncrementsBy(1);
            return builder;
        }
    }
}
