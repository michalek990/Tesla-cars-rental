using backend.Entity;
using backend.Interfaces;
using backend.Pagination.Request;
using backend.Pagination.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;
    private IRepository<TEntity> _repository;

    protected Repository(AppDbContext context)
    {
        Context = context;
    }
    
    public async Task<Page<TEntity>> GetAllAsync(PageRequest<TEntity> pageRequest)
    {
        return await Paginate(Context.Set<TEntity>(), pageRequest);
    }

    protected async Task<Page<TEntity>> Paginate(IQueryable<TEntity> query, PageRequest<TEntity> pageRequest)
    {
        var totalElements = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((decimal)totalElements / pageRequest.PageSize);

        if (pageRequest.Sort is not null)
        {
            query = pageRequest.Sort.Direction == SortDirection.Asc
                ? query.OrderBy(pageRequest.Sort.SortBy)
                : query.OrderByDescending(pageRequest.Sort.SortBy);
        }

        var data = await query.Skip(pageRequest.PageSize * (pageRequest.PageNumber - 1))
            .Take(pageRequest.PageSize)
            .ToListAsync();
        
        return new Page<TEntity>
        {
            PageNumber = pageRequest.PageNumber,
            PageSize = pageRequest.PageSize,
            NextPage = pageRequest.PageNumber < totalPages ? pageRequest.PageNumber + 1 : null,
            PreviousPage = pageRequest.PageNumber > 1 ? pageRequest.PageNumber - 1 : null,
            FirstPage = 1,
            LastPage = totalPages,
            TotalPages = totalPages,
            TotalElements = totalElements,
            Sort = pageRequest.Sort is not null 
                ? new Sort{ SortBy = ExtractSortByName(pageRequest), Direction = pageRequest.Sort.Direction } 
                : null,
            Data = data
        };
    }
    
    private string? ExtractSortByName(PageRequest<TEntity> pageRequest)
    {
        if (pageRequest.Sort == null) return null;
        
        var body = pageRequest.Sort.SortBy.Body.ToString();
        var startIndex = body.IndexOf(".", StringComparison.Ordinal) + 1;
        var endIndex = body.IndexOf(",", StringComparison.Ordinal);
        var length = endIndex != -1 ? endIndex - startIndex : body.Length - startIndex;
        return body.Substring(startIndex, length);
    }
    
    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}