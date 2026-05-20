using System.Data;

namespace CleanArchitecture.Application.Abstractions;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();

}