<div align="center">

<img width="220" src="https://cdn-icons-png.flaticon.com/512/744/744465.png" />

# 🚗 CleanDrive Architecture

### Plataforma empresarial de alquiler de vehículos con Clean Architecture y .NET 8 ⚡

<p align="center">
  <b>CleanDrive Architecture</b> es un sistema moderno de gestión de alquiler de vehículos desarrollado bajo los principios de Clean Architecture, enfocado en escalabilidad, mantenibilidad y arquitectura empresarial.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white">
  <img src="https://img.shields.io/badge/Clean_Architecture-DD0031?style=for-the-badge">
  <img src="https://img.shields.io/badge/PostgreSQL-Database-336791?style=for-the-badge&logo=postgresql&logoColor=white">
  <img src="https://img.shields.io/badge/Swagger-API_Docs-85EA2D?style=for-the-badge&logo=swagger&logoColor=black">
</p>

<p align="center">
  <a href="#-acerca-del-proyecto">Acerca</a> •
  <a href="#-características">Características</a> •
  <a href="#-tecnologías-utilizadas">Tecnologías</a> •
  <a href="#-instalación">Instalación</a> •
  <a href="#-vista-previa">Vista previa</a>
</p>

</div>

---

# 🚗 Acerca del proyecto

**CleanDrive Architecture** es una plataforma backend empresarial diseñada para la administración de alquiler de vehículos, reservas, usuarios y reseñas utilizando una arquitectura limpia y modular basada en principios SOLID y patrones empresariales modernos.

El sistema fue desarrollado para:

- 🚘 Gestionar vehículos y disponibilidad
- 📅 Administrar reservas de alquiler
- 👥 Gestionar usuarios del sistema
- ⭐ Administrar reseñas y calificaciones
- 💰 Calcular precios dinámicos
- 📊 Mantener control transaccional
- ⚡ Implementar arquitectura empresarial escalable

La aplicación demuestra buenas prácticas avanzadas de desarrollo backend utilizando .NET 8 y Clean Architecture.

---

# ✨ Características

## 🚘 Gestión de vehículos

- 🚗 Catálogo de vehículos
- 📅 Disponibilidad por fechas
- 📦 Gestión de accesorios
- ⚡ Control dinámico de reservas
- 📊 Estado de disponibilidad

---

## 📅 Sistema de alquileres

- 📝 Reservas de vehículos
- ⚡ Validaciones de negocio
- 🚫 Prevención de conflictos
- 📊 Gestión de estados
- 💰 Cálculo automático de costos

---

## 👥 Gestión de usuarios

- 👤 Administración de usuarios
- 📋 Gestión de perfiles
- 🔐 Seguridad y autenticación
- ⚡ Operaciones seguras
- 📊 Relación con alquileres

---

## ⭐ Sistema de reseñas

- 📝 Comentarios post-alquiler
- ⭐ Calificaciones de servicio
- 📊 Evaluaciones de experiencia
- 🚘 Opiniones de vehículos
- ⚡ Gestión de feedback

---

## 💰 Sistema de precios

- 💵 Precios dinámicos
- 📦 Cálculo con accesorios
- 📊 Tarifas automáticas
- ⚡ Reglas de negocio
- 🧾 Gestión financiera

---

## 📊 Arquitectura empresarial

- 🧱 Clean Architecture
- ⚡ CQRS con MediatR
- 🛡️ Repository Pattern
- 🔄 Unit of Work
- 📦 Specification Pattern

---

# 👨‍💻 Módulos del sistema

## 🚘 Vehicle Management Module

Sistema de administración de vehículos.

### Funcionalidades:

- 🚗 Gestión de vehículos
- 📅 Disponibilidad
- 📦 Accesorios
- 📊 Estados operativos
- ⚡ Control de inventario

---

## 📅 Rental Management Module

Gestión de alquileres y reservas.

### Funcionalidades:

- 📝 Reservaciones
- ⚡ Validaciones
- 📊 Gestión de estados
- 💰 Cálculo de precios
- 🚫 Prevención de conflictos

---

## 👥 User Management Module

Administración de usuarios.

### Funcionalidades:

- 👤 Gestión de perfiles
- 🔐 Seguridad
- 📋 Información de usuarios
- ⚡ Control administrativo

---

## ⭐ Review Management Module

Sistema de reseñas y comentarios.

### Funcionalidades:

- ⭐ Calificaciones
- 📝 Comentarios
- 📊 Feedback del servicio
- 🚘 Opiniones de vehículos

---

## 📊 Analytics & Business Module

Módulo analítico empresarial.

### Funcionalidades:

- 📈 Métricas operativas
- 📊 Tracking de alquileres
- 💰 Reportes financieros
- ⚡ Estadísticas del sistema

---

# 🛠️ Tecnologías utilizadas

## ⚙️ Backend

<p>
  <img src="https://skillicons.dev/icons?i=dotnet,cs" />
</p>

- .NET 8
- ASP.NET Core Web API
- Arquitectura modular
- APIs REST
- Principios SOLID

---

## ⚙️ Arquitectura y patrones

<p>
  <img src="https://skillicons.dev/icons?i=visualstudio" />
</p>

- Clean Architecture
- CQRS
- MediatR
- Repository Pattern
- Unit of Work
- Domain Events
- Specification Pattern

---

## 🗄️ Base de datos

<p>
  <img src="https://skillicons.dev/icons?i=postgresql" />
</p>

