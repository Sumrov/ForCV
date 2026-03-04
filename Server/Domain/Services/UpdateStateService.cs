using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Services;

public class UpdateStateService
{
    public async Task UpdateElectionState()
    {

    }

    public async Task UpdateLegislativeVotingState()
    {

    }

    public async Task UpdateCitizenLocationState(CitizenId citizenId)
    {

    }

    //        // TODO возможно перенести все методы в другое место что бы не захломлять стартовую загрузку?
    //        await updateDataByServerService.TryFinishedElection(citizen.Location.CityLocation.GovernmentId);
    //        //await governmentService.TryCalculateLegislativeVotings(citizen.Location.CityLocation.SquareId);
    //        //await governmentService.TryCalculateRegionLeaderDocuments(citizen.Location.CityLocation.SquareId);
    //        //await governmentService.CalculateFinishVotings(citizen.Location.CityLocation.SquareId);
    //        await citizenService.TryUpdateCitizenLocation(citizen);
    //        await contextRepository.SaveChangesAsync();
    ////public class UpdateDataByServerService(IBranchRepository branchRepository, ESLOnlineDbContext context, IDeliveryOrderRepository deliveryOrderRepository, IContextRepository contextRepository, IGovernmentRepository governmentRepository, ITransactionService transactionService) : IUpdateDataByServerService
    ////{
    //    //public async Task TryCalculateLegislativeVotings(int governmentId)
    //    //{
    //    //    GovernmentSpecification governmentSpecification = new(
    //    //        id: governmentId,
    //    //        include_LegislativeVotings: true,
    //    //        include_LegislativeVotings_Votes: true);
    //    //    if (await governmentRepository.SingleOrDefaultAsync(governmentSpecification) is not Government government)
    //    //        return;

    //    //    //int squareId = government.Location.Buildings.OfType<Square>().Single().Id;
    //    //    //Protest? protest = protestCacheService.GetProtest(squareId);
    //    //    //if (protest != null)
    //    //    //    government.LegislativeVotings.Add(protest.ProtestVoting);

    //    //    // Проверка времени
    //    //    //DateTime deadline = government.LegislativeLastCalculateLegislativeVotings.AddDays(ShareGameSettings.LegislativeCalculateVotingsCycle);
    //    //    //if (deadline > DateTime.UtcNow)
    //    //    //    return;

    //    //    for (int branch = 0; branch < government.LegislativeVotings.Count; branch++)
    //    //    {
    //    //        LegislativeVoting voting = government.LegislativeVotings[branch];
    //    //        int countSupport = voting.Votes.Count(o => o.Support);
    //    //        int countUnsupport = voting.Votes.Count(o => !o.Support);
    //    //        if (voting.Stage == StageGovermentVoting.Legislative)
    //    //        {
    //    //            if (countSupport > countUnsupport)
    //    //                voting.Stage = StageGovermentVoting.LeaderCabinet;
    //    //            else
    //    //                context.VoteNoHandler(voting);
    //    //        }
    //    //        else if (voting.Stage == StageGovermentVoting.LegislativeSecond)
    //    //        {
    //    //            if (countSupport > countUnsupport) // TODO добавить 75% а не просто больше чем отрицательных
    //    //                voting.Stage = StageGovermentVoting.Finish;
    //    //            else
    //    //                context.VoteNoHandler(voting);
    //    //        }
    //    //    }
    //    //    context.SaveChanges();
    //    //}

    //    //TODO доделать метод все калькуляции должны быть каким то образом для всех регионов а не только для того в который вошли(?)
    //    //public async Task TryCalculateRegionLeaderDocuments(int governmentId)
    //    //{
    //    //    GovernmentSpecification governmentSpecification = new(
    //    //        id: governmentId,
    //    //        include_LegislativeVotings: true,
    //    //        include_LegislativeVotings_Votes: true);
    //    //    if (await governmentRepository.SingleOrDefaultAsync(governmentSpecification) is not Government government)
    //    //        return;

    //    //    //int squareId = government.Location.Buildings.OfType<Square>().Single().Id;
    //    //    //Protest? protest = protestCacheService.GetProtest(squareId);
    //    //    //if (protest != null)
    //    //    //    government.LegislativeVotings.Add(protest.ProtestVoting);

    //    //    if (!government.LegislativeVotings.Any(o => o.Stage == StageGovermentVoting.LeaderCabinet))
    //    //        return;

    //    //    // проверка времени
    //    //    //DateTime deadline = government.RegionLeaderLastCalculateLegislativeVotings.AddDays(GameSettings.RegionLeaderCalculateLegislativeVotingCooldown);
    //    //    //if (deadline > DateTime.UtcNow)
    //    //    //    return;

    //    //    for (int branch = 0; branch < government.LegislativeVotings.Count; branch++)
    //    //    {
    //    //        LegislativeVoting legislativeVoting = government.LegislativeVotings[branch];
    //    //        context.RemoveRange(legislativeVoting.Votes);
    //    //        legislativeVoting.Stage = StageGovermentVoting.LegislativeSecond;
    //    //    }

    //    //    government.RegionLeaderLastCalculateLegislativeVotings = DateTime.UtcNow;

    //    //    context.SaveChanges();
    //    //}

    //    //public async Task CalculateFinishVotings(int governmentId)
    //    //{
    //    //    // TODO дописать подгрузку напрямую из таблицы LegislativeVotings
    //    //    GovernmentSpecification governmentSpecification = new(
    //    //        id: governmentId,
    //    //        include_LegislativeVotings: true,
    //    //        include_LegislativeVotings_Votes_asHireHeadDepartment_Candidate: true);
    //    //    if (await governmentRepository.SingleOrDefaultAsync(governmentSpecification) is not Government government)
    //    //        return;

    //    //    //int squareId = government.Location.Buildings.OfType<Square>().Single().Id;
    //    //    //Protest? protest = protestCacheService.GetProtest(squareId);
    //    //    //if (protest != null && protest.ProtestVoting.Stage == StageGovermentVoting.Finish)
    //    //    //    await protest.ProtestVoting.Apply(governmentId, governmentRepository);

