$(document).ready(function () {
    // Máscara para o campo CPF
    $('#CPF').mask('000.000.000-00', { reverse: true });

    // Máscara para o campo Telefone
    $('#TelefoneADMCreate').mask('(00) 0000-0000');

    // Máscara para o campo CEP
    $('#CEP').mask('00000-000');
});