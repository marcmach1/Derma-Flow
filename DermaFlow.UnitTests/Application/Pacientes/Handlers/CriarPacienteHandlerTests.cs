using Moq;
using Xunit;
using DermaFlow.Application.Pacientes.Commands;
using DermaFlow.Application.Pacientes.Handlers;
using DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

namespace DermaFlow.UnitTests.Application.Pacientes.Handlers;

public class CriarPacienteHandlerTests
{
    [Fact]
    public async Task Handle_DadoComandoValido_DeveSalvarNoRepositorioERetornarId()
    {
        // Arrange
        var repositoryMock = new Mock<IPacienteRepository>();
        repositoryMock
            .Setup(r => r.AdicionarAsync(It.IsAny<Paciente>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Guid.NewGuid());

        var handler = new CriarPacienteHandler(repositoryMock.Object);
        var command = new CriarPacienteCommand("Paciente Teste", "12345678900", "11999999999", "paciente@email.com", Guid.NewGuid());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        repositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<Paciente>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
