using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model;
using BrazilianBarbecue.Core.Model.Commands.Results;
using BrazilianBarbecue.Infrastructure.Repositories.DataUtil;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace BrazilianBarbecue.Infrastructure.Repositories
{
    public class BarbecueScheduleRepository : IBarbecueScheduleRepository
    {
        private readonly SqlConnection _connection;
        private readonly ScriptUtil<BarbecueSchedule> _scriptUtil = new ScriptUtil<BarbecueSchedule>();

        public BarbecueScheduleRepository(IOptions<SqlServerConfiguration> sqlServerConfiguration)
        {
            _connection = new SqlConnection(sqlServerConfiguration.Value.SQLConnection);
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Execute("Delete From [BarbecueSchedule] Where Id = @id", param: new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BarbecueScheduleResult> GetAll()
        {
            try
            {
                var query = @"SELECT BarbecueScheduleResult.[Id]
                                    ,BarbecueScheduleResult.[ParticipantId]
                                    ,BarbecueScheduleResult.[BarbecueDate]
                                    ,BarbecueScheduleResult.[Description]
                                    ,BarbecueScheduleResult.[AdditionalObservations]
                                    ,BarbecueScheduleResult.[SuggestedAmountDrink]
                                    ,BarbecueScheduleResult.[SuggestedAmountFood]
                                FROM [BarbecueSchedule] As BarbecueScheduleResult";

                return _connection.Query<BarbecueScheduleResult>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BarbecueScheduleResult GetById(int id)
        {
            try
            {
                var query = @"SELECT BarbecueScheduleResult.[Id]
                                    ,BarbecueScheduleResult.[ParticipantId]
                                    ,BarbecueScheduleResult.[BarbecueDate]
                                    ,BarbecueScheduleResult.[Description]
                                    ,BarbecueScheduleResult.[AdditionalObservations]
                                    ,BarbecueScheduleResult.[SuggestedAmountDrink]
                                    ,BarbecueScheduleResult.[SuggestedAmountFood]
                                FROM [BarbecueSchedule] As BarbecueScheduleResult
                               Where BarbecueScheduleResult.[Id] = @id ";

                return _connection.QueryFirst<BarbecueScheduleResult>(query, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(BarbecueSchedule entity)
        {
            try
            {
                _connection.Execute(_scriptUtil.GetInsert(entity), entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(BarbecueSchedule entity)
        {
            try
            {
                _connection.Execute(_scriptUtil.GetUpdate(entity), entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
