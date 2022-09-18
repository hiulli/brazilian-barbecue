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
    public class BarbecueRepository : IBarbecueRepository
    {
        private readonly SqlConnection _connection;
        private readonly ScriptUtil<Barbecue> _scriptUtil = new ScriptUtil<Barbecue>();

        public BarbecueRepository(IOptions<SqlServerConfiguration> sqlServerConfiguration)
        {
            _connection = new SqlConnection(sqlServerConfiguration.Value.SQLConnection);
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Execute("Delete From [Barbecue] Where Id = @id", param: new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BarbecueResult> GetAll()
        {
            try
            {
                var query = @"SELECT [BarbecueResult].[Id]                                    
                                    ,[BarbecueResult].[BarbecueDate]
                                    ,[BarbecueResult].[Description]
                                    ,[BarbecueResult].[AdditionalObservations]
                                    ,[BarbecueResult].[SuggestedAmountDrink]
                                    ,[BarbecueResult].[SuggestedAmountFood]
                                FROM [Barbecue] As BarbecueResult";

                return _connection.Query<BarbecueResult>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BarbecueResult GetById(int id)
        {
            try
            {
                var query = @"SELECT BarbecueResult.[Id]                                    
                                    ,BarbecueResult.[BarbecueDate]
                                    ,BarbecueResult.[Description]
                                    ,BarbecueResult.[AdditionalObservations]
                                    ,BarbecueResult.[SuggestedAmountDrink]
                                    ,BarbecueResult.[SuggestedAmountFood]
                                FROM [Barbecue] As BarbecueResult
                               Where BarbecueResult.[Id] = @id ";

                return _connection.QueryFirst<BarbecueResult>(query, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BarbecueDetailResult GetDetailById(int id)
        {
            try
            {
                var query = @"Select [BarbecueDetailResult].[Id]
                                    ,[BarbecueDetailResult].[BarbecueDate]
                                    ,[BarbecueDetailResult].[Description]
                                    ,[BarbecueDetailResult].[AdditionalObservations]
                                    ,[BarbecueDetailResult].[SuggestedAmountDrink]
                                    ,[BarbecueDetailResult].[SuggestedAmountFood] 
                                    ,[BarbecueAmount].[CollectedAmount]
                                From [Barbecue] As [BarbecueDetailResult]
                               Left Join (Select [BarbecueParticipant].[BarbecueId] ,Sum([ContributionAmount]) CollectedAmount
                                             From [BarbecueParticipant]
                                            Where [BarbecueParticipant].[Payed] = 1 
                                              And [BarbecueParticipant].[BarbecueId] = @Id
                                            Group by [BarbecueParticipant].[BarbecueId]) As [BarbecueAmount] 
                                        On [BarbecueAmount].[BarbecueId] = [BarbecueDetailResult].[Id]
                                 Where [BarbecueDetailResult].[Id] = @Id";

                return _connection.QueryFirst<BarbecueDetailResult>(query, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Barbecue entity)
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

        public void Update(Barbecue entity)
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
