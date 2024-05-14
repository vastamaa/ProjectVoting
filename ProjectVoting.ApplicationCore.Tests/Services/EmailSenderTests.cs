using FluentAssertions.Execution;
using Microsoft.Extensions.Configuration;
using Moq;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Services;
using SendWithBrevo;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ProjectVoting.ApplicationCore.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class EmailSenderTests
    {
        [Fact]
        public async Task SendEmail_ShouldSendOutEmailUsingApiKey()
        {
            // Arrange

            // Source: https://stackoverflow.com/questions/50201588/c-sharp-how-to-mock-configuration-getsectionfoobar-getliststring
            var configurationMock = new Mock<IConfiguration>();
            var configurationSectionMock = new Mock<IConfigurationSection>();

            configurationSectionMock
                .Setup(x => x.Value)
                .Returns("apiKey");

            configurationMock
                .Setup(x => x.GetSection("EmailOptions:ApiKey"))
                .Returns(configurationSectionMock.Object);

            var emailSender = new EmailSender(configurationMock.Object);


            // Act
            await emailSender.SendEmail(
                new EmailMessage(
                    new Sender("Sender Mike" ,"sender@sender.com"),
                    new List<Recipient>() {
                        new Recipient("Receiver Tom", "receiver@receiver.com"),
                        new Recipient("CC Angelica", "cc@receiver.com")
                    },
                    "Test",
                    "I am testing!"
                    )
                );

            // Assert
            using (new AssertionScope())
            {
                configurationMock.VerifyAll();
            }
        }
    }
}
