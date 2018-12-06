using FootStance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Models
{
    public class MusicReviewEdit
    {
        public int MusicReviewId { get; set; }

        public string Artist { get; set; }

        public string MusicTitle { get; set; }

        public ReleaseType ReleaseType { get; set; }

        public MusicGenreType MusicGenreType { get; set; }

        public string MusicStance { get; set; }

        [Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10")]
        public int MusicRating { get; set; }

    }
}
