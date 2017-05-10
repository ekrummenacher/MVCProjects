﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models;
using EventPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Controllers
{
    public class EventTypeController : Controller
    {
        private ApplicationDbContext db_context;

        public EventTypeController(ApplicationDbContext context)
        {
            db_context = context;
        }

        public IActionResult Index()
        {
  
            var eTypes = db_context.EventType.Select(e => e);
            return View(eTypes.ToList());
        }

        //Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventType eventtype)
        {
            db_context.Add(eventtype);
            db_context.SaveChanges();
            return RedirectToAction("Index");

        }

        //Edit

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            EventType eType = db_context.EventType.Where(e => e.Id == Id).SingleOrDefault();
            return View(eType);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int? Id)
        {
            EventType eType = db_context.EventType.Where(e => e.Id == Id).SingleOrDefault();

            if (await TryUpdateModelAsync<EventType>(eType, "", e => e.Id, e => e.Label))
            {

                try
                {
                    await db_context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }

            return View(eType);
        }
    }
}
