using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Logging;
using Moq;
using TesteIbmMQ.Application.Commands.FilaTeste;
using TesteIbmMQ.Application.Notifications;
using TesteIbmMQ.Domain.Entities;
using TesteIbmMQ.Domain.Repositories;
using TesteIbmMQ.Domain.Services;
using TesteIbmMQ.Domain.Settings;
using Xunit;

public class UnitTest1
{
    private readonly Mock<ILogger<FilaTesteHandler>> _loggerMock;
    private readonly Mock<IQueueService> _queueServiceMock;
    private readonly Mock<IFilaTesteRepository> _repositoryMock;
    private readonly RetrySettings _retrySettings;
    private readonly FilaTesteHandler _handler;

    public UnitTest1()
    {
        _loggerMock = new Mock<ILogger<FilaTesteHandler>>();
        _queueServiceMock = new Mock<IQueueService>();
        _repositoryMock = new Mock<IFilaTesteRepository>();
        _retrySettings = new RetrySettings { MaxRetries = 3, RetryTimeInMinutes = 5 };
        _handler = new FilaTesteHandler(_loggerMock.Object, _queueServiceMock.Object, _retrySettings, _repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldLogInformation()
    {
        // Arrange
        var notification = new FilaTesteNotification("Test Message")
        {
            Message = new EstruturaFila { Nome = "Test", Idade = DateTime.Now }
        };

        // Act
        await _handler.Handle(notification, CancellationToken.None);

        // Assert
        _loggerMock.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task ProcessMessage_ShouldProcessCredit()
    {
        // Arrange
        var notification = new FilaTesteNotification("Test Message")
        {
            Message = new EstruturaFila { Nome = "Test", Idade = DateTime.Now }
        };

        // Act
        await _handler.Handle(notification, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(repo => repo.ProcessCredit(It.IsAny<EstruturaFila>()), Times.Once);
    }

    [Fact]
    public async Task ProcessMessage_ShouldRetryAndSendToRetryQueue()
    {
        // Arrange
        var notification = new FilaTesteNotification("Test Message")
        {
            Message = new EstruturaFila { Nome = "Test", Idade = DateTime.Now },
            Retries = 0
        };

        _repositoryMock.Setup(repo => repo.ProcessCredit(It.IsAny<EstruturaFila>())).Throws(new Exception());

        // Act
        await _handler.Handle(notification, CancellationToken.None);

        // Assert
        _queueServiceMock.Verify(service => service.SendMessageToQueue("QL.GDC.DP.Teste_RETRY", It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task ProcessMessage_ShouldSendToDeadLetterQueue()
    {
        // Arrange
        var notification = new FilaTesteNotification("Test Message")
        {
            Message = new EstruturaFila { Nome = "Test", Idade = DateTime.Now },
            Retries = _retrySettings.MaxRetries
        };

        _repositoryMock.Setup(repo => repo.ProcessCredit(It.IsAny<EstruturaFila>())).Throws(new Exception());

        // Act
        await _handler.Handle(notification, CancellationToken.None);

        // Assert
        _queueServiceMock.Verify(service => service.SendMessageToQueue("QL.GDC.DP.Teste_DLQ", It.IsAny<string>()), Times.Once);
    }
}
