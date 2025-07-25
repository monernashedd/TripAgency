﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAgency.Data.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public IEnumerable<PackageTripDestination> PackageTripDestinations{ get; set; }
        public IEnumerable<TripDestination> TripDestinations { get; set; }
        public IEnumerable<DestinationActivity> DestinationActivities { get; set; }



    }
}
