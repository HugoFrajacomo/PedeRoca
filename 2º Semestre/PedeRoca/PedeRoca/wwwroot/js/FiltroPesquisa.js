$(document).ready(function () {
    $("#filtroPesquisa").on("input", function () {
        var termoPesquisa = $(this).val().toLowerCase();

        $(".cartaoProduto").each(function () {
            var nomeProduto = $(this).find("#nomeProduto h5").text().toLowerCase();
            var categoriaProduto = $(this).find(".EnfaseProdutoOculto").text().toLowerCase();

            // Mostra ou oculta o cartão com base no termo de pesquisa
            if (nomeProduto.indexOf(termoPesquisa) === -1 && categoriaProduto.indexOf(termoPesquisa) === -1) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
});

