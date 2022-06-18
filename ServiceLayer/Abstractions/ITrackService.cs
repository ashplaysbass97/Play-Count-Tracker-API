using DomainLayer.Models;

namespace ServiceLayer.Abstractions
{
    public interface ITrackService
    {
        public IEnumerable<Track> GetAllTracks();

        public Track GetTrackById(int id);

        public void CreateTrack(Track track);

        public void UpdateTrack(Track track);

        public void DeleteTrackById(int id);
    }
}
