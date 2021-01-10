using Dapper;
using e_sun_weather.DomainModel.AggregatesModel.OpenWeather;
using e_sun_weather.DomainModel.Repository;
using e_sun_weather.DomainModel.Repository.OpenWeather;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Data.Repositories.OpenWeather
{
    public class OpenWeatherPredictionRecordRepository : IOpenWeatherPredictionRecordRepository
    {
        private IDapperContext uok;
        private string MSSqlConStr { get; set; }

        public OpenWeatherPredictionRecordRepository(IDapperContext uok,
            string MSSqlConStr)
        {
            this.uok = uok;
            this.MSSqlConStr = MSSqlConStr;
        }
        public async Task<bool> AddAsync(OpenWeatherPredictionRecord entity)
        {
            var sql = GetInsertString();

            using (var conn = new SqlConnection(MSSqlConStr))
            {
                conn.Open();

                int count = await conn.ExecuteAsync(sql, entity, uok.Transaction);

                return count > 0;
            }
        }

        public Task<OpenWeatherPredictionRecord> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(OpenWeatherPredictionRecord entity)
        {
            throw new NotImplementedException();
        }

        private string GetInsertString()
        {
            return @"INSERT INTO OpenWeatherPredictionRecord
                               ([ResourceID]
                               ,[DataDescription]
                               ,[Location]
                               ,[Element]
                               ,[StartTime]
                               ,[EndTime]
                               ,[ParameterName]
                               ,[ParameterValue]
                               ,[ParameterUnit]
                               ,[CreateTime])
                         VALUES
                               (@ResourceID
                               ,@DataDescription
                               ,@Location
                               ,@Element
                               ,@StartTime
                               ,@EndTime
                               ,@ParameterName
                               ,@ParameterValue
                               ,@ParameterUnit
                               ,@CreateTime)";
        }
    }
}
