--criando o banco de dados Hospital Cruz Malta
create database hospital_cruz_malta;

--abrindo o banco de dados 
use hospital_cruz_malta;

--criando a tabela de prontuário dos pacientes
create table tab_prontuario_pacientes(
	id_paciente int not null primary key identity,
	nome varchar (50) not null,
	idade int not null,
	sexo varchar (20) not null,
	data_nascimento date not null,
	data_cadastro date not null,
	cor_etnia varchar (30)not null,
	cpf varchar (15) not null,
	rg varchar(20) not null,
	telefone varchar (20) not null, 
	telefone_secundario varchar (20) not null,
	nome_pai varchar (30) not null,
	nome_mae varchar (30) not null,
	nacionalidade varchar (20) not null,
	naturalidade varchar (20) not null,
	nome_responsavel varchar (30),
	profissao varchar (30),
	escolaridade varchar (30)
);

--criando a tabela de médicos e suas especilidades
create table tab_medicos(
	id_medico int not null primary key identity,
	nome varchar (50) not null,
	crm varchar (25) not null,
	cpf varchar (15) not null,
	rg varchar(20) not null,
	especialidade varchar (50) not null
);

--criando a tabela de histórico dos pacientes 
create table tab_historico_pacientes(
	id_historico int not null primary key,
	id_paciente int not null,
	id_medico int not null,
	doencas_preexistentes varchar(100) not null,
    alergias varchar(100) not null,
    medicacoes_atuais varchar(100) not null,
	data_registro date not null,

	constraint fk_paciente
    foreign key (id_paciente)
    references tab_prontuario_pacientes(id_paciente),

	constraint fk_medico
    foreign key (id_medico)
    references tab_medicos(id_medico)
);

--populando a tabela de prontuário de pacientes
insert into tab_prontuario_pacientes
(nome, idade, sexo, data_nascimento, data_cadastro, cor_etnia, cpf, rg, telefone, telefone_secundario,
nome_pai, nome_mae, nacionalidade, naturalidade, nome_responsavel, profissao, escolaridade)
values
('João Silva',30,'masculino','1995-05-10','2026-03-20','branca','111.111.111-11','rg sp 1111111','(11)91111-1111','(11)92222-2222','carlos silva','maria silva','brasileiro','sao paulo',null,'analista','superior'),
('Ana Costa',25,'feminino','2000-08-15','2026-03-20','parda','222.222.222-22','rg sp 2222222','(11)93333-3333','(11)94444-4444','paulo costa','lucia costa','brasileira','campinas',null,'estudante','medio'),
('Carlos Lima',40,'masculino','1985-02-20','2026-03-20','negra','333.333.333-33','rg sp 3333333','(11)95555-5555','(11)96666-6666','joao lima','ana lima','brasileiro','santos',null,'motorista','fundamental'),
('Mariana Alves',35,'feminino','1990-03-12','2026-03-20','branca','444.444.444-44','rg sp 4444444','(11)97777-7777','(11)98888-8888','pedro alves','rosa alves','brasileira','osasco',null,'enfermeira','superior'),
('Pedro Souza',28,'masculino','1997-07-22','2026-03-20','parda','555.555.555-55','rg sp 5555555','(11)99999-9999','(11)90000-0000','marcos souza','julia souza','brasileiro','guarulhos',null,'tecnico','medio'),
('Lucas Fernandes',32,'masculino','1993-11-05','2026-03-20','branca','666.666.666-66','rg sp 6666666','(11)91111-2222','(11)92222-3333','antonio fernandes','carla fernandes','brasileiro','sorocaba',null,'programador','superior'),
('Juliana Rocha',29,'feminino','1996-01-18','2026-03-20','negra','777.777.777-77','rg sp 7777777','(11)93333-4444','(11)94444-5555','roberto rocha','ana rocha','brasileira','barueri',null,'professora','superior'),
('Rafael Dias',45,'masculino','1980-06-30','2026-03-20','parda','888.888.888-88','rg sp 8888888','(11)95555-6666','(11)96666-7777','jose dias','maria dias','brasileiro','diadema',null,'engenheiro','superior'),
('Camila Ribeiro',27,'feminino','1998-09-09','2026-03-20','branca','999.999.999-99','rg sp 9999999','(11)97777-8888','(11)98888-9999','paulo ribeiro','lucia ribeiro','brasileira','maua',null,'designer','superior'),
('Bruno Martins',38,'masculino','1987-12-01','2026-03-20','negra','000.000.000-00','rg sp 0000000','(11)90000-1111','(11)91111-2222','marcos martins','ana martins','brasileiro','santo andre',null,'vendedor','medio');

