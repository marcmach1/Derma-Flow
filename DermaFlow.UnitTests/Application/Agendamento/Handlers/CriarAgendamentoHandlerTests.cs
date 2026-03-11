using Moq;
using Xunit;
using DermaFlow.Application.Agendamentos.Commands;
// Removi o using duplicado que causava o warning!
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.UnitTests.Application.Agendamentos.Handlers;

public class CriarAgendamentoHandlerTests
{
    [Fact]
    public async Task Handle_DadoComandoValido_DeveSalvarNoRepositorioERetornarId()
    {
        // Arrange
        var agendamentoRepoMock = new Mock<IAgendamentoRepository>();
        var procedimentoRepoMock = new Mock<IProcedimentoRepository>();

    agendamentoRepoMock.Setup(r => r.ListarPorDataAsync(It.IsAny<DateTime>()))
    .ReturnsAsync(new List<Agendamento>()); // Certifique-se que o using da Entity está lá

        var handler = new CriarAgendamentoHandler(agendamentoRepoMock.Object, procedimentoRepoMock.Object);

        var command = new CriarAgendamentoCommand(
            Guid.NewGuid(),             // PacienteId
            Guid.NewGuid(),             // ProfissionalId
            DateTime.UtcNow.AddDays(1), // DataHora
            new List<Guid> { Guid.NewGuid() } // Lista de Procedimentos (em vez de "Obs")
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        
        // Verificação ajustada (sem o CancellationToken se for o caso)
        agendamentoRepoMock.Verify(r => r.AdicionarAsync(It.IsAny<Agendamento>()), Times.Once);
    }
}