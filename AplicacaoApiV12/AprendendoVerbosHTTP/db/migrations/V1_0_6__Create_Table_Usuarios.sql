﻿CREATE TABLE usuarios(
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`Login` VARCHAR(10) UNIQUE NOT NULL,
	`AccessKey` VARCHAR(50) NOT NULL,
	PRIMARY KEY(`ID`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=7
;

