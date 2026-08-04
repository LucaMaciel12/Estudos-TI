--criando o banco de dados pizzaria
create database pizzaria;

--abrindo o banco de dados
use pizzaria;

--criando a tabela de clientes 
create table clientes(
	id_cliente int primary key identity not null,
	nome varchar(100) not null,
	telefone varchar(20) not null,
	email varchar (100) not null,
	-- Coluna "data_cadastro" do tipo DATE; se nenhum valor for informado no INSERT,
	-- o SQL Server preenche automaticamente com a data atual do sistema (GETDATE()).
	data_cadastro date default getdate() not null
);

--criando a tabela de fornecedores
create table fornecedores(
	 id_fornecedor INT PRIMARY KEY IDENTITY not null,
    nome_empresa VARCHAR(100) NOT NULL,
    contato VARCHAR(100)not null,
    telefone VARCHAR(20)not null,
    produto_fornecido VARCHAR(100) not null
);

--criando a tabela funcionários
create table funcionarios(
	id_funcionario INT PRIMARY KEY IDENTITY not null,
    nome VARCHAR(100) NOT NULL,
    cargo VARCHAR(50) not null,
    salario DECIMAL(10,2) not null,
    data_contratacao DATE DEFAULT GETDATE() not null
);

--criando a tabela de produtos
create table produtos(
	 id_produto INT PRIMARY KEY IDENTITY not null,
    nome_produto VARCHAR(100) NOT NULL,
    categoria VARCHAR(50) not null,
    preco DECIMAL(10,2) not null,
    id_fornecedor INT not null,
    CONSTRAINT fk_prod_fornecedor 
        FOREIGN KEY (id_fornecedor) REFERENCES fornecedores(id_fornecedor)
);

--criando a tabela de mesas
create table mesas(
	id_mesa INT PRIMARY KEY IDENTITY not null,
    capacidade INT not null,
    status VARCHAR(20) not null,
);

