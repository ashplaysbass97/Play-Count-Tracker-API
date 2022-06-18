using DomainLayer.Models;
using ServiceLayer.Abstractions;

namespace PlayCountTrackerAPI.Routes
{
    public static class ArtistRoutes
    {
        public static void ConfigureArtistRoutes(this WebApplication app)
        {
            app.MapGet("/artists", GetAllArtists);
            app.MapGet("/artists/{id}", GetArtistById);
            app.MapPost("/artists", CreateArtist);
            app.MapPut("/artists", UpdateArtist);
            app.MapDelete("/artists/{id}", DeleteArtistById);
        }

        private static IResult GetAllArtists(IArtistService artistService)
        {
            try
            {
                return Results.Ok(artistService.GetAllArtists());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetArtistById(int id, IArtistService artistService)
        {
            try
            {
                var artist = artistService.GetArtistById(id);
                return artist is null ? Results.NotFound() : Results.Ok(artist);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult CreateArtist(Artist artist, IArtistService artistService)
        {
            try
            {
                artistService.CreateArtist(artist);
                return Results.Created($"/artists/{artist.Id}", artist);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult UpdateArtist(Artist artist, IArtistService artistService)
        {
            try
            {
                artistService.UpdateArtist(artist);
                return Results.Ok(artist);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult DeleteArtistById(int id, IArtistService artistService)
        {
            try
            {
                artistService.DeleteArtistById(id);
                return Results.Ok($"Artist {id} has been deleted.");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }

}
