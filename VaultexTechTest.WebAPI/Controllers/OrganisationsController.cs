using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaultexTechTest.Data;
using VaultexTechTest.Domain;

namespace VaultexTechTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationsController : ControllerBase
    {
        private readonly VaultexTechTestContext _context;

        public OrganisationsController(VaultexTechTestContext context)
        {
            _context = context;
        }

        // GET: api/Organisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisation>>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }

        // GET: api/Organisations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisation>> GetOrganisation(Guid id)
        {
            var organisation = await _context.Organisations.FindAsync(id);

            if (organisation == null)
            {
                return NotFound();
            }

            return organisation;
        }

        // PUT: api/Organisations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisation(Guid id, Organisation organisation)
        {
            if (id != organisation.ID)
            {
                return BadRequest();
            }

            _context.Entry(organisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Organisations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Organisation>> PostOrganisation(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganisation", new { id = organisation.ID }, organisation);
        }

        // DELETE: api/Organisations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organisation>> DeleteOrganisation(Guid id)
        {
            var organisation = await _context.Organisations.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }

            _context.Organisations.Remove(organisation);
            await _context.SaveChangesAsync();

            return organisation;
        }

        private bool OrganisationExists(Guid id)
        {
            return _context.Organisations.Any(e => e.ID == id);
        }
    }
}
