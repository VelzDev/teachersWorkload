﻿using System.ComponentModel.DataAnnotations;

namespace teachersWorkload.Concrete
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
