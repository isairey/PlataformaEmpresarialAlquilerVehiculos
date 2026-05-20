using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
{
    public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}