--criando a tabela de reservas
create table reservas(
	id_reserva INT PRIMARY KEY IDENTITY not null,
    id_mesa INT not null,
    id_cliente INT not null,
    data_reserva DATE not null,
    horario_reserva VARCHAR(10) not null,
    qtd_pessoas INT,
    status_reserva VARCHAR(20) not null,
    CONSTRAINT fk_res_mesa 
    FOREIGN KEY (id_mesa) REFERENCES mesas(id_mesa),
    CONSTRAINT fk_res_cliente 
   FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

--criando a tabela de pedidos
create table pedidos(
	id_pedido INT PRIMARY KEY IDENTITY not null,
    id_cliente INT not null,
    id_mesa INT not null,
    id_funcionario INT not null,
    data_pedido DATE DEFAULT GETDATE() not null,
    valor_total DECIMAL(10,2) not null,
    status_pedido VARCHAR(20) not null,
    CONSTRAINT fk_ped_cliente 
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT fk_ped_mesa 
    FOREIGN KEY (id_mesa) REFERENCES mesas(id_mesa),
    CONSTRAINT fk_ped_func 
	FOREIGN KEY (id_funcionario) REFERENCES funcionarios(id_funcionario)
);

--criando a tabela de itens do pedido
create table itens_do_pedido(
	id_item INT PRIMARY KEY IDENTITY not null,
    id_pedido INT not null,
    id_produto INT not null,
    quantidade INT not null,
    preco_unitario DECIMAL(10,2) not null,
    subtotal DECIMAL(10,2) not null,
    CONSTRAINT fk_item_pedido 
    FOREIGN KEY (id_pedido) REFERENCES pedidos(id_pedido),
    CONSTRAINT fk_item_produto 
    FOREIGN KEY (id_produto) REFERENCES produtos(id_produto)
);

--inserindo na tabela de clientes
INSERT INTO clientes (nome, telefone, email) VALUES
('João Silva', '11999990001', 'joao@email.com'),
('Maria Souza', '11999990002', 'maria@email.com'),
('Carlos Lima', '11999990003', 'carlos@email.com'),
('Ana Paula', '11999990004', 'ana@email.com'),
('Bruno Rocha', '11999990005', 'bruno@email.com'),
('Juliana Alves', '11999990006', 'juliana@email.com'),
('Pedro Santos', '11999990007', 'pedro@email.com'),
('Lucas Costa', '11999990008', 'lucas@email.com'),
('Fernanda Dias', '11999990009', 'fernanda@email.com'),
('Rafael Gomes', '11999990010', 'rafael@email.com');

--inserindo na tabela de fornecedores
INSERT INTO fornecedores (nome_empresa, contato, telefone, produto_fornecido) VALUES
('Fornecedor A', 'Carlos', '1133330001', 'Queijo'),
('Fornecedor B', 'Ana', '1133330002', 'Molho'),
('Fornecedor C', 'João', '1133330003', 'Massa'),
('Fornecedor D', 'Lucas', '1133330004', 'Bebidas'),
('Fornecedor E', 'Marcos', '1133330005', 'Carnes'),
('Fornecedor F', 'Julia', '1133330006', 'Vegetais'),
('Fornecedor G', 'Bruna', '1133330007', 'Embalagens'),
('Fornecedor H', 'Pedro', '1133330008', 'Temperos'),
('Fornecedor I', 'Renato', '1133330009', 'Doces'),
('Fornecedor J', 'Paula', '1133330010', 'Sorvetes');

--inserindo na tabela de funcionários 
INSERT INTO funcionarios (nome, cargo, salario) VALUES
('Carlos Souza', 'Garçom', 1800),
('Ana Lima', 'Caixa', 2000),
('João Pedro', 'Pizzaiolo', 2500),
('Lucas Alves', 'Garçom', 1800),
('Mariana Costa', 'Atendente', 1900),
('Bruno Silva', 'Entregador', 1700),
('Fernanda Rocha', 'Caixa', 2000),
('Pedro Santos', 'Gerente', 3500),
('Juliana Dias', 'Atendente', 1900),
('Rafael Gomes', 'Pizzaiolo', 2600);

--inserindo na tabela de produtos
INSERT INTO produtos (nome_produto, categoria, preco, id_fornecedor) VALUES
('Pizza Calabresa', 'PIZZA', 35.00, 1),
('Pizza Mussarela', 'PIZZA', 30.00, 1),
('Pizza Frango', 'PIZZA', 38.00, 5),
('Coca-Cola', 'BEBIDA', 8.00, 4),
('Guaraná', 'BEBIDA', 7.00, 4),
('Água', 'BEBIDA', 5.00, 4),
('Pizza Portuguesa', 'PIZZA', 40.00, 2),
('Pizza Quatro Queijos', 'PIZZA', 42.00, 1),
('Sorvete', 'SOBREMESA', 12.00, 10),
('Pudim', 'SOBREMESA', 10.00, 9);

--inserindo na tabela de mesas
INSERT INTO mesas (capacidade, status) VALUES
(2, 'DISPONIVEL'),
(4, 'OCUPADA'),
(6, 'RESERVADA'),
(4, 'DISPONIVEL'),
(2, 'OCUPADA'),
(8, 'DISPONIVEL'),
(6, 'RESERVADA'),
(4, 'DISPONIVEL'),
(2, 'OCUPADA'),
(10, 'DISPONIVEL');

--inserindo na tabela de reservas
INSERT INTO reservas (id_mesa, id_cliente, data_reserva, horario_reserva, qtd_pessoas, status_reserva) VALUES
(1, 1, '2026-05-10', '19:00', 2, 'ATIVA'),
(2, 2, '2026-05-10', '20:00', 4, 'ATIVA'),
(3, 3, '2026-05-11', '18:30', 6, 'CANCELADA'),
(4, 4, '2026-05-11', '21:00', 3, 'ATIVA'),
(5, 5, '2026-05-12', '19:30', 2, 'ATIVA'),
(6, 6, '2026-05-12', '20:30', 5, 'ATIVA'),
(7, 7, '2026-05-13', '18:00', 6, 'ATIVA'),
(8, 8, '2026-05-13', '21:30', 4, 'CANCELADA'),
(9, 9, '2026-05-14', '19:00', 2, 'ATIVA'),
(10, 10, '2026-05-14', '20:00', 8, 'ATIVA');

--inserindo na tabela pedidos
INSERT INTO pedidos (id_cliente, id_mesa, id_funcionario, valor_total, status_pedido) VALUES
(1, 1, 1, 50.00, 'FINALIZADO'),
(2, 2, 2, 70.00, 'PENDENTE'),
(3, 3, 3, 90.00, 'FINALIZADO'),
(4, 4, 4, 40.00, 'CANCELADO'),
(5, 5, 5, 60.00, 'FINALIZADO'),
(6, 6, 6, 80.00, 'PENDENTE'),
(7, 7, 7, 55.00, 'FINALIZADO'),
(8, 8, 8, 100.00, 'PENDENTE'),
(9, 9, 9, 45.00, 'FINALIZADO'),
(10, 10, 10, 120.00, 'FINALIZADO');

--inserindo na tabela itens de pedido
INSERT INTO itens_do_pedido (id_pedido, id_produto, quantidade, preco_unitario, subtotal) VALUES
(1, 1, 1, 35.00, 35.00),
(1, 4, 2, 8.00, 16.00),
(2, 2, 2, 30.00, 60.00),
(3, 3, 2, 38.00, 76.00),
(4, 5, 3, 7.00, 21.00),
(5, 6, 2, 5.00, 10.00),
(6, 7, 1, 40.00, 40.00),
(7, 8, 1, 42.00, 42.00),
(8, 9, 2, 12.00, 24.00),
(9, 10, 3, 10.00, 30.00);


select*from clientes;
select*from fornecedores;
select*from funcionarios;
select*from produtos;
select*from mesas;
select*from reservas;
select*from pedidos;
select*from itens_do_pedido;


--mostrando a pizza mais vendida
SELECT TOP 1 
    p.nome_produto, 
    SUM(ip.quantidade) AS total_vendido
FROM produtos p
JOIN itens_do_pedido ip ON p.id_produto = ip.id_produto
JOIN pedidos ped ON ip.id_pedido = ped.id_pedido
WHERE p.categoria = 'PIZZA'
GROUP BY p.nome_produto
ORDER BY total_vendido DESC;

--mostrando o faturamento por mês
SELECT 
    YEAR(data_pedido) AS ano,
    MONTH(data_pedido) AS mes,
    SUM(valor_total) AS faturamento
	FROM pedidos
	GROUP BY YEAR(data_pedido), MONTH(data_pedido)
	ORDER BY ano, mes;

--mostrando os clientes que mais fez pedidos
SELECT 
    c.nome, 
    COUNT(p.id_pedido) AS total_pedidos, 
    SUM(p.valor_total) AS total_gasto
	FROM clientes c
	JOIN pedidos p ON c.id_cliente = p.id_cliente
	GROUP BY c.nome
	ORDER BY total_gasto DESC;

--mostrando as reservas ativas
SELECT 
    r.id_reserva, 
    m.id_mesa, 
    m.capacidade, 
    c.nome, 
    r.data_reserva, 
    r.horario_reserva
FROM reservas r
JOIN mesas m ON r.id_mesa = m.id_mesa
JOIN clientes c ON r.id_cliente = c.id_cliente
WHERE r.status_reserva = 'ATIVA';

--mostrando produtos mais vendidos
SELECT 
    p.nome_produto, 
    p.categoria, 
    SUM(ip.quantidade) AS total_vendido
FROM produtos p
JOIN itens_do_pedido ip ON p.id_produto = ip.id_produto
GROUP BY p.nome_produto, p.categoria
ORDER BY total_vendido DESC;

--mostrando os funcionários e qntde de pedidos atentidos
SELECT 
    f.nome, 
    f.cargo, 
    COUNT(p.id_pedido) AS pedidos_atendidos
FROM funcionarios f
LEFT JOIN pedidos p ON f.id_funcionario = p.id_funcionario
GROUP BY f.nome, f.cargo
ORDER BY pedidos_atendidos DESC;

--mostrando o ticket médio por pedido
SELECT AVG(valor_total) AS ticket_medio 
FROM pedidos;

--commit básico 
BEGIN TRANSACTION;

INSERT INTO clientes (nome, telefone, email)
VALUES ('Roberto Carlos', '11988887777', 'roberto@email.com');

COMMIT;

-- Verificar
SELECT * FROM clientes;

--rollback simples
BEGIN TRANSACTION;

INSERT INTO fornecedores (nome_empresa, contato, telefone, produto_fornecido)
VALUES ('Fornecedor Teste', 'Teste', '11999999999', 'Teste');

SAVE TRANSACTION antes_rollback;

-- Verificar
SELECT * FROM fornecedores;

ROLLBACK; -- desfaz tudo

-- Verificar novamente
SELECT * FROM fornecedores;


--save point + rollback parcial
BEGIN TRANSACTION;

-- Inserir pedido
INSERT INTO pedidos (id_cliente, id_mesa, id_funcionario, valor_total, status_pedido)
VALUES (2, 2, 4, 85.00, 'PENDENTE');

SAVE TRANSACTION pedido_criado;

-- Inserir itens (erro simulado)
INSERT INTO itens_do_pedido (id_pedido, id_produto, quantidade, preco_unitario, subtotal)
VALUES (11, 2, 2, 48.00, 96.00);

INSERT INTO itens_do_pedido (id_pedido, id_produto, quantidade, preco_unitario, subtotal)
VALUES (11, 6, 3, 8.00, 24.00);

-- Desfaz só os itens
ROLLBACK TRANSACTION pedido_criado;

-- Inserir corretamente
INSERT INTO itens_do_pedido (id_pedido, id_produto, quantidade, preco_unitario, subtotal)
VALUES (11, 2, 1, 48.00, 48.00);

INSERT INTO itens_do_pedido (id_pedido, id_produto, quantidade, preco_unitario, subtotal)
VALUES (11, 6, 2, 8.00, 16.00);

COMMIT;

--Cenário de Reserva
SELECT * 
FROM mesas 
WHERE status = 'DISPONIVEL' AND capacidade >= 4;

-- 2. Iniciar transação
BEGIN TRANSACTION;

INSERT INTO reservas 
(id_mesa, id_cliente, data_reserva, horario_reserva, qtd_pessoas, status_reserva)
VALUES 
(4, 4, '2026-11-28', '21:00', 4, 'ATIVA');

SAVE TRANSACTION reserva_criada;

-- Atualizar status da mesa
UPDATE mesas 
SET status = 'RESERVADA'
WHERE id_mesa = 4;

SAVE TRANSACTION mesa_atualizada;

-- Conferir resultado
SELECT r.id_reserva, m.status, c.nome
FROM reservas r
JOIN mesas m ON r.id_mesa = m.id_mesa
JOIN clientes c ON r.id_cliente = c.id_cliente
WHERE r.id_mesa = 4;

--Confirmar
COMMIT;

--Relatório completo da pizzaria
SELECT 
    'Total de Pedidos: ' + CAST(COUNT(*) AS VARCHAR) +
    ' | Faturamento: R$ ' + FORMAT(SUM(valor_total), 'N2', 'pt-BR') AS resumo
FROM pedidos
WHERE status_pedido = 'FINALIZADO';