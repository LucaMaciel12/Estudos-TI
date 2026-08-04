use DB_02751_Luca;

create table tab_contatos(
	id_contato int primary key auto_increment,
    nome varchar(50) not null,
    telefone varchar (22) not null,
    email varchar (50) not null
);

create table tab_grupo_contatos(
	id_grupo int primary key auto_increment,
    nome varchar(30) not null
);

create table tab_telefones(
	id_telefone int primary key auto_increment,
    numero varchar(22) not null,
    recado varchar (22) not null
);

show tables;

insert into tab_contatos(nome, telefone, email) values
('João Silva', '(11) 91111-1111', 'joaoa@gmail.com'),
('Maria Ribeiro', '(11) 92222-2222', 'maria@outlook.com');

insert into tab_grupo_contatos(nome) values
('Futebol'),
('Família');

insert into tab_telefones(numero, recado) values
('(13) 91234-5678', '(14) 92134-6578'),
('(21) 91243-5687', '(33) 29319-8765');

select*from tab_contatos;
select*from tab_grupo_contatos;
select*from tab_telefones;