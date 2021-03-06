﻿using FootStance.Models;
using FootStance.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootStance.WebMVC.Controllers
{
    [Authorize]
    public class GameReviewController : Controller
    {
        // GET: GameReview
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameReviewService(userId);
            var model = service.GetGameReviews();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameReviewService();

            if (service.CreateGameReview(model))
            {
                TempData["SaveResult"] = "Your Stance has been successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your Stance could not be created at this time");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameReviewService();
            var model = svc.GetGameReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameReviewService();
            var detail = service.GetGameReviewById(id);
            var model =
                new GameReviewEdit
                {
                    GameReviewId = detail.GameReviewId,
                    GameTitle = detail.GameTitle,
                    GameDeveloper = detail.GameDeveloper,
                    Platform = detail.Platform,
                    GameGenre = detail.GameGenre,
                    GameReleaseYear = detail.GameReleaseYear,
                    GameStance = detail.GameStance,
                    GameRating = detail.GameRating
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameReviewEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.GameReviewId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateGameReviewService();

            if (service.UpdateGameReview(model))
            {
                TempData["SaveResult"] = "Your Stance has been successfully updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your Stance could not be updated at this time");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateGameReviewService();
            var model = svc.GetGameReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGameStance(int id)
        {
            var service = CreateGameReviewService();

            service.DeleteGameReview(id);

            TempData["SaveResult"] = "Your Stance was successfully removed";

            return RedirectToAction("Index");
        }

        private GameReviewService CreateGameReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameReviewService(userId);
            return service;
        }

    }
}