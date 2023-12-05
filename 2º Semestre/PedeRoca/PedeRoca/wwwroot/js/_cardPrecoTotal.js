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

