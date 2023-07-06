-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: lab_exam
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.28-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_lab_request`
--

DROP TABLE IF EXISTS `tbl_lab_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lab_request` (
  `lab_id` varchar(255) NOT NULL,
  `lab_req_name` varchar(255) NOT NULL,
  `lab_verify_status` varchar(128) NOT NULL DEFAULT 'PENDING',
  `lab_ref_hn` varchar(32) NOT NULL,
  `lab_req_unit` varchar(255) NOT NULL,
  `approve_datetime` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `approve_staff_id` varchar(255) DEFAULT NULL,
  `lab_result_list_id` varchar(255) NOT NULL,
  PRIMARY KEY (`lab_id`),
  KEY `FK_LAB_REF_HN` (`lab_ref_hn`),
  KEY `FK_REF_UNIT` (`lab_req_unit`),
  CONSTRAINT `FK_LAB_REF_HN` FOREIGN KEY (`lab_ref_hn`) REFERENCES `tbl_patient_details` (`HN`),
  CONSTRAINT `FK_REF_UNIT` FOREIGN KEY (`lab_req_unit`) REFERENCES `tbl_units` (`unit_code_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lab_request`
--

LOCK TABLES `tbl_lab_request` WRITE;
/*!40000 ALTER TABLE `tbl_lab_request` DISABLE KEYS */;
INSERT INTO `tbl_lab_request` VALUES ('6503-51200','Non-insulin-dependent diabetes','PENDING','9999999','ER','0000-00-00 00:00:00','','100744727');
/*!40000 ALTER TABLE `tbl_lab_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lab_result`
--

DROP TABLE IF EXISTS `tbl_lab_result`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lab_result` (
  `result_list_id` varchar(255) NOT NULL,
  `result_lab_id` varchar(255) NOT NULL,
  `result_code` varchar(255) NOT NULL,
  `result_name` varchar(255) NOT NULL,
  `result_status` varchar(255) NOT NULL,
  `result_type` varchar(255) NOT NULL,
  `result_value` float NOT NULL,
  `result_unit` varchar(255) NOT NULL,
  `result_flag` varchar(255) NOT NULL,
  `result_ref_range` varchar(255) NOT NULL,
  `result_datetime` datetime NOT NULL,
  `result_test_code` varchar(255) NOT NULL,
  `result_test_name` varchar(255) NOT NULL,
  `cri_flag` varchar(255) NOT NULL,
  `cri_remark` varchar(255) NOT NULL,
  `dilution_flag` varchar(255) NOT NULL,
  `inform_cri_by` varchar(255) NOT NULL,
  `inform_cri_datetime` varchar(255) NOT NULL,
  `inform_cri_to` varchar(255) NOT NULL,
  `repeat_flag` varchar(255) NOT NULL,
  `report_by` varchar(255) NOT NULL,
  `result_remark` varchar(255) NOT NULL,
  `specimen_code` varchar(255) NOT NULL,
  `specimen_name` varchar(255) NOT NULL,
  `test_remark` varchar(255) NOT NULL,
  UNIQUE KEY `result_list_id` (`result_list_id`),
  KEY `FK_REF_LAB-ID` (`result_lab_id`) USING BTREE,
  CONSTRAINT `FK_REF_LAD-ID` FOREIGN KEY (`result_lab_id`) REFERENCES `tbl_lab_request` (`lab_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lab_result`
--

LOCK TABLES `tbl_lab_result` WRITE;
/*!40000 ALTER TABLE `tbl_lab_result` DISABLE KEYS */;
INSERT INTO `tbl_lab_result` VALUES ('100744727-1','6503-51200','15','*BUN','A','T',26.8,'mg/dL','H','8.9 - 20.6','0000-00-00 00:00:00','CH002','*BUN','','','','','','','0','AMS','','8','Lit',''),('100744727-2','6503-51200','16','*Creatinine','A','T',1.78,'mg/dL','H','0.73 - 1.18','0000-00-00 00:00:00','CH003','*Creatinine','','','','','','','0','AMS','','8','Lit',''),('100744727-3','6503-51200','24','*Uric acid','A','T',8.7,'mg/dL','H','3.5 - 7.2','0000-00-00 00:00:00','CH011','*Uric acid','','','','','','','0','AMS','','8','Lit',''),('100744727-4','6503-51200','25','*Cholesterol','A','T',144,'mg/dL','','< 200','0000-00-00 00:00:00','CH012','*Cholesterol','','','','','','','0','AMS','','8','Lit',''),('100744727-5','6503-51200','26','*Triglyceride','A','T',165,'mg/dL','H','< 150','0000-00-00 00:00:00','CH013','*Triglyceride','','','','','','','0','AMS','','8','Lit',''),('100744727-6','6503-51200','27','*HDL-C','A','T',43.8,'mg/dL','','> 40','0000-00-00 00:00:00','CH014','*HDL-C','','','','','','','0','AMS','','8','Lit',''),('100744727-7','6503-51200','28','*LDL-C','A','T',80.9,'mg/dL','','< 130','0000-00-00 00:00:00','CH015','*LDL-C','','','','','','','0','AMS','','8','Lit','');
/*!40000 ALTER TABLE `tbl_lab_result` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lab_staff`
--

DROP TABLE IF EXISTS `tbl_lab_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lab_staff` (
  `staff_id` varchar(32) NOT NULL,
  `staff_name` varchar(255) NOT NULL,
  `staff_last_name` varchar(255) NOT NULL,
  `staff_permission` varchar(255) NOT NULL,
  `staff_unit` varchar(255) NOT NULL,
  `staff_password` varchar(255) NOT NULL,
  `staff_passcode` varchar(32) NOT NULL,
  PRIMARY KEY (`staff_id`),
  KEY `FK_REF_UNIT_CNAME` (`staff_unit`),
  CONSTRAINT `FK_REF_UNIT_CNAME` FOREIGN KEY (`staff_unit`) REFERENCES `tbl_units` (`unit_code_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lab_staff`
--

LOCK TABLES `tbl_lab_staff` WRITE;
/*!40000 ALTER TABLE `tbl_lab_staff` DISABLE KEYS */;
INSERT INTO `tbl_lab_staff` VALUES ('00001','SARAN','K','VERIFY','ER','666666','666666'),('00002','STAFF-1','LN','VERIFY','ER','123456','123456');
/*!40000 ALTER TABLE `tbl_lab_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_patient_details`
--

DROP TABLE IF EXISTS `tbl_patient_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_patient_details` (
  `HN` varchar(32) NOT NULL,
  `prefix_name` varchar(32) NOT NULL,
  `first_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `last_name` varchar(128) NOT NULL,
  `date_of_birth` datetime NOT NULL,
  `sex` varchar(16) NOT NULL,
  `weight` float NOT NULL,
  `height` int(11) NOT NULL,
  PRIMARY KEY (`HN`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_patient_details`
--

LOCK TABLES `tbl_patient_details` WRITE;
/*!40000 ALTER TABLE `tbl_patient_details` DISABLE KEYS */;
INSERT INTO `tbl_patient_details` VALUES ('9999999','นางสาว','สมวารีพักตร์','สมัครใจมา','0000-00-00 00:00:00','F',52,175);
/*!40000 ALTER TABLE `tbl_patient_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_units`
--

DROP TABLE IF EXISTS `tbl_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_units` (
  `unit_code_name` varchar(255) NOT NULL,
  `unit_detail` varchar(255) NOT NULL,
  PRIMARY KEY (`unit_code_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_units`
--

LOCK TABLES `tbl_units` WRITE;
/*!40000 ALTER TABLE `tbl_units` DISABLE KEYS */;
INSERT INTO `tbl_units` VALUES ('CHEM',''),('ER',''),('HEMATO','');
/*!40000 ALTER TABLE `tbl_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'lab_exam'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-07  1:17:35
