$(document).ready(function () {
    $('#olhoToggle').click(function () {
        const senhaInput = $('#senhaInput');
        const olhoIcon = $('#olhoIcon');

        if (senhaInput.attr('type') === 'password') {
            senhaInput.attr('type', 'text');
            olhoIcon.addClass('visible');
        } else {
            senhaInput.attr('type', 'password');
            olhoIcon.removeClass('visible');
        }
    });
});