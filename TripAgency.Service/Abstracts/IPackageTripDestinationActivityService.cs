﻿using TripAgency.Data.Entities;
using TripAgency.Data.Result.TripAgency.Core.Results;
using TripAgency.Service.Feature.PackageTripDestinationActivity.Commands;
using TripAgency.Service.Feature.PackageTripDestinationActivity.Queries;
using TripAgency.Service.Generic;

namespace TripAgency.Service.Abstracts
{
    public interface IPackageTripDestinationActivityService : IWriteService<PackageTripDestinationActivity, AddPackageTripDestinationActivityDto, UpdatePackageTripDestinationActivityDto, GetPackageTripDestinationActivitiesDto>
    {
        public Task<Result<GetPackageTripDestinationActivityByIdDto>> GetPackageTripDestinationActivity( int PackageTripId , int DestinationId ,int ActivityId);
        public Task<Result> DeletePackageTripDestinationActivity( int PackageTripId , int DestinationId ,int ActivityId);
    }
}
