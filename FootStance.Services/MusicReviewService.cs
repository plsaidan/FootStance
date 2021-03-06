﻿using FootStance.Data;
using FootStance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootStance.Services
{
    public class MusicReviewService
    {
        private readonly Guid _userId;

        public MusicReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMusicReview(MusicReviewCreate model)
        {
            var entity =
                new MusicReview()
                {
                    OwnerId = _userId,
                    Artist = model.Artist,
                    MusicTitle = model.MusicTitle,
                    ReleaseType = model.ReleaseType,
                    MusicGenreType = model.MusicGenreType,
                    MusicStance = model.MusicStance,
                    MusicRating = model.MusicRating
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MusicReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MusicReviewListItem> GetMusicReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .MusicReviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MusicReviewListItem
                                {
                                    MusicReviewId = e.MusicReviewId,
                                    Artist = e.Artist,
                                    MusicTitle = e.MusicTitle,
                                    ReleaseType = e.ReleaseType,
                                    MusicGenreType = e.MusicGenreType,
                                    MusicStance = e.MusicStance,
                                    MusicRating = e.MusicRating
                                }
                         );

                return query.ToArray();
            }
        }
        public MusicReviewDetail GetMusicReviewById(int musicReviewId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MusicReviews
                        .Single(e => e.MusicReviewId == musicReviewId && e.OwnerId == _userId);
                return
                    new MusicReviewDetail
                    {
                        MusicReviewId = entity.MusicReviewId,
                        Artist = entity.Artist,
                        MusicTitle = entity.MusicTitle,
                        ReleaseType = entity.ReleaseType,
                        MusicGenreType = entity.MusicGenreType,
                        MusicStance = entity.MusicStance,
                        MusicRating = entity.MusicRating
                    };
            }
        }
        public bool UpdateMusicReview(MusicReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx 
                        .MusicReviews
                        .Single(e => e.MusicReviewId == model.MusicReviewId && e.OwnerId == _userId);

                entity.Artist = model.Artist;
                entity.MusicTitle = model.MusicTitle;
                entity.ReleaseType = model.ReleaseType;
                entity.MusicGenreType = model.MusicGenreType;
                entity.MusicStance = model.MusicStance;
                entity.MusicRating = model.MusicRating;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteMusicReview(int musicReviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MusicReviews
                        .Single(e => e.MusicReviewId == musicReviewId && e.OwnerId == _userId);

                ctx.MusicReviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
