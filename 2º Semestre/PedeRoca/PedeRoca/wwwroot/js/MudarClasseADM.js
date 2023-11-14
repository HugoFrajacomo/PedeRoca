// Obtém o caminho da URL da página atual
var url = window.location.href;

// Obtém todos os elementos <a> com a classe linkPadraoNav
var links = document.querySelectorAll('.linkPadraoNavADM');

// Itera sobre cada link e verifica se o href corresponde à URL atual
links.forEach(function (link) {
    if (link.href === url) {
        link.classList.add('linkPadraoNavADM-Ativo');
    }
});