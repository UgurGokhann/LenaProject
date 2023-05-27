using LenaProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.Business
{
    public class FormUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
    }
}
