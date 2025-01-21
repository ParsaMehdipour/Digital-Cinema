using Application.Casts.Queries.GetCasts;
using Application.Casts.Queries.GetCasts.Criteria;
using AutoMapper;
using Domain.Entities.Casts;
using Domain.Enums;
using Domain.Repositories;
using Domain.ValueObjects;
using Moq;

namespace UnitTests.Application.Casts.Queries;
public class GetCastsTests
{
    private readonly Mock<ICastRepository> _castsRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly GerCastsQueryHandler _sustemUnderTest;

    public GetCastsTests()
    {
        _sustemUnderTest = new(_castsRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnsPagedResult_WhenValidRequestAsync()
    {
        // Arrange
        var testCasts = new List<Cast>
        {
            Cast.Create( firstName: FirstName.Create("John").Value, lastName: LastName.Create("Doe").Value, gender: Gender.Male, castType: CastType.Director, isAlive: true, age: Age.Create(30).Value),
            Cast.Create( firstName: FirstName.Create("Jane").Value, lastName: LastName.Create("Smith").Value, gender: Gender.Female, castType: CastType.ActorActress, isAlive: true, age: Age.Create(25).Value)
        }.AsQueryable();

        var testDtos = new List<GetCastsDto>
        {
           new GetCastsDto { FirstName = "John", LastName = "Doe", Age = 30 },
           new GetCastsDto { FirstName = "Jane", LastName = "Smith", Age = 25 }
        };

        var parameters = new CastsQueryStringParameters(
        FirstName: "John",
        LastName: "Doe",
        Age: 30,
        MaxPageSize: 100,
        PageNumber: 1,
        PageSize: 10,
        IsDeleted: false
        );

        var request = new GetCastsQuery(parameters);

        _castsRepositoryMock.Setup(repo => repo.Get()).Returns(testCasts);
        _mapperMock.Setup(mapper => mapper.ConfigurationProvider).Returns(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cast, GetCastsDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age.Value)); ;
            }));

        // Act
        var result = await _sustemUnderTest.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        var pagedResult = result.Value;
        Assert.NotNull(pagedResult);
        Assert.Equal(1, pagedResult.TotalPagesCount); // Adjust this based on your pagination logic
        Assert.Equal(1, pagedResult.TotalItemsCount);
        Assert.Contains(pagedResult.Items, r => r.FirstName == "John");
    }
}
