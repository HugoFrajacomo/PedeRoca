USE [db_PedeRoca]
GO
SET IDENTITY_INSERT [dbo].[tb_usuarios] ON 

INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (1, N'Hugo Vitor Colombo Frajacomo', N'455.648.484-84', N'(16) 98159-2207', CAST(N'1993-01-20' AS Date), N'frajacomo2@gmail.com', N'14805-026', N'SP', N'Araraquara', N'Av. Humberto de Onofre', N'Jardim Botânico', 48, N'Casa', N'hugo123', 0, 0, 0, 1, 1)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (2, N'Gabriel Dall'' Acqua Pelícolla', N'54894984954', N'4561561561', CAST(N'1996-08-07' AS Date), N'g.d.p@gmail.com', N'14801000', N'SP', N'Araraquara', N'Rua Não vou informar', N'Sem informação', 895, N'', N'gabriel987', 0, 0, 0, 1, 1)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (5, N'Ana Silva', N'12345678900', N'11987654321', CAST(N'1992-04-15' AS Date), N'ana@email.com', N'01234567', N'SP', N'São Paulo', N'Rua das Flores', N'Jardim Primavera', 123, N'Apartamento 101', N'ana123', 1, 1, 1, 1, 2)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (6, N'Pedro Oliveira', N'98765432100', N'2123456789', CAST(N'1988-09-25' AS Date), N'pedroliveira@email.com', N'54321098', N'RJ', N'Rio de Janeiro', N'Avenida Central', N'Centro', 456, N'Casa 2', N'minhasenha', 1, 1, 1, 1, 2)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (8, N'Carla Santos', N'11122233344', N'31555559999', CAST(N'1995-07-03' AS Date), N'carla.santos@email.com', N'70000000', N'MG', N'Belo Horizonte', N'Rua das Palmeiras', N'Vila Verde', 789, N'casa', N'carla123', 1, 1, 1, 1, 2)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (9, N'Mariana Souza', N'55544433322', N'11999998888', CAST(N'1990-12-22' AS Date), N'mariana.souza@gmail.com', N'54321678', N'SP', N'São Paulo', N'Avenida Brasil', N'Jardim América', 985, N'Apartamento bloco 2', N'mariana456', 1, 1, 1, 1, 2)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (10, N'Juliana Lima', N'44433322211', N'11222223333', CAST(N'1989-07-30' AS Date), N'juliana.lima@email.com', N'98765432', N'MG', N'Belo Horizonte', N'Avenida Central', N'Savassi', 1234, N'Apt 501', N'lima789', 1, 1, 1, 1, 2)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (11, N'Geraldo Elfridis da Cunha', N'15184847848', N'84848512318', CAST(N'2000-08-21' AS Date), N'geraldoelf@gmail.com', N'54848484', N'SP', N'Araraquara', N'Av. Milton Scarfs', N'Melhado', 95, N'casa', N'51/84164+1esda@', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (12, N'Rodrigo Defante', N'51818123121', N'16198748418', CAST(N'2007-11-13' AS Date), N'rodrigo.defante@hotmail.com', N'14801232', N'SP', N'Araraquara', N'Av. Gusmão Bertine', N'Altos do Jaraguá', 48, N'Apt 302', N'3612/*-41+11av@@@3q', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (13, N'Gabriela Vieira de Santos', N'61298498145', N'16987421848', CAST(N'2001-09-06' AS Date), N'gabi.vieira@outlook.com.br', N'14801533', N'MG', N'Poços de Caldas', N'Av Prudente de Morais', N'Liberdade', 123, N'Casa B', N'654184632a1vz84', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (14, N'Fernando Bertrini', N'51697849871', N'19846151981', CAST(N'1997-05-22' AS Date), N'fernandoBrt@gmail.com', N'16584984', N'SP', N'Pirapora', N'Rua Daniel Jalão', N'São Miguel', 98, N'nenhum', N'ac99- 192j 3', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (15, N'Hercolis Menenguel', N'48945198498', N'98498498198', CAST(N'1982-02-15' AS Date), N'h.meneguel@gmailcom', N'16541848', N'SP', N'Araraquara', N'Rua Prudente de Morais', N'Botânico', 84, N'casa', N'49846521888487652165a1 212 3dav@#$¨@#$', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (16, N'Bento Ribeiro', N'184.841.518-54', N'(16) 98847-6216', CAST(N'1962-12-20' AS Date), N'bentoribeiro@gmail.com', N'16541848', N'SP', N'Araraquara', N'Av. Tester', N'Jardim Botânico', 48, N'Casa', N'bento1234', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (17, N'Gabriel Laroca', N'21946515181', N'15964151651', CAST(N'2001-11-05' AS Date), N'homemsemalianca@gmail.com', N'65184184', N'SP', N'Araraquara', N'Av. Cheiro de Laranja', N'Cultrale', 666, N'Casa da amante', N'gaybriel69', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (18, N'Lucas Monitor', N'98498484181', N'15184848484', CAST(N'1999-01-20' AS Date), N'lucasoperado@gmail.com', N'14805620', N'SP', N'Araraquara', N'Rua Suspeita', N'Britos', 659, N'3º balão a esquerda, pedir permissão pro dono da boca', N'651as81a', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (19, N'Robson da Silva', N'15685484848', N'16945945848', CAST(N'2010-05-15' AS Date), N'robsonbololo@gmail.com', N'14802652', N'SP', N'Araraquara', N'Rua Sei lá mesmo', N'Seilandia', 6565, N'casa', N'aaaaas65as9a5', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (20, N'Camila Sernelho de Santos', N'430.116.497-21', N'(16) 98847-6216', CAST(N'1988-02-20' AS Date), N'camila.sernelho@email.com', N'14805-026', N'SP', N'Araraquara', N'Avenida Humberto de Onofre', N'Jardim Botânico', 65, N'casa', N'1854/84q62as9a4', 1, 1, 1, 1, 0)
INSERT [dbo].[tb_usuarios] ([id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]) VALUES (22, N'Sebastião Colombo', N'459.788.416-23', N'(16) 98152-5987', CAST(N'1990-11-25' AS Date), N'seba@email.com', N'14805-029', N'SP', N'Araraquara', N'', N'Jardim Botânico', 2, N'Apartamento 3', N'4515a18v42$@$a984', 1, 1, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[tb_usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_carrinhoCompras] ON 

INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (1, 5)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (2, 1)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (3, 2)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (6, 9)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (7, 16)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (11, 6)
INSERT [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra], [id_usuario]) VALUES (13, 8)
SET IDENTITY_INSERT [dbo].[tb_carrinhoCompras] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_compras] ON 

INSERT [dbo].[tb_compras] ([id_compra], [id_usuario], [id_carrinhoCompra], [dataHoraCompra], [valorTotal]) VALUES (4, 1, 1, CAST(N'2023-12-04T00:00:00.000' AS DateTime), CAST(1000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[tb_compras] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_produtos] ON 

INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (1, N'Alface', N'Alface fresca e crocante, fonte de nutrientes essenciais. Ideal para saladas e sanduíches. Qualidade e sabor para suas refeições!', N'Alface.jpg', 80, CAST(4.39 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (3, N'Cebolinha', N'Erva aromática baixa em calorias, rica em antioxidantes e vitaminas A e C.', N'Cebolinha.jpg', 50, CAST(7.20 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (4, N'Repolho roxo', N'Hortaliça nutritiva, rico em fibras, vitamina C e antioxidantes, que auxiliam na saúde intestinal e fortalecem o sistema imunológico.', N'RepolhoRoxo.jpg', 50, CAST(4.50 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (5, N'Repolho', N'Hortaliça versátil, baixa em calorias e rica em fibras, vitaminas C e K, além de minerais como potássio e cálcio.', N'Repolho.jpg', 15, CAST(4.85 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (6, N'Rúcula', N'Baixo teor calórico, vitaminas A e K, além de minerais como ferro e cálcio, promovendo a saúde ocular e óssea.', N'Rucula.jpg', 48, CAST(4.75 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (7, N'Salsinha', N'A salsinha é uma erva aromática rica em vitaminas A e C, além de minerais, com propriedades benéficas para a saúde.', N'Salsinha.jpg', 48, CAST(2.58 AS Decimal(18, 2)), 3, 3, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (8, N'Banana', N'A banana é uma fruta nutritiva, rica em potássio, fibras e vitaminas C e B6, fornecendo energia.', N'Banana.jpg', 7, CAST(8.90 AS Decimal(18, 2)), 6, 1, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (9, N'Maçã', N'A salsina é uma erva aromática rica em vitaminas A e C, além de minerais, com propriedades benéficas para  a saúde.', N'Maca.jpg', 40, CAST(1.80 AS Decimal(18, 2)), 4, 1, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (10, N'Limão', N'Fruta cítrica rica em vitamina C e antioxidantes, com propriedades desintoxicantes, digestivas e fortalecedoras do sistema imunológico.', N'Limao.jpg', 251, CAST(4.90 AS Decimal(18, 2)), 4, 1, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (11, N'Melancia', N'A melancia é uma fruta refrescante e hidratante, composta principalmente por água, além de ser fonte de vitaminas A e C.', N'Melancia.jpg', 0, CAST(13.40 AS Decimal(18, 2)), 4, 1, 0)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (12, N'Pera', N'Fruta suculenta e rica em fibras, vitaminas C e K, além de minerais como cobre e potássio, promovendo a saúde digestiva.', N'Pera.jpg', 85, CAST(7.20 AS Decimal(18, 2)), 4, 1, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (13, N'Abobrinha', N'Vegetal de baixo teor calórico, rico em fibras, vitaminas A e C, além de minerais como potássio, trazendo benefícios para a digestão.', N'Maca.jpg', 47, CAST(4.80 AS Decimal(18, 2)), 4, 2, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (14, N'Berinjela', N'Vegetal nutritivo, rico em fibras, antioxidantes e vitaminas B e K, auxiliando na saúde digestiva.', N'Beringela.jpg', 14, CAST(5.64 AS Decimal(18, 2)), 4, 2, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (15, N'Cenoura', N'Raiz nutritiva, rica em vitamina A, fibras e antioxidantes, beneficiando a saúde ocular, imunidade e saúde da pele.', N'Cenoura.jpg', 150, CAST(2.17 AS Decimal(18, 2)), 4, 2, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (16, N'Primentão', N'Raiz nutritiva, rica em vitamina A, fibras e antioxidantes, beneficiando a saúde ocular, imunidade e saúde da pele.', N'Pimentao.jpg', 71, CAST(7.90 AS Decimal(18, 2)), 4, 2, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (17, N'Rabanete', N'Raiz crocante e picante, rico em fibras, vitamina C e potássio, contribuindo para a saúde digestiva.', N'Rabanete.jpg', 64, CAST(4.60 AS Decimal(18, 2)), 4, 2, 1)
INSERT [dbo].[tb_produtos] ([id_produto], [nome], [descricao], [imagem], [qtd_estoque], [preco_unitario], [unidade], [tipo_produto], [ativo]) VALUES (18, N'Uva', N'Fruta suculenta e rica em fibras, vitaminas C e K, além de minerais como cobre e potássio, promovendo a saúde digestiva.', N'Uva.jpg', 150, CAST(4.85 AS Decimal(18, 2)), 4, 1, 1)
SET IDENTITY_INSERT [dbo].[tb_produtos] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_itensCarrinho] ON 

INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (1, 5, 1, 5)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (2, 4, 1, 3)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (3, 7, 1, 1)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (4, 8, 1, 2)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (6, 3, 7, 1)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (7, 1, 7, 1)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (8, 4, 7, 1)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (9, 12, 7, 2)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (10, 13, 7, 5)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (11, 4, 2, 10)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (12, 9, 2, 2)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (13, 7, 2, 4)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (14, 4, 2, 1)
INSERT [dbo].[tb_itensCarrinho] ([id_itemCarrinho], [id_produto], [id_carrinhoCompra], [quantidade]) VALUES (15, 8, 2, 1)
SET IDENTITY_INSERT [dbo].[tb_itensCarrinho] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_favoritoProdutos] ON 

INSERT [dbo].[tb_favoritoProdutos] ([id_favoritoProduto], [id_produto], [id_usuario]) VALUES (1, 1, 5)
INSERT [dbo].[tb_favoritoProdutos] ([id_favoritoProduto], [id_produto], [id_usuario]) VALUES (2, 1, 6)
SET IDENTITY_INSERT [dbo].[tb_favoritoProdutos] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_contatos] ON 

INSERT [dbo].[tb_contatos] ([id_contato], [e_mail], [conteudo]) VALUES (3, N'julieta.pereira@email.com', N'Olá Equipe,

Gostaria de expressar minha experiência recente ao utilizar o site para adquirir produtos de hortifrúti. Primeiramente, queria parabenizá-los pela variedade de itens frescos oferecidos. No entanto, ao navegar pelo site, percebi que algumas categorias poderiam ser mais detalhadas para facilitar a busca de produtos específicos, como variedades de tomates ou tipos de alfaces.

Além disso, senti falta de informações mais detalhadas sobre a procedência dos produtos, como região de cultivo, métodos agrícolas utilizados e possíveis certificações orgânicas. Isso seria extremamente útil para consumidores preocupados com a origem e qualidade dos alimentos que estão adquirindo.

Por fim, gostaria de parabenizar o excelente atendimento prestado pela equipe de suporte ao cliente. Recebi ajuda prontamente quando precisei tirar uma dúvida sobre os prazos de entrega.

Agradeço a atenção e adoraria ver essas sugestões sendo consideradas para a melhoria contínua do site.')
INSERT [dbo].[tb_contatos] ([id_contato], [e_mail], [conteudo]) VALUES (5, N'marcos.rodrigues@email.com', N'Prezada Equipe,

Recentemente, realizei uma compra de frutas e verduras em seu site e gostaria de compartilhar minha experiência. Em primeiro lugar, fiquei muito satisfeito com a qualidade dos produtos recebidos, estavam frescos e bem embalados. No entanto, durante o processo de navegação, identifiquei um pequeno problema ao tentar aplicar um cupom de desconto que recebi por e-mail. Parece que o código não estava sendo aceito no momento do checkout.

Além disso, senti falta de mais opções de frutas exóticas e variedades menos comuns. Seria ótimo se pudessem expandir o catálogo para incluir esses itens, pois são difíceis de encontrar em outros lugares.

Por outro lado, elogio o serviço de entrega, que foi pontual e o pacote chegou em perfeitas condições. No entanto, seria interessante ter a opção de agendar um horário mais preciso para a entrega, já que tive que esperar um pouco mais do que o previsto.')
INSERT [dbo].[tb_contatos] ([id_contato], [e_mail], [conteudo]) VALUES (6, N'gabriel.oliveira@email.com', N'Gostaria de aproveitar este momento para compartilhar minha experiência ao utilizar o site para adquirir produtos frescos. Primeiramente, parabéns pela interface intuitiva e fácil navegação. Foi muito simples encontrar os produtos que precisava.

No entanto, durante a finalização da compra, encontrei uma dificuldade ao tentar pagar com um cartão internacional. Parece que o sistema não estava aceitando essa modalidade de pagamento, o que acabou atrasando um pouco o processo. Seria interessante se houvesse uma maior compatibilidade de formas de pagamento para atender clientes internacionais.

Além disso, percebi que seria útil ter mais informações nutricionais disponíveis para os produtos. Para quem busca por uma alimentação mais saudável, esses detalhes são essenciais na hora de escolher os itens.')
INSERT [dbo].[tb_contatos] ([id_contato], [e_mail], [conteudo]) VALUES (7, N'Jose.vernicio@email.com', N'Escrevo para compartilhar minha recente experiência de compra em seu site. Primeiramente, quero expressar minha satisfação com a qualidade dos produtos que adquiri. Os vegetais estavam incrivelmente frescos e corresponderam totalmente às expectativas.

No entanto, gostaria de sugerir a inclusão de um sistema de avaliações e comentários por parte dos clientes. Acredito que essa funcionalidade poderia ser muito útil para outros usuários, permitindo compartilhar opiniões e experiências com os produtos adquiridos, além de auxiliar na escolha para futuras compras.

Além disso, senti falta de uma seção de receitas ou sugestões de preparo para os produtos disponíveis no site. Isso seria extremamente interessante para clientes que buscam inspiração na cozinha e desejam explorar diferentes formas de utilizar os itens comprados.

Por último, mas não menos importante, destaco o excelente serviço de entrega. Os produtos chegaram no prazo estabelecido e o entregador foi muito cordial.')
SET IDENTITY_INSERT [dbo].[tb_contatos] OFF
GO
