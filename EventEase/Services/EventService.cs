using EventEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEase.Services
{
    // Represents one participant’s record
    public record ParticipantRecord(
        string FullName,
        string Email,
        DateTime RegisteredAt
    );

    public class EventService
    {
        // Static event list
        private readonly List<EventModel> _events = new()
        {
            new() { Id = 1, Name = "Tech Summit 2026", Date = DateTime.Today.AddDays(7), Location = "Jakarta", Description = "Innovation & networking." },
            new() { Id = 2, Name = "HR Leadership Forum", Date = DateTime.Today.AddDays(14), Location = "Bandung", Description = "People-first strategies." },
            new() { Id = 3, Name = "Cloud & DevOps Day", Date = DateTime.Today.AddDays(21), Location = "Surabaya", Description = "Hands-on sessions." }
        };

        // Event ID -> List of participant records
        private readonly Dictionary<int, List<ParticipantRecord>> _participants =
            new Dictionary<int, List<ParticipantRecord>>();

        // Get all events sorted by date
        public Task<List<EventModel>> GetEventsAsync() =>
            Task.FromResult(_events.OrderBy(e => e.Date).ToList());

        // Get event by ID
        public Task<EventModel?> GetByIdAsync(int id) =>
            Task.FromResult(_events.FirstOrDefault(e => e.Id == id));

        // Register a participant with full name, email, and timestamp
        public void RegisterAttendance(int eventId, string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email))
                return;

            if (!_participants.TryGetValue(eventId, out var list))
            {
                list = new List<ParticipantRecord>();
                _participants[eventId] = list;
            }

            // Avoid duplicate registration based on full name only
            if (!list.Any(p => p.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase)))
            {
                list.Add(new ParticipantRecord(
                    FullName: fullName.Trim(),
                    Email: email.Trim(),
                    RegisteredAt: DateTime.Now
                ));
            }
        }

        // Check if a full name is already registered in an event
        public bool IsNameRegistered(int eventId, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return false;

            return _participants.TryGetValue(eventId, out var list)
                && list.Any(p => p.FullName.Equals(fullName.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Get all participant records for an event (sorted by name)
        public List<ParticipantRecord> GetParticipants(int eventId)
        {
            if (_participants.TryGetValue(eventId, out var list))
                return list.OrderBy(p => p.FullName).ToList();

            return new List<ParticipantRecord>();
        }

        // Get total participant count
        public int GetAttendanceCount(int eventId)
        {
            return _participants.TryGetValue(eventId, out var list)
                ? list.Count
                : 0;
        }
    }
}