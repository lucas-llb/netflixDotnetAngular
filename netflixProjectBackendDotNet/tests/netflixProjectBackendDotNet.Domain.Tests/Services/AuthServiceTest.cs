using FluentAssertions;
using Microsoft.Extensions.Configuration;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Domain.Services.Impl;
using NSubstitute;
using System.IdentityModel.Tokens.Jwt;
using Xunit;

namespace netflixProjectBackendDotNet.Domain.Tests.Services;

public class AuthServiceTest
{
    private const string Issuer = "MyIssuer";
    private readonly IUserRepository _userRepositoryMock;
    private readonly IConfiguration _configurationMock;

    public AuthServiceTest()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Jwt:Issuer", Issuer },
            {"Jwt:Key", "hO1bl4Mr3SQkmIVD0kdEpaaA4zVC+g6xxdQwYt0MkNY=" }
        };
        _configurationMock = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
    }

    [Fact]
    public async Task Should_LoginAynsc()
    {
        // Given
        const string User = "user";
        const string Password = "password";
        _userRepositoryMock.LoginAsync(User, Password).Returns(true);
        var service = GetService();
        // When
        var token = await service.LoginAsync(User, Password);
        // Then
        var handler = new JwtSecurityTokenHandler();
        var readToken = handler.ReadJwtToken(token);
        readToken.Issuer.Should().Be(Issuer);
    }

    private AuthService GetService() => new(_userRepositoryMock, _configurationMock);
}
