using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Driver.DTO;

namespace Query.Driver.GetList;
public class GetDriverListQueryHandler : IQueryHandler<GetDriverListQuery, List<DriverDto>>
{
    private readonly PostCompanyContext _context;
    public GetDriverListQueryHandler(PostCompanyContext context)
    {
        _context = context;
    }

    public async Task<List<DriverDto>> Handle(GetDriverListQuery request, CancellationToken cancellationToken)
    {
        var Drivers = await _context.Drivers.ToListAsync(cancellationToken);

        return Drivers.MapList();
    }
}