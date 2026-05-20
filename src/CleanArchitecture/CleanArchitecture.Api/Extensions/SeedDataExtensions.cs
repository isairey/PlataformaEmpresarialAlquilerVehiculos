using Bogus;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Vehiculos;
using Dapper;

namespace CleanArchitecture.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory =
            scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var existingVehiculos = connection.QuerySingle<int>(
            "SELECT COUNT(*) FROM public.vehiculos"
        );
        var existingUsers = connection.QuerySingle<int>("SELECT COUNT(*) FROM public.users");

        if (existingVehiculos > 0 || existingUsers > 0)
        {
            Console.WriteLine("Data already seeded. Skipping seed operation.");
            return;
        }

        var faker = new Faker("es");
        var vehiculos = new List<object>();
        var users = new List<object>();

        var usuarios = new[]
        {
            new
            {
                Nombre = "Carlos",
                Apellido = "Martínez",
                Email = "carlos.martinez@test.com",
            },
            new
            {
                Nombre = "Ana",
                Apellido = "García",
                Email = "ana.garcia@test.com",
            },
            new
            {
                Nombre = "Luis",
                Apellido = "Rodríguez",
                Email = "luis.rodriguez@test.com",
            },
            new
            {
                Nombre = "María",
                Apellido = "López",
                Email = "maria.lopez@test.com",
            },
            new
            {
                Nombre = "Pedro",
                Apellido = "Sánchez",
                Email = "pedro.sanchez@test.com",
            },
        };

        foreach (var usuario in usuarios)
        {
            users.Add(
                new
                {
                    Id = Guid.NewGuid(),
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Email,
                }
            );
        }

        var vehiculoFaker = new Faker();
        Randomizer.Seed = new Random();

        for (var i = 0; i < 50; i++)
        {
            vehiculos.Add(
                new
                {
                    Id = Guid.NewGuid(),
                    Vin = vehiculoFaker.Vehicle.Vin(),
                    Modelo = vehiculoFaker.Vehicle.Model(),
                    Pais = vehiculoFaker.Address.Country(),
                    Departamento = vehiculoFaker.Address.State(),
                    Provincia = vehiculoFaker.Address.County(),
                    Ciudad = vehiculoFaker.Address.City(),
                    Calle = vehiculoFaker.Address.StreetAddress(),
                    PrecioMonto = vehiculoFaker.Random.Decimal(50m, 500m),
                    PrecioTipoMoneda = "USD",
                    PrecioMantenimiento = vehiculoFaker.Random.Decimal(100m, 200m),
                    PrecioMantenimientoTipoMoneda = "USD",
                    FechaUltima = vehiculoFaker.Date.Past(2),
                    Accesorios = GenerateRandomAccessories(vehiculoFaker),
                }
            );
        }

        try
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using var transaction = connection.BeginTransaction();

            const string sqlUsers = """
                INSERT INTO public.users (id, nombre, apellido, email)
                VALUES (@Id, @Nombre, @Apellido, @Email);
                """;

            var usersInserted = connection.Execute(sqlUsers, users, transaction);
            Console.WriteLine($"Inserted {usersInserted} users");

            const string sqlVehiculos = """
                INSERT INTO public.vehiculos
                    (id, vin, modelo, direccion_pais, direccion_departamento, direccion_provincia, 
                     direccion_ciudad, direccion_calle, precio_monto, precio_tipo_moneda, 
                     mantenimiento_monto, mantenimiento_tipo_moneda, fecha_ultimo_alquiler, accesorios)
                VALUES
                    (@Id, @Vin, @Modelo, @Pais, @Departamento, @Provincia, @Ciudad, @Calle, 
                     @PrecioMonto, @PrecioTipoMoneda, @PrecioMantenimiento, @PrecioMantenimientoTipoMoneda, 
                     @FechaUltima, @Accesorios);
                """;

            var vehiculosInserted = connection.Execute(sqlVehiculos, vehiculos, transaction);
            Console.WriteLine($"Inserted {vehiculosInserted} vehiculos");

            transaction.Commit();
            Console.WriteLine("Seed data completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error seeding data: {ex.Message}");
            throw;
        }
    }

    private static int[] GenerateRandomAccessories(Faker faker)
    {
        var availableAccessories = new[]
        {
            (int)Accesorio.Wifi,
            (int)Accesorio.AppleCar,
            (int)Accesorio.AndroidCar,
        };

        var count = faker.Random.Int(1, Math.Min(3, availableAccessories.Length));
        return faker.Random.Shuffle(availableAccessories).Take(count).ToArray();
    }
}
