const produtos = document.querySelectorAll('.produto');

// Itera sobre cada produto para adicionar o c�lculo din�mico
produtos.forEach((produto, index) => {
    // Selecione o input de quantidade, o span do valor total e o span do pre�o unit�rio para cada produto
    const inputQuantidade = produto.querySelector('.quantidadeProduto');
    const spanValorTotal = produto.querySelector('.valorTotalProduto');
    const spanPrecoUnitario = produto.querySelector('.precoUnitario');

    // Adicione um evento de escuta para o input de quantidade
    inputQuantidade.addEventListener('input', function () {
        // Obtenha a quantidade inserida pelo usu�rio
        const quantidade = parseInt(this.value) || 0;

        // Obtenha o pre�o unit�rio do produto espec�fico
        const precoUnitario = parseFloat(spanPrecoUnitario.textContent);

        // Calcule o valor total multiplicando a quantidade pelo pre�o unit�rio
        const valorTotal = quantidade * precoUnitario;

        // Exiba o valor total no span de valor total do produto
        spanValorTotal.textContent = `${valorTotal.toFixed(2)}`; // Exibe o valor formatado com duas casas decimais
    });
});

