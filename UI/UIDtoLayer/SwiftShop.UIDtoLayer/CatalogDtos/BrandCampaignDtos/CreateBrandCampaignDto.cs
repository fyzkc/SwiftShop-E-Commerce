﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.UIDtoLayer.CatalogDtos.BrandCampaignDtos
{
    public class CreateBrandCampaignDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
