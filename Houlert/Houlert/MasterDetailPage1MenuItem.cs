﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houlert
{

    public class MasterDetailPage1MenuItem
    {
        public MasterDetailPage1MenuItem()
        {
            TargetType = typeof(AddProperty);
        }
        public int Id { get; set; }
        public string Title { get; set; }
		public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}