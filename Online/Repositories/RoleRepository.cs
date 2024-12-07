using Online.Context;
using Online.Contracts;
using Online.Entities;

namespace Online.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly DapperContext _context;

    public RoleRepository(DapperContext context) : base(context)
    {
        _context = context;
    }
}