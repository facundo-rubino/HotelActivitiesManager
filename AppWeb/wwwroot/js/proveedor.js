let numeroProveedor;

function guardoNumero(num) {
    numeroProveedor = num;
    console.log(numeroProveedor);
}

document.querySelector("#submitButton").addEventListener("click", enviarDatos);

function enviarDatos() {
    descuentoIngresado = Number(document.querySelector("#descuentoIngresado").value);

    var dataToSend = {
        numero: numeroProveedor,
        descuento: descuentoIngresado,
    };

    $.ajax({
        url: '/proveedor/DescuentoXNumero',
        type: 'POST',
        data: dataToSend,
        success: function (response) {
            console.log(response);
            $.get('/proveedor', { identificador: numeroProveedor }, function (data) {
                // Update a specific section of your page with the loaded content
                console.log(numeroProveedor);
                document.querySelector('[data-td-id="' + numeroProveedor + '"]').html(data);
                console.log("pasó");


            });

        },
        error: function (error) {
            console.error(error);
        }
    });

}

