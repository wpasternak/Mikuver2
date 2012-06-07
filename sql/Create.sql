SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `mikuver2` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mikuver2` ;

-- -----------------------------------------------------
-- Table `mikuver2`.`Kunden`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Kunden` (
  `ID` INT NOT NULL ,
  `KundeSeit` DATE NULL ,
  `UnternehmenID` INT NULL ,
  `EmpfohlenVon` VARCHAR(50) NULL ,
  `GeschaeftspartnerID` INT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) ,
  UNIQUE INDEX `UnternehmenID_UNIQUE` (`UnternehmenID` ASC) ,
  UNIQUE INDEX `GeschaeftspartnerID_UNIQUE` (`GeschaeftspartnerID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Geschaeftspatner`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Geschaeftspatner` (
  `ID` INT NOT NULL ,
  `lft` INT NULL ,
  `rgt` INT NULL ,
  `Vorgesetzter` INT NULL ,
  `Eintrittsdatum` DATE NOT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) ,
  UNIQUE INDEX `lft_UNIQUE` (`lft` ASC) ,
  UNIQUE INDEX `rgt_UNIQUE` (`rgt` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Person`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Person` (
  `ID` INT NOT NULL ,
  `Vorname` VARCHAR(50) NULL ,
  `Nachname` VARCHAR(50) NULL ,
  `Geburtsdatum` DATE NULL ,
  `GeschlechtID` INT NULL ,
  `Fax` INT NULL ,
  `Telefon` INT NULL ,
  `Strasse` VARCHAR(50) NULL ,
  `Hausnummer` VARCHAR(10) NULL ,
  `PLZ` INT NULL ,
  `Ort` VARCHAR(30) NULL ,
  `E-Mail` VARCHAR(60) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Unternehmen`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Unternehmen` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(50) NULL ,
  `Ansprechpartner` VARCHAR(50) NULL ,
  `Angestellte` INT NULL ,
  `Webseite` VARCHAR(50) NULL ,
  `Geschaeftspartner` INT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Aufgabe`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Aufgabe` (
  `ID` INT NOT NULL ,
  `Titel` VARCHAR(50) NULL ,
  `Beschreibung` VARCHAR(140) NULL ,
  `ErstelltAm` DATE NULL ,
  `Status` INT NULL ,
  `FaelligAm` DATE NULL ,
  `ErstelltVon` INT NULL ,
  `Bearbeiter` INT NULL ,
  `Kategorie` INT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Termin`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Termin` (
  `ID` INT NOT NULL ,
  `Titel` VARCHAR(50) NULL ,
  `Beschreibung` VARCHAR(140) NULL ,
  `ErstelltAm` DATE NULL ,
  `Von` DATE NULL ,
  `Bis` DATE NULL ,
  `Ganztagsereignis` TINYINT(1) NULL ,
  `BenachrichtigungAn` INT NULL ,
  `Terminart` INT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Kategorie`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Kategorie` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(30) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Terminart`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Terminart` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(30) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mikuver2`.`Status`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mikuver2`.`Status` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(30) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
