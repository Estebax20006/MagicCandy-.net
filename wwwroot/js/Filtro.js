// Obtener referencia al campo de filtro
const filtroInput = document.getElementById('filtro');
// Obtener todos los productos
const productos = document.querySelectorAll('.producto');
// Obtener el mensaje de no encontrado
const notFoundMessage = document.getElementById('not-found');

// Escuchar el evento de entrada en el campo de filtro
filtroInput.addEventListener('input', function() {
    const filtro = filtroInput.value.toLowerCase(); // Obtener el valor del filtro y pasarlo a minúsculas
    let productosEncontrados = false; // Variable para controlar si se encuentran productos

    // Iterar sobre cada producto
    productos.forEach(producto => {
        const nombreProducto = producto.querySelector('h5').textContent.toLowerCase(); // Obtener el nombre del producto y pasarlo a minúsculas
        
        // Comprobar si el nombre del producto coincide con el filtro
        if (nombreProducto.includes(filtro)) {
            producto.style.display = 'block'; // Mostrar el producto si coincide con el filtro
            productosEncontrados = true; // Marcar que se encontró al menos un producto
        } else {
            producto.style.display = 'none'; // Ocultar el producto si no coincide con el filtro
        }
    });

    // Mostrar u ocultar el mensaje de no encontrado según corresponda
    if (!productosEncontrados) {
        notFoundMessage.style.display = 'block'; // Mostrar el mensaje si no se encontraron productos
    } else {
        notFoundMessage.style.display = 'none'; // Ocultar el mensaje si se encontraron productos
    }
});
