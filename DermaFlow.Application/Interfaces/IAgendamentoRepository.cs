namespace DermaFlow.Application.Interfaces;
using DermaFlow.Domain.Entities;

public interface IAgendamentoRepository
{
    Task AdicionarAsync(Agendamento agendamento);
    Task<List<Agendamento>> ListarTodosComPacientesAsync();

}