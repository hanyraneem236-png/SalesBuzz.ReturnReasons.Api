using Microsoft.EntityFrameworkCore;
using SalesBuzz.ReturnReasons.Api.Models;
using SalesBuzz.Shared.Data;

namespace SalesBuzz.ReturnReasons.Api.Data;

public class ReturnReasonsDbContext : SalesBuzzDbContextBase
{
    public ReturnReasonsDbContext(
        DbContextOptions<ReturnReasonsDbContext> options,
        ICurrentBUContext current)
        : base(options, current)
    {
    }

    public DbSet<ReturnReason> ReturnReasons { get; set; }
}