﻿namespace TripAgency.Service.Feature.Hotel.Commands
{
    public class AddHotelDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int Rate { get; set; }
        public int MidPriceForOneNight { get; set; }
        public int CityId { get; set; }

    }
}
