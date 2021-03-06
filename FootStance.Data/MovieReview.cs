﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Data
{
    public enum MovieGenre
    {
        Action =1,
        Adventure,
        Animation,
        Anime,
        Comedy,
        Crime,
        Drama,
        Fantasy,
        Historical,
        Horror,
        Musical,
        Syfy,
        Thriller,
        War,
        Western
    }

    public class MovieReview
    {
        [Key]
        public int MovieReviewId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string MovieTitle { get; set; }

        [Required]
        [Range(1888,2018, ErrorMessage ="Please Enter a valid year")]
        public string MovieReleaseYear { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public MovieGenre MovieGenre { get; set; }

        [Required]
        public string MovieStance { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Please Enter a rating on a scale of 1-10")]
        public int MovieRating { get; set; }

    }
}
