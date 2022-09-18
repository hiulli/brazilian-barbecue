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
    public class BarbecueParticipantRepository : IBarbecueParticipantRepository
    {
        private readonly SqlConnection _connection;
        private readonly ScriptUtil<BarbecueParticipant> _scriptUtil = new ScriptUtil<BarbecueParticipant>();
        public BarbecueParticipantRepository(IOptions<SqlServerConfiguration> sqlServerConfiguration)
        {
            _connection = new SqlConnection(sqlServerConfiguration.Value.SQLConnection);
        }

        public void ConfirmPayment(int id)
        {
            try
            {
                _connection.Execute("Update [BarbecueParticipant] Set [Payed] = 1  Where [Id] = @Id", param: new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Execute("Delete From [BarbecueParticipant] Where Id = @id", param: new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAllByBarbecueId(int barbecueId)
        {
            try
            {
                _connection.Execute("Delete From [BarbecueParticipant] Where barbecueId = @barbecueId", param: new { barbecueId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExistParticipantInBarbecue(int participantId)
        {
             try
            {
                var query = @"Select COUNT(1)
                                From BarbecueParticipant 
                               Where [BarbecueParticipant].[ParticipantId] = @participantId";

                return _connection.QueryFirst<int>(query, new { participantId }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BarbecueParticipantResult> GetAllByBarbecueId(int id)
        {
            try
            {
                var query = @"SELECT [BarbecueParticipantResult].[Id]
                                    ,[BarbecueParticipantResult].[BarbecueId]
                                    ,[BarbecueParticipantResult].[ParticipantId]
                                    ,[BarbecueParticipantResult].[ContributionAmount]
                                    ,[BarbecueParticipantResult].[Payed]
									,[Participant].[Name]
									,[Participant].[Email]									
                                FROM [BarbecueParticipant] As [BarbecueParticipantResult]
								Inner Join [Participant] On [Participant].[Id] = [BarbecueParticipantResult].[ParticipantId]
                               WHERE [BarbecueParticipantResult].[BarbecueId] = 1";

                return _connection.Query<BarbecueParticipantResult>(query, new {id});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BarbecueParticipantResult GetById(int id)
        {
            try
            {
                var query = @"SELECT [BarbecueParticipantResult].[Id]
                                    ,[BarbecueParticipantResult].[BarbecueId]
                                    ,[BarbecueParticipantResult].[ParticipantId]
                                    ,[BarbecueParticipantResult].[ContributionAmount]
                                    ,[BarbecueParticipantResult].[Payed]
                                FROM [BarbecueParticipant] As [BarbecueParticipantResult]
                               WHERE [BarbecueParticipantResult].[Id] = @id";

                return _connection.QueryFirst<BarbecueParticipantResult>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(BarbecueParticipant entity)
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

        public void Update(BarbecueParticipant entity)
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
