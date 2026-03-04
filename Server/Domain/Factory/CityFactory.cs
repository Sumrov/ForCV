using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.Domain.Factory.Params;
using EslOnline.SharedKernel.Domain.Enums;

namespace EslOnline.Domain.Factory;

public class CityFactory
{
    public CityFactoryResult Create(string language)
    {
        var city = City.Create($"{language}City", language);
        (Government government, BankAccount bankAccount) = Government.Create($"{language}Government", city.Id);
        var townhall = Tawnhall.Create(city.Id);
        var square = Square.Create(BuildingMaterial.Ground, city.Id);

        var crossroads = new List<CrossRoad>
        {
            CrossRoad.Create((-10, -100), BuildingMaterial.Ground, city.Id),
            CrossRoad.Create((-10, 10), BuildingMaterial.Ground, city.Id),
            CrossRoad.Create((100, -100), BuildingMaterial.Ground, city.Id),
            CrossRoad.Create((100, 10), BuildingMaterial.Ground, city.Id),
        };

        var roads = new List<Road>();
        int x = 0;
        int z = 10;
        for (int i = 0; i < 10; i++)
        {
            x += 10;
            z -= 10;
            roads.Add(Road.Create((x, -100), BuildingRotation.Ninety, BuildingMaterial.Ground, city.Id));
            roads.Add(Road.Create((x, 10), BuildingRotation.Ninety, BuildingMaterial.Ground, city.Id));
            roads.Add(Road.Create((-10, z), BuildingRotation.Ninety, BuildingMaterial.Ground, city.Id));
            roads.Add(Road.Create((100, z), BuildingRotation.Ninety, BuildingMaterial.Ground, city.Id));
        }

        return new(city, bankAccount, government, townhall, square, crossroads, roads);
    }
}