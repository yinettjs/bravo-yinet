let carrito = [];

function agregarAlCarrito(nombre, precio) {
  carrito = JSON.parse(localStorage.getItem("carrito")) || [];
  carrito.push({ nombre, precio });
  localStorage.setItem("carrito", JSON.stringify(carrito));
  alert(`${nombre} agregado al carrito`);
}

function cargarCarrito() {
  carrito = JSON.parse(localStorage.getItem("carrito")) || [];
  actualizarCarrito();
}

function eliminarDelCarrito(index) {
  carrito.splice(index, 1);
  localStorage.setItem("carrito", JSON.stringify(carrito));
  actualizarCarrito();
}

function actualizarCarrito() {
  const contenedor = document.getElementById("carrito-contenedor");
  if (!contenedor) return;
  contenedor.innerHTML = "";
  let total = 0;

  carrito.forEach((item, index) => {
    total += item.precio;

    const div = document.createElement("div");
    div.className = "item-carrito";

    const nombre = document.createElement("p");
    nombre.textContent = item.nombre;

    const precio = document.createElement("p");
    precio.textContent = `$${item.precio}`;

    const btn = document.createElement("button");
    btn.textContent = "Eliminar";
    btn.onclick = () => eliminarDelCarrito(index);

    div.appendChild(nombre);
    div.appendChild(precio);
    div.appendChild(btn);

    contenedor.appendChild(div);
  });

  document.getElementById("total").textContent = `Total: $${total}`;
}

function pagar() {
  if (carrito.length === 0) {
    alert("Tu carrito está vacío.");
  } else {
    alert(`Gracias por tu compra de $${carrito.reduce((acc, p) => acc + p.precio, 0)}!`);
    carrito = [];
    localStorage.removeItem("carrito");
    actualizarCarrito();
  }
}

document.addEventListener("DOMContentLoaded", cargarCarrito);
