using Moq;
using Xunit;
using DermaFlow.Application.Agendamentos.Queries;
using DermaFlow.Application.Interfaces;
using DermaFlow.Shared.DTOs;
using DermaFlow.Domain.Entities;
using System.Collections.Generic;

namespace DermaFlow.UnitTests;

public class ObterAgendamentosHandlerTests
{
    [Fact]
    public async Task Handle_DeveRetornarListaDeAgendamentoResponseDTO()
    {
        // Arrange
        var repoMock = new Mock<IAgendamentoRepository>();
        repoMock.Setup(r => r.ListarTodosComPacientesAsync())
            .ReturnsAsync(new List<Agendamento> {
                new Agendamento(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, "Obs")
            });
        var handler = new ObterAgendamentosHandler(repoMock.Object);
        var query = new ObterAgendamentosQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        repoMock.Verify(r => r.ListarTodosComPacientesAsync(), Times.Once);
    }
}
