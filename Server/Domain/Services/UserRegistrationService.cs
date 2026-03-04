using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.Domain.Exceptions;
using EslOnline.Domain.Factory;
using EslOnline.Domain.Factory.Params;
using EslOnline.Domain.Interfaces;
using EslOnline.Domain.Specifications;

namespace EslOnline.Domain.Services;

public class UserRegistrationService(
    CityFactory cityFactory,
    UserFactory userFactory,
    IRepository<User> userRepo,
    IRepository<City> cityRepo,
    IRepository<Government> governmentRepo,
    IRepository<Square> squareRepo,
    IRepository<Citizen> citizenRepo,
    IRepository<CrossRoad> crossRoadRepo,
    IRepository<Road> roadRepo,
    IRepository<Tawnhall> tawnHallRepo,
    IRepository<BankAccount> bancAccountRepo
    )
{
    public async Task RegisterNewUser(int maxCitizenInCity, string name, string language, string gmail)
    {
        var userSpec = new UserSpecification(gmail: gmail);
        var existingUser = await userRepo.AnyAsync(userSpec);
        if (existingUser)
            throw new Exception();
        bool haveAvailableCity = await IsHaveAvailableCity(maxCitizenInCity, language);
        City city;
        Government government;
        Square square;
        if (!haveAvailableCity)
        {
            CityFactoryResult result = cityFactory.Create(language);
            city = result.City;
            government = result.Government;
            square = result.Square;
            await cityRepo.AddAsync(city);
            await bancAccountRepo.AddAsync(result.governmentBancAccount);
            await governmentRepo.AddAsync(government);
            await squareRepo.AddAsync(square);
            await tawnHallRepo.AddAsync(result.Townhall);
            await crossRoadRepo.AddRangeAsync(result.Crossroads);
            await roadRepo.AddRangeAsync(result.Roads);
        }
        else
        {
            city = await cityRepo.FirstOrDefaultAsync(new CitySpecification(language: language)) ?? throw new DomainException("");
            government = await governmentRepo.FirstOrDefaultAsync(new GovernmentSpecification(locationId: city.Id)) ?? throw new DomainException(""); ;
            square = await squareRepo.SingleOrDefaultAsync(new SquareSpecification(locationId: city.Id)) ?? throw new DomainException("");
        }
        (User user, Citizen citizen, BankAccount bankAccount) = userFactory.Create(name, gmail, language, square.Id, government);
        await citizenRepo.AddAsync(citizen);
        await userRepo.AddAsync(user);
        await bancAccountRepo.AddAsync(bankAccount);
    }

    private async Task<bool> IsHaveAvailableCity(int maxCitizenInCity, string language)
    {
        int countCitizen = await userRepo.CountAsync(new UserSpecification(language: language));
        int countCity = await cityRepo.CountAsync(new CitySpecification(language: language));
        return countCitizen < countCity * maxCitizenInCity;
    }
}
