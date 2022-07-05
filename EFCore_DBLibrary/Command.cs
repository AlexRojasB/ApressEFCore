using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DBLibrary
{
    public partial class Command
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string HowTo { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string CommandLine { get; set; } = null!;
    }
}
