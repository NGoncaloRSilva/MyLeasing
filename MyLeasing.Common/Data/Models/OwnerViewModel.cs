﻿using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data.Models
{
    public class OwnerViewModel : Owner
    {
        
            [Display(Name = "Image")]
            public IFormFile ImageFile { get; set; }
        
    }
}
