// Función para cargar los productos del carrito desde el localStorage
function cargarProductosDelCarrito() {
    var carrito = JSON.parse(localStorage.getItem('carrito')) || [];
    var carritoHTML = document.getElementById('carrito');
    var totalFactura = 0; // Variable para almacenar el total de la factura

    // Limpiar contenido previo del carrito
    carritoHTML.innerHTML = '';

    // Mostrar los productos en el carrito
    if (carrito.length === 0) {
        carritoHTML.innerHTML = '<p>El carrito está vacío</p>';
    } else {
        carrito.forEach(function(producto) {
            var productoHTML = document.createElement('div');
            var subtotalProducto = producto.precio * producto.cantidad; // Calcular el subtotal del producto
            totalFactura += subtotalProducto; // Sumar al total de la factura
            productoHTML.innerHTML = `
                <div>
                    <img src="${producto.imagen}" alt="${producto.nombre}" style="width: 50px; height: 50px;">
                    <p>${producto.nombre} - $${producto.precio} - Subtotal: $${subtotalProducto}</p>
                    <input type="number" min="1" value="${producto.cantidad}" id="cantidad-${producto.id}" onchange="actualizarCantidad(${producto.id}, this.value)">
                    <button onclick="eliminarDelCarrito(${producto.id})"><i class="fas fa-trash"></i></button>
                </div>
            `;
            carritoHTML.appendChild(productoHTML);
        });

        // Mostrar el total de la factura
        var totalFacturaHTML = document.createElement('div');
        if (totalFactura === 0) {
            totalFacturaHTML.innerHTML = '<p>Total: $${totalFactura}</p><p>El carrito está vacío</p>';
        } else {
            totalFacturaHTML.innerHTML = '<p>Total: $${totalFactura}</p>';
        }
        carritoHTML.appendChild(totalFacturaHTML);


        // Agregar botón para seguir comprando
        var continuarComprandoBtn = document.createElement('button');
        continuarComprandoBtn.textContent = 'Seguir comprando';
        continuarComprandoBtn.addEventListener('click', function() {
            // Redireccionar a la página de productos
            window.location.href = 'productos.html'; 
        });
        carritoHTML.appendChild(continuarComprandoBtn);

        // Agregar botón para finalizar compra
        var finalizarCompraBtn = document.createElement('button');
        finalizarCompraBtn.textContent = 'Finalizar compra';
        finalizarCompraBtn.addEventListener('click', function() {
            // limpiar el carrito y redireccionar a una página de confirmación de compra
            localStorage.removeItem('carrito');
            cargarProductosDelCarrito(); // Limpiar la vista del carrito
            alert('¡Compra realizada con éxito!');
        });
        carritoHTML.appendChild(finalizarCompraBtn);
    }
}

function agregarAlCarrito(idProducto, nombreProducto, precioProducto, imagenProducto, elementoClicado) {
    var carrito = JSON.parse(localStorage.getItem('carrito')) || [];
    // Verificar si el producto ya está en el carrito
    var productoExistente = carrito.find(function(producto) {
        return producto.id === idProducto;
    });
    if (productoExistente) {
        // Si el producto ya está en el carrito, aumentar su cantidad en 1
        productoExistente.cantidad++;
    } else {
        // Si el producto no está en el carrito, agregarlo con cantidad 1
        carrito.push({ id: idProducto, nombre: nombreProducto, precio: precioProducto, imagen: imagenProducto, cantidad: 1 });
    }
    localStorage.setItem('carrito', JSON.stringify(carrito));
    
    // Opcionalmente, puedes redirigir a la página del carrito después de agregar el producto
    // window.location.href = "Carrito.html";
}

// Función para eliminar un producto del carrito
function eliminarDelCarrito(idProducto) {
    var carrito = JSON.parse(localStorage.getItem('carrito')) || [];
    var nuevoCarrito = carrito.filter(function(producto) {
        return producto.id !== idProducto;
    });
    localStorage.setItem('carrito', JSON.stringify(nuevoCarrito));
    cargarProductosDelCarrito();
}

// Función para actualizar la cantidad de un producto en el carrito
function actualizarCantidad(idProducto, cantidad) {
    var carrito = JSON.parse(localStorage.getItem('carrito')) || [];
    var productoIndex = carrito.findIndex(function(producto) {
        return producto.id === idProducto;
    });
    if (productoIndex !== -1) {
        carrito[productoIndex].cantidad = parseInt(cantidad);
        localStorage.setItem('carrito', JSON.stringify(carrito));
        cargarProductosDelCarrito(); // Recargar los productos del carrito para reflejar los cambios
    }
}

// Cargar los productos del carrito al cargar la página
    window.onload = function() {
        cargarProductosDelCarrito();

    // Habilitar el botón "Finalizar compra"
    document.getElementById('finalizarCompraBtn').disabled = false;
};
