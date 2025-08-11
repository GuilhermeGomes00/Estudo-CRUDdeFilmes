using CRUD_FilmesAPI.Data;
using CRUD_FilmesAPI.Models.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CRUD_FilmesAPI.Models;

public static class FilmesRotas
{
    public static void AddFilmes(this WebApplication app)
        {
            // 
            var EndPointsFilmes = app.MapGroup("Filmes");
            
            // Criando
            EndPointsFilmes.MapPost("",
                async (AddFilmesRequest request, AppDbContext ctx) =>
                {
                    var AssistidoCheck = await ctx.Filme.AnyAsync(Filmes => Filmes.JaAssistido == request.Watched && Filmes.Titulo == request.Title);
                    if (AssistidoCheck) return Results.Conflict("Já enviado!");
                    
                    var NovoFilme = new Filmes(request.Title,
                        request.Year,
                        request.Director,
                        request.Genre,
                        request.Watched);
                    await ctx.Filme.AddAsync(NovoFilme);
                    await ctx.SaveChangesAsync();

                    var FilmesRetorno = new FilmesDTO(NovoFilme.Id, NovoFilme.Titulo, NovoFilme.AnoLancamento,  NovoFilme.Diretor, NovoFilme.Genero);
                    
                    return Results.Ok(FilmesRetorno);
                });
        
            // Retornando Tudo
            EndPointsFilmes.MapGet("", 
                async (AppDbContext ctx) =>
                {
                var Filmes = await ctx
                    .Filme
                    .Where(Filmes => Filmes.JaAssistido)
                    .Select(Filmes => new FilmesDTO(
                        Filmes.Id, Filmes.Titulo, Filmes.AnoLancamento, Filmes.Diretor, Filmes.Genero)
                            )
                    .ToListAsync();
                return Filmes;
            });
            
            // Atualizar Titulo Filme
            EndPointsFilmes.MapPut("{Title}", async (string title ,UptFilmeRequest request, AppDbContext ctx) =>
            {
                var Filme = await ctx.Filme.SingleOrDefaultAsync(Filmes => Filmes.Titulo == title);
                if (Filme == null) return Results.NotFound();
                
                Filme.AtualizarTitulo(request.Title);
                await ctx.SaveChangesAsync();
                return Results.Ok(new FilmesDTO(Filme.Id, Filme.Titulo, Filme.AnoLancamento, Filme.Diretor, Filme.Genero));
            });
            
            // Soft Delete
            EndPointsFilmes.MapDelete("{Title}", async (string title, AppDbContext ctx) =>
            {
                var filme = await ctx.Filme.SingleOrDefaultAsync(filme => filme.Titulo == title);
                if (filme == null) return Results.NotFound();
                
                filme.Desativar();
                
                await ctx.SaveChangesAsync();
                return Results.Ok();

            });
        }   
    
    
}