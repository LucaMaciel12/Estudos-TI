--criando o banco de dados loja de doces
create database loja_doces;

--abrindo o banco de dados loja de doces
use loja_doces;

--criando a tabela de usuários
create table tab_usuarios(
	id_usuario int primary key identity,
	login varchar (20) not null,
	senha varchar (100) not null,
	palavra_chave varchar (15) not null
);

--criando a tabela de funcionário
create table tab_funcionarios(
	id_funcionario int primary key identity,
	id_usuario int not null,
	nome varchar (25) not null,
	email varchar (30) not null,
	cpf varchar (25) not null,
	rg varchar (25) not null, 
	telefone varchar (15) not null,
	status int not null,

	constraint fk_funcionario_usuario
	foreign key (id_usuario)
	references tab_usuarios(id_usuario)
);
 
--criando a tabela de clientes
create table tab_clientes(
	id_cliente int primary key identity,
	id_usuario int not null,
	nome varchar (25) not null,
	email varchar (30) not null,
	telefone varchar (15) not null,
	dtnasc date not null,

	constraint fk_cliente_usuario
	foreign key (id_usuario)
	references tab_usuarios(id_usuario)
);

-- criando a tabela de fornecedores 
create table tab_fornecedores(
	id_fornecedor int primary key identity,
	id_funcionario int not null,
	nome varchar (20) not null,
	data_entrega date not null,
	quantidade int not null,

	constraint fk_funcionario_fornecedor
	foreign key (id_funcionario)
	references tab_funcionarios (id_funcionario)
);

--criando a tabela de produtos
create table tab_produtos(
	id_produto int primary key identity,
	id_fornecedor int not null,
	nome varchar (10) not null,
	quantidade int not null,
	valor decimal (10, 2) not null,
	descricao varchar (20) not null,
	data_vencimento date not null,

	constraint fk_fornecedor_produto
	foreign key (id_fornecedor)
	references tab_fornecedores (id_fornecedor)
);

--criando a tabela de pedidos
create table tab_pedidos(
	id_pedido int primary key identity,
	id_cliente int not null,
	id_funcionario int not null,
	data date not null,
	total decimal (10, 2),

	constraint fk_cliente_pedido
	foreign key (id_cliente)
	references tab_clientes (id_cliente),

	constraint fk_funcionario_pedido
	foreign key (id_funcionario)
	references tab_funcionarios(id_funcionario)
);
 
 --criando a tabela de itens do pedidos
 create table tab_itens_pedido(
	 id_item int primary key identity,
	 id_pedido int not null,
	 id_produto int not null,
	 valor decimal(10,2) not null,
	 quantidade int not null,
	 subtotal decimal (10,2),

	 constraint fk_pedido_itens_pedido
	 foreign key (id_pedido)
	 references tab_pedidos (id_pedido),

	 constraint fk_produto_itens_pedido
	 foreign key (id_produto)
	 references tab_produtos(id_produto)
 );

