using BravoYinet.Models;
using BravoYinet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BravoYinet.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarritoService _carrito;

        // Lista fija de productos (puedes moverla a una base de datos más adelante)
        private readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Manzana", Precio = 79, Imagen = "manzana.jpg" },
            new Producto { Id = 2, Nombre = "Leche", Precio = 99, Imagen = "leche.jpg" },
            new Producto { Id = 3, Nombre = "Carne", Precio = 299, Imagen = "carne1.jpg" },
            new Producto { Id = 4, Nombre = "Pan", Precio = 199, Imagen = "pan.jpg" },
            new Producto { Id = 5, Nombre = "Arroz", Precio = 299, Imagen = "arroz1.jpg" },
            new Producto { Id = 6, Nombre = "Pistacho", Precio = 400, Imagen = "pistacho.png" },
            new Producto { Id = 7, Nombre = "Chocolate", Precio = 99, Imagen = "chocolate.jpg" }
        };

        public HomeController(CarritoService carrito)
        {
            _carrito = carrito;
        }

        public IActionResult Index() => View();

        public IActionResult Explorar() => View(_productos);

        public IActionResult Carrito() => View(_carrito.ObtenerCarrito());

        [HttpPost]
        public IActionResult Agregar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _carrito.AgregarProducto(producto);
            }
            // 🔹 Ahora regresa a Explorar en vez de Carrito
            return RedirectToAction("Explorar");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _carrito.EliminarProducto(id);
            return RedirectToAction("Carrito");
        }

        // Acción para simular el pago
        [HttpPost]
        public IActionResult Pagar()
        {
            _carrito.VaciarCarrito(); // Limpia el carrito después del pago
            ViewBag.Mensaje = "✅ Pago realizado con éxito. ¡Gracias por tu compra!";
            return View("Carrito", _carrito.ObtenerCarrito());
        }
    }
}