    //    //    List<LegislativeVoting> legislativeVotings = [.. government.LegislativeVotings.Where(o => o.Stage == StageGovermentVoting.Finish)];
    //    //    foreach (var branch in legislativeVotings)
    //    //        await branch.Apply(governmentId, governmentRepository, protestCacheService);

    //    //    context.RemoveRange(legislativeVotings);
    //    //    context.SaveChanges();
    //    //}

    //    public async Task TryFinishedElection(int governmentId)
    //    {
    //        GovernmentSpecification governmentSpecification = new(
    //            id: governmentId,
    //            include_RegionLeader: true,
    //            include_Legislators: true,
    //            include_LegislativeVotings: true,
    //            include_Codex: true,
    //            include_GovernmentElectionVoting_Candidates: true,
    //            include_GovernmentElectionVoting_Votes: true);
    //        if (await governmentRepository.SingleOrDefaultAsync(governmentSpecification) is not Government government)
    //            return;

    //        if (government.GovernmentElectionVoting.StartElectionTime > DateTime.UtcNow)
    //            return;

    //        if (government.GovernmentElectionVoting is RegionLeader)
    //            await TryFinishedRegionLeaderElection(government);
    //        else if (government.GovernmentElectionVoting is Legislative)
    //            await TryFinishedLegislativeElection(government);
    //        else
    //            throw new Exception();
    //    }

    //    public async Task TryFinishedRegionLeaderElection(Government government)
    //    {
    //        // Проверка на возможность выборов
    //        if (government.Codex.LeaderPeriod == LeaderPeriod.Unlimited)
    //            return;

    //        ////проверка истекло ли время выборов
    //        //DateTime deadline = government.GovernmentElectionVoting.StartElectionTime.AddDays(GameSettings.GovernmentElectionDays);
    //        //if (DateTime.UtcNow < deadline)
    //        //    return;

    //        // поиск выигрывшего
    //        int? winnerId = government.GovernmentElectionVoting.Votes
    //            .GroupBy(v => v.CandidateId)
    //            .OrderByDescending(g => g.Count())
    //            .FirstOrDefault()?.Key;
    //        Citizen? winner = government.GovernmentElectionVoting.Candidates
    //            .FirstOrDefault(c => c.Id == winnerId);

    //        // продление выборов
    //        if (winner == null)
    //            government.GovernmentElectionVoting.StartElectionTime = DateTime.UtcNow;

    //        // инагурация
    //        government.RegionLeader = winner;

    //        government.RegionLeaderLastElection = DateTime.UtcNow;

    //        // назначаются новые выборы
    //        if ((government.Codex.LegislatorsCount != LegislatorsCount.Zero) && (government.GovernmentElectionVoting is RegionLeader regionLeader) && (!regionLeader.IsSelfFireReason))
    //        {
    //            government.GovernmentElectionVoting = new Legislative(false);
    //        }
    //        else
    //        {
    //            government.GovernmentElectionVoting = new RegionLeader(false)
    //            {
    //                StartElectionTime = DateTime.UtcNow.AddDays((int)government.Codex.LeaderPeriod * 12)
    //            };
    //        }

    //        await contextRepository.SaveChangesAsync();
    //    }

    //    public async Task TryFinishedLegislativeElection(Government government)
    //    {
    //        // Проверка на возможность выборов
    //        if (government.Codex.LegislatorsCount == LegislatorsCount.Zero)
    //            return;

    //        //проверка истекло ли время выборов
    //        DateTime deadline = government.GovernmentElectionVoting!.StartElectionTime.AddDays(GameRules.GovernmentElectionDays);
    //        if (DateTime.UtcNow < deadline)
    //            return;

    //        // поиск выигрывшего
    //        var winners = government.GovernmentElectionVoting.Votes
    //            .GroupBy(v => v.CandidateId)
    //            .OrderByDescending(g => g.Count())
    //            .Take((int)government.Codex.LegislatorsCount) // берём столько кандидатов, сколько мест
    //            .Select(g => government.GovernmentElectionVoting.Candidates.First(c => c.Id == g.Key))
    //            .ToList();

    //        // продление выборов
    //        if (winners.Count == 0)
    //        {
    //            government.GovernmentElectionVoting.StartElectionTime = DateTime.UtcNow;
    //            return;
    //        }

    //        // инагурация
    //        government.Legislators = winners;

    //        // Сброс законопроектов и сроков
    //        government.LegislativeLastCalculateLegislativeVotings = DateTime.UtcNow;
    //        contextRepository.RemoveRange(government.LegislativeVotings);

    //        // назначаются новые выборы
    //        government.GovernmentElectionVoting = new RegionLeader(false)
    //        {
    //            StartElectionTime = DateTime.UtcNow.AddDays((int)government.Codex.LeaderPeriod * 12)
    //            //StartElectionTime = IsRegionLeaderLostPosition ? DateTime.UtcNow : DateTime.UtcNow.AddDays((int)government.Codex.HeadRegionPeriod * 12)
    //        };

    //        await contextRepository.SaveChangesAsync();
    //    }

    //    // пробуем списать деньги если нет то можно выселять
    //    public async Task TryGetPayFromRenter(RoomRentContract contract, int currencyId)
    //    {
    //        if (DateTime.UtcNow < contract.NextPay)
    //            return;

    //        var (successful, _) = await transactionService.CreateOperation(
    //            contract.RenterId,
    //            contract.Room.OwnerId,
    //            contract.Pay,
    //            currencyId,
    //            [TransactionType.Rent, TransactionType.HomeRoom]);

    //        if (successful)
    //            contract.NextPay = DateTime.UtcNow.AddDays(contract.PayPeriod);
    //    }

    //    public async Task TryGetPenaltyFromRenter(RoomRentContract contract, int currencyId)
    //    {
    //        var (successful, _) = await transactionService.CreateOperation(
    //            contract.RenterId,
    //            contract.Room.OwnerId,
    //            contract.Pay,
    //            currencyId,
    //            [TransactionType.Rent, TransactionType.HomeRoom]);

    //        if (!successful)
    //        {
    //            // TODO добавляем долг
    //        }
    //    }

