-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 14, 2016 at 08:02 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 7.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ufo`
--
CREATE DATABASE IF NOT EXISTS `ufo` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `ufo`;

-- --------------------------------------------------------

--
-- Table structure for table `artist`
--

CREATE TABLE IF NOT EXISTS `artist` (
  `ArtistId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `EMail` varchar(40) NOT NULL,
  `CategoryId` varchar(2) DEFAULT NULL,
  `CountryCode` char(2) DEFAULT NULL,
  `Picture` mediumtext,
  `PromoVideo` mediumtext,
  PRIMARY KEY (`ArtistId`),
  KEY `R_8` (`CategoryId`),
  KEY `R_11` (`CountryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `artistview`
--
CREATE TABLE IF NOT EXISTS `artistview` (
`ArtistId` int(11)
,`ArtistName` varchar(30)
,`EMail` varchar(40)
,`CategoryId` varchar(2)
,`CategoryName` varchar(40)
,`CountryCode` char(2)
,`CountryName` varchar(30)
,`Picture` mediumtext
,`PromoVideo` mediumtext
);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `CategoryId` varchar(2) NOT NULL,
  `Name` varchar(40) NOT NULL,
  `Color` char(7) NOT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `country`
--

CREATE TABLE IF NOT EXISTS `country` (
  `Code` char(2) NOT NULL,
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `location`
--

CREATE TABLE IF NOT EXISTS `location` (
  `LocationId` int(11) NOT NULL AUTO_INCREMENT,
  `Longitude` decimal(8,5) NOT NULL,
  `Latitude` decimal(8,5) NOT NULL,
  `Name` varchar(30) NOT NULL,
  PRIMARY KEY (`LocationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `performance`
--

CREATE TABLE IF NOT EXISTS `performance` (
  `Date` datetime NOT NULL,
  `ArtistId` int(11) NOT NULL,
  `VenueId` char(2) DEFAULT NULL,
  PRIMARY KEY (`ArtistId`,`Date`),
  KEY `R_14` (`VenueId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `performanceview`
--
CREATE TABLE IF NOT EXISTS `performanceview` (
`ArtistId` int(11)
,`Date` datetime
,`VenueId` char(2)
,`ArtistName` varchar(30)
,`EMail` varchar(40)
,`CategoryId` varchar(2)
,`CategoryName` varchar(40)
,`CountryCode` char(2)
,`CountryName` varchar(30)
,`Picture` mediumtext
,`PromoVideo` mediumtext
,`VenueName` varchar(40)
,`LocationId` int(11)
,`Longitude` decimal(8,5)
,`Latitude` decimal(8,5)
,`LocationName` varchar(30)
);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) DEFAULT NULL,
  `LastName` varchar(30) DEFAULT NULL,
  `Password` varchar(50) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `IsArtist` tinyint(1) NOT NULL,
  `ArtistId` int(11) DEFAULT NULL,
  `EMail` varchar(40) NOT NULL,
  PRIMARY KEY (`UserId`),
  KEY `R_5` (`ArtistId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `userview`
--
CREATE TABLE IF NOT EXISTS `userview` (
`UserId` int(11)
,`FirstName` varchar(30)
,`LastName` varchar(30)
,`UserMail` varchar(40)
,`Password` varchar(50)
,`IsAdmin` tinyint(1)
,`IsArtist` tinyint(1)
,`ArtistId` int(11)
,`ArtistName` varchar(30)
,`ArtistMail` varchar(40)
,`CategoryId` varchar(2)
,`CategoryName` varchar(40)
,`CountryCode` char(2)
,`CountryName` varchar(30)
,`Picture` mediumtext
,`PromoVideo` mediumtext
);

-- --------------------------------------------------------

--
-- Table structure for table `venue`
--

CREATE TABLE IF NOT EXISTS `venue` (
  `Name` varchar(40) NOT NULL,
  `VenueId` char(2) NOT NULL,
  `LocationId` int(11) NOT NULL,
  PRIMARY KEY (`VenueId`),
  KEY `R_19` (`LocationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `venueview`
--
CREATE TABLE IF NOT EXISTS `venueview` (
`VenueId` char(2)
,`VenueName` varchar(40)
,`LocationId` int(11)
,`Longitude` decimal(8,5)
,`Latitude` decimal(8,5)
,`LocationName` varchar(30)
);

-- --------------------------------------------------------

--
-- Structure for view `artistview`
--
DROP TABLE IF EXISTS `artistview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `artistview`  AS  select `a`.`ArtistId` AS `ArtistId`,`a`.`Name` AS `ArtistName`,`a`.`EMail` AS `EMail`,`a`.`CategoryId` AS `CategoryId`,`ca`.`Name` AS `CategoryName`,`a`.`CountryCode` AS `CountryCode`,`co`.`Name` AS `CountryName`,`a`.`Picture` AS `Picture`,`a`.`PromoVideo` AS `PromoVideo` from ((`artist` `a` left join `category` `ca` on((`a`.`CategoryId` = `ca`.`CategoryId`))) join `country` `co`) where (`a`.`CountryCode` = `co`.`Code`) ;

-- --------------------------------------------------------

--
-- Structure for view `performanceview`
--
DROP TABLE IF EXISTS `performanceview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `performanceview`  AS  select `a`.`ArtistId` AS `ArtistId`,`p`.`Date` AS `Date`,`v`.`VenueId` AS `VenueId`,`a`.`ArtistName` AS `ArtistName`,`a`.`EMail` AS `EMail`,`a`.`CategoryId` AS `CategoryId`,`a`.`CategoryName` AS `CategoryName`,`a`.`CountryCode` AS `CountryCode`,`a`.`CountryName` AS `CountryName`,`a`.`Picture` AS `Picture`,`a`.`PromoVideo` AS `PromoVideo`,`v`.`VenueName` AS `VenueName`,`v`.`LocationId` AS `LocationId`,`v`.`Longitude` AS `Longitude`,`v`.`Latitude` AS `Latitude`,`v`.`LocationName` AS `LocationName` from (`artistview` `a` join (`performance` `p` left join `venueview` `v` on((`p`.`VenueId` = `v`.`VenueId`)))) where (`a`.`ArtistId` = `p`.`ArtistId`) ;

-- --------------------------------------------------------

--
-- Structure for view `userview`
--
DROP TABLE IF EXISTS `userview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `userview`  AS  select `u`.`UserId` AS `UserId`,`u`.`FirstName` AS `FirstName`,`u`.`LastName` AS `LastName`,`u`.`EMail` AS `UserMail`,`u`.`Password` AS `Password`,`u`.`IsAdmin` AS `IsAdmin`,`u`.`IsArtist` AS `IsArtist`,`a`.`ArtistId` AS `ArtistId`,`a`.`ArtistName` AS `ArtistName`,`a`.`EMail` AS `ArtistMail`,`a`.`CategoryId` AS `CategoryId`,`a`.`CategoryName` AS `CategoryName`,`a`.`CountryCode` AS `CountryCode`,`a`.`CountryName` AS `CountryName`,`a`.`Picture` AS `Picture`,`a`.`PromoVideo` AS `PromoVideo` from (`user` `u` left join `artistview` `a` on((`a`.`ArtistId` = `u`.`ArtistId`))) ;

-- --------------------------------------------------------

--
-- Structure for view `venueview`
--
DROP TABLE IF EXISTS `venueview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `venueview`  AS  select `v`.`VenueId` AS `VenueId`,`v`.`Name` AS `VenueName`,`v`.`LocationId` AS `LocationId`,`l`.`Longitude` AS `Longitude`,`l`.`Latitude` AS `Latitude`,`l`.`Name` AS `LocationName` from (`venue` `v` join `location` `l`) where (`v`.`LocationId` = `l`.`LocationId`) ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `artist`
--
ALTER TABLE `artist`
  ADD CONSTRAINT `R_11` FOREIGN KEY (`CountryCode`) REFERENCES `country` (`Code`),
  ADD CONSTRAINT `R_8` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `performance`
--
ALTER TABLE `performance`
  ADD CONSTRAINT `R_12` FOREIGN KEY (`ArtistId`) REFERENCES `artist` (`ArtistId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `R_14` FOREIGN KEY (`VenueId`) REFERENCES `venue` (`VenueId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `R_5` FOREIGN KEY (`ArtistId`) REFERENCES `artist` (`ArtistId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `venue`
--
ALTER TABLE `venue`
  ADD CONSTRAINT `R_19` FOREIGN KEY (`LocationId`) REFERENCES `location` (`LocationId`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
