using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.DataAccess.Entities
{
    public class Form : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
        public List<Field> Fields { get; set; }
    }
}
