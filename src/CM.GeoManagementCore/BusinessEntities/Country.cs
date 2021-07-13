using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using Newtonsoft.Json;

namespace CM.GeoManagementCore.BusinessEntities
{
    [Serializable]
    public class Country
    {
        private static Mapper _mapper;

        [Required]
        public string CountryCode { get; set; }

        public string CountryName { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public void AddRegion(Region region)
        {
            if (region.CountryCode != CountryCode)
                throw new GeoException("Region must belong to current country.");

            Regions.Add(region);
        }

        static Country()
        {
            _mapper = new Mapper(new MapperConfiguration((conf) =>
            {
                conf.CreateMap<Country, Country>();
                conf.CreateMap<Region, Region>();
            }));
        }

        public Country Clone()
        {
            var country = (Country) this.MemberwiseClone();
            country.Regions = this
                .Regions?
                .Select(x => x.Clone()).ToList();

            return country;

           // var json = JsonConvert.SerializeObject(this);
            //return JsonConvert.DeserializeObject<Country>(json);
            return _mapper.Map<Country>(this);
        }
    }
}
