using DevBr.Core.Mongo.Documents;
using System.Linq.Expressions;

namespace DevBr.Core.Mongo.Repositories
{
    public interface IRepositoryCore<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> FiltrarPor(
            Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TProjected> FiltrarPor<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        TDocument ObterDocumento(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> ObterDocumentoAsync(Expression<Func<TDocument, bool>> filterExpression);

        TDocument ObterPorId(string id);

        Task<TDocument> ObterPorIdAsync(string id);

        void Adicionar(TDocument document);

        Task AdicionarAsync(TDocument document);

        void Adicionar(ICollection<TDocument> documents);

        Task AdicionarAsync(ICollection<TDocument> documents);

        void Atualizar(TDocument document);

        Task AtualizarAsync(TDocument document);

        void Excluir(Expression<Func<TDocument, bool>> filterExpression);

        Task ExcluirAsync(Expression<Func<TDocument, bool>> filterExpression);

        void ExcluirPorId(string id);

        Task ExcluirPorIdAsync(string id);

        void ExcluirVarios(Expression<Func<TDocument, bool>> filterExpression);

        Task ExcluirVariosAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}
