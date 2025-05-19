using System.Runtime.CompilerServices;

namespace JobTracking.Application.Implementation;

public class SingerService : IsingerService
{
    protected DependencyProvider Provider { get; set; }

    public SingerService(DependencyProvider provider)
    {
        Provider = provider;
    }

    public Task<IQueryable<Singer>> GetAllSingers(int page, int pageCount)
    {
        var query = Provider.Db.Singers
            .Skip(page - 1 * pageCount)
            .Take(PageCount);
        
        query = query.Where(s =? s.Name == "preslava");

        var result = query.toList();
        
        
    }
}