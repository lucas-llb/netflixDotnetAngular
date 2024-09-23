using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Api.Models.Responses;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Domain.Services;
using NSubstitute;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class AuthControllerTest
{
    private readonly Fixture _fixture = new Fixture();
    private readonly IUserRepository _userRepositoryMock;
    private readonly IAuthService _authServiceMock;

    public AuthControllerTest()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _authServiceMock = Substitute.For<IAuthService>();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task Should_LoginAsync()
    {
        // Given
        const string TokenMock = "token";
        const string UserMock = "user";
        const string PasswordMock = "password";
        _authServiceMock.LoginAsync(UserMock, PasswordMock).Returns(TokenMock);

        var controller = GetController();
        // When

        var result = await controller.LoginAsync(new Models.Request.LoginRequest { Email = UserMock, Password = PasswordMock });

        // Then
        result.Should().BeOfType<OkObjectResult>();
        var data = result as OkObjectResult;
        var response = (LoginResponse)data.Value;
        response.Token.Should().Be(TokenMock);
    }

    [Fact]
    public async Task Should_RegisterAsync()
    {
        // Given
        _userRepositoryMock.RegisterAsync(Arg.Any<UserEntity>()).ReturnsForAnyArgs(_fixture.Create<UserEntity>());

        var controller = GetController();
        // When

        var result = await controller.RegisterAsync(_fixture.Create<Models.Request.RegisterRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_ReturnBadRequest_When_LoginFailAsync()
    {
        // Given
        const string UserMock = "user";
        const string PasswordMock = "password";
        _authServiceMock.LoginAsync(UserMock, PasswordMock).Returns((string)null);

        var controller = GetController();
        // When

        var result = await controller.LoginAsync(new Models.Request.LoginRequest { Email = UserMock, Password = PasswordMock });

        // Then
        result.Should().BeOfType<BadRequestObjectResult>();
        var response = result as BadRequestObjectResult;
        response.Value.Should().Be("Email or password is incorrect");
    }

    [Fact]
    public async Task Should_ReturnBadRequest_When_RegisterFailAsync()
    {
        // Given
        _userRepositoryMock.RegisterAsync(Arg.Any<UserEntity>()).ReturnsForAnyArgs((UserEntity)null);

        var controller = GetController();
        // When

        var result = await controller.RegisterAsync(_fixture.Create<Models.Request.RegisterRequest>());

        // Then
        result.Should().BeOfType<BadRequestObjectResult>();
        var response = result as BadRequestObjectResult;
        response.Value.Should().Be("User already exists");
    }

    private AuthController GetController() => new(_userRepositoryMock, _authServiceMock);
}