    //    // TODO потом сделать логистические компании и только они могут доставлять товары там же цены, возвратный склад указываеться в машине, в доставку указать товары, доставка может жить отдельно от машины, тоесть товары застревают на складе курьерской службы и клиенты могут получить свои товары уплатив доставку через уведомления на почте
    //    //public async Task UpdateDeliveryState()
    //    //{
    //    //    DeliveryOrderSpecification deliveryOrderSpecification = new(
    //    //        include_Vehicle_BuildingLocation: true,
    //    //        include_Target_Location: true);
    //    //    List<DeliveryOrder> orders = await deliveryOrderRepository.ToListAsync(deliveryOrderSpecification);
    //    //    if (orders.Count == 0)
    //    //        return;

    //    //    List<DeliveryOrder> readyOrders = [.. orders
    //    //        .Where(o =>
    //    //        {
    //    //            DateTime readyTime = o.StartTime.Add(SharesFunctions.CalculateTravelTime2D(
    //    //                o.Vehicle.BuildingLocation.Position,
    //    //                o.Target.Location.Position));
    //    //            return DateTime.UtcNow > readyTime;
    //    //        })];

    //    //    foreach (var branch in readyOrders)
    //    //    {
    //    //        // TODO убрать приведения
    //    //        double goodWeight = (double)branch.Vehicle.Baggage.Sum(o => (decimal)o.Weight);

    //    //        if (branch.IsCanceled)
    //    //        {
    //    //            double distance = SharesFunctions.CalculateDistance2D(branch.Vehicle.BuildingLocation.Position, branch.ReturnWarehouse.Location.Position);
    //    //            SetDebaf(distance, goodWeight, branch.Vehicle);

    //    //            uint goodVolume = (uint)branch.Vehicle.Baggage.Sum(o => (decimal)o.Volume);
    //    //            uint roomFreeVolume = branch.Target.GetFreeVolumeCapacity();

    //    //            //проверка вместимости помещения
    //    //            if (goodVolume > roomFreeVolume)
    //    //            {
    //    //                //TODO уведомление 
    //    //            }
    //    //            else
    //    //            {
    //    //                branch.Target.Warehouse.AddRange(branch.Vehicle.Baggage);
    //    //                branch.Vehicle.Baggage.Clear();
    //    //            }
    //    //            contextRepository.Remove(branch);
    //    //        }
    //    //        else
    //    //        {
    //    //            // TODO убрать приведения
    //    //            double distance = SharesFunctions.CalculateDistance2D(branch.Vehicle.BuildingLocation.Position, branch.Target.Location.Position);
    //    //            SetDebaf(distance, goodWeight, branch.Vehicle);

    //    //            uint goodVolume = (uint)branch.Vehicle.Baggage.Sum(o => (decimal)o.Volume);
    //    //            uint roomFreeVolume = branch.ReturnWarehouse.GetFreeVolumeCapacity();

    //    //            //проверка вместимости помещения
    //    //            if (goodVolume > roomFreeVolume)
    //    //            {
    //    //                branch.IsCanceled = true;
    //    //            }
    //    //            else
    //    //            {
    //    //                branch.Target.Warehouse.AddRange(branch.Vehicle.Baggage);
    //    //                branch.Vehicle.Baggage.Clear();
    //    //                contextRepository.Remove(branch);
    //    //            }
    //    //        }
    //    //    }
    //    //}
    //    public async Task UpdateDeliveryState()
    //    {
    //        DeliveryOrderSpecification deliveryOrderSpecification = new(
    //            isReady: true,
    //            include_Vehicle_Baggage: true,
    //            include_Target_Warehouse: true);
    //        List<DeliveryOrder> orders = await deliveryOrderRepository.ToListAsync(deliveryOrderSpecification);
    //        if (orders.Count == 0)
    //            return;

    //        foreach (var i in orders)
    //        {
    //            SetDebaf(i.Distance, i.Vehicle);

    //            i.Target.Warehouse.AddRange(i.Vehicle.Baggage);
    //            i.Vehicle.Baggage.Clear();
    //            contextRepository.Remove(i);
    //        }
    //    }

    //    private static void SetDebaf(double distance, Vehicle vehicle)
    //    {
    //        // TODO убрать приведения
    //        double goodWeight = (double)vehicle.Baggage.Sum(o => (decimal)o.Weight);
    //        double needFuel = SharesFunctions.CalculateFuelConsumption(distance, vehicle.Power, goodWeight);
    //        double needCondition = SharesFunctions.CalculateVehicleDurabilityLoss(distance, goodWeight);

    //        //амортизация
    //        //расход топлива
    //        vehicle.Tank -= (float)needFuel;
    //        vehicle.Condition -= (float)needCondition;

    //        // TODO добавить усталость волителю
    //    }

    //    public void UpdateDeliveryStateByDestination(Room destination)
    //    {

    //    }

    //    //TODO добавить амортизацию оборуованм
    //    //TODO добавить дебафы работникам (из расчета 12 часов в ноль угоняет усталость)
    //    //TODO возможно декомпозировать метод где вычисления связанные с максимумов отдельно вынести
    //    public async Task UpdateProductionProgress(int companyId)
    //    {
    //        //BranchSpecification branchSpecification = new(
    //        //isProduction: true);

    //        List<Production> branches = await context.Productions
    //            .Include(o => o.Company)
    //            .Include(o => o.Workers)
    //            .Include(o => o.Room)
    //            .ThenInclude(o => o.Warehouse)
    //            .Include(o => o.Room)
    //            .ThenInclude(o => o.Location)
    //            .Where(o => o.CompanyId == companyId && o.Workers.Count != 0 && o.Room != null)
    //            .ToListAsync();

    //        foreach (var branch in branches)
    //        {
    //            IReadOnlyCollection<double> workerEffectivity = [.. branch.Workers.Select(o => o.Productivity)];
    //            TimeSpan period = DateTime.UtcNow.Subtract(branch.LastUpdateProductedGoods);

    //            Equipment? equipment = branch.Room.Warehouse
    //                .OfType<Equipment>()
    //                .FirstOrDefault(f => f.CanProductions.Any(a => a == branch.ProductionType));

    //            int rawMaterial = branch.Room.Warehouse
    //                .Count(c => c.GetType() == equipment?.RawMaterial);

