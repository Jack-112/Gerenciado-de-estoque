-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 11-Dez-2022 às 18:50
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `tcc`
--

DELIMITER $$
--
-- Procedimentos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscaUsuario` (IN `nomeUsuario` VARCHAR(100))  begin
	if(nomeUsuario IN (select nm_usuario from usuarios))then
		select* from usuarios where nm_usuario = nomeUsuario;
	else
		select "usuario n encontrado" as msg;
	end if;
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `caixas`
--

CREATE TABLE `caixas` (
  `id_caixa` int(11) NOT NULL,
  `nm_caixa` varchar(30) NOT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `data_criacao` datetime NOT NULL,
  `criado_por` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `caixas`
--

INSERT INTO `caixas` (`id_caixa`, `nm_caixa`, `descricao`, `data_criacao`, `criado_por`) VALUES
(2, 'teste2', 'teste2 descrição', '2022-04-16 12:23:20', 1),
(10, 'teste', 'teste', '2022-05-30 17:02:52', 2),
(11, 'teste3', 'teste3', '2022-05-31 16:23:35', 2),
(12, 'Teste', 'Teste de criação de embalagem', '2022-11-18 14:32:12', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `caixas_fechadas`
--

CREATE TABLE `caixas_fechadas` (
  `id_caixa_fechada` int(11) NOT NULL,
  `id_caixa` int(11) NOT NULL,
  `usuario` varchar(20) DEFAULT NULL,
  `dt_fechamento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `caixas_fechadas`
--

INSERT INTO `caixas_fechadas` (`id_caixa_fechada`, `id_caixa`, `usuario`, `dt_fechamento`) VALUES
(10, 10, 'JOÃO VITOR MOREIRA', '2022-07-01 13:13:28'),
(11, 2, 'JOÃO VITOR MOREIRA', '2022-07-12 19:40:13'),
(12, 11, 'JOÃO VITOR MOREIRA', '2022-11-15 14:33:10'),
(14, 12, 'JOÃO VITOR MOREIRA', '2022-11-19 17:49:37');

-- --------------------------------------------------------

--
-- Estrutura da tabela `caixa_itens`
--

