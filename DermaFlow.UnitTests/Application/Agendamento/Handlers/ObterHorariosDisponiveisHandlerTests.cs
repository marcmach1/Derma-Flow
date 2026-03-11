using Moq;
using Xunit;
using DermaFlow.Application.Agendamentos.Queries;
using DermaFlow.Application.Interfaces;
using System;
using System.Collections.Generic;
using DermaFlow.Domain.Entities;

namespace DermaFlow.UnitTests;

public class ObterHorariosDisponiveisHandlerTests
{
    [Fact]
    public async Task Handle_DeveRetornarListaDeHorariosDisponiveis()
    {
        // 1. Arrange
        var repoMock = new Mock<IAgendamentoRepository>();
        
        // CORREÇÃO: O repositório retorna List<Agendamento>, não List<DateTime>
        // Mesmo que a lista esteja vazia, ela precisa ser do tipo esperado pela Interface
        repoMock.Setup(r => r.ListarPorDataAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<Agendamento>()); 

        var handler = new ObterHorariosDisponiveisHandler(repoMock.Object);
        
        // Verifique se o construtor do seu Query pede apenas Data e Intervalo
        var query = new ObterHorariosDisponiveisQuery(DateTime.Today, 15);

        // 2. Act
        var result = await handler.Handle(query, CancellationToken.None);

        // 3. Assert
        Assert.NotNull(result);
        
        // Aqui o Assert continua sendo List<DateTime> porque o RESULTADO do Handler 
        // (após processar os agendamentos) é que são os horários livres.
        Assert.IsType<List<DateTime>>(result);
        
        repoMock.Verify(r => r.ListarPorDataAsync(It.IsAny<DateTime>()), Times.Once);
    }
}