﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAgency.Service.Mapping.PackageTripDestination_Entity
{
    public partial class PackageTripDestinationProfile : Profile
    {
        public PackageTripDestinationProfile()
        {
            AddPackageTripDestinationMapping();
            UpdatePackageTripDestinationMapping();
            GetPackageTripDestinationByIdMapping();
        }
    }
}
