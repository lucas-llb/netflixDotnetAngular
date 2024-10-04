using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using System.Security.Claims;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class FavoritesControllerTest
{
    private readonly IFavoriteRepository _favoriteRepositoryMock;
    private HttpContext _httpContextMock;
    private readonly Fixture _fixture = new();

    public FavoritesControllerTest()
    {
        _favoriteRepositoryMock = Substitute.For<IFavoriteRepository>();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MockToken();
    }

    [Fact]
    public async Task Should_CreateFavoriteAsync()
    {
        // Given
        _favoriteRepositoryMock.CreateFavoriteAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<FavoriteEntity>());

        var controller = GetController();
        // When

        var result = await controller.CreateFavoriteAsync(_fixture.Create<Models.Request.Favorites.CreateFavoriteRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_GetFavoriteAsync()
    {
        // Given
        _favoriteRepositoryMock.GetFavoritesByUserIdAsync(Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<IEnumerable<FavoriteEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetFavoritesAsync();

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_DeleteFavoriteAsync()
    {
        // Given
        _favoriteRepositoryMock.RemoveFavoriteAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(true);

        var controller = GetController();
        // When

        var result = await controller.DeleteFavoriteAsync(1);

        // Then
        result.Should().BeOfType<OkResult>();
    }

    private FavoritesController GetController() => new(_favoriteRepositoryMock)
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
