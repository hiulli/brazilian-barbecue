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
    public class ParticipantRepository : IParticipantRepository
    {
        protected readonly SqlConnection _connection;
        private readonly ScriptUtil<Participant> _scriptUtil = new ScriptUtil<Participant>();
        public ParticipantRepository(IOptions<SqlServerConfiguration> sqlServerConfiguration)
        {
            _connection = new SqlConnection(sqlServerConfiguration.Value.SQLConnection);
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Execute("Delete From [Participant] Where Id = @id", param: new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ParticipantResult> GetAll()
        {
            try
            {
                var query = @"SELECT ParticipantResult.[Id]
                                ,ParticipantResult.[Name]
                                ,ParticipantResult.[Email]
                            FROM [Participant] As ParticipantResult ";

                return _connection.Query<ParticipantResult>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParticipantResult GetById(int id)
        {
            try
            {
                var query = @"SELECT ParticipantResult.[Id]
                                ,ParticipantResult.[Name]
                                ,ParticipantResult.[Email]
                            FROM [Participant] As ParticipantResult Where ParticipantResult.[Id] = @id";

                return _connection.QueryFirst<ParticipantResult>(query, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Participant entity)
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

        public void Update(Participant entity)
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
