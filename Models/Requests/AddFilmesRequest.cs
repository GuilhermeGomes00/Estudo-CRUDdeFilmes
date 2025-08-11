namespace CRUD_FilmesAPI.Models.Requests;

public record AddFilmesRequest(string Title, int  Year, string Genre, string Director, bool Watched);