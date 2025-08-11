// URL base de tu API
const apiUrl = "https://localhost:7114/api/Animal";

// Cargar animales al iniciar
document.addEventListener("DOMContentLoaded", cargarAnimales);

// Formulario
const form = document.getElementById("animalForm");
const btnModificar = document.getElementById("btnModificar");
const btnEliminar = document.getElementById("btnEliminar");
let idSeleccionado = null;

// Cargar lista
function cargarAnimales() {
    fetch(apiUrl)
        .then(res => res.json())
        .then(animales => {
            const tbody = document.querySelector("#tablaAnimales tbody");
            tbody.innerHTML = "";
            animales.forEach(animal => {
                const fila = `
                    <tr>
                        <td>${animal.idAnimal}</td>
                        <td>${animal.nombre}</td>
                        <td>${animal.raza}</td>
                        <td>${animal.edad}</td>
                        <td>${animal.sexo}</td>
                        <td>${animal.idDuenio ?? ""}</td>
                        <td class="text-center">
                            <input type="checkbox" class="form-check-input seleccionar-animal" value="${animal.idAnimal}">
                        </td>
                    </tr>`;
                tbody.innerHTML += fila;
            });

            // Asignar eventos a los checkboxes
            document.querySelectorAll(".seleccionar-animal").forEach(chk => {
                chk.addEventListener("change", function () {
                    document.querySelectorAll(".seleccionar-animal").forEach(c => c.checked = false);
                    this.checked = true;
                    idSeleccionado = parseInt(this.value);
                    cargarAnimalEnFormulario(idSeleccionado);
                });
            });
        })
        .catch(err => console.error("Error al cargar animales:", err));
}

// Cargar datos de un animal en el formulario
function cargarAnimalEnFormulario(id) {
    fetch(`${apiUrl}/${id}`)
        .then(res => res.json())
        .then(animal => {
            document.getElementById("animalId").value = animal.idAnimal;
            document.getElementById("nombre").value = animal.nombre;
            document.getElementById("raza").value = animal.raza;
            document.getElementById("edad").value = animal.edad;
            document.getElementById("sexo").value = animal.sexo;
        });
}

// Agregar animal
form.addEventListener("submit", function (e) {
    e.preventDefault();
    const animal = {
        idAnimal: 0, // El servidor lo genera
        nombre: document.getElementById("nombre").value,
        raza: document.getElementById("raza").value,
        edad: document.getElementById("edad").value,
        sexo: document.getElementById("sexo").value
    };

    fetch(apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(animal)
    })
    
    .then(res => {
        if (res.ok) {
            cargarAnimales();
            form.reset();
        }
    })
    .then(res => res.text())
    .then(data => console.log("Respuesta servidor:", data))
    .catch(err => console.error("Error de red:", err));
});

// Modificar
btnModificar.addEventListener("click", function () {
    if (!idSeleccionado) {
        alert("Selecciona un animal para modificar");
        return;
    }

    const animal = {
        idAnimal: idSeleccionado,
        nombre: document.getElementById("nombre").value,
        raza: document.getElementById("raza").value,
        edad: document.getElementById("edad").value,
        sexo: document.getElementById("sexo").value
    };

    fetch(`${apiUrl}/${idSeleccionado}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(animal)
    })
    .then(res => {
        if (res.ok) {
            cargarAnimales();
            form.reset();
            idSeleccionado = null;
        }
    });
});

function filtrarAnimales() {
    const nombre = document.getElementById("filtroNombre").value.trim();
    const razaOEdad = document.getElementById("filtroRazaEdad").value.trim();
    const sexo = document.getElementById("filtroSexo").value;

    const url = `${apiUrl}/filtrar?nombre=${encodeURIComponent(nombre)}&razaEdad=${encodeURIComponent(razaOEdad)}&sexo=${encodeURIComponent(sexo)}`;

    fetch(url)
        .then(res => res.json())
        .then(animales => {
            const tbody = document.querySelector("#tablaAnimales tbody");
            tbody.innerHTML = "";
            animales.forEach(animal => {
                const fila = `
                    <tr>
                        <td>${animal.idAnimal}</td>
                        <td>${animal.nombre}</td>
                        <td>${animal.raza}</td>
                        <td>${animal.edad}</td>
                        <td>${animal.sexo}</td>
                        <td>${animal.idDuenio ?? ""}</td>
                        <td class="text-center">
                            <input type="checkbox" class="form-check-input seleccionar-animal" value="${animal.idAnimal}">
                        </td>
                    </tr>`;
                tbody.innerHTML += fila;
            });

            document.querySelectorAll(".seleccionar-animal").forEach(chk => {
                chk.addEventListener("change", function () {
                    document.querySelectorAll(".seleccionar-animal").forEach(c => c.checked = false);
                    this.checked = true;
                    idSeleccionado = parseInt(this.value);
                    cargarAnimalEnFormulario(idSeleccionado);
                });
            });
        })
        .catch(err => console.error("Error al filtrar:", err));
}


// Eliminar
btnEliminar.addEventListener("click", function () {
    if (!idSeleccionado) {
        alert("Selecciona un animal para eliminar");
        return;
    }

    fetch(`${apiUrl}/${idSeleccionado}`, { method: "DELETE" })
        .then(res => {
            if (res.ok) {
                cargarAnimales();
                form.reset();
                idSeleccionado = null;
            }
        });
});
