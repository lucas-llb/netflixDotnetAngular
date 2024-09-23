using AutoFixture;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Infra.Tests.Context;
using netflixProjectBackendDotNet.Infra.Repositories;

namespace netflixProjectBackendDotNet.Infra.Tests.Repositories;

public class UserRepositoryTest : InMemoryDbContext
{
    private readonly Fixture _fixture = new Fixture();

    public UserRepositoryTest()
    {
        Database.Users.AddRange(_fixture.CreateMany<UserEntity>());

    }

    //private UserRepository GetRepository() => new(Database);

    private UserEntity GetUser() => _fixture.Create<UserEntity>();

    private IEnumerable<EpisodeEntity> GetEpisodes() => _fixture.CreateMany<EpisodeEntity>(10);
}
