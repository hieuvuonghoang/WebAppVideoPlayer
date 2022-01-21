using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceAPI.Models
{
    public class MergeFileModel
    {
        [Required]
        public string FileName { get; set; }
    }
}
