// URL base de la API
const apiUrl = "https://localhost:7114/api/Duenio";

// Elementos
const form = document.getElementById("duenioForm");
const btnModificar = document.getElementById("btnModificar");
const btnEliminar = document.getElementById("btnEliminar");
let idSeleccionado = null;

// Cargar dueños al iniciar
document.addEventListener("DOMContentLoaded", cargarDuenios);

function cargarDuenios() {
    fetch(apiUrl)
        .then(res => res.json())
        .then(duenios => {
            const tbody = document.querySelector("#tablaDuenios tbody");
            tbody.innerHTML = "";
            duenios.forEach(d => {
                const fila = `
                    <tr>
                        <td>${d.idDuenio}</td>
                        <td>${d.dni}</td>
                        <td>${d.nombre}</td>
                        <td>${d.apellido}</td>
                        <td>${d.animales && d.animales.length > 0 
                            ? d.animales.map(a => a.nombre).join(", ") 
                            : ""}</td>
                        <td class="text-center">
                            <input type="checkbox" class="form-check-input seleccionar-duenio" value="${d.idDuenio}">
                        </td>
                    </tr>`;
                tbody.innerHTML += fila;
            });

            // Checkbox: seleccionar solo uno
            document.querySelectorAll(".seleccionar-duenio").forEach(chk => {
                chk.addEventListener("change", function () {
                    document.querySelectorAll(".seleccionar-duenio").forEach(c => c.checked = false);
                    this.checked = true;
                    idSeleccionado = parseInt(this.value);
                    cargarDuenioEnFormulario(idSeleccionado);
                });
            });
        })
        .catch(err => console.error("Error al cargar dueños:", err));
}

// Cargar dueño en formulario
function cargarDuenioEnFormulario(id) {
    fetch(`${apiUrl}/${id}`)
        .then(res => res.json())
        .then(d => {
            document.getElementById("duenioId").value = d.idDuenio;
            document.getElementById("dni").value = d.dni;
            document.getElementById("nombre").value = d.nombre;
            document.getElementById("apellido").value = d.apellido;
            // mostramos el id del primer animal si tiene
            document.getElementById("animalId").value = d.animales?.[0]?.idAnimal ?? "";
        });
}

// Guardar nuevo
form.addEventListener("submit", function (e) {
    e.preventDefault();

    const duenio = {
        idDuenio: 0,
        dni: document.getElementById("dni").value,
        nombre: document.getElementById("nombre").value,
        apellido: document.getElementById("apellido").value,
        animales: [] // por ahora vacío, se gestiona aparte
    };

    fetch(apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(duenio)
    })
    .then(res => {
        if (res.ok) {
            cargarDuenios();
            form.reset();
        }
    })
    .catch(err => console.error("Error al guardar:", err));
});

// Modificar
btnModificar.addEventListener("click", function () {
    if (!idSeleccionado) {
        alert("Selecciona un dueño para modificar");
        return;
    }

    const duenio = {
        idDuenio: idSeleccionado,
        dni: document.getElementById("dni").value,
        nombre: document.getElementById("nombre").value,
        apellido: document.getElementById("apellido").value,
        animales: []
    };

    fetch(`${apiUrl}/${idSeleccionado}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(duenio)
    })
    .then(res => {
        if (res.ok) {
            cargarDuenios();
            form.reset();
            idSeleccionado = null;
        }
    })
    .catch(err => console.error("Error al modificar:", err));
});

// Eliminar
btnEliminar.addEventListener("click", function () {
    if (!idSeleccionado) {
        alert("Selecciona un dueño para eliminar");
        return;
    }

    fetch(`${apiUrl}/${idSeleccionado}`, { method: "DELETE" })
        .then(res => {
            if (res.ok) {
                cargarDuenios();
                form.reset();
                idSeleccionado = null;
            }
        })
        .catch(err => console.error("Error al eliminar:", err));
});
