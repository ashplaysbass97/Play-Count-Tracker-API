using DomainLayer.Models;
using ServiceLayer.Abstractions;

namespace PlayCountTrackerAPI.Routes
{
    public static class TrackRoutes
    {
        public static void ConfigureTrackRoutes(this WebApplication app)
        {
            app.MapGet("/tracks", GetAllTracks);
            app.MapGet("/tracks/{id}", GetTrackById);
            app.MapPost("/tracks", CreateTrack);
            app.MapPut("/tracks", UpdateTrack);
            app.MapDelete("/tracks/{id}", DeleteTrack);
        }

        private static IResult GetAllTracks(ITrackService trackService)
        {
            try
            {
                return Results.Ok(trackService.GetAllTracks());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetTrackById(int id, ITrackService trackService)
        {
            try
            {
                var track = trackService.GetTrackById(id);
                return track is null ? Results.NotFound() : Results.Ok(track);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult CreateTrack(Track track, ITrackService trackService)
        {
            try
            {
                trackService.CreateTrack(track);
                return Results.Created($"/tracks/{track.Id}", track);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult UpdateTrack(Track track, ITrackService trackService)
        {
            try
            {
                trackService.UpdateTrack(track);
                return Results.Ok(track);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult DeleteTrack(int id, ITrackService trackService)
        {
            try
            {
                trackService.DeleteTrackById(id);
                return Results.Ok($"Track {id} has been deleted.");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }

}
