using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Application.Alquileres.GetAlquiler;

internal sealed class GetAlquilerQueryHandler : IQueryHandler<GetAlquilerQuery, AlquilerResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAlquilerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<AlquilerResponse>> Handle(
        GetAlquilerQuery request,
        CancellationToken cancellationToken
    )
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
                SELECT
                    id AS Id,
                    user_id AS UserId,
                    vehiculo_id AS VehiculoId,
                    status AS Status,
                    precio_por_periodo_monto AS PrecioAlquiler,
                    precio_por_periodo_tipo_moneda AS TipoMonedaAlquiler,
                    mantenimiento_monto AS PrecioMantenimiento,
                    mantenimiento_tipo_moneda AS TipoMonedaMantenimiento,
                    accesorios_monto AS AccesoriosPrecio,
                    accesorios_tipo_moneda AS TipoMonedaAccesorio,
                    precio_total_monto AS PrecioTotal,
                    precio_total_tipo_moneda AS PrecioTotalTipoMoneda,
                    duracion_inicio AS DuracionInicio,
                    duracion_fin AS DuracionFinal,
                    fecha_creacion AS FechaCreacion
                FROM alquileres 
                WHERE id = @AlquilerId
            """;

        var alquiler = await connection.QueryFirstOrDefaultAsync<AlquilerResponse>(
            sql,
            new { request.AlquilerId }
        );

        return alquiler!;
    }
}
