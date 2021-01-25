﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prepaid_Mobile_Topup_MVC.Data;
using Prepaid_Mobile_Topup_MVC.Models;

namespace Prepaid_Mobile_Topup_MVC.Controllers
{
    public class TopUpsController : Controller
    {
        private readonly Prepaid_Mobile_Topup_MVCContext _context;

        public TopUpsController(Prepaid_Mobile_Topup_MVCContext context)
        {
            _context = context;
        }

        // GET: TopUps
        public async Task<IActionResult> Index()
        {
            var prepaid_Mobile_Topup_MVCContext = _context.TopUp.Include(t => t.MobileAccount).Include(t => t.TopUpChannel);
            return View(await prepaid_Mobile_Topup_MVCContext.ToListAsync());
        }

        // GET: TopUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topUp = await _context.TopUp
                .Include(t => t.MobileAccount)
                .Include(t => t.TopUpChannel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topUp == null)
            {
                return NotFound();
            }

            return View(topUp);
        }

        // GET: TopUps/Create
        public IActionResult Create()
        {
            ViewData["MobileAccountId"] = new SelectList(_context.MobileAccount, "Id", "Id");
            ViewData["TopUpChannelId"] = new SelectList(_context.TopUpChannel, "Id", "Id");
            return View();
        }

        // POST: TopUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MobileAccountId,TopUpChannelId,TopUpAmount")] TopUp topUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MobileAccountId"] = new SelectList(_context.MobileAccount, "Id", "Id", topUp.MobileAccountId);
            ViewData["TopUpChannelId"] = new SelectList(_context.TopUpChannel, "Id", "Id", topUp.TopUpChannelId);
            return View(topUp);
        }

        // GET: TopUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topUp = await _context.TopUp.FindAsync(id);
            if (topUp == null)
            {
                return NotFound();
            }
            ViewData["MobileAccountId"] = new SelectList(_context.MobileAccount, "Id", "Id", topUp.MobileAccountId);
            ViewData["TopUpChannelId"] = new SelectList(_context.TopUpChannel, "Id", "Id", topUp.TopUpChannelId);
            return View(topUp);
        }

        // POST: TopUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MobileAccountId,TopUpChannelId,TopUpAmount")] TopUp topUp)
        {
            if (id != topUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopUpExists(topUp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MobileAccountId"] = new SelectList(_context.MobileAccount, "Id", "Id", topUp.MobileAccountId);
            ViewData["TopUpChannelId"] = new SelectList(_context.TopUpChannel, "Id", "Id", topUp.TopUpChannelId);
            return View(topUp);
        }

        // GET: TopUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topUp = await _context.TopUp
                .Include(t => t.MobileAccount)
                .Include(t => t.TopUpChannel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topUp == null)
            {
                return NotFound();
            }

            return View(topUp);
        }

        // POST: TopUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topUp = await _context.TopUp.FindAsync(id);
            _context.TopUp.Remove(topUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopUpExists(int id)
        {
            return _context.TopUp.Any(e => e.Id == id);
        }
    }
}