using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlert.Model;
using Houlert.RestClient;

namespace Houlert.Helper
{
    public class LocationDropDown
    {

        public LocationDropDown()
        {
        }

        /// <summary>
        /// Retun List Of States
        /// </summary>
        /// <returns></returns>
        public async Task<List<State>> GetStates()
        {
            var states = await LocationClient.GetStates();
            return states.ToList();
        }


        /// <summary>
        /// Retun List of Localities
        /// </summary>
        /// <returns></returns>
        /// TODO : Locality will be based on State Selected
        public async Task<List<Locality>> GetLocalities()
        {
            var locality = await LocationClient.GetLocality(1);
            return locality.ToList();
        }

        /// <summary>
        /// Return List of Areas
        /// </summary>
        /// <returns></returns>

        //TODO : Area will be based on Locality Selected
        public async Task<List<Area>> GetArea()
        {
            List<Area> areas;
            areas = await PropertyClient.GetAreas(1);
            return areas.ToList();
            // return PropertyList.ItemsSource = propertyTypes.ToList();
        }
    }
}