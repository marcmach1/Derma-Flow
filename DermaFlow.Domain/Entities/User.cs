namespace DermaFlow.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }

    public User(string nome, string telefone)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
    }
}