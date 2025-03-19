using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.App.ValueObjects;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Vehicle.App.Vehicle
{
    public class VehicleDataSeedContributor(IRepository<VehicleAggregateRoot, Guid> vehicleRepository) : IDataSeedContributor, ITransientDependency
    {
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await vehicleRepository.GetCountAsync() > 0)
                return;

            List<VehicleAggregateRoot> vehicles = new List<VehicleAggregateRoot>();

            for (int i = 1; i <= 20; i++)
            {
                Guid vehicleId = Guid.NewGuid();
                string vin = $"VIN{i:D17}";
                string make = i % 2 == 0 ? "Toyota" : "BMW";
                string model = i % 2 == 0 ? "Corolla" : "X5";
                string year = (2010 + i % 10).ToString();
                string color = i % 3 == 0 ? "Red" : i % 3 == 1 ? "Blue" : "Black";
                int mileage = i * 1000;
                string licensePlate = $"ABC-{i:D3}";
                Guid storeId = Guid.NewGuid();
                Guid ownerId = Guid.NewGuid();
                var address1 = new AddressValueObject("贵州省", "贵阳市", "南明区", "云岩大道", "123号");
                var address = new AddressValueObject("贵州省", "遵义市", "红花岗区", "新蒲新区", "123号");
                VehicleAggregateRoot vehicle = new VehicleAggregateRoot(vehicleId, vin, make, model, year, color, mileage, licensePlate, storeId, ownerId);
                vehicle.SetAddress(i % 2 == 0 ? address : address1);
                vehicles.Add(vehicle);
            }

            await vehicleRepository.InsertManyAsync(vehicles);
        }
    }
}
