using BravoYinet.Models;
using System.Collections.Generic;
using System.Linq;

namespace BravoYinet.Services
{
    public class CarritoService
    {
        private readonly List<Producto> _items = new();

        public void AgregarProducto(Producto p) => _items.Add(p);

        public IEnumerable<Producto> ObtenerCarrito() => _items;

        public decimal Total() => _items.Sum(i => i.Precio);

        // Eliminar un producto específico
        public void EliminarProducto(int id)
        {
            var producto = _items.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _items.Remove(producto);
            }
        }

        // 🔹 Nuevo método para vaciar el carrito
        public void VaciarCarrito()
        {
            _items.Clear();
        }
    }
}

