using EslOnline.SharedKernel.Domain.Attributes;
using EslOnline.SharedKernel.Domain.Constants;

namespace EslOnline.SharedKernel.Domain.Enums;

public enum Position
{
    [AllowedFor(AllowedForMarkers.GevernmentJob)] GeneralManager,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadRegion,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadEnforcement,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadFinancial,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadUrban,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadForeignRelations,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] HeadJusticeId,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] Legislator,
    [AllowedFor(AllowedForMarkers.GevernmentJob)] EnforcmentEmployeer,
    [AllowedFor(AllowedForMarkers.CompanyJob)] ProductionEmployeer,
    [AllowedFor(AllowedForMarkers.CompanyJob)] ConstructionProjectEmployeer,
}