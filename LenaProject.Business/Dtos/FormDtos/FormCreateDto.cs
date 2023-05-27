﻿using LenaProject.Business.Interfaces;
using LenaProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.Business
{
    public class FormCreateDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<Field> Fields { get; set; }
    }
}
