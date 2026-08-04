create database DB_02751_Luca;

use DB_02751_Luca;
 
create table Cliente_DonaVo(
 ID_Cliente int primary key auto_increment, 
 Nome varchar(50), 
 Telefone varchar(22), 
 Email varchar(100) 
 ); 
 describe Cliente_DonaVo;
 create table Pedido_DonaVo(
	ID_Pedido int auto_increment primary key,
    Descricao Text,
    Observacao Text,
    Data_Pedido Date,
    ID_Cliente int,
    foreign key (ID_Cliente) references Cliente_DonaVo(ID_Cliente)
    );
    
    show tables;
    describe Pedido_DonaVo;
    
    insert into Cliente_DonaVo(Nome, Telefone, Email)
    Values
    ('Maria Silva','(11) 91111-111', 'maria@gmail.com');
    
    select * from Cliente_DonaVo;
    
    insert into Cliente_DonaVo(Nome, Telefone, Email)
    Values
    ('João Paulo', '(11) 92222-2222', 'joao@gmail.com');
    
    Insert into Pedido_DonaVo (Descricao, Observacao, Data_Pedido, ID_Cliente)
    values ('Bolo de Fubá', 'Sem Açucar', '2025-08-02',2), 
    ('Bolo de Tamarindo', 'Cobertura de Chocolate', '2025-08-07',3);
    
      select * from Pedido_DonaVo;
      
      select * from Cliente_DonaVo order by Nome asc;
      
   select
   C. Nome as Nome_Cliente, 
   P.Descricao, P.Observacao, 
   P.Data_Pedido
   from
   Pedido_DonaVo P 
   join 
   Cliente_DonaVo C ON P.ID_Cliente = C.ID_Cliente;