CREATE TABLE `Employees` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(25) NOT NULL,
    `LastName` varchar(25) NOT NULL,
    `Email` longtext NOT NULL,
    `HourlyPay` decimal(65, 30) NOT NULL,
    CONSTRAINT `PK_Employees` PRIMARY KEY (`Id`)
);

CREATE TABLE `PayPeriods` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Start` datetime(6) NOT NULL,
    `End` datetime(6) NOT NULL,
    CONSTRAINT `PK_PayPeriods` PRIMARY KEY (`Id`)
);

CREATE TABLE `TimeSheets` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Issued` datetime(6) NOT NULL,
    `Submitted` datetime(6) NULL,
    `Approved` datetime(6) NULL,
    `EmployeeId` int NOT NULL,
    `PayPeriodId` int NULL,
    CONSTRAINT `PK_TimeSheets` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TimeSheets_Employees_EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `Employees` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TimeSheets_PayPeriods_PayPeriodId` FOREIGN KEY (`PayPeriodId`) REFERENCES `PayPeriods` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `Activities` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` datetime(6) NOT NULL,
    `Hours` int NOT NULL,
    `Description` longtext NULL,
    `Pay` decimal(65, 30) NOT NULL,
    `TimeSheetId` int NOT NULL,
    CONSTRAINT `PK_Activities` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Activities_TimeSheets_TimeSheetId` FOREIGN KEY (`TimeSheetId`) REFERENCES `TimeSheets` (`Id`) ON DELETE CASCADE
);

INSERT INTO `Employees` (`Id`, `Email`, `FirstName`, `HourlyPay`, `LastName`)
VALUES (1, 'hubert.lin@example.com', 'Hubert', 25.0, 'Lin');
INSERT INTO `Employees` (`Id`, `Email`, `FirstName`, `HourlyPay`, `LastName`)
VALUES (2, 'John.Smith@example.com', 'John', 25.0, 'Smith');
INSERT INTO `Employees` (`Id`, `Email`, `FirstName`, `HourlyPay`, `LastName`)
VALUES (3, 'Luntette.Clowne@example.com', 'Lunette', 25.0, 'Clowne');
INSERT INTO `Employees` (`Id`, `Email`, `FirstName`, `HourlyPay`, `LastName`)
VALUES (4, 'Peter.Parker@example.com', 'Peter', 25.0, 'Parker');

INSERT INTO `PayPeriods` (`Id`, `End`, `Start`)
VALUES (1, '2018-11-01 00:00:00.000000', '2018-11-01 00:00:00.000000');
INSERT INTO `PayPeriods` (`Id`, `End`, `Start`)
VALUES (2, '2018-11-01 00:00:00.000000', '2018-11-01 00:00:00.000000');

INSERT INTO `TimeSheets` (`Id`, `Approved`, `EmployeeId`, `Issued`, `PayPeriodId`, `Submitted`)
VALUES (1, NULL, 1, '2018-11-01 11:03:28.841000', 1, NULL);
INSERT INTO `TimeSheets` (`Id`, `Approved`, `EmployeeId`, `Issued`, `PayPeriodId`, `Submitted`)
VALUES (2, NULL, 2, '2018-11-01 11:03:28.842000', 1, NULL);
INSERT INTO `TimeSheets` (`Id`, `Approved`, `EmployeeId`, `Issued`, `PayPeriodId`, `Submitted`)
VALUES (3, NULL, 3, '2018-11-01 11:03:28.842000', 1, NULL);
INSERT INTO `TimeSheets` (`Id`, `Approved`, `EmployeeId`, `Issued`, `PayPeriodId`, `Submitted`)
VALUES (4, NULL, 4, '2018-11-01 11:03:28.842000', 2, NULL);

INSERT INTO `Activities` (`Id`, `Date`, `Description`, `Hours`, `Pay`, `TimeSheetId`)
VALUES (1, '2018-11-01 00:00:00.000000', 'Teaching Dance', 1, 25.0, 1);

INSERT INTO `Activities` (`Id`, `Date`, `Description`, `Hours`, `Pay`, `TimeSheetId`)
VALUES (2, '2018-11-01 00:00:00.000000', 'Teaching Kids', 1, 25.0, 1);

CREATE INDEX `IX_Activities_TimeSheetId` ON `Activities` (`TimeSheetId`);

CREATE INDEX `IX_TimeSheets_EmployeeId` ON `TimeSheets` (`EmployeeId`);

CREATE INDEX `IX_TimeSheets_PayPeriodId` ON `TimeSheets` (`PayPeriodId`);