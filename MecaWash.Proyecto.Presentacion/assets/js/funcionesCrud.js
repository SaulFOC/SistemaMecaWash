 var object = {status: false, ele: null };

    function confirmaEliminar(ev) {
            if (object.status) {
                return true;
            }

    Swal.fire({
        title: "¿Desea eliminar?",
    text: "Este empleado perderá acceso.",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Sí, eliminar",
    cancelButtonText: "Cancelar",
    closeOnConfirm: true
            }).then((result) => {
                if (result.isConfirmed) {
        Swal.fire({
            title: "Eliminado",
            text: "El empleado fue eliminado con éxito",
            icon: "success"
        });

    // Establecer el estado a verdadero y hacer clic en el elemento
    object.status = true;
    object.ele = ev;
    object.ele.click();
    object.status = false;
                }
            });

    return false;
        }

    function actualizacionExitosa() {
        Swal.fire({
            title: "Actualizado",
            text: "Actualizacion exitoza!",
            icon: "success"
        });
        }

    function registroExitoso() {
        Swal.fire({
            title: "Registrado",
            text: "Registro exitoso!",
            icon: "success"
        });
        }

function notiError(mensaje) {
    Swal.fire({
        title: "Ocurrio un error",
        text: mensaje,
        icon: "error"
    });
}

    $(document).ready(function () {
        $('.js-example-basic-single').select2();
        });