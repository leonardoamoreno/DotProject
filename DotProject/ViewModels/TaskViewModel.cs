using DotProject.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DotProject.ViewModels
{
    public class TaskViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Priority Priority { get; set; }
        public int Status { get; set; }
        public Guid ProjectId { get; set; }
        //public Guid ProjectId { get; set; } = Guid.Empty;
        //public Project Project { get; set; } = null!;
    }
}
