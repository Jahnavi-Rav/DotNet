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
    public class TblEmployeeMastersController : ControllerBase
    {
        private readonly DbEmployeeContext _context;

        public TblEmployeeMastersController(DbEmployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblEmployeeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployeeMaster>>> GetTblEmployeeMasters()
        {
            return await _context.TblEmployeeMasters.ToListAsync();
        }

        // GET: api/TblEmployeeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployeeMaster>> GetTblEmployeeMaster(int id)
        {
            var tblEmployeeMaster = await _context.TblEmployeeMasters.FindAsync(id);

            if (tblEmployeeMaster == null)
            {
                return NotFound();
            }

            return tblEmployeeMaster;
        }

        // PUT: api/TblEmployeeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmployeeMaster(int id, TblEmployeeMaster tblEmployeeMaster)
        {
            if (id != tblEmployeeMaster.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(tblEmployeeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeMasterExists(id))
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

        // POST: api/TblEmployeeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblEmployeeMaster>> PostTblEmployeeMaster(TblEmployeeMaster tblEmployeeMaster)
        {
            _context.TblEmployeeMasters.Add(tblEmployeeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployeeMaster", new { id = tblEmployeeMaster.EmployeeId }, tblEmployeeMaster);
        }

        // DELETE: api/TblEmployeeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEmployeeMaster(int id)
        {
            var tblEmployeeMaster = await _context.TblEmployeeMasters.FindAsync(id);
            if (tblEmployeeMaster == null)
            {
                return NotFound();
            }

            _context.TblEmployeeMasters.Remove(tblEmployeeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblEmployeeMasterExists(int id)
        {
            return _context.TblEmployeeMasters.Any(e => e.EmployeeId == id);
        }
    }
}
