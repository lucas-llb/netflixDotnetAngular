using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Entities.Like;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using System.Security.Claims;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class LikesControllerTest
{
    private readonly ILikeRepository _likeRepositoryMock;
    private readonly Fixture _fixture = new();
    private HttpContext _httpContextMock;

    public LikesControllerTest()
    {
        _likeRepositoryMock = Substitute.For<ILikeRepository>();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MockToken();
    }

    [Fact]
    public async Task Should_CreateLikeAsync()
    {
        // Given
        _likeRepositoryMock.CreateLikeAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<LikeEntity>());

        var controller = GetController();
        // When

        var result = await controller.CreateLikeAsync(_fixture.Create<Models.Request.Likes.CreateLikeRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_DeleteLikeAsync()
    {
        // Given
        _likeRepositoryMock.RemoveAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(true);

        var controller = GetController();
        // When

        var result = await controller.DeleteLikeAsync(1);

        // Then
        result.Should().BeOfType<OkResult>();
    }

    private LikesController GetController() => new(_likeRepositoryMock)
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