    //            //TODO ужасный свитч кейс
    //            rawMaterial = branch.ProductionType switch
    //            {
    //                ProductionType.Material => int.MaxValue,
    //                ProductionType.Alcohol => int.MaxValue,
    //                ProductionType.Grocery => int.MaxValue,
    //                ProductionType.AmmunitionEquipment => int.MaxValue,
    //                ProductionType.ArmorEquipment => int.MaxValue,
    //                ProductionType.DevelopingEquipment => int.MaxValue,
    //                ProductionType.GeneralEquipment => int.MaxValue,
    //                ProductionType.MedicalEquipment => int.MaxValue,
    //                ProductionType.CitizenVehicleEquipment => int.MaxValue,
    //                ProductionType.MilitaryVehicleEquipment => int.MaxValue,
    //                ProductionType.CitizenVehicleRepairEquipment => int.MaxValue,
    //                ProductionType.MilitaryVehicleRepairEquipment => int.MaxValue,
    //                ProductionType.WeaponEquipment => int.MaxValue,
    //                ProductionType.Fuel => int.MaxValue,
    //            };

    //            int roomFreeVolume = (int)branch.Room.GetFreeVolumeCapacity();

    //            //TODO ужасный свитч кейс
    //            int roomFreeVolumeForGood = branch.ProductionType switch
    //            {
    //                ProductionType.Material => roomFreeVolume / (int)ShareGameSettings.MaterialVolume,
    //                ProductionType.Alcohol => roomFreeVolume / (int)ShareGameSettings.AlcoholVolume,
    //                ProductionType.Grocery => roomFreeVolume / (int)ShareGameSettings.GroceryVolume,
    //                ProductionType.AmmunitionEquipment => roomFreeVolume / (int)ShareGameSettings.AmmunitionEquipmentVolume,
    //                ProductionType.ArmorEquipment => roomFreeVolume / (int)ShareGameSettings.ArmorEquipmentEquipmentVolume,
    //                ProductionType.DevelopingEquipment => roomFreeVolume / (int)ShareGameSettings.DevelopingEquipmentVolume,
    //                ProductionType.GeneralEquipment => roomFreeVolume / (int)ShareGameSettings.GeneralEquipmentVolume,
    //                ProductionType.MedicalEquipment => roomFreeVolume / (int)ShareGameSettings.MedicalEquipmentVolume,
    //                ProductionType.CitizenVehicleEquipment => roomFreeVolume / (int)ShareGameSettings.CitizenVehicleEquipmentVolume,
    //                ProductionType.MilitaryVehicleEquipment => roomFreeVolume / (int)ShareGameSettings.MilitaryVehicleEquipmentVolume,
    //                ProductionType.CitizenVehicleRepairEquipment => roomFreeVolume / (int)ShareGameSettings.CitizenVehicleRepairEquipmentVolume,
    //                ProductionType.MilitaryVehicleRepairEquipment => roomFreeVolume / (int)ShareGameSettings.MilitaryVehicleRepairEquipmentVolume,
    //                ProductionType.WeaponEquipment => roomFreeVolume / (int)ShareGameSettings.WeaponEquipmentVolume,
    //                ProductionType.Fuel => roomFreeVolume / (int)ShareGameSettings.FuelVolume,
    //                ProductionType.CitizenVehicle => roomFreeVolume / (int)ShareGameSettings.CitizenVehicleVolume,
    //                ProductionType.MilitaryVehicle => roomFreeVolume / (int)ShareGameSettings.MilitaryVehicleVolume,
    //                ProductionType.Ammunition => roomFreeVolume / (int)ShareGameSettings.AmmunitionVolume,
    //                ProductionType.Armor => roomFreeVolume / (int)ShareGameSettings.ArmorVolume,
    //                ProductionType.Drug => roomFreeVolume / (int)ShareGameSettings.DrugVolume,
    //                ProductionType.Medical => roomFreeVolume / (int)ShareGameSettings.MedicalVolume,
    //                ProductionType.Weapon => roomFreeVolume / (int)ShareGameSettings.WeaponVolume,
    //                _ => throw new NotImplementedException(),
    //            };

    //            //TODO добавить вычитание сырья
    //            uint maxProduced = (uint)Math.Min(
    //                roomFreeVolumeForGood,
    //                rawMaterial);

    //            //TODO добавить время и обновлять последний апдейт не на текущее а на это время
    //            var result = SharesFunctions.CalculateProducedAmount(
    //                (int)period.TotalMinutes,
    //                GameRules.CountGoodsPerMinute,
    //                workerEffectivity,
    //                equipment == null ? 1 : 1, //TODO доделать
    //                (int)maxProduced);

    //            if (result < 1)
    //                continue;

    //            for (int i = 0; i < result; i++)
    //            {
    //                //TODO ужасный свитч кейс
    //                dynamic good = branch.ProductionType switch
    //                {
    //                    ProductionType.Material => new Material(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.CitizenVehicle => new CitizenVehicle(branch.Room, branch.Company, branch.Company, 100, 100, 4, 100, 100), //TODO убрать хардкод
    //                    ProductionType.MilitaryVehicle => new MilitaryVehicle(branch.Room, branch.Company, branch.Company, 100, 100, 4, 100, 100),
    //                    ProductionType.Alcohol => new Alcohol(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Ammunition => new Ammunition(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Armor => new Armor(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Drug => new Drug(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Grocery => new Grocery(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Medical => new Medical(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Weapon => new Weapon(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.AmmunitionEquipment => new AmmunitionEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.ArmorEquipment => new ArmorEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.DevelopingEquipment => new DevelopingEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.GeneralEquipment => new GeneralEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.MedicalEquipment => new MedicalEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.CitizenVehicleEquipment => new CitizenVehicleEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.MilitaryVehicleEquipment => new MilitaryVehicleEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.CitizenVehicleRepairEquipment => new CitizenVehicleEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.MilitaryVehicleRepairEquipment => new MilitaryVehicleEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.WeaponEquipment => new WeaponEquipment(branch.Room, branch.Company, branch.Company),
    //                    ProductionType.Fuel => new Fuel(branch.Room, branch.Company, branch.Company),
    //                    _ => throw new NotImplementedException(),
    //                };

