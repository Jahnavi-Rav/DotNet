using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOTNET_CORE_WEB_API_DEMO.Models;

namespace DOTNET_CORE_WEB_API_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblEducationalDetailsController : ControllerBase
    {
        private readonly DbEmployeeContext _context;

        public TblEducationalDetailsController(DbEmployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblEducationalDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEducationalDetail>>> GetTblEducationalDetails()
        {
            return await _context.TblEducationalDetails.ToListAsync();
        }

        // GET: api/TblEducationalDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEducationalDetail>> GetTblEducationalDetail(int id)
        {
            var tblEducationalDetail = await _context.TblEducationalDetails.FindAsync(id);

            if (tblEducationalDetail == null)
            {
                return NotFound();
            }

            return tblEducationalDetail;
        }

        // PUT: api/TblEducationalDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEducationalDetail(int id, TblEducationalDetail tblEducationalDetail)
        {
            if (id != tblEducationalDetail.EducationalDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(tblEducationalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEducationalDetailExists(id))
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

        // POST: api/TblEducationalDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblEducationalDetail>> PostTblEducationalDetail(TblEducationalDetail tblEducationalDetail)
        {
            _context.TblEducationalDetails.Add(tblEducationalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEducationalDetail", new { id = tblEducationalDetail.EducationalDetailsId }, tblEducationalDetail);
        }

        // DELETE: api/TblEducationalDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEducationalDetail(int id)
        {
            var tblEducationalDetail = await _context.TblEducationalDetails.FindAsync(id);
            if (tblEducationalDetail == null)
            {
                return NotFound();
            }

            _context.TblEducationalDetails.Remove(tblEducationalDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblEducationalDetailExists(int id)
        {
            return _context.TblEducationalDetails.Any(e => e.EducationalDetailsId == id);
        }
    }
}
