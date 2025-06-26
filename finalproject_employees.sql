-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: finalproject
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `EmployeeId` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `BirthMonth` int DEFAULT NULL,
  `BirthDay` int DEFAULT NULL,
  `BirthYear` int DEFAULT NULL,
  `Age` int DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `EmailAddress` varchar(45) DEFAULT NULL,
  `HomeAddress` varchar(45) DEFAULT NULL,
  `EmployeeDepartment` varchar(45) DEFAULT NULL,
  `EmployeeTitle` int DEFAULT NULL,
  `PayRate` int DEFAULT NULL,
  `HoursWorked` int DEFAULT NULL,
  PRIMARY KEY (`EmployeeId`),
  UNIQUE KEY `EmployeeId_UNIQUE` (`EmployeeId`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (6,'Emily','Claire','Jones',7,11,1992,32,'555-6543','emily.jones@example.com','303 Cedar St','Admin',1,22,38),(7,'David','Robert','Garcia',12,16,1985,38,'555-7890','david.garcia@example.com','404 Walnut St','IT',2,28,40),(8,'Laura','Kate','Miller',5,9,1989,35,'555-9876','laura.miller@example.com','505 Spruce St','Marketing',1,20,37),(10,'Alice debug','Grace','Moore',3,25,1995,29,'555-2345','alice.moore@example.com','707 Hemlock St','Finance',2,18,30),(11,'Tom','Henry','Taylor',8,21,1986,38,'555-3457','tom.taylor@example.com','808 Aspen St','Admin',1,22,35),(12,'Natalie','Ann','Harris',11,10,1992,31,'555-4568','natalie.harris@example.com','909 Redwood St','IT',1,27,42),(13,'Richard','Paul','Clark',6,7,1981,43,'555-5679','richard.clark@example.com','1010 Chestnut St','Marketing',3,25,50),(14,'Susan','Marie','Lopez',2,14,1984,40,'555-6780','susan.lopez@example.com','1111 Sycamore St','HR',2,30,45),(15,'Kevin','George','Walker',10,29,1987,36,'555-7891','kevin.walker@example.com','1212 Walnut St','Finance',1,18,40),(16,'Jessica','Ann','Hall',4,17,1990,34,'555-8901','jessica.hall@example.com','1313 Oak St','Admin',2,20,32),(17,'Chris','Daniel','Allen',8,5,1983,41,'555-9012','chris.allen@example.com','1414 Pine St','Sales',3,25,48),(18,'Megan','Elizabeth','Young',1,23,1985,39,'555-1235','megan.young@example.com','1515 Maple St','IT',2,28,37),(19,'Daniel','John','King',5,30,1992,32,'555-2346','daniel.king@example.com','1616 Birch St','Marketing',1,22,39),(20,'Olivia','Grace','Wright',6,18,1986,38,'555-3458','olivia.wright@example.com','1717 Cedar St','Finance',3,35,42),(21,'William','Thomas','Scott',12,2,1984,39,'555-4569','william.scott@example.com','1818 Fir St','Admin',2,20,30),(22,'Emily','Jane','Green',9,27,1991,33,'555-5670','emily.green@example.com','1919 Hemlock St','HR',1,22,40),(23,'Anthony','James','Adams',3,14,1980,44,'555-6781','anthony.adams@example.com','2020 Spruce St','Marketing',2,25,48),(24,'Anna','Louise','Mitchell',11,6,1988,35,'555-7892','anna.mitchell@example.com','2121 Chestnut St','IT',1,22,38),(26,'Chloe','Marie','Baker',4,11,1992,32,'555-9013','chloe.baker@example.com','2323 Oak St','Finance',2,18,30),(27,'Joshua','David','Hall',7,19,1989,35,'555-0123','joshua.hall@example.com','2424 Pine St','Admin',1,20,37),(28,'Amy','Claire','Carter',8,21,1984,40,'555-1236','amy.carter@example.com','2525 Maple St','Marketing',3,25,42),(29,'Justin','Lee','Diaz',5,4,1990,34,'555-2347','justin.diaz@example.com','2626 Birch St','HR',2,28,45),(30,'Grace','Emma','Lopez',12,16,1982,41,'555-3459','grace.lopez@example.com','2727 Cedar St','IT',1,22,39),(31,'Nicholas','Paul','Wood',6,7,1989,35,'555-4560','nicholas.wood@example.com','2828 Fir St','Sales',3,35,50),(32,'Charlotte','Olivia','Price',11,22,1995,28,'555-5671','charlotte.price@example.com','2929 Hemlock St','Finance',2,20,32),(33,'Michael','George','Roberts',2,29,1980,44,'555-6782','michael.roberts@example.com','3030 Spruce St','Admin',1,27,40),(34,'Sarah','Jane','Hall',9,3,1986,38,'555-7893','sarah.hall@example.com','3131 Chestnut St','HR',1,22,35),(35,'Henry','James','Mitchell',4,10,1985,39,'555-8903','henry.mitchell@example.com','3232 Sycamore St','Marketing',3,25,48),(36,'Isabella','Alice','Thomas',6,24,1990,34,'555-9014','isabella.thomas@example.com','3333 Oak St','IT',2,28,42),(37,'David','John','Clark',10,15,1983,41,'555-0124','david.clark@example.com','3434 Pine St','Sales',1,22,39),(38,'Mia','Charlotte','Walker',1,11,1989,35,'555-1237','mia.walker@example.com','3535 Maple St','Finance',3,35,50),(39,'Jack','Henry','Young',12,5,1992,31,'555-2348','jack.young@example.com','3636 Birch St','Admin',1,22,30),(40,'Lily','Grace','Green',7,29,1984,40,'555-3450','lily.green@example.com','3737 Cedar St','HR',2,30,45),(41,'Noah','Michael','Adams',9,3,1993,31,'555-4561','noah.adams@example.com','3838 Fir St','Marketing',2,20,35),(42,'Aria','Elise','Mitchell',2,14,1987,37,'555-5672','aria.mitchell@example.com','3939 Hemlock St','IT',1,27,40),(43,'Lucas','Daniel','Baker',5,21,1982,42,'555-6783','lucas.baker@example.com','4040 Spruce St','Finance',2,25,38),(45,'Daniel','William','Roberts',11,18,1985,38,'555-8904','daniel.roberts@example.com','4242 Sycamore St','Sales',1,35,45),(46,'Layla','Kate','Adams',1,24,1993,31,'555-9015','layla.adams@example.com','4343 Oak St','Marketing',2,20,38),(47,'Elijah','Robert','Young',4,11,1986,38,'555-0125','elijah.young@example.com','4444 Pine St','HR',1,22,40),(48,'Emma','Grace','Moore',9,17,1989,35,'555-1238','emma.moore@example.com','4545 Maple St','IT',3,28,42),(49,'Matthew','James','King',2,6,1990,34,'555-2349','matthew.king@example.com','4646 Birch St','Finance',1,20,32),(50,'Amelia','Claire','Carter',6,22,1988,36,'555-3451','amelia.carter@example.com','4747 Cedar St','Admin',2,25,50);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-25 21:40:36