    //                branches.Single(o => o.Id == branch.Id).Room.Warehouse.Add(good);
    //                context.Add(good);
    //            }
    //            branches.Single(o => o.Id == branch.Id).LastUpdateProductedGoods = DateTime.UtcNow;
    //            await context.SaveChangesAsync();
    //        }
    //    }

    //    public void UpdateConstructionProgectProgress()
    //    {
    //        //throw new NotImplementedException();
    //    }

    //    public async Task UpdateCompanyVotings(Company company, IContextRepository contextRepository)
    //    {
    //        //int daysAfterCalculateVoting = (int)DateTime.UtcNow.Subtract(branch.LastVotingUpdate).TotalDays;
    //        //if(daysAfterCalculateVoting > 3) //TODO убрать хардкод
    //        //    return;

    //        //await contextRepository.EnsureCollectionLoadedAsync(branch, o => o.CompanyVotings);
    //        //await contextRepository.EnsureCollectionLoadedAsync(branch, o => o.SharePackages);
    //        //await contextRepository.EnsureCollectionLoadedAsync(branch, e => e.CompanyVotings, q => q.Include(sp => sp.Votes));

    //        var totalCompanyShares = company.SharePackages.Sum(sp => (decimal)sp.Count);

    //        for (int i = 0; i<company.CompanyVotings.Count; i++)
    //        {
    //            CompanyVoting companyVoting = company.CompanyVotings[i];
    //            // проверка проходит ли количество голосов порог в 50%
    //            if (companyVoting.Votes.Sum(o => (decimal)o.Voter.Count) < totalCompanyShares / 2) // TODO вынести 50% порога
    //            {
    //                contextRepository.RemoveRange(companyVoting.Votes);
    //                contextRepository.Remove(companyVoting);
    //                //branch.CompanyVotings.Remove(companyVoting);
    //                continue;
    //            }

    //            await companyVoting.ApplyVotingResult(transactionService, contextRepository);
    //            contextRepository.RemoveRange(companyVoting.Votes);
    //            contextRepository.Remove(companyVoting);
    //            //branch.CompanyVotings.Remove(companyVoting);
    //        }

    //        company.LastVotingUpdate = DateTime.UtcNow;
    //    }

    //    public async Task UpdateBancruptState(int jurisdictionId)
    //    {
    //        var now = DateTime.UtcNow;

    //        // 1. Загружаем ставки с необходимыми связями
    //        var bids = await context.BancruptAuctionBids
    //            .Include(b => b.Good)
    //            .Include(b => b.Jurisdiction)
    //            .Include(b => b.Bancrupt)
    //            .Where(b => b.Bancrupt.BankruptcyStartTime
    //                .AddHours(ShareGameSettings.HoursForBancruptAuction) <= now)
    //            .Where(b => b.JurisdictionId == jurisdictionId)
    //            .ToListAsync();

    //        if (bids.Count == 0)
    //            return;

    //        // 2. Группируем по товару
    //        var bidsGroupedByGood = bids
    //            .GroupBy(b => b.Good.Id)
    //            .ToList();

    //        // 3. Обрабатываем каждый товар в отдельной транзакции
    //        foreach (var goodBids in bidsGroupedByGood)
    //        {
    //            await using var transaction = await context.Database.BeginTransactionAsync();

    //            try
    //            {
    //                var goodId = goodBids.Key;

    //                // 4. Блокируем товар для обновления (pessimistic lock)
    //                var lockedGood = await context.Set<Domain.Goods.Good>()
    //                    .FromSqlInterpolated($@"
    //                SELECT * FROM Goods WITH (UPDLOCK, ROWLOCK)
    //                WHERE Id = {goodId}")
    //                    .FirstOrDefaultAsync();

    //                if (lockedGood == null)
    //                {
    //                    await transaction.RollbackAsync();
    //                    continue;
    //                }

    //                // 5. Перечитываем ставки с блокировкой
    //                var lockedBids = await context.BancruptAuctionBids
    //                    .FromSqlInterpolated($@"
    //                SELECT * FROM BancruptAuctionBids WITH (UPDLOCK, ROWLOCK)
    //                WHERE GoodId = {goodId} AND JurisdictionId = {jurisdictionId}")
    //                    .Include(b => b.Jurisdiction)
    //                    .Include(b => b.Good)
    //                    .ToListAsync();

    //                if (lockedBids.Count == 0)
    //                {
    //                    await transaction.RollbackAsync();
    //                    continue;
    //                }

    //                // 6. Сортируем ставки
    //                var orderedBids = lockedBids
    //                    .OrderByDescending(b => b.BidAmount)
    //                    .ThenBy(b => b.DateTime)
    //                    .ToList();

    //                BancruptAuctionBid? successfulWinner = null;

    //                // 7. Пытаемся провести операцию
    //                foreach (var bidder in orderedBids)
    //                {
    //                    var (successful, check) = await transactionService.CreateOperation(
    //                        bidder.BidderId,
    //                        bidder.BancruptId,
    //                        bidder.BidAmount,
    //                        bidder.Jurisdiction.CurrencyId,
    //                        [TransactionType.BancruptAuctionBid, bidder.Good.TransactionType]);

    //                    if (successful)
    //                    {
    //                        successfulWinner = bidder;
    //                        break;
    //                    }
    //                }

    //                // 8. Если нашли победителя
    //                if (successfulWinner != null)
    //                {
    //                    lockedGood.OwnerId = successfulWinner.BidderId;
    //                    context.BancruptAuctionBids.RemoveRange(lockedBids);
    //                    await context.SaveChangesAsync();
    //                }

    //                await transaction.CommitAsync();
    //            }
    //            catch (Exception ex)
    //            {
    //                await transaction.RollbackAsync();
    //                // Логирование ошибки
    //                // Можно продолжить обработку других товаров или пробросить исключение
    //            }
    //        }

    //        //await using var transaction = await context.Database.BeginTransactionAsync();
    //        //try
    //        //{
    //        //    var now = DateTime.UtcNow;

