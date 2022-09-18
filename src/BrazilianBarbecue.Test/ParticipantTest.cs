using BrazilianBarbecue.Core.Entities;
using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Model.Commands.Input;
using BrazilianBarbecue.Core.Services;
using BrazilianBarbecue.Infrastructure.Repositories.DataUtil;
using System.Linq;
using Xunit;

namespace BrazilianBarbecue.Test
{
    public class ParticipantTest
    {
        [Fact]
        public void When__Command__Without__Email()
        {
            #region Arrange

            var cmd = new CreateParticipantCommand()
            {
                Email = string.Empty,
                Name = "Hiulli Da Rocha Rodrigues"
            };

            #endregion

            #region act
            cmd.Validate();
            #endregion


            #region Assert            

            Assert.True(!cmd.IsValid);
            Assert.True(cmd.Notifications.Count() == 1);
            #endregion
        }

        [Fact]
        public void When__Command__Email__Invalid()
        {
            #region Arrange

            var cmd = new CreateParticipantCommand()
            {
                Email = "adsfasdfasd",
                Name = "Hiulli Da Rocha Rodrigues"
            };

            #endregion

            #region act
            cmd.Validate();
            #endregion

            #region Assert
            Assert.True(!cmd.IsValid);
            Assert.True(cmd.Notifications.Count() == 1);
            #endregion
        }

        [Fact]
        public void When__Command__Without__Name()
        {
            #region Arrange

            var cmd = new CreateParticipantCommand()
            {
                Email = "teste@gmail.com",
                Name = string.Empty
            };

            #endregion

            #region act
            cmd.Validate();
            #endregion

            #region Assert            

            Assert.True(!cmd.IsValid);
            Assert.True(cmd.Notifications.Count() == 1);
            #endregion
        }
    }
}