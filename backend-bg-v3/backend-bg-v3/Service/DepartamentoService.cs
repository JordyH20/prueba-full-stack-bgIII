using backend_bg_v3.Data;
using backend_bg_v3.Dto.Request;
using backend_bg_v3.Models;
using Dapper;

namespace backend_bg_v3.Service
{
    public class DepartamentoService
    {
        private readonly DataDapper _dataDapper;

        public DepartamentoService(DataDapper context)
        {
            _dataDapper = context;
        }


        // LISTAR TODOS
        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync()
        {
            const string sql = @"
                SELECT
                    DepartamentoId,
                    Nombre,
                    ResponsableId,
                    Estado
                FROM Departamento;
            ";

            using var connection = _dataDapper.CreateConnection();

            return await connection.QueryAsync<Departamento>(sql);
        }

        // BUSCAR POR ID
        public async Task<Departamento?> GetByIdDepartamentoAsync(int id)
        {
            const string sql = @"
                SELECT
                    DepartamentoId,
                    Nombre,
                    ResponsableId,
                    Estado
                FROM Departamento
                WHERE DepartamentoId = @Id;
            ";

            using var connection = _dataDapper.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Departamento>(
                sql, new { Id = id });
        }

        // CREAR
        public async Task<int> CreateDepartamentoAsync(DepartamentoRequest dto)
        {
            const string sql = @"
                INSERT INTO Departamento
                (
                    Nombre,
                    ResponsableId,
                    Estado
                )
                OUTPUT INSERTED.DepartamentoId
                VALUES
                (
                    @Nombre,
                    @ResponsableId,
                    @Estado
                );
            ";

            using var connection = _dataDapper.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(sql, dto);
        }
    }
}

