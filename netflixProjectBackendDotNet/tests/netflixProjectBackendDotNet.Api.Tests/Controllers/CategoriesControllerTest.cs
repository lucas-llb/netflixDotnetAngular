using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Controllers;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Domain.Dtos;
using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Filters;
using netflixProjectBackendDotNet.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace netflixProjectBackendDotNet.Api.Tests.Controllers;

public class CategoriesControllerTest
{
    private readonly Fixture _fixture = new Fixture();
    private readonly ICategoryRepository _categoryRepositoryMock;

    public CategoriesControllerTest()
    {
        _categoryRepositoryMock = Substitute.For<ICategoryRepository>();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task Should_GetCategoriesPaginatedAsync()
    {
        // Given
        _categoryRepositoryMock.GetPaginatedAsync(Arg.Any<PaginatedFilter>()).ReturnsForAnyArgs(_fixture.Create<PaginatedDto<CategoryEntity>>());

        var controller = GetController();
        // When

        var result = await controller.GetPaginatedAsync(_fixture.Create<Models.Request.CategoriesPaginatedRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_GetCategoryByIdAsync()
    {
        // Given
        _categoryRepositoryMock.GetById(Arg.Any<int>()).ReturnsForAnyArgs(_fixture.Create<CategoryEntity>());

        var controller = GetController();
        // When

        var result = await controller.GetById(1);

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }


    [Fact]
    public async Task Should_CreateCategoryAsync()
    {
        // Given
        _categoryRepositoryMock.CreateAsync(Arg.Any<CategoryEntity>()).ReturnsForAnyArgs(_fixture.Create<CategoryEntity>());

        var controller = GetController();
        // When

        var result = await controller.CreateAsync(_fixture.Create<CreateCategoryRequest>());

        // Then
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_DeleteCategoryAsync()
    {
        // Given
        _categoryRepositoryMock.DeleteAsync(Arg.Any<int>()).ReturnsForAnyArgs(true);

        var controller = GetController();
        // When

        var result = await controller.DeleteAsync(1);

        // Then
        result.Should().BeOfType<OkResult>();
    }

    private CategoriesController GetController() => new(_categoryRepositoryMock);
}
