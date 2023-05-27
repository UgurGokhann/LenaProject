using LenaProject.DataAccess.Enums;

namespace LenaProject.DataAccess.Entities
{
    public class Field : BaseEntity
    {
        public RequiredType Required { get; set; }
        public string Name { get; set; }
        public DataTypes DataType{ get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }

    }
}