--populando a tabela de médicos 
insert into tab_medicos
(nome, crm, cpf, rg, especialidade)
values
('Dr. Paulo Rocha','crm/sp 100001','101.101.101-01','rg sp 1010101','cardiologia'),
('Dra. Fernanda Alves','crm/sp 100002','202.202.202-02','rg sp 2020202','dermatologia'),
('Dr. Ricardo Souza','crm/sp 100003','303.303.303-03','rg sp 3030303','clinico geral'),
('Dra. Júlia Lima','crm/sp 100004','404.404.404-04','rg sp 4040404','pediatria'),
('Dr. André Costa','crm/sp 100005','505.505.505-05','rg sp 5050505','ortopedia'),
('Dra. Patricia Dias','crm/sp 100006','606.606.606-06','rg sp 6060606','ginecologia'),
('Dr. Marcos Ribeiro','crm/sp 100007','707.707.707-07','rg sp 7070707','neurologia'),
('Dra. Claudia Fernandes','crm/sp 100008','808.808.808-08','rg sp 8080808','psiquiatria'),
('Dr. Lucas Martins','crm/sp 100009','909.909.909-09','rg sp 9090909','urologia'),
('Dra. Camila Silva','crm/sp 100010','010.010.010-10','rg sp 0101010','endocrinologia');

--populando a tabela de histórico de pacientes
insert into tab_historico_pacientes
(id_historico, id_paciente, id_medico, doencas_preexistentes, alergias, medicacoes_atuais, data_registro)
values
(1,1,1,'hipertensao','penicilina','losartana','2026-03-21'),
(2,2,2,'nenhuma','poeira','nenhuma','2026-03-21'),
(3,3,3,'diabetes','nenhuma','insulina','2026-03-21'),
(4,4,4,'asma','poeira','bombinha','2026-03-21'),
(5,5,5,'nenhuma','dipirona','nenhuma','2026-03-21'),
(6,6,6,'colesterol alto','nenhuma','sinvastatina','2026-03-21'),
(7,7,7,'ansiedade','nenhuma','sertralina','2026-03-21'),
(8,8,8,'depressao','nenhuma','fluoxetina','2026-03-21'),
(9,9,9,'hipertensao','amendoim','atenolol','2026-03-21'),
(10,10,10,'diabetes','nenhuma','metformina','2026-03-21');

--mostrando todas as tabelas do esquema
select * from information_schema.tables;

--mostrando todo o conteúdo da tabela prontuário pacientes
select * from tab_prontuario_pacientes;

--mostrando todo o conteúdo da tabela médicos
select * from tab_medicos;

--mostrando todo o conteúdo da tabela histórico pacientes
select * from tab_historico_pacientes;

--mostrando todos os pacientes ordenados por nome em ordem crescente (A-Z)
select nome from tab_prontuario_pacientes order by nome asc;

--mostrando todos os pacientes ordenados por nome em ordem crescente (Z-A)
select nome from tab_prontuario_pacientes order by nome desc;

--mostrando todos os pacientes ordenados por idade (do mais velho para o mais novo)
select nome, idade from tab_prontuario_pacientes order by idade desc;

--mostrando todos os pacientes ordenados por idade (do mais novo para o mais velho)
select nome, idade from tab_prontuario_pacientes order by idade asc;

--mostrando apenas o nome e o telefone dos pacientes 
select nome,telefone from tab_prontuario_pacientes;

--mostrando os médicos ordenados pela especialidade
select especialidade, nome from tab_medicos order by especialidade;

--mostrando somente pacientes do sexo feminino
select nome, sexo from tab_prontuario_pacientes where sexo = 'feminino';

--mostrando os pacientes com idade maior que 30 anos
select nome, idade from tab_prontuario_pacientes where idade > 30;

--mostrando os pacientes que nasceram depois de 1995
select nome from tab_prontuario_pacientes where data_nascimento > '1995-12-31';

--mostrando os médicos da especialidade "cardiologia"
select nome, especialidade from tab_medicos where especialidade = 'cardiologia';

--mostrando pacientes da cidade "sao paulo"
select nome from tab_prontuario_pacientes where naturalidade = 'sao paulo';

--mostrando os pacientes com escolaridade "superior"
select nome from tab_prontuario_pacientes where escolaridade = 'superior';

--contando quantos pacientes existem na tabela
select COUNT (nome) as 'Pacientes' from tab_prontuario_pacientes;

--fazendo a média de idade dos pacientes
select AVG (idade) as 'Média idade pacientes' from tab_prontuario_pacientes;

--mostrando a maior idade entre os pacientes
select idade as 'Maior idade',nome as 'Paciente mais velho' from tab_prontuario_pacientes where idade = (select MAX(idade) from tab_prontuario_pacientes) ;

--contando quantos médicos tem por especialidade
select COUNT(nome) as 'Médicos', especialidade from tab_medicos group by especialidade;

--contando quantos pacientes são do sexo masculino
select COUNT(sexo) as 'Número de pacientes do sexo masculino' from tab_prontuario_pacientes where sexo = 'masculino';

--agrupando e contando os pacientes por sexo
select sexo, COUNT(*) as 'Quantidade' from tab_prontuario_pacientes group by sexo;

--agrupando os pacientes por escolaridade
select escolaridade, COUNT(*) as 'Escolaridade' from tab_prontuario_pacientes group by escolaridade;

--agrupando os médicos por especialidade
select especialidade, COUNT(*) as 'Especialidade' from tab_medicos group by especialidade;