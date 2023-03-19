using System.Linq.Expressions;

namespace backend.Interfaces;

public interface IColumnSelector<TEntity> where TEntity : class
{
    Dictionary<string, Expression<Func<TEntity, object>>> ColumnSelector { get; }
}