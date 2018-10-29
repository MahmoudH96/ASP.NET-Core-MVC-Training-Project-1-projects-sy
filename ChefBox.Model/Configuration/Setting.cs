using System.ComponentModel.DataAnnotations.Schema;

namespace ChefBox.Model.Configuration
{
    [Table("Settings", Schema = "Configuration")]
    public class Setting
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
