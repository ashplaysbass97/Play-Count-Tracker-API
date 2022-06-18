using Data.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository<Track> _trackRepository;

        public TrackService(ITrackRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return _trackRepository.GetAll();
        }

        public Track GetTrackById(int id)
        {
            return _trackRepository.GetById(id);
        }

        public void CreateTrack(Track track)
        {
            _trackRepository.Create(track);
        }

        public void UpdateTrack(Track track)
        {
            _trackRepository.Update(track);
        }

        public void DeleteTrackById(int id)
        {
            var track = _trackRepository.GetById(id);
            _trackRepository.Delete(track);
        }
    }
}