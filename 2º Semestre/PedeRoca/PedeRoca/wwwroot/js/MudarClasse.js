// Obtém o caminho da URL da página atual
var url = window.location.href;

// Obtém todos os elementos <a> com a classe linkPadraoNav
var links = document.querySelectorAll('.linkPadraoNav');

// Itera sobre cada link e verifica se o href corresponde à URL atual
links.forEach(function (link) {
    if (link.href === url) {
        link.classList.add('linkPadraoNav-ativo');
    }
});

// Obtém a URL da página atual
var paginaAtual = window.location.href;

// Seleciona todos os elementos div > a com p dentro
var elementos = document.querySelectorAll('div > a.ajusteLinkNavMobile + p');

// Verifica se a URL da página atual corresponde ao link do elemento
elementos.forEach(function (elemento) {
    if (elemento.previousElementSibling && elemento.previousElementSibling.getAttribute('href') === paginaAtual) {
        // Adiciona a classe ativoNavDeskop à div pai do elemento encontrado
        elemento.parentElement.classList.add('ativoNavDeskop');
    }
});

$(document).ready(function () {
    // Obtém o nome da página atual de alguma forma (por exemplo, de uma variável no backend)
    var currentPage = "Sobre"; // Substitua isso pela lógica para obter a página atual

    // Adiciona a classe ativoNavDeskop à div correspondente
    $(".ajusteLinkNavMobile").each(function () {
        if ($(this).attr("asp-controller") === currentPage) {
            $(this).closest("div").addClass("ativoNavDeskop");
        }
    });
});