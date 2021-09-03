using HubService.Enums;
using System.ComponentModel.DataAnnotations;

namespace HubService.Database.Entitties
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
    
        public string Description { get; set; }

        public ProjectDifficulty Difficulty { get; set; }
    }
}
