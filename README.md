# Clean Architecture - Sistema de Alquiler de Vehículos

## 📋 Descripción

Sistema de alquiler de vehículos desarrollado con .NET 8 siguiendo los principios de Clean Architecture. La aplicación permite gestionar la reserva de vehículos, usuarios, y reseñas con un diseño modular y escalable.

## 🏗️ Arquitectura

El proyecto está estructurado siguiendo los principios de Clean Architecture con las siguientes capas:

```
src/CleanArchitecture/
├── CleanArchitecture.Domain/          # Entidades de dominio y lógica de negocio
├── CleanArchitecture.Application/     # Casos de uso y lógica de aplicación
├── CleanArchitecture.Infrastructure/  # Implementaciones de persistencia y servicios externos
└── CleanArchitecture.Api/            # Capa de presentación (Web API)
```

### Capas de la Arquitectura

- **Domain**: Contiene las entidades principales (Alquiler, Vehículo, Usuario, Review), value objects, eventos de dominio y interfaces de repositorios.
- **Application**: Implementa casos de uso utilizando CQRS con MediatR, validaciones con FluentValidation, y manejo de comportamientos transversales.
- **Infrastructure**: Implementa la persistencia con Entity Framework Core, configuraciones de base de datos, y servicios externos.
- **Api**: Expone endpoints REST, manejo de excepciones, y configuración de la aplicación.

## 🛠️ Tecnologías Utilizadas

- **.NET 8**
- **Entity Framework Core 7.0.11** con PostgreSQL
- **MediatR** para implementar CQRS
- **FluentValidation** para validaciones
- **Dapper** para consultas de solo lectura
- **Bogus** para generación de datos de prueba
- **Swagger/OpenAPI** para documentación de la API

## 🚀 Características Principales

### Funcionalidades del Sistema

- **Gestión de Vehículos**: Búsqueda de vehículos disponibles por fechas
- **Reservas de Alquiler**: Creación y gestión de reservas con validaciones de negocio
- **Gestión de Usuarios**: Manejo de información de usuarios
- **Sistema de Reseñas**: Calificaciones y comentarios post-alquiler
- **Cálculo de Precios**: Sistema dinámico de precios con accesorios

### Patrones Implementados

- **CQRS** (Command Query Responsibility Segregation)
- **Domain Events** para comunicación entre agregados
- **Repository Pattern** para abstracción de datos
- **Unit of Work** para transacciones
- **Specification Pattern** para consultas complejas

## 📦 Instalación y Configuración

### Prerrequisitos

- .NET 8 SDK
- PostgreSQL
- Visual Studio 2022 o VS Code

### Configuración

1. **Clonar el repositorio**

```bash
git clone <repository-url>
cd CleanArchitecture
```

2. **Configurar la base de datos**

Actualizar la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Database": "Host=localhost;Port=5432;Database=cleanarchitecture;Username=your_user;Password=your_password;"
  }
}
```

3. **Aplicar migraciones**

```bash
cd src/CleanArchitecture/CleanArchitecture.Api
dotnet ef database update
```

4. **Ejecutar la aplicación**

```bash
dotnet run
```

La aplicación estará disponible en `http://localhost:9000`

## 🔧 Estructura del Proyecto

### Domain Layer

**Entidades Principales:**

- `Alquiler`: Gestiona las reservas de vehículos
- `Vehiculo`: Información de vehículos y disponibilidad
- `User`: Datos de usuarios del sistema
- `Review`: Reseñas y calificaciones

**Value Objects:**

- `DateRange`: Manejo de períodos de tiempo
- `Moneda`: Representación de valores monetarios
- `Direccion`: Información de ubicación

### Application Layer

**Casos de Uso:**

- `ReservarAlquiler`: Proceso completo de reserva
- `GetAlquiler`: Consulta de información de alquileres
- `SearchVehiculos`: Búsqueda de vehículos disponibles

**Comportamientos Transversales:**

- `LoggingBehavior`: Registro de actividades
- `ValidationBehavior`: Validaciones automáticas

### Infrastructure Layer

**Persistencia:**

- Configuraciones de Entity Framework
- Repositorios concretos
- Migraciones de base de datos

**Servicios:**

- `EmailService`: Notificaciones (implementación mock)
- `DateTimeProvider`: Abstracción de tiempo
- `SqlConnectionFactory`: Conexiones para Dapper

## 📊 Base de Datos

### Tablas Principales

- **users**: Información de usuarios
- **vehiculos**: Catálogo de vehículos disponibles
- **alquileres**: Registros de reservas y alquileres
- **reviews**: Reseñas y calificaciones

### Características de la BD

- Uso de snake_case para nomenclatura
- Optimistic concurrency control
- Índices para consultas frecuentes
- Soporte para arrays (accesorios del vehículo)

## 🌐 API Endpoints

### Alquileres

- `GET /api/alquileres/{id}` - Obtener alquiler por ID
- `POST /api/alquileres` - Crear nueva reserva

### Vehículos

- `GET /api/vehiculos` - Buscar vehículos disponibles
  - Query parameters: `startDate`, `endDate`

## 🧪 Datos de Prueba

La aplicación incluye un seeder que genera automáticamente 100 vehículos de prueba con datos realistas usando la librería Bogus.

## 🔒 Validaciones y Reglas de Negocio

- Validación de fechas de reserva (inicio < fin)
- Verificación de disponibilidad de vehículos
- Cálculo automático de precios con accesorios
- Manejo de estados de alquiler (Reservado, Confirmado, Completado, etc.)
- Control de concurrencia para evitar dobles reservas

## 🚦 Manejo de Errores

- Middleware personalizado para excepciones
- Validaciones con FluentValidation
