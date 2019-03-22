using System;
using System.Collections.Generic;
using System.Text;

namespace Houlert.Model
{
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class StatesList
    {
        public List<State> states { get; set; }
    }


    public class Area
    {
        public int id { get; set; }
        public int locality_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class AreaList
    {
        public List<Area> area { get; set; }
    }


    public class Locality
    {
        public int id { get; set; }
        public int state_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class LocalityList
    {
        public List<Locality> locality { get; set; }
    }

}