    //        //    // 1. Загружаем ставки с необходимыми связями за один запрос
    //        //    var bids = await context.BancruptAuctionBids
    //        //        .Include(b => b.Good)
    //        //        .Include(b => b.Jurisdiction)
    //        //        .Include(b => b.Bancrupt)
    //        //        .Where(b => b.Bancrupt.BankruptcyStartTime
    //        //            .AddHours(ShareGameSettings.HoursForBancruptAuction) <= now)
    //        //        .Where(b => b.JurisdictionId == jurisdictionId)
    //        //        .ToListAsync();

    //        //    if (bids.Count == 0)
    //        //        return;

    //        //    // 2. Группируем в памяти (уже загружено)
    //        //    var bidsGroupedByGood = bids
    //        //        .GroupBy(b => b.Good.Id)
    //        //        .ToList();

    //        //    // 3. Обрабатываем каждый товар
    //        //    foreach (var goodBids in bidsGroupedByGood)
    //        //    {
    //        //        // 4. Сортируем ставки один раз
    //        //        var orderedBids = goodBids
    //        //            .OrderByDescending(b => b.BidAmount)
    //        //            .ThenBy(b => b.DateTime)
    //        //            .ToList();

    //        //        BancruptAuctionBid? successfulWinner = null;

    //        //        // 5. Пытаемся провести операцию с каждым участником по порядку
    //        //        foreach (var bidder in orderedBids)
    //        //        {
    //        //            var (successful, check) = await transactionService.CreateOperation(
    //        //                bidder.BidderId, // Скорее всего нужен BidderId, а не Id ставки
    //        //                bidder.BancruptId,
    //        //                bidder.BidAmount,
    //        //                bidder.Jurisdiction.CurrencyId,
    //        //                [TransactionType.BancruptAuctionBid, bidder.Good.TransactionType]);

    //        //            if (successful)
    //        //            {
    //        //                successfulWinner = bidder;
    //        //                break; // Нашли победителя, выходим
    //        //            }
    //        //        }

    //        //        // 6. Если нашли успешного победителя
    //        //        if (successfulWinner != null)
    //        //        {
    //        //            // Меняем владельца товара
    //        //            successfulWinner.Good.OwnerId = successfulWinner.BidderId;

    //        //            // Удаляем все ставки на этот товар (включая победителя)
    //        //            context.BancruptAuctionBids.RemoveRange(orderedBids);
    //        //        }
    //        //    }

    //        //    // 7. Сохраняем все изменения одним запросом
    //        //    await context.SaveChangesAsync();

    //        //    await transaction.CommitAsync();
    //        //}
    //        //catch
    //        //{
    //        //    await transaction.RollbackAsync();
    //        //    throw;
    //        //}

    //        //var now = DateTime.UtcNow;

    //        ////Беру все ставки у которых истекло время
    //        //List<BancruptAuctionBid> bids = await context.BancruptAuctionBids
    //        //    .Where(o => o.Bancrupt.BankruptcyStartTime.AddHours(ShareGameSettings.HoursForBancruptAuction) <= now)
    //        //    .Where(b => b.JurisdictionId == jurisdictionId)
    //        //    .ToListAsync();

    //        ////группирую ставки по товарам
    //        //var bidsGroupedByGood = bids.GroupBy(o => o.Good.Id).ToList();

    //        ////перебираю все ставки для каждого товара
    //        //foreach (var branch in bidsGroupedByGood)
    //        //{
    //        //    ////нахожу победителя
    //        //    //BancruptAuctionBid? winner = branch
    //        //    //    .OrderByDescending(b => b.BidAmount)
    //        //    //    .ThenBy(b => b.DateTime)
    //        //    //    .FirstOrDefault();

    //        //    List<BancruptAuctionBid> orderedBids = [.. branch
    //        //        .OrderByDescending(b => b.BidAmount)
    //        //        .ThenBy(b => b.DateTime)];

    //        //    //если ставок нет то пропускаю
    //        //    if (orderedBids.Count == 0)
    //        //        continue;

    //        //    foreach (var winner in orderedBids)
    //        //    {
    //        //        //провожу финансовую операцию
    //        //        var (successful, check) = await transactionService.CreateOperation(
    //        //            winner.Id,
    //        //            winner.BancruptId,
    //        //            winner.BidAmount,
    //        //            winner.Jurisdiction.CurrencyId,
    //        //            [TransactionType.BancruptAuctionBid, winner.Good.TransactionType]);

    //        //        //проверяю прошла ли операция
    //        //        if (successful == false)
    //        //            continue;

    //        //        //меняю права собственности
    //        //        winner.Good.OwnerId = winner.BidderId;
    //        //        await context.SaveChangesAsync();

    //        //        //удаляю все ставки на товар которые не выйграли
    //        //        context.BancruptAuctionBids.RemoveRange(branch.Where(o => o.Id != winner.Id));
    //        //    }
    //    }

    //    public async Task UpdateBancruptCompanyStatus(int jurisdictionId)
    //    {
    //        List<Company> bankruptCompanies = await context.Companies
    //            .Where(o => o.IsBankrupt && o.MyDebts.Count == 0 && o.JurisdictionId == jurisdictionId)
    //            .ToListAsync();

    //        foreach (var i in bankruptCompanies)
    //            i.IsBankrupt = false;

    //        await context.SaveChangesAsync();
    //    }

    //    public async Task UpdateBancruptCompanyStatus()
    //    {
    //        List<Company> bankruptCompanies = await context.Companies
    //            .Where(o => o.IsBankrupt && o.MyDebts.Count == 0)
    //            .ToListAsync();

    //        foreach (var i in bankruptCompanies)
    //            i.IsBankrupt = false;

    //        await context.SaveChangesAsync();
    //    }

    //    //TODO добавить по конкретному региону обновление
    //    public async Task UpdateStopAuctionGovernmentOrdersStatus()
    //    {
    //        DateTime utcNow = DateTime.UtcNow;
    //        DateTime auctionOffset = utcNow.AddDays(-GameRules.GovernmentOrderAuctionPeriod);
    //        DateTime betOffset = utcNow.AddMinutes(-10);

    //        List<GovernmentOrder> orders = [.. context.GovernmentOrders
    //        .Include(o => o.Company)
    //        .Where(o => o.CloseAuction == DateTime.MaxValue
    //                    && o.Company != null
    //                    && o.StartAuction < auctionOffset
    //                    && o.LastUpdateBet < betOffset)];

