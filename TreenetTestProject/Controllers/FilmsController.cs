using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TreenetTestProject.Data;
using TreenetTestProject.Models;

namespace TreenetTestProject.Controllers
{
    public class FilmsController : Controller
    {
        private readonly FilmContexts _context;

        public FilmsController(FilmContexts context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index(string searchText)
        {
            if (!String.IsNullOrEmpty(searchText))
            {
                var film = from f in _context.Film
                           select f;
                searchText = searchText.Split(".", 2).Last();
                film = film.Where(s => s.title.Contains(searchText));
                _context.Add(new Search(searchText));
                await _context.SaveChangesAsync();
                return View(await film.ToListAsync());
            }
            else
            {
                return View(await _context.Film.ToListAsync());
            }

        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.filmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("filmID,title,producer,duration")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("filmID,title,producer,duration")] Film film)
        {
            if (id != film.filmID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.filmID))
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
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.filmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Email(string emailSender, string emailRecepient, string subject, string password)
        {

            //Setting up SMTP Connection
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465)) {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Fetching Data from Db 
                Search search = _context.Search.ToList().Last();
                var film = from f in _context.Film
                           select f;
                if (!String.IsNullOrEmpty(search.searchText))
                {
                    film = film.Where(s => s.title.Contains(search.searchText));
                    //Adding Data to Mail body
                    mail.Body = film.ToString();
                }
                //Mail Addressing
                mail.From = new MailAddress(emailSender);
                mail.To.Add(new MailAddress(emailRecepient));
                //Mail Authentication
                smtpClient.Credentials = new NetworkCredential(emailSender, password);
                smtpClient.Send(mail);
            }
                
            return View();
        }

        public async Task<IActionResult> UpdateAutoComplete()
        {
            return View(await _context.Film.ToListAsync());
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.filmID == id);
        }
    }
}
