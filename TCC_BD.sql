/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 10.4.22-MariaDB : Database - tcc
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`tcc` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `tcc`;

/*Table structure for table `caixa_itens` */

DROP TABLE IF EXISTS `caixa_itens`;

CREATE TABLE `caixa_itens` (
  `id_caixa_item` int(11) NOT NULL AUTO_INCREMENT,
  `id_caixa` int(11) NOT NULL,
  `id_item` int(11) NOT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `valor_total` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_caixa_item`),
  KEY `id_item` (`id_item`),
  KEY `id_caixa` (`id_caixa`),
  CONSTRAINT `caixa_itens_ibfk_1` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`),
  CONSTRAINT `caixa_itens_ibfk_2` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4;

/*Data for the table `caixa_itens` */

insert  into `caixa_itens`(`id_caixa_item`,`id_caixa`,`id_item`,`quantidade`,`valor_total`) values 
(22,10,1,10,66.20),
(23,2,1,10,186.20),
(24,2,6,10,186.20),
(25,11,1,4,26.48),
(29,12,1,1,25.24),
(30,12,6,1,25.24);

/*Table structure for table `caixas` */

DROP TABLE IF EXISTS `caixas`;

CREATE TABLE `caixas` (
  `id_caixa` int(11) NOT NULL AUTO_INCREMENT,
  `nm_caixa` varchar(30) NOT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `data_criacao` datetime NOT NULL,
  `criado_por` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_caixa`),
  KEY `alterado_por` (`criado_por`),
  CONSTRAINT `caixas_ibfk_1` FOREIGN KEY (`criado_por`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

/*Data for the table `caixas` */

insert  into `caixas`(`id_caixa`,`nm_caixa`,`descricao`,`data_criacao`,`criado_por`) values 
(2,'teste2','teste2 descrição','2022-04-16 12:23:20',1),
(10,'teste','teste','2022-05-30 17:02:52',2),
(11,'teste3','teste3','2022-05-31 16:23:35',2),
(12,'Teste','Teste de criação de embalagem','2022-11-18 14:32:12',1);

/*Table structure for table `caixas_fechadas` */

DROP TABLE IF EXISTS `caixas_fechadas`;

CREATE TABLE `caixas_fechadas` (
  `id_caixa_fechada` int(11) NOT NULL AUTO_INCREMENT,
  `id_caixa` int(11) NOT NULL,
  `usuario` varchar(20) DEFAULT NULL,
  `dt_fechamento` datetime NOT NULL,
  PRIMARY KEY (`id_caixa_fechada`),
  KEY `id_caixa` (`id_caixa`),
  CONSTRAINT `caixas_fechadas_ibfk_1` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;

/*Data for the table `caixas_fechadas` */

insert  into `caixas_fechadas`(`id_caixa_fechada`,`id_caixa`,`usuario`,`dt_fechamento`) values 
(10,10,'JOÃO VITOR MOREIRA','2022-07-01 13:13:28'),
(11,2,'JOÃO VITOR MOREIRA','2022-07-12 19:40:13'),
(12,11,'JOÃO VITOR MOREIRA','2022-11-15 14:33:10'),
(14,12,'JOÃO VITOR MOREIRA','2022-11-19 17:49:37');

/*Table structure for table `classe_item` */

DROP TABLE IF EXISTS `classe_item`;

CREATE TABLE `classe_item` (
  `id_classe_item` int(11) NOT NULL AUTO_INCREMENT,
  `nm_classe` varchar(50) NOT NULL,
  `ds_classe` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_classe_item`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `classe_item` */

insert  into `classe_item`(`id_classe_item`,`nm_classe`,`ds_classe`) values 
(1,'Material Escolar','Todo tipo de material escolar'),
(2,'Roupa','Roupas em geral'),
(9,'Alimento','comidas em geral');

/*Table structure for table `enviar_caixas` */

DROP TABLE IF EXISTS `enviar_caixas`;

CREATE TABLE `enviar_caixas` (
  `id_enviar_caixa` int(11) NOT NULL AUTO_INCREMENT,
  `nome_cliente` varchar(200) NOT NULL,
  `estado` char(2) NOT NULL,
  `cidade` varchar(100) NOT NULL,
  `rua` varchar(200) NOT NULL,
  `numero` varchar(11) NOT NULL,
  `telefone` char(15) NOT NULL,
  `id_caixa` int(11) NOT NULL,
  `id_enviado_por` int(11) DEFAULT NULL,
  `data_envio` date DEFAULT NULL,
  PRIMARY KEY (`id_enviar_caixa`),
  KEY `id_caixa` (`id_caixa`),
  KEY `enviar_caixas_ibfk_2` (`id_enviado_por`),
  CONSTRAINT `enviar_caixas_ibfk_1` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`),
  CONSTRAINT `enviar_caixas_ibfk_2` FOREIGN KEY (`id_enviado_por`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `enviar_caixas` */

insert  into `enviar_caixas`(`id_enviar_caixa`,`nome_cliente`,`estado`,`cidade`,`rua`,`numero`,`telefone`,`id_caixa`,`id_enviado_por`,`data_envio`) values 
(7,'1','1','1','1','1','(11) 111111111',10,1,'2022-11-15'),
(8,'AAAAAAAAA','AA','AAAAAAA','AAAAAAAAA','11111','(11) 111111111',2,2,'2022-11-15'),
(9,'AAAAAAAAA','AA','AAAAAAA','AAAAAAAAA','11111','(11) 111111111',11,2,'2022-11-15');

/*Table structure for table `fornecedores` */

DROP TABLE IF EXISTS `fornecedores`;

CREATE TABLE `fornecedores` (
  `id_fornecedor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(200) NOT NULL,
  `logradouro` varchar(200) NOT NULL,
  `bairro` varchar(200) NOT NULL,
  `numero` int(11) NOT NULL,
  `estado` char(2) NOT NULL,
  `cidade` varchar(200) NOT NULL,
  `cep` char(9) NOT NULL,
  `telefone` char(14) NOT NULL,
  `email` varchar(100) NOT NULL,
  `cnpj` char(18) NOT NULL,
  PRIMARY KEY (`id_fornecedor`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `fornecedores` */

insert  into `fornecedores`(`id_fornecedor`,`nome`,`logradouro`,`bairro`,`numero`,`estado`,`cidade`,`cep`,`telefone`,`email`,`cnpj`) values 
(1,'fornecedor1','Avenida Calama','Embratel',331,'RO','Porto Velho','76820-865','(69)98630-9380','isabellafranciscadaluz@tirel.com.br','47.158.625/0001-40'),
(2,'fornecedor2','Rua Alcino Firmo da Rocha','Presidente Costa e Silva',982,'RN','Mossoró','59625-646','(84)99599-6099','henrique_baptista@aquino.com.br','15.349.387/0001-63'),
(3,'fornecedor3','Rua Aubé','Saguaçu',542,'SC','Joinville','89221-011','(47)98497-2158','nina.giovanna.daluz@ruilacos.com.br','54.519.152/0001-24');

/*Table structure for table `itens` */

DROP TABLE IF EXISTS `itens`;

CREATE TABLE `itens` (
  `id_item` int(11) NOT NULL AUTO_INCREMENT,
  `nm_item` varchar(100) NOT NULL,
  `descritivo` varchar(300) DEFAULT NULL,
  `classe_item` int(255) NOT NULL,
  `codigo_barras` int(255) NOT NULL,
  `data_validade` date DEFAULT NULL,
  `quantidade` int(255) NOT NULL,
  `quantidadeMini` decimal(10,0) NOT NULL,
  `valor_custo` decimal(10,2) NOT NULL,
  `valor_venda` decimal(10,2) NOT NULL,
  `prateleira` int(11) NOT NULL,
  `andar` int(11) NOT NULL,
  `id_fornecedor` int(11) NOT NULL,
  PRIMARY KEY (`id_item`),
  KEY `classe_item` (`classe_item`),
  KEY `id_fornecedor` (`id_fornecedor`),
  CONSTRAINT `itens_ibfk_1` FOREIGN KEY (`classe_item`) REFERENCES `classe_item` (`id_classe_item`),
  CONSTRAINT `itens_ibfk_2` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedores` (`id_fornecedor`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4;

/*Data for the table `itens` */

insert  into `itens`(`id_item`,`nm_item`,`descritivo`,`classe_item`,`codigo_barras`,`data_validade`,`quantidade`,`quantidadeMini`,`valor_custo`,`valor_venda`,`prateleira`,`andar`,`id_fornecedor`) values 
(1,'DANONI','',9,1,'2022-11-19',16,10,2.06,6.62,1,1,1),
(6,'CHOCOLATE 100','',9,2,'2023-10-10',14,0,2.00,6.00,1,2,1),
(7,'LÁPIS DE COR','FABER-CASTELL 100 CORES',1,3,NULL,50,0,100.00,159.00,1,3,2),
(11,'HELLMANNS ','Molho 3 em 1 Hellmann\'s Squeeze 370g',9,4,'2023-11-18',15,20,7.00,9.82,2,1,3),
(12,'BATATA PRINGLES ','Original 114g',9,5,'2022-09-21',30,0,9.00,11.09,2,2,3),
(16,'ITEM 1','',2,6,NULL,111,12,10.00,13.00,1,3,1);

/*Table structure for table `itens_vendidos` */

DROP TABLE IF EXISTS `itens_vendidos`;

CREATE TABLE `itens_vendidos` (
  `id_item_vendido` int(11) NOT NULL AUTO_INCREMENT,
  `id_item` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `valor_venda` decimal(10,2) NOT NULL,
  `dt_venda` datetime NOT NULL,
  PRIMARY KEY (`id_item_vendido`),
  KEY `id_item` (`id_item`),
  CONSTRAINT `itens_vendidos_ibfk_1` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

/*Data for the table `itens_vendidos` */

insert  into `itens_vendidos`(`id_item_vendido`,`id_item`,`quantidade`,`valor_venda`,`dt_venda`) values 
(1,1,2,13.24,'2022-06-02 14:07:24'),
(2,6,2,12.00,'2022-06-02 14:08:06'),
(3,1,2,13.24,'2022-06-02 14:09:23'),
(4,7,1,159.00,'2022-06-02 15:45:48'),
(5,1,1,6.62,'2022-07-01 13:06:14'),
(6,1,1,6.62,'2022-11-19 11:50:48'),
(7,1,1,6.62,'2022-11-19 11:51:23');

/*Table structure for table `menus` */

DROP TABLE IF EXISTS `menus`;

CREATE TABLE `menus` (
  `id_menu` int(11) NOT NULL AUTO_INCREMENT,
  `nm_menu` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_menu`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `menus` */

insert  into `menus`(`id_menu`,`nm_menu`) values 
(1,'mnAdmim'),
(2,'mnItens'),
(3,'mnCaixaRegistradora'),
(4,'mnCaixa'),
(5,'mnRelatorios');

/*Table structure for table `movimenta_itens` */

DROP TABLE IF EXISTS `movimenta_itens`;

CREATE TABLE `movimenta_itens` (
  `id_mov_it` int(11) NOT NULL AUTO_INCREMENT,
  `id_responsavel` int(11) NOT NULL,
  `id_receptor` int(11) NOT NULL,
  `data_mov_it` datetime NOT NULL,
  `quantidade_movida` int(11) DEFAULT NULL,
  `id_item` int(11) NOT NULL,
  PRIMARY KEY (`id_mov_it`),
  KEY `id_mov_it_resp` (`id_responsavel`),
  KEY `id_receptor` (`id_receptor`),
  KEY `movimenta_itens_ibfk_3` (`id_item`),
  CONSTRAINT `movimenta_itens_ibfk_1` FOREIGN KEY (`id_responsavel`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `movimenta_itens_ibfk_2` FOREIGN KEY (`id_receptor`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `movimenta_itens_ibfk_3` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4;

/*Data for the table `movimenta_itens` */

insert  into `movimenta_itens`(`id_mov_it`,`id_responsavel`,`id_receptor`,`data_mov_it`,`quantidade_movida`,`id_item`) values 
(15,2,3,'2022-06-02 20:01:55',10,6),
(17,2,2,'2022-10-04 11:08:14',1,1),
(18,2,3,'2022-10-04 11:14:41',1,6),
(19,2,3,'2022-10-04 11:14:56',1,1),
(20,2,3,'2022-10-04 11:14:56',1,6),
(21,1,2,'2022-10-04 11:20:45',1,6),
(22,2,2,'2022-11-15 14:13:28',1,1),
(24,2,1,'2022-11-19 11:02:25',1,1);

/*Table structure for table `setores` */

DROP TABLE IF EXISTS `setores`;

CREATE TABLE `setores` (
  `id_setor` int(11) NOT NULL AUTO_INCREMENT,
  `nm_setor` varchar(40) DEFAULT NULL,
  `nm_encarregado` varchar(100) DEFAULT NULL,
  `contato_encarregado` varchar(14) DEFAULT NULL,
  PRIMARY KEY (`id_setor`),
  KEY `id_encarregado` (`nm_encarregado`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `setores` */

insert  into `setores`(`id_setor`,`nm_setor`,`nm_encarregado`,`contato_encarregado`) values 
(1,'Financeiro','ADMINISTRADOR','(14)99728-0304'),
(2,'administrativo','JOÃO VITOR MOREIRA','(14)99728-0502'),
(5,'Estoque','RODRIGO','(14)99728-0503');

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(15) NOT NULL,
  `nm_usuario` varchar(50) NOT NULL,
  `dt_nascimento` date NOT NULL,
  `tp_usuario` enum('ADMIN','USUÁRIO') NOT NULL,
  `senha` varchar(10) NOT NULL,
  `id_setor` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `id_setor` (`id_setor`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_setor`) REFERENCES `setores` (`id_setor`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `usuarios` */

insert  into `usuarios`(`id_usuario`,`login`,`nm_usuario`,`dt_nascimento`,`tp_usuario`,`senha`,`id_setor`) values 
(1,'ADMIN','ADMINISTRADOR','2022-03-01','ADMIN','admin',2),
(2,'','JOÃO VITOR MOREIRA','1998-06-10','ADMIN','',2),
(3,'TENSHI','RODRIGO','1991-07-11','USUÁRIO','1111',1);

/*Table structure for table `usuarios_menus` */

DROP TABLE IF EXISTS `usuarios_menus`;

CREATE TABLE `usuarios_menus` (
  `id_usuario_menu` int(11) NOT NULL AUTO_INCREMENT,
  `id_menu` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  PRIMARY KEY (`id_usuario_menu`),
  KEY `id_menu` (`id_menu`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `usuarios_menus_ibfk_1` FOREIGN KEY (`id_menu`) REFERENCES `menus` (`id_menu`),
  CONSTRAINT `usuarios_menus_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4;

/*Data for the table `usuarios_menus` */

insert  into `usuarios_menus`(`id_usuario_menu`,`id_menu`,`id_usuario`) values 
(41,1,2),
(42,2,2),
(43,3,2),
(44,4,2),
(45,5,2),
(46,1,1),
(47,2,1),
(48,3,1),
(49,4,1),
(50,5,1),
(53,3,3);

/* Procedure structure for procedure `buscaUsuario` */

/*!50003 DROP PROCEDURE IF EXISTS  `buscaUsuario` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `buscaUsuario`(in nomeUsuario varchar(100) )
begin
	if(nomeUsuario IN (select nm_usuario from usuarios))then
		select* from usuarios where nm_usuario = nomeUsuario;
	else
		select "usuario n encontrado" as msg;
	end if;
end */$$
DELIMITER ;

/*Table structure for table `vw_dt_aniversario` */

DROP TABLE IF EXISTS `vw_dt_aniversario`;

/*!50001 DROP VIEW IF EXISTS `vw_dt_aniversario` */;
/*!50001 DROP TABLE IF EXISTS `vw_dt_aniversario` */;

/*!50001 CREATE TABLE  `vw_dt_aniversario`(
 `id_usuario` int(11) ,
 `login` varchar(15) ,
 `nm_usuario` varchar(50) ,
 `dt_nascimento` date ,
 `tp_usuario` enum('ADMIN','USUÁRIO') ,
 `senha` varchar(10) ,
 `id_setor` int(11) 
)*/;

/*Table structure for table `vw_usuarios` */

DROP TABLE IF EXISTS `vw_usuarios`;

/*!50001 DROP VIEW IF EXISTS `vw_usuarios` */;
/*!50001 DROP TABLE IF EXISTS `vw_usuarios` */;

/*!50001 CREATE TABLE  `vw_usuarios`(
 `nm_usuario` varchar(50) ,
 `dt_nascimento` varchar(10) 
)*/;

/*View structure for view vw_dt_aniversario */

/*!50001 DROP TABLE IF EXISTS `vw_dt_aniversario` */;
/*!50001 DROP VIEW IF EXISTS `vw_dt_aniversario` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_dt_aniversario` AS select `usuarios`.`id_usuario` AS `id_usuario`,`usuarios`.`login` AS `login`,`usuarios`.`nm_usuario` AS `nm_usuario`,`usuarios`.`dt_nascimento` AS `dt_nascimento`,`usuarios`.`tp_usuario` AS `tp_usuario`,`usuarios`.`senha` AS `senha`,`usuarios`.`id_setor` AS `id_setor` from `usuarios` where month(`usuarios`.`dt_nascimento`) = month(current_timestamp()) */;

/*View structure for view vw_usuarios */

/*!50001 DROP TABLE IF EXISTS `vw_usuarios` */;
/*!50001 DROP VIEW IF EXISTS `vw_usuarios` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_usuarios` AS select `usuarios`.`nm_usuario` AS `nm_usuario`,date_format(`usuarios`.`dt_nascimento`,'%d/%m/%Y') AS `dt_nascimento` from `usuarios` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
