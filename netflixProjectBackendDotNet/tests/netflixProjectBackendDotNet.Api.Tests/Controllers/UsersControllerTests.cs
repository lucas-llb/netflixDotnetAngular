using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Api.Models.Request.User;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using System.Security.Claims;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class UsersControllerTests
{
    private readonly IUserRepository _userRepositoryMock;
    private readonly Fixture _fixture = new();
    private HttpContext _httpContextMock;

    public UsersControllerTests()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MockToken();
    }

    [Fact]
    public async Task Should_GetCurrentUserAsync()
    {
        // Given        
        var controller = GetController();

        // When

        var result = await controller.GetUserAsync();

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_UpdateUserAsync()
    {
        // Given
        _userRepositoryMock.UpdateAsync(_fixture.Create<UserEntity>()).ReturnsForAnyArgs(_fixture.Create<UserEntity>());

        var controller = GetController();
        // When

        var result = await controller.UpdateUserAsync(_fixture.Create<UpdateUserRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_UpdatePasswordAsync()
    {
        // Given
        _userRepositoryMock.CheckPasswordAsync(Arg.Any<int>(), Arg.Any<string>()).ReturnsForAnyArgs(true);
        _userRepositoryMock.UpdatePasswordAsync(Arg.Any<int>(), Arg.Any<string>()).ReturnsForAnyArgs(_fixture.Create<UserEntity>());


        var controller = GetController();
        // When

        var result = await controller.UpdatePasswordAsync(_fixture.Create<UpdatePasswordRequest>());

        // Then
        result.Should().BeOfType<OkResult>();
    }

    [Fact]
    public async Task Should_NotUpdatePasswordAsync()
    {
        // Given
        _userRepositoryMock.CheckPasswordAsync(Arg.Any<int>(), Arg.Any<string>()).ReturnsForAnyArgs(false);

        var controller = GetController();
        // When

        var result = await controller.UpdatePasswordAsync(_fixture.Create<UpdatePasswordRequest>());

        // Then
        result.Should().BeOfType<BadRequestObjectResult>();
    }


    private UsersController GetController() => new(_userRepositoryMock)
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
        var emailClaim = new Claim(ClaimTypes.Email, "teste@email.com");
        var birthClaim = new Claim(ClaimTypes.DateOfBirth, "10/10/2010");
        var phoneClam = new Claim(ClaimTypes.MobilePhone, "999999999");
        var nameClaim = new Claim(ClaimTypes.Name, "Teste");
        var surnameClaim = new Claim(ClaimTypes.Surname, "Testerson");
        claimsPrincipalMock.FindFirst(ClaimTypes.Sid).Returns(sidClaim);
        claimsPrincipalMock.FindFirst(ClaimTypes.Email).Returns(emailClaim);
        claimsPrincipalMock.FindFirst(ClaimTypes.DateOfBirth).Returns(birthClaim);
        claimsPrincipalMock.FindFirst(ClaimTypes.MobilePhone).Returns(phoneClam);
        claimsPrincipalMock.FindFirst(ClaimTypes.Name).Returns(nameClaim);
        claimsPrincipalMock.FindFirst(ClaimTypes.Surname).Returns(surnameClaim);

        claimsPrincipalMock.Identity.IsAuthenticated.Returns(true);

        _httpContextMock.User.Returns(claimsPrincipalMock);
    }
}