CREATE TABLE `caixa_itens` (
  `id_caixa_item` int(11) NOT NULL,
  `id_caixa` int(11) NOT NULL,
  `id_item` int(11) NOT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `valor_total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `caixa_itens`
--

INSERT INTO `caixa_itens` (`id_caixa_item`, `id_caixa`, `id_item`, `quantidade`, `valor_total`) VALUES
(22, 10, 1, 10, '66.20'),
(23, 2, 1, 10, '186.20'),
(24, 2, 6, 10, '186.20'),
(25, 11, 1, 4, '26.48'),
(29, 12, 1, 1, '25.24'),
(30, 12, 6, 1, '25.24');

-- --------------------------------------------------------

--
-- Estrutura da tabela `classe_item`
--

CREATE TABLE `classe_item` (
  `id_classe_item` int(11) NOT NULL,
  `nm_classe` varchar(50) NOT NULL,
  `ds_classe` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `classe_item`
--

INSERT INTO `classe_item` (`id_classe_item`, `nm_classe`, `ds_classe`) VALUES
(1, 'Material Escolar', 'Todo tipo de material escolar'),
(2, 'Roupa', 'Roupas em geral'),
(9, 'Alimento', 'comidas em geral');

-- --------------------------------------------------------

--
-- Estrutura da tabela `enviar_caixas`
--

CREATE TABLE `enviar_caixas` (
  `id_enviar_caixa` int(11) NOT NULL,
  `nome_cliente` varchar(200) NOT NULL,
  `estado` char(2) NOT NULL,
  `cidade` varchar(100) NOT NULL,
  `rua` varchar(200) NOT NULL,
  `numero` varchar(11) NOT NULL,
  `telefone` char(15) NOT NULL,
  `id_caixa` int(11) NOT NULL,
  `id_enviado_por` int(11) DEFAULT NULL,
  `data_envio` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `enviar_caixas`
--

INSERT INTO `enviar_caixas` (`id_enviar_caixa`, `nome_cliente`, `estado`, `cidade`, `rua`, `numero`, `telefone`, `id_caixa`, `id_enviado_por`, `data_envio`) VALUES
(7, '1', '1', '1', '1', '1', '(11) 111111111', 10, 1, '2022-11-15'),
(8, 'AAAAAAAAA', 'AA', 'AAAAAAA', 'AAAAAAAAA', '11111', '(11) 111111111', 2, 2, '2022-11-15'),
(9, 'AAAAAAAAA', 'AA', 'AAAAAAA', 'AAAAAAAAA', '11111', '(11) 111111111', 11, 2, '2022-11-15');

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedores`
--

CREATE TABLE `fornecedores` (
  `id_fornecedor` int(11) NOT NULL,
  `nome` varchar(200) NOT NULL,
  `logradouro` varchar(200) NOT NULL,
  `bairro` varchar(200) NOT NULL,
  `numero` int(11) NOT NULL,
  `estado` char(2) NOT NULL,
  `cidade` varchar(200) NOT NULL,
  `cep` char(9) NOT NULL,
  `telefone` char(14) NOT NULL,
  `email` varchar(100) NOT NULL,
  `cnpj` char(18) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `fornecedores`
--

INSERT INTO `fornecedores` (`id_fornecedor`, `nome`, `logradouro`, `bairro`, `numero`, `estado`, `cidade`, `cep`, `telefone`, `email`, `cnpj`) VALUES
(1, 'fornecedor1', 'Avenida Calama', 'Embratel', 331, 'RO', 'Porto Velho', '76820-865', '(69)98630-9380', 'isabellafranciscadaluz@tirel.com.br', '47.158.625/0001-40'),
(2, 'fornecedor2', 'Rua Alcino Firmo da Rocha', 'Presidente Costa e Silva', 982, 'RN', 'Mossoró', '59625-646', '(84)99599-6099', 'henrique_baptista@aquino.com.br', '15.349.387/0001-63'),
(3, 'fornecedor3', 'Rua Aubé', 'Saguaçu', 542, 'SC', 'Joinville', '89221-011', '(47)98497-2158', 'nina.giovanna.daluz@ruilacos.com.br', '54.519.152/0001-24');

-- --------------------------------------------------------

--
-- Estrutura da tabela `itens`
--

CREATE TABLE `itens` (
  `id_item` int(11) NOT NULL,
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
  `id_fornecedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `itens`
--

INSERT INTO `itens` (`id_item`, `nm_item`, `descritivo`, `classe_item`, `codigo_barras`, `data_validade`, `quantidade`, `quantidadeMini`, `valor_custo`, `valor_venda`, `prateleira`, `andar`, `id_fornecedor`) VALUES
(1, 'DANONI', '', 9, 1, '2022-11-19', 16, '10', '2.06', '6.62', 1, 1, 1),
(6, 'CHOCOLATE 100', '', 9, 2, '2023-10-10', 14, '0', '2.00', '6.00', 1, 2, 1),
(7, 'LÁPIS DE COR', 'FABER-CASTELL 100 CORES', 1, 3, NULL, 50, '0', '100.00', '159.00', 1, 3, 2),
(11, 'HELLMANNS ', 'Molho 3 em 1 Hellmann\'s Squeeze 370g', 9, 4, '2023-11-18', 15, '20', '7.00', '9.82', 2, 1, 3),
(12, 'BATATA PRINGLES ', 'Original 114g', 9, 5, '2023-01-21', 30, '0', '9.00', '11.09', 2, 2, 3),
(16, 'ITEM 1', '', 2, 6, NULL, 111, '12', '10.00', '13.00', 1, 3, 1),
(17, 'PRODUTO ', '', 2, 7, '2023-02-10', 22, '10', '5.00', '10.00', 3, 1, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `itens_vendidos`
--

CREATE TABLE `itens_vendidos` (
  `id_item_vendido` int(11) NOT NULL,
  `id_item` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `valor_venda` decimal(10,2) NOT NULL,
  `dt_venda` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `itens_vendidos`
--

INSERT INTO `itens_vendidos` (`id_item_vendido`, `id_item`, `quantidade`, `valor_venda`, `dt_venda`) VALUES
(1, 1, 2, '13.24', '2022-06-02 14:07:24'),
(2, 6, 2, '12.00', '2022-06-02 14:08:06'),
(3, 1, 2, '13.24', '2022-06-02 14:09:23'),
(4, 7, 1, '159.00', '2022-06-02 15:45:48'),
(5, 1, 1, '6.62', '2022-07-01 13:06:14'),
(6, 1, 1, '6.62', '2022-11-19 11:50:48'),
(7, 1, 1, '6.62', '2022-11-19 11:51:23');

-- --------------------------------------------------------

--
-- Estrutura da tabela `menus`
--

CREATE TABLE `menus` (
  `id_menu` int(11) NOT NULL,
  `nm_menu` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `menus`
--

INSERT INTO `menus` (`id_menu`, `nm_menu`) VALUES
(1, 'mnAdmim'),
(2, 'mnItens'),
(3, 'mnCaixaRegistradora'),
(4, 'mnCaixa'),
(5, 'mnRelatorios');

-- --------------------------------------------------------

--
-- Estrutura da tabela `movimenta_itens`
--

CREATE TABLE `movimenta_itens` (
  `id_mov_it` int(11) NOT NULL,
  `id_responsavel` int(11) NOT NULL,
  `id_receptor` int(11) NOT NULL,
  `data_mov_it` datetime NOT NULL,
  `quantidade_movida` int(11) DEFAULT NULL,
  `id_item` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `movimenta_itens`
--

INSERT INTO `movimenta_itens` (`id_mov_it`, `id_responsavel`, `id_receptor`, `data_mov_it`, `quantidade_movida`, `id_item`) VALUES
(15, 2, 3, '2022-06-02 20:01:55', 10, 6),
(17, 2, 2, '2022-10-04 11:08:14', 1, 1),
(18, 2, 3, '2022-10-04 11:14:41', 1, 6),
(19, 2, 3, '2022-10-04 11:14:56', 1, 1),
(20, 2, 3, '2022-10-04 11:14:56', 1, 6),
(21, 1, 2, '2022-10-04 11:20:45', 1, 6),
(22, 2, 2, '2022-11-15 14:13:28', 1, 1),
(24, 2, 1, '2022-11-19 11:02:25', 1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `setores`
--

CREATE TABLE `setores` (
  `id_setor` int(11) NOT NULL,
  `nm_setor` varchar(40) DEFAULT NULL,
  `nm_encarregado` varchar(100) DEFAULT NULL,
  `contato_encarregado` varchar(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `setores`
--

INSERT INTO `setores` (`id_setor`, `nm_setor`, `nm_encarregado`, `contato_encarregado`) VALUES
(1, 'Financeiro', 'ADMINISTRADOR', '(14)99728-0304'),
(2, 'administrativo', 'JOÃO VITOR MOREIRA', '(14)99728-0502'),
(5, 'Estoque', 'RODRIGO', '(14)99728-0503');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `login` varchar(15) NOT NULL,
  `nm_usuario` varchar(50) NOT NULL,
  `dt_nascimento` date NOT NULL,
  `tp_usuario` enum('ADMIN','USUÁRIO') NOT NULL,
  `senha` varchar(10) NOT NULL,
  `id_setor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `login`, `nm_usuario`, `dt_nascimento`, `tp_usuario`, `senha`, `id_setor`) VALUES
(1, 'ADMIN', 'ADMINISTRADOR', '2022-03-01', 'ADMIN', 'admin', 2),
(2, 'JOAO VITOR', 'JOÃO VITOR MOREIRA', '1998-06-10', 'ADMIN', '', 2),
(3, 'TENSHI', 'RODRIGO', '1991-07-11', 'USUÁRIO', '1111', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios_menus`
--

CREATE TABLE `usuarios_menus` (
  `id_usuario_menu` int(11) NOT NULL,
  `id_menu` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuarios_menus`
--

INSERT INTO `usuarios_menus` (`id_usuario_menu`, `id_menu`, `id_usuario`) VALUES
(41, 1, 2),
(42, 2, 2),
(43, 3, 2),
(44, 4, 2),
(45, 5, 2),
(46, 1, 1),
(47, 2, 1),
(48, 3, 1),
(49, 4, 1),
(50, 5, 1),
(53, 3, 3);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vw_dt_aniversario`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vw_dt_aniversario` (
`id_usuario` int(11)
,`login` varchar(15)
,`nm_usuario` varchar(50)
,`dt_nascimento` date
,`tp_usuario` enum('ADMIN','USUÁRIO')
,`senha` varchar(10)
,`id_setor` int(11)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vw_usuarios`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vw_usuarios` (
`nm_usuario` varchar(50)
,`dt_nascimento` varchar(10)
);

-- --------------------------------------------------------

--
-- Estrutura para vista `vw_dt_aniversario`
--
DROP TABLE IF EXISTS `vw_dt_aniversario`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_dt_aniversario`  AS SELECT `usuarios`.`id_usuario` AS `id_usuario`, `usuarios`.`login` AS `login`, `usuarios`.`nm_usuario` AS `nm_usuario`, `usuarios`.`dt_nascimento` AS `dt_nascimento`, `usuarios`.`tp_usuario` AS `tp_usuario`, `usuarios`.`senha` AS `senha`, `usuarios`.`id_setor` AS `id_setor` FROM `usuarios` WHERE month(`usuarios`.`dt_nascimento`) = month(current_timestamp()) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vw_usuarios`
--
DROP TABLE IF EXISTS `vw_usuarios`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_usuarios`  AS SELECT `usuarios`.`nm_usuario` AS `nm_usuario`, date_format(`usuarios`.`dt_nascimento`,'%d/%m/%Y') AS `dt_nascimento` FROM `usuarios` ;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `caixas`
--
ALTER TABLE `caixas`
  ADD PRIMARY KEY (`id_caixa`),
  ADD KEY `alterado_por` (`criado_por`);

--
-- Índices para tabela `caixas_fechadas`
--
ALTER TABLE `caixas_fechadas`
  ADD PRIMARY KEY (`id_caixa_fechada`),
  ADD KEY `id_caixa` (`id_caixa`);

--
-- Índices para tabela `caixa_itens`
--
ALTER TABLE `caixa_itens`
  ADD PRIMARY KEY (`id_caixa_item`),
  ADD KEY `id_item` (`id_item`),
  ADD KEY `id_caixa` (`id_caixa`);

--
-- Índices para tabela `classe_item`
--
ALTER TABLE `classe_item`
  ADD PRIMARY KEY (`id_classe_item`);

--
-- Índices para tabela `enviar_caixas`
--
ALTER TABLE `enviar_caixas`
  ADD PRIMARY KEY (`id_enviar_caixa`),
  ADD KEY `id_caixa` (`id_caixa`),
  ADD KEY `enviar_caixas_ibfk_2` (`id_enviado_por`);

--
-- Índices para tabela `fornecedores`
--
ALTER TABLE `fornecedores`
  ADD PRIMARY KEY (`id_fornecedor`);

--
-- Índices para tabela `itens`
--
ALTER TABLE `itens`
  ADD PRIMARY KEY (`id_item`),
  ADD KEY `classe_item` (`classe_item`),
  ADD KEY `id_fornecedor` (`id_fornecedor`);

--
-- Índices para tabela `itens_vendidos`
--
ALTER TABLE `itens_vendidos`
  ADD PRIMARY KEY (`id_item_vendido`),
  ADD KEY `id_item` (`id_item`);

--
-- Índices para tabela `menus`
--
ALTER TABLE `menus`
  ADD PRIMARY KEY (`id_menu`);

--
-- Índices para tabela `movimenta_itens`
--
ALTER TABLE `movimenta_itens`
  ADD PRIMARY KEY (`id_mov_it`),
  ADD KEY `id_mov_it_resp` (`id_responsavel`),
  ADD KEY `id_receptor` (`id_receptor`),
  ADD KEY `movimenta_itens_ibfk_3` (`id_item`);

--
-- Índices para tabela `setores`
--
ALTER TABLE `setores`
  ADD PRIMARY KEY (`id_setor`),
  ADD KEY `id_encarregado` (`nm_encarregado`);

--
-- Índices para tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD KEY `id_setor` (`id_setor`);

--
-- Índices para tabela `usuarios_menus`
--
ALTER TABLE `usuarios_menus`
  ADD PRIMARY KEY (`id_usuario_menu`),
  ADD KEY `id_menu` (`id_menu`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `caixas`
--
ALTER TABLE `caixas`
  MODIFY `id_caixa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `caixas_fechadas`
--
ALTER TABLE `caixas_fechadas`
  MODIFY `id_caixa_fechada` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de tabela `caixa_itens`
--
ALTER TABLE `caixa_itens`
  MODIFY `id_caixa_item` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de tabela `classe_item`
--
ALTER TABLE `classe_item`
  MODIFY `id_classe_item` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `enviar_caixas`
--
ALTER TABLE `enviar_caixas`
  MODIFY `id_enviar_caixa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `fornecedores`
--
ALTER TABLE `fornecedores`
  MODIFY `id_fornecedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `itens`
--
ALTER TABLE `itens`
  MODIFY `id_item` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de tabela `itens_vendidos`
--
ALTER TABLE `itens_vendidos`
  MODIFY `id_item_vendido` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `menus`
--
ALTER TABLE `menus`
  MODIFY `id_menu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `movimenta_itens`
--
ALTER TABLE `movimenta_itens`
  MODIFY `id_mov_it` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de tabela `setores`
--
ALTER TABLE `setores`
  MODIFY `id_setor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `usuarios_menus`
--
ALTER TABLE `usuarios_menus`
  MODIFY `id_usuario_menu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `caixas`
--
ALTER TABLE `caixas`
  ADD CONSTRAINT `caixas_ibfk_1` FOREIGN KEY (`criado_por`) REFERENCES `usuarios` (`id_usuario`);

--
-- Limitadores para a tabela `caixas_fechadas`
--
ALTER TABLE `caixas_fechadas`
  ADD CONSTRAINT `caixas_fechadas_ibfk_1` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`);

--
-- Limitadores para a tabela `caixa_itens`
--
ALTER TABLE `caixa_itens`
  ADD CONSTRAINT `caixa_itens_ibfk_1` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`),
  ADD CONSTRAINT `caixa_itens_ibfk_2` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`);

--
-- Limitadores para a tabela `enviar_caixas`
--
ALTER TABLE `enviar_caixas`
  ADD CONSTRAINT `enviar_caixas_ibfk_1` FOREIGN KEY (`id_caixa`) REFERENCES `caixas` (`id_caixa`),
  ADD CONSTRAINT `enviar_caixas_ibfk_2` FOREIGN KEY (`id_enviado_por`) REFERENCES `usuarios` (`id_usuario`);

--
-- Limitadores para a tabela `itens`
--
ALTER TABLE `itens`
  ADD CONSTRAINT `itens_ibfk_1` FOREIGN KEY (`classe_item`) REFERENCES `classe_item` (`id_classe_item`),
  ADD CONSTRAINT `itens_ibfk_2` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedores` (`id_fornecedor`);

--
-- Limitadores para a tabela `itens_vendidos`
--
ALTER TABLE `itens_vendidos`
  ADD CONSTRAINT `itens_vendidos_ibfk_1` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`);

--
-- Limitadores para a tabela `movimenta_itens`
--
ALTER TABLE `movimenta_itens`
  ADD CONSTRAINT `movimenta_itens_ibfk_1` FOREIGN KEY (`id_responsavel`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `movimenta_itens_ibfk_2` FOREIGN KEY (`id_receptor`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `movimenta_itens_ibfk_3` FOREIGN KEY (`id_item`) REFERENCES `itens` (`id_item`);

--
-- Limitadores para a tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_setor`) REFERENCES `setores` (`id_setor`);

--
-- Limitadores para a tabela `usuarios_menus`
--
ALTER TABLE `usuarios_menus`
  ADD CONSTRAINT `usuarios_menus_ibfk_1` FOREIGN KEY (`id_menu`) REFERENCES `menus` (`id_menu`),
  ADD CONSTRAINT `usuarios_menus_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
