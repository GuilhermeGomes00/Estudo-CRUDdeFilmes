namespace CRUD_FilmesAPI.Models;

public record FilmesDTO(Guid Id, string Titulo, int AnoLancamento, string Diretor, string Genero);