    //        if (orders.Count == 0)
    //            return;

    //        for (int i = 0; i < orders.Count; i++)
    //        {
    //            GovernmentOrder order = orders[i];
    //            DateTime closeTimeByPeriod = order.StartAuction.AddDays(2);
    //            DateTime closeTimeByLastBet = order.LastUpdateBet.AddMinutes(10);

    //            order.CloseAuction = closeTimeByPeriod > closeTimeByLastBet
    //                ? closeTimeByPeriod
    //                : closeTimeByLastBet;
    //            if (order.Company == null)
    //            {
    //                //TODO сообщение на почту министру
    //                context.Remove(order);
    //            }

    //            // создание проекта строительства для строительной компании
    //            if (order is RoadsOrder roadsOrder)
    //            {
    //                if (order.Company is not Development development)
    //                {
    //                    throw new Exception("Government order company is not development");
    //                }

    //                await contextRepository.EnsureCollectionLoadedAsync(roadsOrder, o => o.Roads);

    //                foreach (var road in roadsOrder.Roads)
    //                {
    //                    ConstructionProject project = new(false, development, road);
    //                    road.IsDraft = false;
    //                    context.Add(project);
    //                }
    //            }
    //        }

    //        await context.SaveChangesAsync();
    //    }

    //    //TODO добавить по конкретному региону обновление
    //    public async Task CompleteGovernmentOreder()
    //    {
    //        List<GovernmentOrder> orders = [.. context.GovernmentOrders
    //        .Where(o => o.CloseAuction != DateTime.MaxValue
    //                    && o.Company != null
    //                    && o.CloseAuction.AddDays(o.WorkPeriod) < DateTime.UtcNow)];

    //        if (orders.Count == 0)
    //            return;

    //        for (int i = 0; i < orders.Count; i++)
    //        {
    //            GovernmentOrder order = orders[i];
    //            bool result = await order.Complete(context);
    //            if (result)
    //            {
    //                var deposit = SharesFunctions.CalculateDeposit(
    //                    order.Budget,
    //                    order.Bet);

    //                result = await transactionService.CreateOperationGovernmentOrderDeposit(
    //                    order.Company.Id,
    //                    (ulong)deposit,
    //                    order.Government.CurrencyId,
    //                    true);
    //                if (result == false)
    //                    throw new Exception();

    //                (bool successful, Check? check) = await transactionService.CreateOperation(
    //                    order.GovernmentId,
    //                    order.Company.Id,
    //                    order.Bet,
    //                    order.Government.CurrencyId,
    //                    [TransactionType.GovernmentOrder]);
    //                if (successful == false)
    //                    throw new Exception();
    //            }
    //            //если не исполнено
    //            else
    //            {
    //                ulong deposit = (ulong)SharesFunctions.CalculateDeposit(order.Budget, order.Bet);
    //                Government government = await context.Governments.SingleAsync(o => o.Id == order.GovernmentId);
    //                await transactionService.CreateOperationGovernmentOrderAddDepositToGovernment(government.Id, deposit, government.CurrencyId);
    //            }
    //            context.Remove(order);
    //            await context.SaveChangesAsync();
    //        }
    //    }

    //    //var now = DateTime.UtcNow;

    //    //// 1. Берём всех банкротов в указанной юрисдикции
    //    //var expiredBankrupts = await context.Companies
    //    //    .Where(s => s.IsBankrupt
    //    //                && s.BankruptcyStartTime.AddHours(ShareGameSettings.HoursForBancruptAuction) <= now
    //    //                && s.JurisdictionId == jurisdictionId)
    //    //    .ToListAsync();

    //    //foreach (var bankrupt in expiredBankrupts)
    //    //{
    //    //    await using var transaction = await context.Database.BeginTransactionAsync();

    //    //    // 2. Блокируем банкрота
    //    //    Company? lockedBankrupt = await context.Companies
    //    //        .FromSqlInterpolated($@"
    //    //        SELECT * FROM Subjects WITH (UPDLOCK, ROWLOCK)
    //    //        WHERE Id = {bankrupt.Id} AND IsBankrupt = 1 AND JurisdictionId = {jurisdictionId}")
    //    //        .FirstOrDefaultAsync();

    //    //    if (lockedBankrupt == null)
    //    //    {
    //    //        await transaction.RollbackAsync();
    //    //        continue;
    //    //    }

    //    //    // 3. Получаем ставки только для этой юрисдикции
    //    //    List<BancruptAuctionBid> bids = await context.BancruptAuctionBids
    //    //        .Where(b => b.BancruptId == bankrupt.Id && b.JurisdictionId == jurisdictionId)
    //    //        .ToListAsync();

    //    //    if (bids.Count==0)
    //    //    {
    //    //        await transaction.RollbackAsync();
    //    //        continue;
    //    //    }

    //    //    BancruptAuctionBid? winner = null;

    //    //    foreach (var branch in bids)
    //    //    {
    //    //        // 4. Победитель
    //    //        winner = bids
    //    //            .OrderByDescending(b => b.BidAmount)
    //    //            .ThenBy(b => b.DateTime)
    //    //            .First();

    //    //        // 5. Финансовая операция
    //    //        var (successful, check)= await transactionService.CreateOperation(
    //    //            winner.Id,
    //    //            lockedBankrupt.Id,
    //    //            winner.BidAmount,
    //    //            lockedBankrupt.Jurisdiction.CurrencyId,
    //    //            [TransactionType.BancruptAuctionBid, winner.Good.TransactionType]);

    //    //        if (successful == false)
    //    //            continue;

    //    //        //передача прав собственности
    //    //        winner.Good.OwnerId = winner.BidderId;

    //    //        await context.SaveChangesAsync();
    //    //    }

    //    //    // 6. Удаляем проигравшие ставки
    //    //    await context.Database.ExecuteSqlInterpolatedAsync($@"
    //    //    DELETE FROM BancruptAuctionBids
    //    //    WHERE BancruptId = {bankrupt.Id} AND JurisdictionId = {jurisdictionId} AND Id <> {winner?.Id};
    //    //    ");

