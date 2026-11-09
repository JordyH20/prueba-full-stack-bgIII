using backend_bg_v3.Data;
using backend_bg_v3.Dto.Request;
using backend_bg_v3.Dto.Response;
using backend_bg_v3.Models;
using Dapper;

namespace backend_bg_v3.Service
{
    public class ColaboradorService
    {
        private readonly DataDapper _dataDapper;

        public ColaboradorService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }


        public async Task<IEnumerable<ColaboradorResponse>> GetAllColaboradoresAsync()
        {
            using var connection = _dataDapper.CreateConnection();
            var query = "SELECT * FROM Colaborador";
            var colaboradores = await connection.QueryAsync<ColaboradorResponse>(query);
            return colaboradores;
        }


        public async Task<ColaboradorResponse> GettByIdColaborador(int id)
        {
            const string sql = @"SELECT ColaboradorId, Identificacion, Nombre, Correo, DepartamentoId, Estado 
                               FROM Colaborador WHERE ColaboradorId = @ColaboradorId;";
            using var connection = _dataDapper.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ColaboradorResponse>(sql, new { ColaboradorId = id });
        }
        public async Task<int> CreateAsync(ColaboradorRequest dto)
        {
            const string sql = @"
        INSERT INTO Colaborador
        (
            Identificacion,
            Nombre,
            Correo,
            DepartamentoId,
            Estado
        )
        OUTPUT INSERTED.ColaboradorId
        VALUES
        (
            @Identificacion,
            @Nombre,
            @Correo,
            @DepartamentoId,
            @Estado
        );
    ";

            using var connection = _dataDapper.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(sql, dto);
        }
    }
}
