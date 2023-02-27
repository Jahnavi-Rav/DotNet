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
    public class TblErrorLogsController : ControllerBase
    {
        private readonly DbEmployeeContext _context;

        public TblErrorLogsController(DbEmployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblErrorLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblErrorLog>>> GetTblErrorLogs()
        {
            return await _context.TblErrorLogs.ToListAsync();
        }

        // GET: api/TblErrorLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblErrorLog>> GetTblErrorLog(int id)
        {
            var tblErrorLog = await _context.TblErrorLogs.FindAsync(id);

            if (tblErrorLog == null)
            {
                return NotFound();
            }

            return tblErrorLog;
        }

        // PUT: api/TblErrorLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblErrorLog(int id, TblErrorLog tblErrorLog)
        {
            if (id != tblErrorLog.ErrorId)
            {
                return BadRequest();
            }

            _context.Entry(tblErrorLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblErrorLogExists(id))
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

        // POST: api/TblErrorLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblErrorLog>> PostTblErrorLog(TblErrorLog tblErrorLog)
        {
            _context.TblErrorLogs.Add(tblErrorLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblErrorLog", new { id = tblErrorLog.ErrorId }, tblErrorLog);
        }

        // DELETE: api/TblErrorLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblErrorLog(int id)
        {
            var tblErrorLog = await _context.TblErrorLogs.FindAsync(id);
            if (tblErrorLog == null)
            {
                return NotFound();
            }

            _context.TblErrorLogs.Remove(tblErrorLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblErrorLogExists(int id)
        {
            return _context.TblErrorLogs.Any(e => e.ErrorId == id);
        }
    }
}
