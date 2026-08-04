CREATE DATABASE sisvendas;

USE sisvendas;

CREATE TABLE tab_usuarios (
  id_usuario int NOT NULL PRIMARY KEY IDENTITY,
  nome varchar(50)  NOT NULL,
  email varchar(50)  NOT NULL,
  login varchar(20) NOT NULL,
  senha varchar(100)  NOT NULL,
  frase varchar(100)  NOT NULL,
  nivel int NOT NULL,
  ativo int NOT NULL
);

CREATE TABLE tab_clientes (
  id_cliente int NOT NULL PRIMARY KEY IDENTITY,
  nome varchar(50) NOT NULL,
  email varchar(50)  NOT NULL,
  fone varchar(15)  NOT NULL,
  dtnasc date NOT NULL,
  sexo varchar(10)  NOT NULL,
  ativo int NOT NULL
);

CREATE TABLE tab_produtos (
  id_produto int NOT NULL PRIMARY KEY IDENTITY,
  nome varchar(100)  NOT NULL,
  foto varchar(30)  NOT NULL,
  descricao VARCHAR(1000) NOT NULL,
  qtde int NOT NULL,
  valor decimal(10,2) NOT NULL,
  ativo int NOT NULL
);

CREATE TABLE tab_pedidos (
  id_pedido int NOT NULL PRIMARY KEY IDENTITY,
  id_cliente int NOT NULL,
  id_usuario int NOT NULL,
  data date NOT NULL,
  total decimal(10,2) NOT NULL,
  CONSTRAINT fk_id_cliente
  FOREIGN KEY (id_cliente)
  REFERENCES tab_clientes(id_cliente),

  CONSTRAINT fk_id_usuario
  FOREIGN KEY (id_usuario)
  REFERENCES tab_usuarios(id_usuario)
);

CREATE TABLE tab_itens_pedido (
  id_item int NOT NULL PRIMARY KEY IDENTITY,
  id_pedido int NOT NULL,
  id_produto int NOT NULL,
  valor decimal(10,2) NOT NULL,
  qtde int NOT NULL,
  subtotal decimal(10,2) NOT NULL,
  CONSTRAINT fk_id_pedido
  FOREIGN KEY (id_pedido)
  REFERENCES tab_pedidos(id_pedido)
);

SELECT * FROM INFORMATION_SCHEMA.TABLES;

INSERT INTO tab_usuarios (nome, email, login, senha, frase, nivel, ativo) VALUES
('Fábio Corrêa', 'shefarol@hotmail.com', 'admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão', 0, 1),
('Maria Aparecida', 'maria@gmail.com', 'maria', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão', 1, 1);


INSERT INTO tab_clientes (nome, email, fone, dtnasc, sexo, ativo) VALUES
('Tereza Aparecida', 'tereza@gmail.com', '11911111111', '2011-02-16', 'Feminino', 1),
('João da Silva Pereira', 'joao@gmail.com', '11922222222', '2003-05-20', 'Masculino', 1);


INSERT INTO tab_produtos (nome, foto, descricao, qtde, valor, ativo) VALUES
('Teclado Gamer Dragon Vinik', 'teclado.jpg', 'O teclado Dragon da Vinik traz um design simples e recursos interessantes para o público gamer iniciante. O acessório conta com 126 teclas macias e de rápida resposta com letras gravadas a laser. Além disso, as teclas multimídia permitem controlar a reprodução de músicas sem minimizar ou abrir janelas.', 10, '35.00', 1),
('Mouse para jogos RGB level 20', 'mouse.jpg', 'O Level 20 RGB é um mouse para jogos de alto desempenho equipado com um poderoso sensor óptico de jogos de 16.000 DPI e comutadores OMRON duráveis ​​com capacidade de até 50 milhões de cliques para infinitas horas de jogo.', 10, '28.00', 1),
('Headphone Bluetooth FUN com Entrada MicroSD', 'headphone.jpg', 'Leve suas músicas sempre com você com praticidade e segurança! O Headphone GT Fun dá um show de versatilidade: além da função bluetooth, possui entrada para cartão de memória e também conexão P2! Experimente toda a liberdade de usar seu fone sem precisar estar sempre conectado ao celular, garantindo maior segurança e economia da bateria do seu aparelho!', 10, '145.20', 1),
('Câmera IP Wifi 720P Robo C/ Áudio Grava CartãoSD', 'camera-seguranca.jpg', 'Câmera IP Imagem Em Alta resolução Full HD 720p P2P Visão Noturna Wireless Protocolo Onvif 2.4\r\n\r\nGarantimos 100% De Satisfação\r\nEnviamos Video Tutorial, Passo a Passa e Suporte Por WhatsApp\r\nPode ser usada Também em Qualquer Nvr inclusive Intelbras\r\nEnvio de alarme para celular por sensor de movimento\r\n\r\nNova Versão maior alcance e rapidez na transmissão Wifi e Movimento Agora com duas antenas\r\n(não trava como as demais)', 10, '143.56', 1),
('iPhone 13 Pro Max Apple (128GB) Grafite, Tela de 6', 'iphone.jpg', 'iPhone 13 Pro Max. O maior upgrade do sistema de câmera Pro até hoje. Tela Super Retina XDR com ProMotion para uma experiência mais rápida e responsiva. Chip A15 Bionic com velocidade impressionante. 5G ultrarrápido*. Design resistente. E a maior duração de bateria em um iPhone**. ', 10, '9200.40', 1),
('Projetor Epson PowerLite E10+ XGA 1024x768p', 'projetor.jpg', 'O projetor PowerLite E10+ é o projetor ideal para o seu negócio. Oferece uma tela de mais de 300\" com qualidade excepcional. A tecnologia 3LCD oferece imagens claras, brilhantes e repletas de cor. Seu brilho de 3.600 lumens em cores e 3.600 lumens em branco o torna a melhor escolha. Sua resolução XGA de 1.024x768 pixels é ideal para apresentações. Seu design compacto e portátil o torna a melhor escolha para os executivos modernos. Ele ainda tem as conexões 1 HDMI 1, USB e 1 VGA e tem disponibilidade na cor branca.', 10, '4654.05', 1),
('Echo Dot (4ª geração): Smart Speaker com Relógio e', 'sem-imagem.jpg', 'Complete qualquer ambiente com a Alexa. Nosso smart speaker de maior sucesso tem um design elegante e compacto que se encaixa perfeitamente em espaços pequenos. O novo design de áudio direcional (1 speaker de 1,6”) garante mais graves e um som completo. Ele oferece vocais nítidos e graves equilibrados para você aproveitar em qualquer lugar de sua casa.', 10, '480.10', 1);


SELECT * FROM tab_usuarios;
SELECT * FROM tab_clientes;
SELECT * FROM tab_produtos;
SELECT * FROM tab_pedidos;
SELECT * FROM tab_itens_pedido;