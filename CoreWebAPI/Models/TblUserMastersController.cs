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
    public class TblUserMastersController : ControllerBase
    {
        private readonly DbEmployeeContext _context;

        public TblUserMastersController(DbEmployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblUserMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserMaster>>> GetTblUserMasters()
        {
            return await _context.TblUserMasters.ToListAsync();
        }

        // GET: api/TblUserMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserMaster>> GetTblUserMaster(int id)
        {
            var tblUserMaster = await _context.TblUserMasters.FindAsync(id);

            if (tblUserMaster == null)
            {
                return NotFound();
            }

            return tblUserMaster;
        }

        // PUT: api/TblUserMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserMaster(int id, TblUserMaster tblUserMaster)
        {
            if (id != tblUserMaster.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserMasterExists(id))
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

        // POST: api/TblUserMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserMaster>> PostTblUserMaster(TblUserMaster tblUserMaster)
        {
            _context.TblUserMasters.Add(tblUserMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserMaster", new { id = tblUserMaster.UserId }, tblUserMaster);
        }

        // DELETE: api/TblUserMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserMaster(int id)
        {
            var tblUserMaster = await _context.TblUserMasters.FindAsync(id);
            if (tblUserMaster == null)
            {
                return NotFound();
            }

            _context.TblUserMasters.Remove(tblUserMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserMasterExists(int id)
        {
            return _context.TblUserMasters.Any(e => e.UserId == id);
        }
    }
}
