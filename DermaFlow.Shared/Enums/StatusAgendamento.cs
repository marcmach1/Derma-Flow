namespace DermaFlow.Shared.Enums;

public enum StatusAgendamento
{
    Agendado = 1,
    Confirmado = 2,    // Cliente confirmou via WhatsApp (n8n pode atualizar isso)
    EmAtendimento = 3,
    Concluido = 4,     // Gatilho para o n8n pedir feedback em 15 dias
    Cancelado = 5,
    Faltou = 6
}