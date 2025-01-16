using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

public class TestDatabaseController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly Random _random;

    public TestDatabaseController(ApplicationDbContext context)
    {
        _context = context;
        _random = new Random();
    }

    public async Task<IActionResult> Index()
    {
        try {
            var products = await _context.Products.ToListAsync();
            return View(products);
        } catch (Exception ex) {

            System.IO.File.AppendAllLines("___error.txt", [DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + ex.Message]);

            throw;
        }
    }

    public async Task<IActionResult> AddRandomProduct()
    {
        var product = new Product
        {
            Name = $"Product {_random.Next(1, 1000)}",
            Price = _random.Next(10, 1000)
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
} 