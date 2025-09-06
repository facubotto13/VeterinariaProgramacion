// js/atenciones.js

const API_URL = "https://localhost:5001/api/Atencion"; // ajusta si tu backend corre en otro puerto o URL

document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("atencionForm");
    const tabla = document.getElementById("tablaAtenciones").querySelector("tbody");
    const btnModificar = document.getElementById("btnModificar");
    const btnEliminar = document.getElementById("btnEliminar");

    let selectedId = null;

    // Cargar todas las atenciones
    async function cargarAtenciones() {
        try {
            const resp = await fetch(API_URL);
            if (!resp.ok) throw new Error("Error al obtener atenciones");
            const data = await resp.json();
            renderTabla(data);
        } catch (err) {
            console.error(err);
            alert("No se pudieron cargar las atenciones.");
        }
    }

    // Guardar nueva atención
    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const nuevaAtencion = {
            idAtencion: selectedId || 0,
            tipoAtencion: document.getElementById("atencion").value,
            motivo: document.getElementById("motivo").value,
            tratamientoRebicido: document.getElementById("tratamiento").value,
            medicamentos: document.getElementById("medicamentos").value,
            fecha: document.getElementById("fecha").value,
            animal: { idAnimal: parseInt(document.getElementById("animalId").value) }
        };

        try {
            let resp;
            if (selectedId) {
                // Modificación
                resp = await fetch(`${API_URL}/${selectedId}`, {
                    method: "PUT",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(nuevaAtencion)
                });
            } else {
                // Creación
                resp = await fetch(API_URL, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(nuevaAtencion)
                });
            }

            if (!resp.ok) throw new Error("Error al guardar atención");

            form.reset();
            selectedId = null;
            await cargarAtenciones();
        } catch (err) {
            console.error(err);
            alert("No se pudo guardar la atención.");
        }
    });

    // Modificar (cargar en formulario)
    btnModificar.addEventListener("click", async () => {
        if (!selectedId) {
            alert("Selecciona una atención primero.");
            return;
        }

        try {
            const resp = await fetch(`${API_URL}/${selectedId}`);
            if (!resp.ok) throw new Error("No se encontró la atención");
            const atencion = await resp.json();

            document.getElementById("animalId").value = atencion.animal?.idAnimal || "";
            document.getElementById("atencion").value = atencion.tipoAtencion;
            document.getElementById("motivo").value = atencion.motivo;
            document.getElementById("tratamiento").value = atencion.tratamientoRebicido;
            document.getElementById("medicamentos").value = atencion.medicamentos;
            document.getElementById("fecha").value = atencion.fecha?.split("T")[0]; // cortar hora si viene en formato ISO
        } catch (err) {
            console.error(err);
            alert("Error al cargar la atención.");
        }
    });

    // Eliminar
    btnEliminar.addEventListener("click", async () => {
        if (!selectedId) {
            alert("Selecciona una atención primero.");
            return;
        }

        if (!confirm("¿Seguro que deseas eliminar esta atención?")) return;

        try {
            const resp = await fetch(`${API_URL}/${selectedId}`, { method: "DELETE" });
            if (!resp.ok) throw new Error("Error al eliminar atención");

            selectedId = null;
            form.reset();
            await cargarAtenciones();
        } catch (err) {
            console.error(err);
            alert("No se pudo eliminar la atención.");
        }
    });

    // Renderizar la tabla
    function renderTabla(atenciones) {
        tabla.innerHTML = "";

        atenciones.forEach(atencion => {
            const tr = document.createElement("tr");
            tr.innerHTML = `
                <td>${atencion.idAtencion}</td>
                <td>${atencion.tipoAtencion}</td>
                <td>${atencion.motivo}</td>
                <td>${atencion.tratamientoRebicido}</td>
                <td>${atencion.medicamentos}</td>
                <td>${atencion.fecha ? atencion.fecha.split("T")[0] : ""}</td>
                <td>
                    <button class="btn btn-sm btn-info seleccionar">Seleccionar</button>
                </td>
            `;

            tr.querySelector(".seleccionar").addEventListener("click", () => {
                selectedId = atencion.idAtencion;
                document.querySelectorAll("#tablaAtenciones tbody tr").forEach(r => r.classList.remove("table-active"));
                tr.classList.add("table-active");
            });

            tabla.appendChild(tr);
        });
    }

    cargarAtenciones();
});
