﻿using FootStance.Data;
using FootStance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Services
{
    public class MovieReviewService
    {
        private readonly Guid _userId;

        public MovieReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovieReview(MovieReviewCreate model)
        {
            var entity =
                new MovieReview()
                {
                    OwnerId = _userId,
                    MovieTitle = model.MovieTitle,
                    MovieReleaseYear = model.MovieReleaseYear,
                    Director = model.Director,
                    MovieGenre = model.MovieGenre,
                    MovieStance = model.MovieStance,
                    MovieRating = model.MovieRating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MovieReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieReviewListItem> GetMovieReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .MovieReviews
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new MovieReviewListItem
                            {
                                MovieReviewId = e.MovieReviewId,
                                MovieTitle = e.MovieTitle,
                                MovieReleaseYear = e.MovieReleaseYear,
                                Director = e.Director,
                                MovieGenre = e.MovieGenre,
                                MovieStance = e.MovieStance,
                                MovieRating = e.MovieRating
                            }
                    );
                return query.ToArray();
                    
            }

        }

        public MovieReviewDetail GetMovieReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews
                        .Single(e => e.MovieReviewId == id && e.OwnerId == _userId);
                return
                    new MovieReviewDetail
                    {
                        MovieReviewId = entity.MovieReviewId,
                        MovieTitle = entity.MovieTitle,
                        MovieReleaseYear = entity.MovieReleaseYear,
                        Director = entity.Director,
                        MovieGenre = entity.MovieGenre,
                        MovieStance = entity.MovieStance,
                        MovieRating = entity.MovieRating
                    };
            }
        }
        public bool UpdateMovieReview(MovieReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews
                        .Single(e => e.MovieReviewId == model.MovieReviewId && e.OwnerId == _userId);

                entity.MovieTitle = model.MovieTitle;
                entity.MovieReleaseYear = model.MovieReleaseYear;
                entity.Director = model.Director;
                entity.MovieGenre = model.MovieGenre;
                entity.MovieStance = model.MovieStance;
                entity.MovieRating = model.MovieRating;

                return ctx.SaveChanges() == 1;
            }

            
        }
        public bool DeleteMovieReview(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MovieReviews
                        .Single(e => e.MovieReviewId == id && e.OwnerId == _userId);

                ctx.MovieReviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
