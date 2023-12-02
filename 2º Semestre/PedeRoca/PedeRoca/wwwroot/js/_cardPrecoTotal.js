// Função para calcular o valor total do produto
function calcularTotalProduto(itemIndex) {
    // Obter o preço unitário do produto
    var precoUnitario = parseFloat(document.getElementById('precoProduto' + itemIndex).innerText);

    // Obter a quantidade do produto
    var quantidade = parseFloat(document.getElementById('quantidadeProduto' + itemIndex).value);

    // Calcular o valor total do produto
    var valorTotal = precoUnitario * quantidade;

    // Atualizar o span com o valor total do produto
    document.getElementById('valorTotalProduto' + itemIndex).innerText = valorTotal.toFixed(2); // Exibindo o valor com 2 casas decimais
}

// Exemplo de chamada para calcular o valor total do produto ao alterar a quantidade
document.querySelectorAll('.quantidadeProduto').forEach((input, index) => {
    input.addEventListener('change', function () {
        calcularTotalProduto(index + 1);
    });
});
