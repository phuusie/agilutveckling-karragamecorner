using System.Text.Json.Serialization;

namespace KarraGameCorner.DataAccess.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EntertainmentSoftwareRatingBoard
{
    Everyone,
    Everyone10Plus,
    Teen,
    Mature,
    AdultsOnly,
    RatingPending
}