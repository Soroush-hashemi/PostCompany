using Common.Query;
using Query.Driver.DTO;

namespace Query.Driver.GetList;
public record GetDriverListQuery : IQuery<List<DriverDto>>;