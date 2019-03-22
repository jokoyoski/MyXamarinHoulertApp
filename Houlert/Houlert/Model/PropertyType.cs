using System;
using System.Collections.Generic;
using System.Text;

namespace Houlert.Model
{
    public class PropertyType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertyTypeRoot
    {
        public List<PropertyType> property_type { get; set; }
    }


    public class PropertySubType
    {
        public int id { get; set; }
        public int property_type_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertySubTypeList
    {
        public List<PropertySubType> Property_sub_types { get; set; }
    }


    public class PropertyPurpose
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertyPurposesList
    {
        public List<PropertyPurpose> property_purpose { get; set; }
    }


    public class PropertyUse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public object description { get; set; }
        public int is_active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertyUseList
    {
        public List<PropertyUse> property_use { get; set; }
    }
}