using HubService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubService.Database.Entitties
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public int HubId { get; set; }

        [Column(TypeName="varchar(20)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }

        public string Text { get; set; }

        public string Contributors { get; set; }

        public double Credibility { get; set; }

        public LessonDifficulty Difficulty { get; set; }

        public LessonType Type { get; set; }
    }
}
