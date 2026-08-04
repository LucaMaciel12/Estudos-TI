use DB_02751_Luca;

create table DBDev_Alunos(
	id_aluno int primary key auto_increment, -- chave primária auto increment
    nome varchar(50) not null, -- não aceita valores vazios ou nulos
    sobrenome varchar(20) not null, -- não aceita valores vazios ou nulos
    email varchar(80) unique, -- não aceita email duplicados
    data_nascimento date, -- aceita valores vazios ou nulos
    ativo boolean default true -- coluna com valores lógico verdadeiro ou falso (1/0)
);

create table DBDev_Cursos(
	id_curso int primary key auto_increment,
    titulo varchar(60) not null,
    descricao text, 
    carga_horaria int,
    preco decimal(10,2)
);

show tables;
describe DBDev_Alunos;
describe DBDev_Cursos;

insert into DBDev_Alunos(nome, sobrenome, email, data_nascimento) values
('Ana', 'Costa', 'anacosta@gmail.com', '2006-08-18'),
('Pedro', 'Lima', 'pedrolima@gmail.com', '2006-09-19');

insert into DBDev_Alunos(nome, sobrenome, email, data_nascimento, ativo) values
('Carlos', 'Gomes', 'carlosgomes@gmail.com','2006-10-20', false);

insert into DBDev_Alunos(nome, sobrenome, email) values
('Mariana', 'Souza', 'mariasouza@gmail.com'),
('Vitoria', 'Almeida', 'vitoriaalmeida@gmail.com');


insert into DBDev_Cursos(titulo, descricao, carga_horaria, preco) values
('Introdução ao SQL', 'Fundamentos de SQL',40,399.90),
('Desenvolvimento WEB com python', 'Aprenda a criar aplicação web com python',60,699.90),
('Banco de dados Avançado', 'Tópicos avançados em Banco de dados',80,1099.9);

select*from DBDev_Alunos;
select*from DBDev_Cursos;

select id_aluno, nome from DBDev_Alunos
where nome='Pedro';

update DBDev_Alunos set email = 'pedro.novo.email@email.com' where id_aluno = 2;

begin;
update DBDev_Alunos set ativo = false where id_aluno = 4;
select*from DBDev_Alunos;
commit;
rollback;

DELETE FROM DBDev_Alunos WHERE id_aluno = 3;