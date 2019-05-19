-- --------------------------------------------------------
-- Servidor:                     localhost
-- Versão do servidor:           10.1.30-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              10.1.0.5464
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para bancoapi
CREATE DATABASE IF NOT EXISTS `bancoapi` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `bancoapi`;

-- Copiando estrutura para tabela bancoapi.changelog
CREATE TABLE IF NOT EXISTS `changelog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` tinyint(4) DEFAULT NULL,
  `version` varchar(50) DEFAULT NULL,
  `description` varchar(200) NOT NULL,
  `name` varchar(300) NOT NULL,
  `checksum` varchar(32) DEFAULT NULL,
  `installed_by` varchar(100) NOT NULL,
  `installed_on` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `success` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bancoapi.changelog: ~8 rows (aproximadamente)
DELETE FROM `changelog`;
/*!40000 ALTER TABLE `changelog` DISABLE KEYS */;
INSERT INTO `changelog` (`id`, `type`, `version`, `description`, `name`, `checksum`, `installed_by`, `installed_on`, `success`) VALUES
	(1, 2, '0', 'Empty schema found: bancoapi.', 'bancoapi', '', 'root', '2019-03-23 19:54:33', 1),
	(2, 0, '1.0.1', 'Create Table Pessoas', 'V1_0_1__Create_Table_Pessoas.sql', 'C726DAFB6A64224A61635432ED4B5455', 'root', '2019-03-23 19:54:33', 1),
	(3, 0, '1.0.2', 'Alter Table Pessoas', 'V1_0_2__Alter_Table_Pessoas.sql', 'D9F8F9CCD73F927CFCD9B1B9FE3C05B4', 'root', '2019-03-23 19:54:33', 1),
	(4, 0, '1.0.3', 'Insert data in pessoas', 'V1_0_3__Insert_data_in_pessoas.sql', '5DF5671E99DD68B90DB491F7A6228648', 'root', '2019-03-23 19:54:33', 1),
	(5, 0, '1.0.4', 'Create Table Livros', 'V1_0_4__Create_Table_Livros.sql', 'CEA0FD4E6180270ED380256470DEA767', 'root', '2019-03-23 19:54:33', 1),
	(6, 0, '1.0.5', 'Insert data in livros', 'V1_0_5__Insert_data_in_livros.sql', 'AE4B20F4BF71006D48B0D42221FA7F78', 'root', '2019-03-23 19:54:33', 1),
	(7, 0, '1.0.6', 'Create Table Usuarios', 'V1_0_6__Create_Table_Usuarios.sql', 'AE63A037D9F8A13734B27C0FE84F2453', 'root', '2019-03-23 19:54:34', 1),
	(8, 0, '1.0.7', 'Insert data in usuarios', 'V1_0_7__Insert_data_in_usuarios.sql', 'E9BC5657FB0AFCB6A165453949C50B24', 'root', '2019-03-23 19:54:34', 1);
/*!40000 ALTER TABLE `changelog` ENABLE KEYS */;

-- Copiando estrutura para tabela bancoapi.livros
CREATE TABLE IF NOT EXISTS `livros` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(50) DEFAULT NULL,
  `Autor` varchar(50) DEFAULT NULL,
  `Preco` decimal(10,2) DEFAULT NULL,
  `DataLancamento` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bancoapi.livros: ~0 rows (aproximadamente)
DELETE FROM `livros`;
/*!40000 ALTER TABLE `livros` DISABLE KEYS */;
INSERT INTO `livros` (`ID`, `Titulo`, `Autor`, `Preco`, `DataLancamento`) VALUES
	(1, 'Nárnia', 'Joao', 90.00, '1998-09-25 00:00:00');
/*!40000 ALTER TABLE `livros` ENABLE KEYS */;

