﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAgency.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List <Destination>? Destinations { get; set; }
        public List <Hotel>? Hotels { get; set; } 

    }
}
