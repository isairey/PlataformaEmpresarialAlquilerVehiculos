using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerCommandHandler
    : ICommandHandler<ReservarAlquilerCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly PrecioService _precioService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReservarAlquilerCommandHandler(
        IUserRepository userRepository,
        IVehiculoRepository vehiculoRepository,
        IAlquilerRepository alquilerRepository,
        PrecioService precioService,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    )
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _precioService = precioService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(
        ReservarAlquilerCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var vehiculo = await _vehiculoRepository.GetByIdAsync(
            request.VehiculoId,
            cancellationToken
        );

        if (vehiculo is null)
        {
            return Result.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);
        var isOverlapping = await _alquilerRepository.IsOverlappingAsync(
            vehiculo,
            duracion,
            cancellationToken
        );

        if (isOverlapping)
        {
            return Result.Failure<Guid>(AlquilerErrors.Overlap);
        }

        try
        {
            var alquiler = Alquiler.Reservar(
                vehiculo,
                user.Id,
                duracion,
                _dateTimeProvider.CurrentTime,
                _precioService
            );

            _alquilerRepository.Add(alquiler);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return alquiler.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(AlquilerErrors.Overlap);
        }
    }
}
