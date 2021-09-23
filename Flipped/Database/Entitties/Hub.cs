using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubService.Database.Entitties
{
    public class Hub
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }

        public int CreatorId { get; set; }
    }
}
