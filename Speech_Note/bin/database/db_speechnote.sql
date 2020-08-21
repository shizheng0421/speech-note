/*
Navicat MySQL Data Transfer

Source Server         : Speech_Note
Source Server Version : 50713
Source Host           : localhost:3306
Source Database       : db_speechnote

Target Server Type    : MYSQL
Target Server Version : 50713
File Encoding         : 65001

Date: 2017-04-18 23:48:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for fekeystb
-- ----------------------------
DROP TABLE IF EXISTS `fekeystb`;
CREATE TABLE `fekeystb` (
  `Keys` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of fekeystb
-- ----------------------------
INSERT INTO `fekeystb` VALUES ('green');

-- ----------------------------
-- Table structure for filetb
-- ----------------------------
DROP TABLE IF EXISTS `filetb`;
CREATE TABLE `filetb` (
  `ID` int(10) NOT NULL,
  `filename` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of filetb
-- ----------------------------
INSERT INTO `filetb` VALUES ('1', 'data', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\data.txt');
INSERT INTO `filetb` VALUES ('2', 'green (1)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\green (1).txt');
INSERT INTO `filetb` VALUES ('3', 'green (3)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\green (3).txt');
INSERT INTO `filetb` VALUES ('4', 'red', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\red.txt');
INSERT INTO `filetb` VALUES ('5', 'yellow', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\yellow.txt');
INSERT INTO `filetb` VALUES ('6', '天气 - 副本 (5)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\天气 - 副本 (5).txt');
INSERT INTO `filetb` VALUES ('7', '天气 - 副本 (6)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\天气 - 副本 (6).txt');
INSERT INTO `filetb` VALUES ('8', '天气 - 副本', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\天气 - 副本.txt');
INSERT INTO `filetb` VALUES ('9', '天气', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\天气.txt');
INSERT INTO `filetb` VALUES ('10', '阴雨', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\阴雨.txt');
INSERT INTO `filetb` VALUES ('11', '天气 - 副本 (2)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\医疗\\天气 - 副本 (2).txt');
INSERT INTO `filetb` VALUES ('12', '天气 - 副本 (3)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\医疗\\天气 - 副本 (3).txt');
INSERT INTO `filetb` VALUES ('13', '天气 - 副本 (4)', 'E:\\TheWayOfCoder\\20170202Speech_Note\\Speech_Note\\Speech_Note\\bin\\Debug\\recent_files\\医疗\\天气 - 副本 (4).txt');

-- ----------------------------
-- Table structure for keystb
-- ----------------------------
DROP TABLE IF EXISTS `keystb`;
CREATE TABLE `keystb` (
  `Keys` varchar(255) NOT NULL,
  PRIMARY KEY (`Keys`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of keystb
-- ----------------------------
INSERT INTO `keystb` VALUES ('attaches');
INSERT INTO `keystb` VALUES ('china');
INSERT INTO `keystb` VALUES ('chinese');
INSERT INTO `keystb` VALUES ('cooperative');
INSERT INTO `keystb` VALUES ('donald');
INSERT INTO `keystb` VALUES ('first');
INSERT INTO `keystb` VALUES ('great');
INSERT INTO `keystb` VALUES ('green');
INSERT INTO `keystb` VALUES ('his');
INSERT INTO `keystb` VALUES ('importance');
INSERT INTO `keystb` VALUES ('in');
INSERT INTO `keystb` VALUES ('inauguration');
INSERT INTO `keystb` VALUES ('kiba');
INSERT INTO `keystb` VALUES ('last');
INSERT INTO `keystb` VALUES ('meeting');
INSERT INTO `keystb` VALUES ('monday');
INSERT INTO `keystb` VALUES ('month');
INSERT INTO `keystb` VALUES ('official');
INSERT INTO `keystb` VALUES ('on');
INSERT INTO `keystb` VALUES ('president');
INSERT INTO `keystb` VALUES ('red');
INSERT INTO `keystb` VALUES ('relations');
INSERT INTO `keystb` VALUES ('said');
INSERT INTO `keystb` VALUES ('senior');
INSERT INTO `keystb` VALUES ('since');
INSERT INTO `keystb` VALUES ('states');
INSERT INTO `keystb` VALUES ('stop');
INSERT INTO `keystb` VALUES ('the');
INSERT INTO `keystb` VALUES ('to');
INSERT INTO `keystb` VALUES ('trump');
INSERT INTO `keystb` VALUES ('united');
INSERT INTO `keystb` VALUES ('us');
INSERT INTO `keystb` VALUES ('with');

-- ----------------------------
-- Table structure for rd1232134keystb
-- ----------------------------
DROP TABLE IF EXISTS `rd1232134keystb`;
CREATE TABLE `rd1232134keystb` (
  `Keys` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of rd1232134keystb
-- ----------------------------

-- ----------------------------
-- Table structure for userstb
-- ----------------------------
DROP TABLE IF EXISTS `userstb`;
CREATE TABLE `userstb` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `KeystbName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userstb
-- ----------------------------
INSERT INTO `userstb` VALUES ('1', 'rd', '123456', 'keystb');
INSERT INTO `userstb` VALUES ('26', 'rd1232134', '123456', 'rd1232134keystb');
INSERT INTO `userstb` VALUES ('27', 'fe', '123456', 'fekeystb');

-- ----------------------------
-- Table structure for visitorstb
-- ----------------------------
DROP TABLE IF EXISTS `visitorstb`;
CREATE TABLE `visitorstb` (
  `UserName` varchar(255) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Content` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of visitorstb
-- ----------------------------
INSERT INTO `visitorstb` VALUES ('rd', '2017-04-18 23:11:13', 'rd 是个好人');
INSERT INTO `visitorstb` VALUES ('rd', '2017-04-18 23:14:02', '');
INSERT INTO `visitorstb` VALUES ('rd', '2017-04-18 23:14:06', '');
INSERT INTO `visitorstb` VALUES ('rd', '2017-04-18 23:22:41', '好辛苦啊~');
INSERT INTO `visitorstb` VALUES ('rd', '2017-04-18 23:45:38', 'tionghaode\r\n');
