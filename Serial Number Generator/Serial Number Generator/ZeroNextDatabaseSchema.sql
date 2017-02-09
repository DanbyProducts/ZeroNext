CREATE DATABASE Zeronext;

USE ZERONEXT;

CREATE TABLE UserProfiles(
UserId int8 not null auto_increment,
Username varchar(50) not null unique,
UserPassword varchar(25) not null,
LoginTime DateTime not null,
IsActive boolean,
primary key(UserId)
);

use zeronext;

CREATE TABLE SerialNumbers (
serialNumberID int8 not null auto_increment,
SerialNumber int8 not null unique,
ProductCode int4 not null,
ProductCategory varchar(100) not null,
FactoryID int3 not null,
FactoryAppriseCodes varchar(20) not null,
SerialCreationDate date,
CreatedBy int8 not null,
primary key (serialNumberID),
foreign key (CreatedBy) references UserProfiles(UserId)
);


use zeronext;

CREATE table FactoryIDs(
AppriseCodes varchar(50),
Factoryname varchar(50),
Location varchar(50),
FactoryID int4 not null
);



use zeronext;

CREATE TABLE ProductCodes(
ProductCode int4 not null,
ProductCategory varchar(50)
);


use zeronext;

INSERT INTO serialnumbers (serialnumbers.SerialNumber,serialnumbers.ProductCode,serialnumbers.ProductCategory,serialnumbers.FactoryID,serialnumbers.FactoryAppriseCodes,serialnumbers.SerialCreationDate)
values (1234567891234,34,'Freezer Chest',43,'XINGXI','2017/02/08');

use zeronext;

INSERT INTO UserProfiles(userprofiles.Username,userprofiles.UserPassword, userprofiles.LoginTime, userprofiles.IsActive) Values 
('test','admin','2017-02-09 12:55:56',TRUE);

INSERT INTO UserProfiles(userprofiles.Username,userprofiles.UserPassword, userprofiles.LoginTime, userprofiles.IsActive) Values 
('test1','admin','2017-02-09 12:55:56',TRUE);


use zeronext;

INSERT INTO FactoryIDs ()  values
('GALANZ2','Galanz New Plant','Zhongshan','40'), ('HEFEIHL','Hefei Hualing,Jinxiu Ave','Hefei,Juixiu Ave','41'), ('','','','42' ),
('XINGXI','XingXing','Taizhou','43'), ('XINGXIFOS2','XingXing','Foshan','44'),
('MDDOME','Midea AC','Shunde','45'), ('MDDOME2','Mideo Dishawasher','Foshan','46' ),
('MDDOME3','Mideo Microwave','Shunde','47' ), ('MDDOME5','Midea AC','Wuhu','48' ),
('NEWWIDET','New Widetech','Kaiping City','49' ), ('MEILING','Meiling','Hefei','50' ),
('HEIFEIHL','Hefei Hualing, Yulan Ave','Hefei, Yulan Ave','51' ), ('HOMAAPPL','Homa','Zhongshan','52' ),
('MEIHE','Meihe','Dongguan','53' ), ('SHUNXI','Shunxiang','Zhongshan','54' ),
('JINLIN','Jingling','Jiangmen','55' ),('MINEA','Minea','Zhongshan','56' ),
('JINTONG','Jintong','Ningbo','57' ),('EUROASIA','Euroasia','Zhongshan','58' ),
('GALANZ','Galanz Main Location','','59' ),('GREEELEC','Gree','Zhuhai','61' ),
('TCL','TCL','Zhongshan','62' ), ('HOMESU','Shunde Homesun','Shunde','63' ),
('CANDOR','Zhongshan Candor','Zhongshan','64' ), ('YOAO','Youao','Changzhou','65' ),
('LMD01M','Assembly Location','Rancho California','08' ),('MDDOME4','Midea Hualing Refrigerator CO.,LTD','Guangzhou','66' ),
('8000129','Panasonic','San Diego','67' ),('XINBAO','Xinbao','Foshan','68' ),
('QNN','QNN Safe Manufacturing Co LTD','Foshan, Guandong','69' ),('JHS','Dongguan JHS Electrical Co LTD','Dongguan, China','70' ), ('DANBYLTD','Danby Products Ltd','Guelph, Ontario','71' );

use zeronext;

INSERT INTO productcodes() values
('30','Refrigerator - Compact, under 7.75 cu ft'),
('31','Refrigerator - Mid-Size, 7.75 - 12.3 cu ft'),
('32','Refrigerator - Large, greater than 12.3 cu ft'),
('33','Freezer - Chest'),
('34','Freezer Upright' ),
('35','Wine Cooler' ),
('36','Beverage Center and Party Center' ),
('37','Keg Cooler' ),
('38','Ice Maker' ),
('39','Dishwasher - Countertop' ),
('40','Dishwasher - 18\'' ),
('41','Waher - Twin Tub' ),
('42','Washer - Top Landing' ),
('43','Microwaves - 0 to 0.7 cubic ft' ),
('44','Microwaves - 0.71 cubic ft and greater' ),
('45','Air Conditioner - Portable, 1 to 9999 btu' ),
('46','Air Conditioner - Portable, 10000 and 11999' ),
('47','Air Conditioner - Portable, 12000 and greater' ),
('48','Air Conditioner - Room, 1 to 5999 btu' ),
('49','Air Conditioner - Room, 6000 to 9999 btu' ),
('50','Air Conditioner - Room, 10000 btu and greater' ),
('51','Dehumidifier - 1 to 50 pints' ),
('52','Dehumidifier - 51 pints and greater' ),
('53','Assembled Frig/Microwave' ),
('54','Niche' ),
('55','Small Appliances' ),
('56','Pedestal' ),
('57','Safe' );

