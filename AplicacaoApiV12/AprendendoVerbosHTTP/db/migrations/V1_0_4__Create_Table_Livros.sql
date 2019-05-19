﻿CREATE TABLE livros (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Titulo` VARCHAR(50),
	`Autor` VARCHAR(50),
	`Preco` DECIMAL(10,2),
	`DataLancamento` DATETIME,
	PRIMARY KEY(ID)
);