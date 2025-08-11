namespace CRUD_FilmesAPI.Models;

public class Filmes
{
    public Guid Id { get; init; }
    public string Titulo { get; private set; }
    public int AnoLancamento { get; private set; }
    public string Diretor { get; private set; }
    public string Genero { get; private set; }
    public bool JaAssistido { get; private set; }

    public Filmes(string titulo, int anoLancamento, string diretor, string genero, bool jaAssistido)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        AnoLancamento = anoLancamento;
        Diretor = diretor;
        Genero = genero;
        JaAssistido = jaAssistido;
    }

    public void AtualizarTitulo(string titulo)
    {
        Titulo = titulo;
    }

    public void Desativar()
    {
        JaAssistido = false;
    }
}