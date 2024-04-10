using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.User;
using Query.User.DTO;

namespace Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly PostCompanyContext _context;

    public GetUserByPhoneNumberQueryHandler(PostCompanyContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber.Value == request.PhoneNumber, cancellationToken);

        if (user == null)
            return null;

        return user.Map();
    }
}