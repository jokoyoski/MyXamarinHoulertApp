using System;
using System.Collections.Generic;
using System.Text;

namespace Houlert.Model
{
    public class Data
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string user_type { get; set; }
        public object company_id { get; set; }
        public string api_token { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
    }
}
