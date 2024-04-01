function mostrarDetalles(id) {
    var modal = document.getElementById("detalles-producto");
    var nombreProducto = document.getElementById("nombre-producto");
    var precioProducto = document.getElementById("precio-producto");
    var imagenDetalle = document.getElementById("imagen-detalle");
    
    if (id === 1) {
        nombreProducto.textContent = "Anisadas";
        precioProducto.textContent = "$3.800";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Anisadas.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    } else if (id === 2) {
        nombreProducto.textContent = "BonbonBum";
        precioProducto.textContent = "$4.200";
        imagenDetalle.src = "../SRC/ASSETS/IMG/BonbonBum.png";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 3) {
        nombreProducto.textContent = "Candy Mix";
        precioProducto.textContent = "$4.400";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Candy mix.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 4) {
        nombreProducto.textContent = "Candy Ranch";
        precioProducto.textContent = "$5.000";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Candy Ranch.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 5) {
        nombreProducto.textContent = "Deditos de Chocolate";
        precioProducto.textContent = "$6.100";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Deditos.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 6) {
        nombreProducto.textContent = "Fruticas";
        precioProducto.textContent = "$6.700";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Fruticas.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 7) {
        nombreProducto.textContent = "Grissly";
        precioProducto.textContent = "$3.100";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Grissly.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 8) {
        nombreProducto.textContent = "Max";
        precioProducto.textContent = "$4.600";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Max.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 9) {
        nombreProducto.textContent = "Max";
        precioProducto.textContent = "$4.600";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Max.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 10) {
        nombreProducto.textContent = "Panditas";
        precioProducto.textContent = "$7.300";
        imagenDetalle.src = "./SRC/ASSETS/IMG/Producto 3.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 11) {
        nombreProducto.textContent = "Trigo";
        precioProducto.textContent = "$2.400";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Producto 6.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 12) {
        nombreProducto.textContent = "Pastillitas";
        precioProducto.textContent = "$4.300";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Pastillitas.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 13) {
        nombreProducto.textContent = "Anisadas";
        precioProducto.textContent = "$4.300";
        imagenDetalle.src = "../SRC/ASSETS/IMG/FiestaMix.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }else if (id === 14) {
        nombreProducto.textContent = "Anisadas";
        precioProducto.textContent = "$4.300";
        imagenDetalle.src = "../SRC/ASSETS/IMG/Frutas.jpg";
        imagenDetalle.style.width = "200px";
        imagenDetalle.style.height = "auto";
    }
    
    modal.style.display = "block";
}

function cerrarDetalles() {
    document.getElementById("detalles-producto").style.display = "none";
}
