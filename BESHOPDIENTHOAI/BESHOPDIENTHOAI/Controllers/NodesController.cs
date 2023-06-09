﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BESHOPDIENTHOAI.Models;

namespace BESHOPDIENTHOAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly ShopDienThoaiContext _context;

        public NodesController(ShopDienThoaiContext context)
        {
            _context = context;
        }

        // GET: api/Nodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetNodes()
        {
          if (_context.Nodes == null)
          {
              return NotFound();
          }
            return await _context.Nodes.ToListAsync();
        }

        // GET: api/Nodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Node>> GetNode(int id)
        {
          if (_context.Nodes == null)
          {
              return NotFound();
          }
            var node = await _context.Nodes.FindAsync(id);

            if (node == null)
            {
                return NotFound();
            }

            return node;
        }

        // PUT: api/Nodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNode(int id, Node node)
        {
            if (id != node.Id)
            {
                return BadRequest();
            }

            _context.Entry(node).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(id))
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

        // POST: api/Nodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode(Node node)
        {
          if (_context.Nodes == null)
          {
              return Problem("Entity set 'ShopDienThoaiContext.Nodes'  is null.");
          }
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNode", new { id = node.Id }, node);
        }

        // DELETE: api/Nodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNode(int id)
        {
            if (_context.Nodes == null)
            {
                return NotFound();
            }
            var node = await _context.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NodeExists(int id)
        {
            return (_context.Nodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
