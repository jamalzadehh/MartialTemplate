﻿using MarialaTemplate.Models.Common;

namespace MarialaTemplate.Models
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