- PostgreSQL
- Entity Framework Core
- Dapper
- Migraciones
- Optimistic Concurrency
- Persistencia relacional

---

## 🔐 Seguridad y validaciones

<p>
  <img src="https://skillicons.dev/icons?i=swagger" />
</p>

- FluentValidation
- Middleware de excepciones
- Swagger/OpenAPI
- Validaciones automáticas
- Seguridad transaccional

---

## 🧰 Herramientas

<p>
  <img src="https://skillicons.dev/icons?i=git,github,vscode,visualstudio" />
</p>

- Git
- GitHub
- VS Code
- Visual Studio 2022
- Bogus Seeder

---

# 📂 Estructura del proyecto

```bash
src/PlataformaEmpresarialAlquilerVehiculos/
│
├── CleanArchitecture.Domain/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Events/
│   └── Interfaces/
│
├── CleanArchitecture.Application/
│   ├── Behaviors/
│   ├── Features/
│   ├── Commands/
│   ├── Queries/
│   └── Validators/
│
├── CleanArchitecture.Infrastructure/
│   ├── Persistence/
│   ├── Repositories/
│   ├── Services/
│   └── Configurations/
│
├── CleanArchitecture.Api/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Extensions/
│   └── appsettings.json
│
├── README.md
└── LICENSE
```

---

# 🏗️ Arquitectura del sistema

## ⚡ Arquitectura Clean Architecture

```text
API → Application → Domain ← Infrastructure
```

---

## 🔄 Flujo operativo

```text
Usuario → Reserva → Validación → Disponibilidad → Confirmación → Alquiler
```

---

# 📊 Funcionalidades principales

## 🚘 Vehículos

- Gestión de catálogo
- Disponibilidad dinámica
- Accesorios configurables
- Estados operativos

---

## 📅 Reservas

- Creación de alquileres
- Validaciones de negocio
- Prevención de conflictos
- Gestión de estados

---

## 💰 Precios

- Cálculo dinámico
- Tarifas automáticas
- Gestión de accesorios
- Reglas empresariales

---

## 📈 Administración

- CQRS empresarial
- Eventos de dominio
- Persistencia desacoplada
- Arquitectura escalable

---

# 🔐 Seguridad

## 🛡️ Protección del sistema

- 🔒 Validaciones automáticas
- ⚡ Middleware de excepciones
- 🛡️ Control transaccional
- 🚫 Prevención de inconsistencias
- 📋 Validaciones de negocio
- 🔐 Arquitectura desacoplada

---

# ⚡ Instalación

## 📋 Requisitos

- .NET 8 SDK
- PostgreSQL
- Visual Studio 2022 o VS Code
- Git

---

# 🚀 Configuración del proyecto

## 1️⃣ Clonar repositorio

```bash
git clone https://github.com/isairey/PlataformaEmpresarialAlquilerVehiculos
```

---

## 2️⃣ Entrar al proyecto

```bash
cd PlataformaEmpresarialAlquilerVehiculos
```

---

## 3️⃣ Configurar base de datos

Editar `appsettings.json`

```json
{
  "ConnectionStrings": {
    "Database": "Host=localhost;Port=5432;Database=cleanarchitecture;Username=your_user;Password=your_password;"
  }
}
```

---

## 4️⃣ Aplicar migraciones

```bash
cd src/CleanArchitecture/CleanArchitecture.Api
dotnet ef database update
```

---

## 5️⃣ Ejecutar aplicación

```bash
dotnet run
```

---

## 6️⃣ Abrir API

```bash
http://localhost:9000
```

---


# 👥 Roles del sistema

| Rol | Nivel |
|---|---|
| 👑 Admin | Acceso completo |
| 👨‍💼 Manager | Supervisión |
| 👤 User | Reservas y reseñas |
| 🚘 Operator | Gestión operativa |
| 📊 Analyst | Reportes y métricas |

---

# 🧠 Objetivos del proyecto

## 🎯 Arquitectura y aprendizaje

- Clean Architecture
- Desarrollo backend empresarial
- CQRS y MediatR
- Persistencia desacoplada
- Diseño modular
- Arquitectura escalable
- Buenas prácticas .NET

---

# 🚧 Roadmap

## 🔮 Próximas mejoras

- 📱 Aplicación móvil
- ☁️ Cloud deployment
- 🔔 Notificaciones en tiempo real
- 🤖 IA para recomendaciones
- 📊 Dashboard avanzado
- 🌐 Multi-language support
- 💳 Integración de pagos online

---

# 🤝 Contribuciones

Las contribuciones son bienvenidas ❤️

## Cómo contribuir

1. Fork del proyecto

```bash
git checkout -b feature/nueva-funcionalidad
```

2. Commit

```bash
git commit -m "✨ Nueva funcionalidad"
```

3. Push

```bash
git push origin feature/nueva-funcionalidad
```

4. Pull Request 🚀

---

# 👨‍💻 Desarrollador

<div align="center">

## Isai Reyes - Backend & Clean Architecture Developer

Desarrollador apasionado por arquitecturas empresariales, sistemas escalables y desarrollo backend moderno 🚀

</div>

---

# 🌟 Apoya el proyecto

⭐ Dale una estrella  
🍴 Haz fork  
📢 Comparte el proyecto

---

# 📜 Licencia

Proyecto open source orientado al aprendizaje de Clean Architecture, CQRS y desarrollo backend empresarial con .NET 8.

---

<div align="center">

### 🚗 CleanDrive Architecture — arquitectura limpia para sistemas de alquiler ⚡

</div>