--inserindo na tabela de usuarios
insert into tab_usuarios(login, senha, palavra_chave) values
('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão'),
('suadmin', 'b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0', 'padrão'),
('comum', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão'),
('comum', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão'),
('comum', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão');

--inserindo na tabela de funcionários
insert into tab_funcionarios(id_usuario, nome, email, cpf, rg, telefone, status) values 
(3, 'João da Silva', 'joao@gmail.com', '418178832-67', '61998114-3', '(11) 9211-72918', 1);

--inserindo na tabela de clientes
insert into tab_clientes(id_usuario, nome, email, telefone, dtnasc)values
(4, 'Maria Santos','maria@outlook.com', '(12) 9221-6240', '2000-09-29' ),
(5, 'Mateus Nascimento', 'mateus@hotmail.com', '(17) 9276-1222', '1999-02-12');

--inserindo na tabela de fornecedores
insert into tab_fornecedores(id_funcionario, nome, data_entrega, quantidade)values
(1, '7belo', '2026-07-10', 10),
(1, 'Deliket', '2026-07-10', 10),
(1, 'Kibon', '2026-07-15', 20);

--inserindo na tabela de produtos
insert into tab_produtos(id_fornecedor, nome, quantidade,valor, descricao, data_vencimento) values
(1, 'Pirulito', 10, 3.5, 'Sabor Framboesa', '2028-02-10'),
(2, 'Jujuba', 10, 2.00, 'Bala de goma','2029-03-05'),
(3, 'Chocolate', 20, 7.00,  'Branco meio amargo', '2027-12-09');

--inserindo na tabela de pedidos
insert into tab_pedidos(id_cliente, id_funcionario, data) values
(1,1, '2026-03-26'),
(2,1, '2026-04-10');

--inserindo na tabela de itens do pedido
insert into tab_itens_pedido(id_pedido, id_produto,quantidade, valor, subtotal)values
(1, 2, 5,2.00, 10),
(2,1,3,3.5,10.5),
(2,3,2,7,14);

select *from tab_itens_pedido;

--Listando todos os usuários
select*from tab_usuarios;

--Exibindo o nome e o email dos funcionários
select nome as Funcionário, email as Email from tab_funcionarios;

--Listando todos os clientes apenas pelo nome e data nascimento
select nome as Cliente, dtnasc as Data_Nascimento from tab_clientes;

--Exibindo os produtos com nome, valor e quantidade
select nome as Produto, valor as Preço, quantidade as Quantidade from tab_produtos;

--Listando apenas os fornecedores
select nome as Fornecedores from tab_fornecedores;

--Mostrando os telefones dos funcionários
select telefone as Contato from tab_funcionarios;

--Exibindo produtos q possuem quantidade maior q 10
select nome as Produtos from tab_produtos where quantidade > 10;

--Listando os clientes nascidos após o ano de 2000
select nome as Clientes from tab_clientes where dtnasc > '1999-12-31';

--Mostrando o funcionário cujo o nome é João
select nome as Funcionário from tab_funcionarios where nome like 'João%';

--Mostrando os produtos com o preço maior q R$5,00
select nome as Produtos from tab_produtos where valor >5;

--Listando os fornecedores cuja entrega seja no dia 2026-07-10
select nome as Fornecedor from tab_fornecedores where data_entrega = '2026-07-10';

-- Mostrando os funcionário ativos
select nome as Funcionário from tab_funcionarios where status = 1;

--Exibindo os clientes cujo e-mail contenha "hotmail"
select nome as Clientes from tab_clientes where email like '%hotmail.com';

--Listando os produtos que vencem antes de 2028-01-01
select nome as Produtos from tab_produtos where data_vencimento  < '2028-01-01';

-- Listando os produtos do menor para o maior preço 
select nome as Produtos, valor as Preço from tab_produtos order by valor asc, nome desc ;

--Exibindo os clientes em ordem alfabética
select nome as Clientes from tab_clientes order by nome asc;

--Mostrando os produtos pelo nome do mais caro para o mais barato
select nome as Produto, valor as Preço from tab_produtos order by valor desc, nome asc;

--Listando os pedidos do mais recente para o mais antigo
select id_pedido as Pedido, data as Data from tab_pedidos order by data desc;

--Mostrando quantos clientes estão cadastrados
select count(*) as total_clientes from tab_clientes;

--Mostrando quantos produtos existem
select count(quantidade) as quantidade_produtos from tab_produtos;

--Mostrando qual é o maior valor de produto
select MAX(valor) as produto_mais_caro from tab_produtos;

--Mostrando qual é o menor valor de produto
select MIN(valor) as produto_mais_barato from tab_produtos;

--Mostrando a média dos preços dos produtos
select AVG(valor) as media_precos from tab_produtos;

--Mostrando a soma de todas as quantidades dos produtos
select SUM(quantidade) as total_produtos from tab_produtos;

--Listando o nome de cada funcionário junto com seu login de usuário
select tab_funcionarios.nome as Funcionario, tab_usuarios.login as Login

from tab_funcionarios inner join tab_usuarios

on	tab_funcionarios.id_usuario = tab_usuarios.id_usuario;
 
--Listando o nome de cada cliente e seu login
select tab_clientes.nome as Cliente, tab_usuarios.login as Login

from tab_clientes inner join tab_usuarios

on tab_clientes.id_usuario = tab_usuarios.id_usuario;

--Mostrando os produtos e o fornecedor responsável
select tab_produtos.nome as Produto, tab_fornecedores.nome as Fornecedor

from tab_produtos inner join tab_fornecedores

on tab_produtos.id_fornecedor = tab_fornecedores.id_fornecedor;

--Listando cada pedido mostrando o nome do cliente
select tab_pedidos.id_pedido as Pedido , tab_clientes.nome as Cliente

from tab_pedidos inner join tab_clientes

on tab_pedidos.id_cliente = tab_clientes.id_cliente;

--Exibindo cada pedido mostrando o funcionário responsável
select tab_pedidos.id_pedido as Pedido, tab_funcionarios.nome as Funcionario

from tab_pedidos inner join tab_funcionarios

on tab_pedidos.id_funcionario  = tab_funcionarios.id_funcionario;

--Mostrando o nome do produto e a quantidade vendida em cada item do pedido
select tab_produtos.nome as Produtos, tab_itens_pedido.quantidade as Quantidade

from tab_produtos inner join tab_itens_pedido

on	tab_produtos.id_produto = tab_itens_pedido.id_produto;

--Listando número do pedido, nome do cliente, nome do funcionário, data do pedido
select tab_pedidos.id_pedido as Numero_pedido, tab_clientes.nome as Cliente, 
tab_funcionarios.nome as Funcionario, tab_pedidos.data as Data

from tab_pedidos inner join tab_clientes
on tab_pedidos.id_cliente = tab_clientes.id_cliente

inner join tab_funcionarios
on tab_pedidos.id_funcionario = tab_funcionarios.id_funcionario;

--Exibindo nome do produto, fornecedor, preço
select tab_produtos.nome as Produto, tab_fornecedores.nome as Fornecedor,
tab_produtos.valor as Preco

from tab_produtos inner join tab_fornecedores
on tab_produtos.id_fornecedor = tab_fornecedores.id_fornecedor;

--Mostrando pedido, cliente, produto comprado, quantidade, subtotal
select tab_pedidos.id_pedido as Pedido, tab_clientes.nome as Cliente, tab_produtos.nome as Produto_comprado, 
tab_itens_pedido.quantidade as Quantidade, tab_itens_pedido.subtotal as Subtotal

from tab_clientes inner join tab_pedidos
on tab_clientes.id_cliente = tab_pedidos.id_cliente

inner join tab_itens_pedido
on tab_pedidos.id_pedido = tab_itens_pedido.id_pedido

inner join tab_produtos
on tab_produtos.id_produto = tab_itens_pedido.id_produto;

--Listando todos os pedidos mostrando, cliente, funcionário, produto, quantidade
select tab_pedidos.id_pedido as Pedido, tab_clientes.nome as Cliente, tab_funcionarios.nome as Funcionario,
tab_produtos.nome as Produto, tab_itens_pedido.quantidade as Quantidade

from tab_pedidos inner join tab_clientes
on tab_pedidos.id_cliente = tab_clientes.id_cliente

inner join tab_funcionarios
on tab_funcionarios.id_funcionario = tab_pedidos.id_funcionario

inner join tab_itens_pedido 
on tab_itens_pedido.id_pedido = tab_pedidos.id_pedido

inner join tab_produtos
on tab_produtos.id_produto = tab_itens_pedido.id_produto;

--Descobrindo qual pedido possui o maior valor total
select id_pedido as Pedido, MAX(subtotal) as Valor from tab_itens_pedido group by id_pedido;

--Exibindo o faturamento da loja
select sum(subtotal) as Total_vendido from tab_itens_pedido;

