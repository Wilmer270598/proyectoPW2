using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentaDeComputadoras.Data;
using VentaDeComputadoras.Models;

namespace VentaDeComputadoras.Controllers
{
    [Authorize]
    public class DetallePedidoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallePedidoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallePedidoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallePedidos.Include(d => d.pedido).Include(d => d.producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallePedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.pedido)
                .Include(d => d.producto)
                .FirstOrDefaultAsync(m => m.idDetallePedido == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public IActionResult Create()
        {
            ViewData["idPedido"] = new SelectList(_context.Pedidos, "idPedido", "estadoPedido");
            ViewData["idProduto"] = new SelectList(_context.Productos, "id_producto", "NombreProducto");
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDetallePedido,idProduto,idPedido,cantidad,precio")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idPedido"] = new SelectList(_context.Pedidos, "idPedido", "estadoPedido", detallePedido.idPedido);
            ViewData["idProduto"] = new SelectList(_context.Productos, "id_producto", "NombreProducto", detallePedido.idProduto);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["idPedido"] = new SelectList(_context.Pedidos, "idPedido", "estadoPedido", detallePedido.idPedido);
            ViewData["idProduto"] = new SelectList(_context.Productos, "id_producto", "NombreProducto", detallePedido.idProduto);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDetallePedido,idProduto,idPedido,cantidad,precio")] DetallePedido detallePedido)
        {
            if (id != detallePedido.idDetallePedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.idDetallePedido))
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
            ViewData["idPedido"] = new SelectList(_context.Pedidos, "idPedido", "estadoPedido", detallePedido.idPedido);
            ViewData["idProduto"] = new SelectList(_context.Productos, "id_producto", "NombreProducto", detallePedido.idProduto);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.pedido)
                .Include(d => d.producto)
                .FirstOrDefaultAsync(m => m.idDetallePedido == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedidos.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.idDetallePedido == id);
        }
    }
}
