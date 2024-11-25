-- Tabel Gender
CREATE TABLE Gender (
    ID CHAR(1) NOT NULL,
    Description VARCHAR(100) NOT NULL,
    PRIMARY KEY (ID)
);

INSERT INTO Gender (ID, Description)
VALUES
    ('L', 'Laki-laki'),
    ('P', 'Perempuan');

-- Tabel Dosen
CREATE TABLE Dosen (
    DosenID CHAR(10) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    NIP VARCHAR(20) NOT NULL,
    Telephone VARCHAR(20) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Address VARCHAR(300) NOT NULL,
    Active BIT NOT NULL,
    PRIMARY KEY (DosenID)
);

INSERT INTO Dosen (DosenID, Name, NIP, Telephone, Gender, Address, Active)
VALUES 
    ('x', 'x', 'x', 'x', 'L', 'x', 1);

-- Tabel Matkul
CREATE TABLE Matkul (
    ID INT PRIMARY KEY NOT NULL,
    KodeMataKuliah VARCHAR(10) NOT NULL,
    NamaMataKuliah VARCHAR(50) NOT NULL,
    DosenPengampu VARCHAR(100) NOT NULL
);

INSERT INTO Matkul (ID, KodeMataKuliah, NamaMataKuliah, DosenPengampu)
VALUES
    (1, 'x', 'x', 'x');

-- Tabel Employee
CREATE TABLE Employee (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    NIP VARCHAR(20) NOT NULL,
    Telephone VARCHAR(15) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Address VARCHAR(100) NOT NULL,
    Birthdate DATE DEFAULT '1900-01-01'
);

INSERT INTO Employee (Name, NIP, Telephone, Gender, Address, Birthdate)
VALUES 
    -- Tambahkan data sesuai kebutuhan
    ('x', 'x', 'x', 'P', 'x', 'x');

-- Tabel Fakultas
CREATE TABLE Fakultas (
    Fakultas_Code CHAR(10) NOT NULL,
    Fakultas_Name CHAR(50) NOT NULL,
    Dekan_Fakultas CHAR(10) NOT NULL,
    Wakil_Dekan CHAR(10) NOT NULL,
    PRIMARY KEY (Fakultas_Code)
);

INSERT INTO Fakultas (Fakultas_Code, Fakultas_Name, Dekan_Fakultas, Wakil_Dekan)
VALUES 
    ('x', 'x', 'x', 'x');

-- Tabel Department
CREATE TABLE Department (
    Department_Code CHAR(10) NOT NULL,
    Department_Name CHAR(50) NOT NULL,
    Ketua_Department CHAR(10) NOT NULL,
    Start_Year CHAR(4) NOT NULL,
    IsActive BIT NOT NULL,
    Fakultas_Code CHAR(10) NOT NULL,
    Jenjang CHAR(2) NOT NULL,
    PRIMARY KEY (Department_Code)
);

INSERT INTO Department (Department_Code, Department_Name, Ketua_Department, Start_Year, IsActive, Fakultas_Code, Jenjang)
VALUES 
    ('x', 'x', 'D001', 'x', 1, 'x', 'x');

-- Tabel tblMahasiswa
CREATE TABLE tblMahasiswa (
    ID INT IDENTITY(1,1) NOT NULL,
    NIM VARCHAR(14) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Telephone CHAR(15) NOT NULL,
    Address VARCHAR(300) NOT NULL,
    Join_Date DATETIME NOT NULL,
    Graduation_Date DATE NULL,
    Dosen_Wali CHAR(10) NULL,
    Fakultas_Code CHAR(10) NOT NULL,
    Department_Code CHAR(10) NOT NULL,
    PRIMARY KEY (ID, NIM),
    FOREIGN KEY (Gender) REFERENCES Gender(ID),
    FOREIGN KEY (Dosen_Wali) REFERENCES Dosen(DosenID) ON DELETE SET NULL,
    FOREIGN KEY (Department_Code) REFERENCES Department(Department_Code),
    FOREIGN KEY (Fakultas_Code) REFERENCES Fakultas(Fakultas_Code)
);

INSERT INTO tblMahasiswa (NIM, Name, Gender, Telephone, Address, Join_Date, Graduation_Date, Dosen_Wali, Fakultas_Code, Department_Code)
VALUES 
    ('x', 'x', 'L', 'x', 'x', 'x', NULL, 'x', 'x', 'x');



SELECT * FROM Department
SELECT * FROM Dosen
SELECT * FROM Employee
SELECT * FROM Fakultas
SELECT * FROM Gender
SELECT * FROM Matkul
SELECT * FROM tblMahasiswa

DROP TABLE Employee
DROP TABLE Matkul
DROP TABLE Department
DROP TABLE Dosen
DROP TABLE Fakultas
DROP TABLE Gender
DROP TABLE tblMahasiswa
