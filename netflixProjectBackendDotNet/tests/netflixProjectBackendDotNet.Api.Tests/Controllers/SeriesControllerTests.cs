using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Api.Models.Request.Series;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Filters;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using System.IO;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class SeriesControllerTests
{
    private readonly ISerieRepository _serieRepositoryMock;
    private readonly IFavoriteRepository _favoriteRepositoryMock;
    private readonly ILikeRepository _likeRepositoryMock;
    private IWebHostEnvironment _webHostMock;
    private readonly Fixture _fixture = new();
    private HttpContext _httpContextMock;

    public SeriesControllerTests()
    {
        _favoriteRepositoryMock = Substitute.For<IFavoriteRepository>();
        _serieRepositoryMock = Substitute.For<ISerieRepository>();
        _likeRepositoryMock = Substitute.For<ILikeRepository>();
        _webHostMock = Substitute.For<IWebHostEnvironment>();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MockToken();
    }

    [Fact]
    public async Task Should_GetFeaturedSeriesAsync()
    {
        // Given
        _serieRepositoryMock.GetRandomFeaturedSeriesAsync().ReturnsForAnyArgs(_fixture.Create<IEnumerable<SerieEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetFeaturedSeriesAsync();

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_GetNewestSeriesAsync()
    {
        // Given
        _serieRepositoryMock.GetTopTenNewestAsync().ReturnsForAnyArgs(_fixture.Create<IEnumerable<SerieEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetNewestSeriesAsync();

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_FindSeriesByNameAsync()
    {
        // Given
        _serieRepositoryMock.FindByNameAsync(Arg.Any<string>(), Arg.Any<PaginatedFilter>()).ReturnsForAnyArgs(_fixture.Create<IEnumerable<SerieEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetSeriesByNameAsync(_fixture.Create<string>(), _fixture.Create<PaginatedRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_GetPopularSeriesAsync()
    {
        // Given
        _serieRepositoryMock.GetTopTenByLikesAsync().ReturnsForAnyArgs(_fixture.Create<IEnumerable<SerieEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetTopTenSeriesByLikeAsync();

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_GetSeriesWithEpisodeAsync()
    {
        // Given
        _serieRepositoryMock.GetByIdWithEpisodesAsync(Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<SerieEntity>());
        _favoriteRepositoryMock.IsFavoriteAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(true);
        _likeRepositoryMock.IsLikedAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(true);

        var controller = GetController();
        // When

        var result = await controller.GetWithEpisodesAsync(1);

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    private SeriesController GetController() => new(_serieRepositoryMock, _webHostMock, _favoriteRepositoryMock, _likeRepositoryMock)
    {
        ControllerContext = new ControllerContext()
        {
            HttpContext = _httpContextMock,
        }
    };

    private void MockToken()
    {
        _httpContextMock = Substitute.For<HttpContext>();
        var claimsPrincipalMock = Substitute.For<ClaimsPrincipal>();

        var sidClaim = new Claim(ClaimTypes.Sid, "12345");
        claimsPrincipalMock.FindFirst(ClaimTypes.Sid).Returns(sidClaim);
        claimsPrincipalMock.Identity.IsAuthenticated.Returns(true);

        _httpContextMock.User.Returns(claimsPrincipalMock);
    }
}
