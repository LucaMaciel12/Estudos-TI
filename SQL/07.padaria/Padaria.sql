use DB_02751_Luca;

create table PaoQuente_Fornecedor(
	id_fornecedor int primary key auto_increment,
    nome varchar(50) not null,
    telefone varchar(22) not null
);

create table PaoQuente_Produto(
	id_produto int primary key auto_increment,
    nome varchar(50)not null,
    preco decimal(8,2) not null,
    id_fornecedor int,
    
    foreign key (id_fornecedor)
    references PaoQuente_Fornecedor (id_fornecedor)
);

create table PaoQuente_Venda(
	id_venda int primary key auto_increment,
    id_produto int not null,
    quantidade int not null,
    data_venda date not null,
    
    foreign key (id_produto)
    references PaoQuente_Produto (id_produto)
);

show tables;

insert into PaoQuente_Fornecedor(nome, telefone) values 
('Moinhos Santista', '(11) 91111-1111'),
('SA Laticinios Parmalat','(11) 92222-2222'),
('Moinhos Hernmann','(11) 93333-3333');

select*from PaoQuente_Fornecedor;
select*from PaoQuente_Produto;
select*from PaoQuente_Venda;

insert into PaoQuente_Produto(nome,preco,id_fornecedor) values
('Farinha de trigo', 542.25, 1),
('Leite Longa Vida', 85.70, 2),
('Fermento Itaiquara', 41.65, 3),
('Amido de milho', 23.14, 1),
('Requiejão integral', 12.85, 2),
('Farinha de rosca', 489.78, 3);

insert into PaoQuente_Venda(id_produto,quantidade,data_venda) values
(1,3,'2025-07-18'),
(2,5,'2025-07-18'),
(3,10,'2025-07-18'),
(5,15,'2025-07-18'),
(6,8,'2025-07-18'),
(4, 3,'2025-07-18'),
(2,10,'2025-07-18');

select quantidade ,id_produto from PaoQuente_Venda order by quantidade asc;

select V.quantidade, V.id_produto , P.nome
from PaoQuente_Venda V join
PaoQuente_Produto P where
V.id_produto = P.id_produto 
order by quantidade asc;