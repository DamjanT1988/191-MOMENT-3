using _191_MOMENT_3.Models;
using _191_MOMENT_3_TEST1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _191_MOMENT_3.Controllers
{
    public class GuestbookController : Controller
    {
        //---DATABASE

        //create db connection (protected)
        private readonly GuestbookContext _context;

        public GuestbookController(GuestbookContext context)
        {
            //protected db connection
            _context = context;
        }

        
        //---VIEWS

        //start page
        //make async, to have more tasks
        public async Task<IActionResult> Index()
        {
            //return list of objects from db (make list by ToList)
            return View(await _context.guestbook.ToListAsync());
        }

        //create page
        public IActionResult Create()
        {
            return View();
        }


        //---HTTP ACTIONS

        //on POST
        [HttpPost]
        //control that the actual form is sent
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuestbookModel guestbook)
        {
            if (ModelState.IsValid)
            {
                //add to db, adding instance guestbook
                _context.Add(guestbook);
                //save changes, async
                await _context.SaveChangesAsync();

                //redirect user to index page
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //on POST
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var guestbookItem = await _context.guestbook.FindAsync(Id);
            if(guestbookItem != null)
            {
                _context.guestbook.Remove(guestbookItem);
                await _context.SaveChangesAsync();
            }

            //redirect user to index page
            return RedirectToAction(nameof(Index));
        }
    }
}