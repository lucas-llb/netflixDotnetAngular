using netflixProjectBackendDotNet.Domain.Entities.Episode;

namespace netflixProjectBackendDotNet.Infra.Context.SeedData;

internal static class EpisodeSeedData
{
    public static List<EpisodeEntity> EpisodesData = new List<EpisodeEntity>
    {
        new EpisodeEntity
        {
            Id = 1,
            Name = "Episode 1",
            Synopsis = "This is the Episode 1",
            Order = 0,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
            SecondsLong = 325,
            CreatedAt = DateTime.UtcNow,
            SerieId = 1,
        },
        new EpisodeEntity
        {
            Id = 2,
            CreatedAt = DateTime.UtcNow,
            Name = "Episode 2",
            Synopsis = "This is the Episode 2",
            Order = 1,
            SecondsLong = 325,
            SerieId = 1,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
        },
        new EpisodeEntity
        {
            Id = 3,
            CreatedAt = DateTime.UtcNow,
            Name = "Episode 3",
            Synopsis = "This is the Episode 3",
            Order = 2,
            SecondsLong = 325,
            SerieId = 1,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
        },
        new EpisodeEntity
        {
            Id = 4,
            CreatedAt = DateTime.UtcNow,
            Name = "Episode 1",
            Synopsis = "This is the Episode 1",
            Order = 0,
            SecondsLong = 325,
            SerieId = 7,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
        },
        new EpisodeEntity
        {
            Id = 5,
            CreatedAt = DateTime.UtcNow,
            Name = "Episode 1",
            Synopsis = "This is the Episode 1",
            Order = 0,
            SecondsLong = 325,
            SerieId = 3,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
        },
        new EpisodeEntity
        {
            Id = 6,
            CreatedAt = DateTime.UtcNow,
            Name = "Episode 1",
            Synopsis = "This is the Episode 1",
            Order = 0,
            SecondsLong = 325,
            SerieId = 2,
            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4",
            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
        },
    };
}
