--criando o banco de dados
create database lojaeletronicos;

--ativando o banco de dados
use lojaeletronicos;

--criando tabela de clientes
create table tab_clientes(
	id_cliente int not null primary key identity,
	nome varchar(100) not null,
	endereco varchar(100) not null,
	telefone varchar(15) not null,
	email varchar(100) not null,
	data_cadastro date
);

--criando tabela de pedidos
create table tab_pedidos(
	id_pedido int not null primary key identity,
	id_cliente int not null,
	nome_produto varchar(100) not null,
	descricao varchar(100) not null,
	data_venda date not null,
	prazo_validade date not null,
	quantidade int not null,
	valor_unitario decimal(10,2) not null,
	valor_total decimal(10,2) not null,

	 constraint fk_id_cliente
	 foreign key (id_cliente)
	 references tab_clientes (id_cliente)	
);

select * from INFORMATION_SCHEMA.TABLES;


--populando a tabela de clientes
insert into tab_clientes(nome,endereco,telefone, email, data_cadastro)values
('João Silva', 'Rua da lama, 34','(11) 91111-1111', 'joaosilva@gmail.com','2026-03-17'),
('Maria Santos', 'Avenida B', '(11) 92222-2222', 'maria_snts@gmail.net', '2025-08-19'),
('Pedro Oliveira', 'Rua C, 789', '(21) 97777-3333','pedro@email.com', '2024-09-10'),
('Ana Costa', 'Av D, 321','(31) 96666-4444', 'ana@email.com','2023-10-09'),
('Carlos Lima','Rua E, 654','(41) 95555-5555', 'carlos@email.com', '2022-03-20');

--populando a tabela de pedidos
insert into tab_pedidos(id_cliente,nome_produto, descricao,data_venda,prazo_validade,
quantidade,valor_unitario,valor_total)values
(1, 'Notebook Dell', 'Notebook i7 16GB RAM', '2024-01-15', '2026-01-16', 2, 3500.00,7000.00),
(1,' Mouse Wireless', 'Mouse sem fio', '2024-01-15','2027-01-09', 3, 89.90, 269.70),
(2, 'Smart TV50', 'TV 4K', '2024-01-20', '2026-01-16',1, 599.00, 599.00),
(3, 'Smartphone', 'Celular 128GB', '2024-01-02','2025-02-01',2,1899.00, 3798.00),
(4, 'Fone Bluetooth', 'Fone sem fio', '2024-02-10', '2026-10-01',3, 149.90, 449.70);

select*from tab_clientes;

select*from tab_pedidos;

select nome, telefone from tab_clientes;

select nome_produto, data_venda, quantidade from tab_pedidos;

select * from tab_clientes order by nome asc;

select * from tab_clientes order by nome desc;

select * from tab_pedidos order by data_venda desc;

select * from tab_pedidos order by data_venda asc;

select * from tab_pedidos order by valor_total asc;

select * from tab_pedidos order by valor_total desc;

select *from tab_clientes where endereco = 'rua a, 123';

select * from tab_pedidos where nome_produto = 'notebook dell';

select * from tab_pedidos where quantidade > 1;

select * from tab_pedidos where valor_unitario > 1000;

select * from tab_pedidos where data_venda = '2024-01-15';

select distinct nome_produto from tab_pedidos;

select distinct data_venda from tab_pedidos;

select * from tab_pedidos where nome_produto = 'smartphone'and quantidade > 1;

select * from tab_pedidos where valor_total > 2000 and quantidade = 1;

select * from tab_pedidos where data_venda between '2024-01-01' and '2024-01-31';