using Flutter_Hello_Word_API.Data.Entities;
using Flutter_Hello_Word_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flutter_Hello_Word_API.Controllers
{ 
    [ApiController]
    [Route("[controller]")]    
    public class ProduitController : ControllerBase
    {
        private readonly Data.MonDbContext _context;

        public ProduitController(Data.MonDbContext context)
        {
            _context = context;
        }

        // GET: api/produit
        [HttpGet]
        public ActionResult<IEnumerable<Produit>> GetProduits()
        {
            var produits = _context.Produits.ToList();
            return Ok(produits);
        }

        // GET: api/produit/5
        [HttpGet("{id}")]
        public ActionResult<Produit> GetProduit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(produit);
        }

        // POST: api/produit
        [HttpPost(Name = "PostProduit")]
        public ActionResult<Produit> PostProduit(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduit), new { id = produit.Id }, produit);
        }

        // PUT: api/produit/5
        [HttpPut("{id}")]
        public IActionResult PutProduit(int id, Produit produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Produits.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/produit/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produits.Remove(produit);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
