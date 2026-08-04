/* criando o banco de dados*/
create database barbearia;


/* abrindo o banco de dados*/
use barbearia;

/* criando a tabela de usuários*/
create table tab_usuarios(
	id_usuario int not null primary key identity,
	nome varchar (50) not null,
	email varchar(50) not null,
	telefone varchar(50) not null,
	login varchar(20) not null,
	senha varchar(100) not null,
	frase varchar(50) not null,
	nivel int not null,
	situacao int not null
);

/*criando a tabela de cliente*/
create table tab_clientes(
	id_cliente int not null primary key identity,
	nome varchar(30) not null,
	cpf varchar(20)not null,
	telefone varchar(25) not null,
	email varchar(50) not null,
	ativo int not null
);

/*criando a tabela de serviços*/
create table tab_servicos(
	id_servico int not null primary key identity,
	nome varchar(30) not null,
	valor decimal(10,2) not null,
	tempo_estimado time not null,
	ativo int not null
);

/*criando a tabela de agendamentos*/
create table tab_agendamentos(
	id_agendamento int not null primary key identity,
	id_cliente int not null,
	id_servico int not null,
	data date not null,
	horario time not null,
	ativo int not null,
	valorTotal decimal(10,2) not null,
	tempo time not null,

	CONSTRAINT fk_id_cliente
	FOREIGN KEY (id_cliente)
	REFERENCES tab_clientes(id_cliente),

	constraint fk_id_servico
	foreign key (id_servico)
	references tab_servicos(id_servico)
);
 
 SELECT * FROM INFORMATION_SCHEMA.TABLES;

 insert into tab_usuarios(nome,email,telefone,login,senha,frase,nivel,situacao)values
 ('Luca Maciel','lucamaciel15nasc@gmail.com', '(11) 98398-1743','admin','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3','Padrão',0,1),
 ('Tais Maciel','taismaciel83@gmail.com','(11) 95178-0529','comum','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3','Padrão',1,1);

 insert into tab_clientes(nome,cpf,telefone,email,ativo)values
 ('Rafael','111.111.111-11','(11) 91111-1111', 'rafael@gmail.com',1),
 ('Gabriel','222.222.222-22','(11) 92222-2222', 'gabriel@gmail.com',1);

 insert into tab_servicos(nome,valor,tempo_estimado,ativo)values
 ('Corte',35,'00:40',1),
 ('Barba',20, '00:15',1);

select *from tab_clientes;
 select * from tab_servicos;
 select * from tab_usuarios;
 select*from tab_agendamentos;
 SELECT * FROM INFORMATION_SCHEMA.TABLES;

 use barbearia;