-- Copiando estrutura para tabela bancoapi.pessoas
CREATE TABLE IF NOT EXISTS `pessoas` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  `Sobrenome` varchar(50) DEFAULT NULL,
  `Endereco` varchar(50) DEFAULT NULL,
  `Sexo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bancoapi.pessoas: ~100 rows (aproximadamente)
DELETE FROM `pessoas`;
/*!40000 ALTER TABLE `pessoas` DISABLE KEYS */;
INSERT INTO `pessoas` (`ID`, `Nome`, `Sobrenome`, `Endereco`, `Sexo`) VALUES
	(1, 'Merrile', 'Minchinden', '25 Raven Pass', 'Female'),
	(2, 'Carrie', 'Croasdale', '46529 Jenna Trail', 'Female'),
	(3, 'Peria', 'Tures', '2 Nevada Place', 'Female'),
	(4, 'Dusty', 'Arnold', '99 Monica Circle', 'Female'),
	(5, 'Eb', 'Lambin', '789 Kennedy Alley', 'Male'),
	(6, 'Isidro', 'Harburtson', '9 Waxwing Park', 'Male'),
	(7, 'Kimberli', 'Bartul', '1819 Canary Plaza', 'Female'),
	(8, 'Thornie', 'Sheals', '56 Utah Junction', 'Male'),
	(9, 'Benson', 'Itscowics', '005 Melvin Court', 'Male'),
	(10, 'Bekki', 'Greaves', '92240 School Lane', 'Female'),
	(11, 'Mitchael', 'Crawshay', '50655 Londonderry Place', 'Male'),
	(12, 'Chery', 'Birtwisle', '2 Anderson Street', 'Female'),
	(13, 'Everett', 'Betancourt', '80 Dakota Plaza', 'Male'),
	(14, 'Gertrude', 'Hugonnet', '58 Center Way', 'Female'),
	(15, 'Lenette', 'Johncey', '45797 Shoshone Place', 'Female'),
	(16, 'Benjy', 'Maxstead', '13 Novick Crossing', 'Male'),
	(17, 'Zeb', 'Yare', '250 Bowman Way', 'Male'),
	(18, 'Ashbey', 'Varnes', '429 Dapin Court', 'Male'),
	(19, 'Kenna', 'Marqyes', '90 Forster Junction', 'Female'),
	(20, 'Ricardo', 'Jirousek', '0 Bunting Drive', 'Male'),
	(21, 'Kaleb', 'Shortland', '21 Moose Pass', 'Male'),
	(22, 'Glenden', 'MacKeever', '7225 Clove Alley', 'Male'),
	(23, 'Cody', 'Bidwell', '155 South Street', 'Female'),
	(24, 'Bent', 'Guislin', '9066 Rieder Drive', 'Male'),
	(25, 'Brandtr', 'Mourgue', '6 Northview Center', 'Male'),
	(26, 'Niki', 'Cutteridge', '6725 Fieldstone Street', 'Male'),
	(27, 'Midge', 'Patient', '005 Artisan Avenue', 'Female'),
	(28, 'Hamid', 'Whaplington', '229 Maple Way', 'Male'),
	(29, 'Mattheus', 'Illyes', '6262 Summit Road', 'Male'),
	(30, 'Montgomery', 'Mossop', '30 Cody Avenue', 'Male'),
	(31, 'Brianna', 'McSaul', '02 Bobwhite Park', 'Female'),
	(32, 'Darcy', 'Paraman', '0014 Eagle Crest Parkway', 'Male'),
	(33, 'Burnaby', 'Bennell', '1155 Vera Lane', 'Male'),
	(34, 'Meryl', 'Durrell', '63060 Trailsway Pass', 'Female'),
	(35, 'Marshal', 'Cadreman', '5703 Namekagon Alley', 'Male'),
	(36, 'Webster', 'Kentwell', '507 6th Point', 'Male'),
	(37, 'Alyson', 'Waumsley', '8316 Victoria Court', 'Female'),
	(38, 'Genevra', 'Janc', '28 Bellgrove Road', 'Female'),
	(39, 'Lorene', 'Crates', '4 Upham Lane', 'Female'),
	(40, 'Isadore', 'Culleford', '88517 Oak Court', 'Male'),
	(41, 'Demetri', 'Gregorace', '667 Meadow Ridge Drive', 'Male'),
	(42, 'Isaac', 'Mathis', '69318 Melrose Place', 'Male'),
	(43, 'Cammie', 'Kock', '65 Granby Circle', 'Female'),
	(44, 'Cherie', 'Colenutt', '31738 Kropf Drive', 'Female'),
	(45, 'Almire', 'Clarkin', '472 Forest Dale Street', 'Female'),
	(46, 'Kacie', 'Fonquernie', '91 Armistice Lane', 'Female'),
	(47, 'Daryl', 'Manville', '4 Del Sol Circle', 'Female'),
	(48, 'Ottilie', 'Bullingham', '27 Bluestem Terrace', 'Female'),
	(49, 'Kaylil', 'Tertre', '96 Stone Corner Street', 'Female'),
	(50, 'Rica', 'Massie', '08263 Boyd Center', 'Female'),
	(51, 'Nettie', 'Huxham', '0297 Westridge Avenue', 'Female'),
	(52, 'Nikolaos', 'Ducker', '00734 High Crossing Plaza', 'Male'),
	(53, 'Ichabod', 'Kneeland', '5 Maple Junction', 'Male'),
	(54, 'Bel', 'Petheridge', '1742 Alpine Trail', 'Female'),
	(55, 'Doria', 'Corp', '291 Main Center', 'Female'),
	(56, 'Riccardo', 'Cowan', '912 6th Trail', 'Male'),
	(57, 'Olag', 'Conring', '93107 Heffernan Road', 'Male'),
	(58, 'Gerhardine', 'Von Der Empten', '87 Comanche Crossing', 'Female'),
	(59, 'Hilliard', 'Matthias', '4 Marquette Center', 'Male'),
	(60, 'Kippie', 'Denver', '14980 Gerald Lane', 'Female'),
	(61, 'Holt', 'O"Hagirtie', '06416 Coleman Plaza', 'Male'),
	(62, 'Pepito', 'Ainsley', '67964 Elka Point', 'Male'),
	(63, 'Irena', 'Botwood', '526 David Trail', 'Female'),
	(64, 'Hendrick', 'Small', '81 Ronald Regan Avenue', 'Male'),
	(65, 'Larry', 'Coupar', '47 Hallows Alley', 'Male'),
	(66, 'Barnabe', 'Scraggs', '4367 Carey Lane', 'Male'),
	(67, 'Bel', 'Heavy', '23590 Little Fleur Center', 'Female'),
	(68, 'Dulcie', 'Blazi', '0888 Esker Drive', 'Female'),
	(69, 'Georas', 'Greenan', '1 Di Loreto Hill', 'Male'),
	(70, 'Daron', 'Tutin', '08822 Weeping Birch Point', 'Male'),
	(71, 'Bethina', 'Tregunna', '6540 Rusk Road', 'Female'),
	(72, 'Tucky', 'Beszant', '920 Prairieview Junction', 'Male'),
	(73, 'Devonna', 'Sirrell', '6 Hoepker Court', 'Female'),
	(74, 'Lauritz', 'Fairburne', '5572 Old Shore Place', 'Male'),
	(75, 'Larine', 'Gillet', '1470 Muir Road', 'Female'),
	(76, 'Adrien', 'Bambrugh', '53106 Merrick Way', 'Male'),
	(77, 'Sosanna', 'Trewman', '464 Upham Way', 'Female'),
	(78, 'Brodie', 'Rosoni', '913 Roxbury Way', 'Male'),
	(79, 'Cobb', 'Hyde', '224 Myrtle Junction', 'Male'),
	(80, 'Rodi', 'Hincham', '06029 Grasskamp Center', 'Female'),
	(81, 'Tobin', 'Baume', '55 Cardinal Plaza', 'Male'),
	(82, 'Winna', 'Pelcheur', '666 Artisan Junction', 'Female'),
	(83, 'Field', 'Antonognoli', '86493 Havey Center', 'Male'),
	(84, 'Ilyse', 'Ianizzi', '07 Express Junction', 'Female'),
	(85, 'Missy', 'Bysaker', '62320 Holy Cross Circle', 'Female'),
	(86, 'Kevyn', 'Gaddes', '66510 Scott Lane', 'Female'),
	(87, 'Josiah', 'Inott', '42794 Sherman Drive', 'Male'),
	(88, 'Iorgos', 'Chesterfield', '3090 Mcguire Circle', 'Male'),
	(89, 'Hilton', 'Heads', '50090 Pine View Hill', 'Male'),
	(90, 'Kelsey', 'Rintoul', '247 Riverside Plaza', 'Female'),
	(91, 'Donn', 'Johnes', '457 Brickson Park Alley', 'Male'),
	(92, 'Willdon', 'Berrington', '08573 Ludington Circle', 'Male'),
	(93, 'Elton', 'Dougherty', '0840 Fair Oaks Drive', 'Male'),
	(94, 'Bettine', 'Monelle', '7 Morrow Pass', 'Female'),
	(95, 'Adena', 'Bru', '602 Bartelt Junction', 'Female'),
	(96, 'Bay', 'Jentet', '49 Petterle Avenue', 'Male'),
	(97, 'Therine', 'Tott', '8 Waubesa Hill', 'Female'),
	(98, 'Levy', 'Mussolini', '1664 Alpine Court', 'Male'),
	(99, 'Marty', 'Mannering', '2 Stang Trail', 'Male'),
	(100, 'Nat', 'Bussetti', '74 Stoughton Street', 'Female');
/*!40000 ALTER TABLE `pessoas` ENABLE KEYS */;

-- Copiando estrutura para tabela bancoapi.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Login` varchar(10) NOT NULL,
  `AccessKey` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Login` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela bancoapi.usuarios: ~2 rows (aproximadamente)
DELETE FROM `usuarios`;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`ID`, `Login`, `AccessKey`) VALUES
	(7, 'Leandro', 'admin123'),
	(8, 'flavio', 'user123');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
