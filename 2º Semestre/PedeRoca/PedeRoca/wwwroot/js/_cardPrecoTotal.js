<<<<<<< HEAD
//function calcularValorTotal(id) {
//  let idElementoPreco = "precoProduto_" + id;
//  let idElementoQuantidade = "quantidadeProduto_" + id;
//  let idElementoValorTotal = "valorTotalProduto_" + id;

//  let precoProduto = Number(document.getElementById(idElementoPreco).innerHTML.replace('R$',''));
//  let quantidadeProduto = Number(document.getElementById(idElementoQuantidade).value);
//  document.getElementById(idElementoValorTotal).innerHTML = String((precoProduto * quantidadeProduto).toFixed(2)).replace('.',',');
//}


function calcularValorTotal(id) {
    let idElementoPreco = "precoProduto_" + id;
    let idElementoQuantidade = "quantidadeProduto" + id; // Removendo o underline (_) extra
    let idElementoValorTotal = "valorTotalProduto_" + id;

    let precoProduto = Number(document.getElementById(idElementoPreco).innerHTML.replace('R$', ''));
    let quantidadeProduto = Number(document.getElementById(idElementoQuantidade).value);
    document.getElementById(idElementoValorTotal).innerHTML = String((precoProduto * quantidadeProduto).toFixed(2)).replace('.', ',');
}

=======
const produtos = document.querySelectorAll('.produto');

// Itera sobre cada produto para adicionar o cálculo dinâmico
produtos.forEach((produto, index) => {
    // Selecione o input de quantidade, o span do valor total e o span do preço unitário para cada produto
    const inputQuantidade = produto.querySelector('.quantidadeProduto');
    const spanValorTotal = produto.querySelector('.valorTotalProduto');
    const spanPrecoUnitario = produto.querySelector('.precoUnitario');

    // Adicione um evento de escuta para o input de quantidade
    inputQuantidade.addEventListener('input', function () {
        // Obtenha a quantidade inserida pelo usuário
        const quantidade = parseInt(this.value) || 0;

        // Obtenha o preço unitário do produto específico
        const precoUnitario = parseFloat(spanPrecoUnitario.textContent);

        // Calcule o valor total multiplicando a quantidade pelo preço unitário
        const valorTotal = quantidade * precoUnitario;

        // Exiba o valor total no span de valor total do produto
        spanValorTotal.textContent = `${valorTotal.toFixed(2)}`; // Exibe o valor formatado com duas casas decimais
    });
});

>>>>>>> parent of b596196 (Carrinho de Compras)