    //    //    await transaction.CommitAsync();
    //    //}
    //    //public async Task UpdateCompanyVotings(Company branch, IContextRepository contextRepository)
    //    //{
    //    //    //await contextRepository.EnsureCollectionLoadedAsync(branch, o => o.CompanyVotings);
    //    //    //await contextRepository.EnsureCollectionLoadedAsync(branch, o => o.SharePackages);
    //    //    //await contextRepository.EnsureCollectionLoadedAsync(branch, e => e.CompanyVotings, q => q.Include(cv => cv.Votes));

    //    //    var totalCompanyShares = branch.SharePackages.Sum(sp => (decimal)sp.Count);

    //    //    // Обратный перебор
    //    //    for (int branch = branch.CompanyVotings.Count - 1; branch >= 0; branch--)
    //    //    {
    //    //        var companyVoting = branch.CompanyVotings[branch];

    //    //        var totalVotes = companyVoting.Votes.Sum(v => (decimal)v.Voter.Count);

    //    //        if (totalVotes < totalCompanyShares)
    //    //        {
    //    //            // Удаляем сначала все голоса
    //    //            foreach (var vote in companyVoting.Votes.ToList())
    //    //            {
    //    //                contextRepository.Remove(vote);
    //    //            }

    //    //            // Потом удаляем сам CompanyVoting
    //    //            contextRepository.Remove(companyVoting);
    //    //            continue;
    //    //        }

    //    //        await companyVoting.ApplyVotingResult(transactionService, contextRepository);

    //    //        // После применения результата удаляем голоса и CompanyVoting
    //    //        foreach (var vote in companyVoting.Votes.ToList())
    //    //        {
    //    //            contextRepository.Remove(vote);
    //    //        }
    //    //        contextRepository.Remove(companyVoting);
    //    //    }

    //    //    branch.LastVotingUpdate = DateTime.UtcNow;
    //    //    await contextRepository.SaveChangesAsync();
    //    //}
    //    //}


    //    //???
    //    //public void UpdateVehicleState(int vehicleId)
    //    //{
    //    //    VehicleDTO vehicle = _context.Vehicles
    //    //        .Include(o => o.Baggage)
    //    //        .Include(o => o.BaseLocation)
    //    //            .ThenInclude(o => o.LocationCenterPosition)
    //    //        .Include(o => o.GasStationLocation)
    //    //            .ThenInclude(o => o.LocationCenterPosition)
    //    //        .Single(o => o.Id == vehicleId);

    //    //    switch (vehicle.State)
    //    //    {
    //    //        case VehicleState.IsReady:
    //    //            break;
    //    //        case VehicleState.DeliveryOrderDTO:
    //    //            DeliveryOrder? deliveryOrder = _context.DeliveryVehicles
    //    //                .Include(o => o.TargetCodex)
    //    //                    .ThenInclude(o => o.LocationCenterPosition)
    //    //                .SingleOrDefault(o => o.Id == vehicle.DeliveryOrderId);
    //    //            if (deliveryOrder == null)
    //    //                return; //TODO обработать и залогировать ошибку

    //    //            TimeSpan officeToDeliveryTime = SharesFunctions.CalculateTravelTime2D(
    //    //                vehicle.BaseLocation.LocationCenterPosition.Position,
    //    //                deliveryOrder.TargetCodex.LocationCenterPosition.Position);
    //    //            TimeSpan NowDifferenceStartMoveTime = DateTime.Now.Subtract(vehicle.StartMoveTime);
    //    //            if (UpdateVehiclePosition(vehicle.Id))
    //    //            {
    //    //                foreach (var i in vehicle.Baggage)
    //    //                    i.Owner = deliveryOrder.Customer;
    //    //                deliveryOrder.TargetCodex.WarehouseId.AddRange(vehicle.Baggage);
    //    //                //vehicle.BuildingLocation = deliveryOrder.TargetCodex.LocationCenterPosition;
    //    //                vehicle.TargetLocation = vehicle.BaseLocation.LocationCenterPosition;
    //    //                vehicle.StartMoveTime = DateTime.Now.AddMinutes(officeToDeliveryTime.TotalMinutes - NowDifferenceStartMoveTime.TotalMinutes);
    //    //                vehicle.State = VehicleState.MoveToOffice;
    //    //            }
    //    //            if (UpdateVehiclePosition(vehicle.Id))
    //    //            {
    //    //                vehicle.State = VehicleState.IsReady;
    //    //            }
    //    //            break;
    //    //        case VehicleState.Gas:
    //    //            vehicle.Tank = vehicle.MaxTank;
    //    //            break;
    //    //        case VehicleState.MoveToOffice:
    //    //            TimeSpan locationToOfficeTime = SharesFunctions.CalculateTravelTime2D(
    //    //                vehicle.BuildingLocation.Position,
    //    //                vehicle.BaseLocation.LocationCenterPosition.Position);
    //    //            TimeSpan DifferenceTime = DateTime.Now.Subtract(vehicle.StartMoveTime);
    //    //            if (DifferenceTime > locationToOfficeTime)
    //    //            {
    //    //                UpdateVehiclePosition(vehicle.Id);
    //    //            }
    //    //            break;
    //    //        default:
    //    //            break;
    //    //    }
    //    //}

    //    //private bool UpdateVehiclePosition(int vehicleId)
    //    //{
    //    //    VehicleDTO vehicle = _context.Vehicles
    //    //        .Include(o => o.TargetLocation)
    //    //        .Include(o => o.BuildingLocation)
    //    //        .Single(o => o.Id == vehicleId);

    //    //    TimeSpan travelTime = DateTime.Now.Subtract(vehicle.StartMoveTime);
    //    //    TimeSpan locationToTargetTime = SharesFunctions.CalculateTravelTime2D(
    //    //                vehicle.BuildingLocation.Position,
    //    //                vehicle.TargetLocation.Position);

    //    //    if (travelTime < locationToTargetTime)
    //    //        return false;

    //    //    vehicle.BuildingLocation = vehicle.TargetLocation;
    //    //    vehicle.TargetLocation = null;
    //    //    //TODO добавить расход топлива
    //    //    vehicle.StartMoveTime = DateTime.MaxValue;
    //    //    return true;
    //    //}
    //}
}
