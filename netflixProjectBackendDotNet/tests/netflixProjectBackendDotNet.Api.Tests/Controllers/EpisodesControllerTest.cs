using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using System.Security.Claims;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class EpisodesControllerTest
{
    private readonly IEpisodeRepository _episodeRepositoryMock;
    private readonly IWatchTimeRepository _watchTimeRepositoryMock;
    private IWebHostEnvironment _webHostMock;
    private readonly Fixture _fixture = new();
    private HttpContext _httpContextMock;

    public EpisodesControllerTest()
    {
        _episodeRepositoryMock = Substitute.For<IEpisodeRepository>();
        _watchTimeRepositoryMock = Substitute.For<IWatchTimeRepository>();
        _webHostMock = Substitute.For<IWebHostEnvironment>();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MockToken();
    }

    [Fact]
    public async Task Should_GetWatchTimeAsync()
    {
        // Given
        _watchTimeRepositoryMock.GetWatchTimeAsync(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<WatchTimeEntity>());

        var controller = GetController();
        // When

        var result = await controller.GetWatchTimeAsync(1);

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_SetWatchTimeAsync()
    {
        // Given
        _watchTimeRepositoryMock.SetWatchTimeAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<WatchTimeEntity>());

        var controller = GetController();
        // When

        var result = await controller.SetWatchTimeAsync(1, 1000);

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    private EpisodesController GetController() => new(_watchTimeRepositoryMock, _episodeRepositoryMock, _webHostMock)
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
