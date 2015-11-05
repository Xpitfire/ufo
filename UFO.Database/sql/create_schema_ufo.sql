-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 05, 2015 at 07:42 PM
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
  `ID` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `EMail` varchar(40) NOT NULL,
  `CategoryID` int(11) NOT NULL,
  `CountryCode` char(2) NOT NULL,
  `Picture` blob,
  `PromoVideo` mediumtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `country`
--

CREATE TABLE IF NOT EXISTS `country` (
  `Code` char(2) NOT NULL,
  `Name` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `performance`
--

CREATE TABLE IF NOT EXISTS `performance` (
  `Date` date NOT NULL,
  `ArtistID` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Lon` decimal(8,5) DEFAULT NULL,
  `Lat` decimal(8,5) DEFAULT NULL,
  `SpotID` char(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Password` varchar(30) DEFAULT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `IsArtist` tinyint(1) NOT NULL,
  `ArtistID` int(11) DEFAULT NULL,
  `EMail` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `venue`
--

CREATE TABLE IF NOT EXISTS `venue` (
  `Lon` decimal(8,5) NOT NULL,
  `Lat` decimal(8,5) NOT NULL,
  `Street` varchar(40) NOT NULL,
  `Description` text,
  `SpotID` char(2) NOT NULL,
  `Name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `artist`
--
ALTER TABLE `artist`
  ADD PRIMARY KEY (`ID`), ADD KEY `R_8` (`CategoryID`), ADD KEY `R_11` (`CountryCode`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`Code`);

--
-- Indexes for table `performance`
--
ALTER TABLE `performance`
  ADD PRIMARY KEY (`ArtistID`,`Date`), ADD KEY `R_14` (`Lon`,`Lat`,`SpotID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`), ADD KEY `R_5` (`ArtistID`);

--
-- Indexes for table `venue`
--
ALTER TABLE `venue`
  ADD PRIMARY KEY (`Lon`,`Lat`,`SpotID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `artist`
--
ALTER TABLE `artist`
ADD CONSTRAINT `R_11` FOREIGN KEY (`CountryCode`) REFERENCES `country` (`Code`),
ADD CONSTRAINT `R_8` FOREIGN KEY (`CategoryID`) REFERENCES `category` (`ID`);

--
-- Constraints for table `performance`
--
ALTER TABLE `performance`
ADD CONSTRAINT `R_12` FOREIGN KEY (`ArtistID`) REFERENCES `artist` (`ID`),
ADD CONSTRAINT `R_14` FOREIGN KEY (`Lon`, `Lat`, `SpotID`) REFERENCES `venue` (`Lon`, `Lat`, `SpotID`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
ADD CONSTRAINT `R_5` FOREIGN KEY (`ArtistID`) REFERENCES `artist` (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
