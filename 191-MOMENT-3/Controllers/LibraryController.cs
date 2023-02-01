using _191_MOMENT_3.Models;
using _191_MOMENT_3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _191_MOMENT_3.Controllers
{
    public class LibraryController : Controller
    {
        //---DATABASE

        //create db connection (protected)
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
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
            return View(await _context.mainLibrary.ToListAsync());
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
        public async Task<IActionResult> Create(LibraryModel mainlibrary)
        {
            if (ModelState.IsValid)
            {
                //add to db, adding instance library
                _context.Add(mainlibrary);
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
            var libraryItem = await _context.mainLibrary.FindAsync(Id);
            if(libraryItem != null)
            {
                _context.mainLibrary.Remove(libraryItem);
                await _context.SaveChangesAsync();
            }

            //redirect user to index page
            return RedirectToAction(nameof(Index));
        }
    }
}