FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files in the correct order
COPY ["src/CleanArchitecture/CleanArchitecture.Domain/CleanArchitecture.Domain.csproj", "src/CleanArchitecture/CleanArchitecture.Domain/"]
COPY ["src/CleanArchitecture/CleanArchitecture.Application/CleanArchitecture.Application.csproj", "src/CleanArchitecture/CleanArchitecture.Application/"]
COPY ["src/CleanArchitecture/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj", "src/CleanArchitecture/CleanArchitecture.Infrastructure/"]
COPY ["src/CleanArchitecture/CleanArchitecture.Api/CleanArchitecture.Api.csproj", "src/CleanArchitecture/CleanArchitecture.Api/"]

# Restore packages
RUN dotnet restore "src/CleanArchitecture/CleanArchitecture.Api/CleanArchitecture.Api.csproj"

# Copy all source code
COPY . .

# Build
WORKDIR "/src/src/CleanArchitecture/CleanArchitecture.Api"
RUN dotnet build "CleanArchitecture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Api.dll"]