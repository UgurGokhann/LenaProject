using LenaProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.Business
{
    public class FieldListDto : IDto
    {
        public string Name { get; set; }
        public string Required { get; set; }
        public string DataType { get; set; }
    }
}
