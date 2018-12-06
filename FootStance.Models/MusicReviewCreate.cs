using FootStance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Models
{
    public class MusicReviewCreate
    {
        [Required]
        public string Artist { get; set; }

        [Required]
        public string MusicTitle { get; set; }

        [Required]
        public ReleaseType ReleaseType { get; set; }

        [Required]
        public MusicGenreType MusicGenreType { get; set; }

        [Required]
        public string MusicStance { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Please enter a number between 1 and 10")]
        public int MusicRating { get; set; }

        public override string ToString() => $" {Artist} {MusicTitle} ";



    }
}
