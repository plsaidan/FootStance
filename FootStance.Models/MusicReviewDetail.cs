﻿using FootStance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Models
{
    public class MusicReviewDetail
    {
        public int MusicReviewId { get; set; }

        public string Artist { get; set; }

        [Display(Name = "Title")]
        public string MusicTitle { get; set; }

        [Display(Name = "Release Type")]
        public ReleaseType ReleaseType { get; set; }

        [Display(Name = "Genre")]
        public MusicGenreType MusicGenreType { get; set; }

        [Display(Name = "Stance")]
        public string MusicStance { get; set; }

        [Display(Name = "Rating")]
        public int MusicRating { get; set; }
        public override string ToString() => $"[{MusicReviewId}] {Artist} {MusicTitle} ";
    }
}
