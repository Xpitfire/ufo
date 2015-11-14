-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 13, 2015 at 09:35 PM
-- Server version: 5.6.24
-- PHP Version: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `ufo`
--

-- --------------------------------------------------------

--
-- Table structure for table `artist`
--

CREATE TABLE IF NOT EXISTS `artist` (
  `ArtistId` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `EMail` varchar(40) NOT NULL,
  `CategoryId` varchar(2) DEFAULT NULL,
  `CountryCode` char(2) NOT NULL,
  `Picture` mediumtext,
  `PromoVideo` mediumtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `CategoryId` varchar(2) NOT NULL,
  `Name` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `country`
--

CREATE TABLE IF NOT EXISTS `country` (
  `Code` char(2) NOT NULL,
  `Name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `location`
--

CREATE TABLE IF NOT EXISTS `location` (
  `LocationId` int(11) NOT NULL,
  `Longitude` decimal(8,5) DEFAULT NULL,
  `Latitude` decimal(8,5) DEFAULT NULL,
  `Name` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `performance`
--

CREATE TABLE IF NOT EXISTS `performance` (
  `Date` datetime NOT NULL,
  `ArtistId` int(11) NOT NULL,
  `VenueId` char(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `UserId` int(11) NOT NULL,
  `FirstName` varchar(30) DEFAULT NULL,
  `LastName` varchar(30) DEFAULT NULL,
  `Password` varchar(30) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `IsArtist` tinyint(1) NOT NULL,
  `ArtistId` int(11) DEFAULT NULL,
  `EMail` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `venue`
--

CREATE TABLE IF NOT EXISTS `venue` (
  `Name` varchar(40) NOT NULL,
  `VenueId` char(2) NOT NULL,
  `LocationId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `artist`
--
ALTER TABLE `artist`
  ADD PRIMARY KEY (`ArtistId`), ADD KEY `R_8` (`CategoryId`), ADD KEY `R_11` (`CountryCode`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`CategoryId`);

--
-- Indexes for table `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`Code`);

--
-- Indexes for table `location`
--
ALTER TABLE `location`
  ADD PRIMARY KEY (`LocationId`);

--
-- Indexes for table `performance`
--
ALTER TABLE `performance`
  ADD PRIMARY KEY (`ArtistId`,`Date`), ADD KEY `R_14` (`VenueId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserId`), ADD KEY `R_5` (`ArtistId`);

--
-- Indexes for table `venue`
--
ALTER TABLE `venue`
  ADD PRIMARY KEY (`VenueId`), ADD KEY `R_19` (`LocationId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `artist`
--
ALTER TABLE `artist`
ADD CONSTRAINT `R_11` FOREIGN KEY (`CountryCode`) REFERENCES `country` (`Code`),
ADD CONSTRAINT `R_8` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryId`);

--
-- Constraints for table `performance`
--
ALTER TABLE `performance`
ADD CONSTRAINT `R_12` FOREIGN KEY (`ArtistId`) REFERENCES `artist` (`ArtistId`),
ADD CONSTRAINT `R_14` FOREIGN KEY (`VenueId`) REFERENCES `venue` (`VenueId`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
ADD CONSTRAINT `R_5` FOREIGN KEY (`ArtistId`) REFERENCES `artist` (`ArtistId`);

--
-- Constraints for table `venue`
--
ALTER TABLE `venue`
ADD CONSTRAINT `R_19` FOREIGN KEY (`LocationId`) REFERENCES `location` (`LocationId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
