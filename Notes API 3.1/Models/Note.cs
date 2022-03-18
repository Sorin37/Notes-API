using System;
using System.ComponentModel.DataAnnotations;

namespace Notes_API_3._1
{
    public class Note
    {
        [Required] public string? Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "OwnerId Error")]
        public Guid OwnerId { get; set; }
    }
}
