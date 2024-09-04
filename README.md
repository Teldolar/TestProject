# Скрипты для создания базы данных

```sql
CREATE TABLE Sector (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Number NVARCHAR(50)
);
```

```sql
CREATE TABLE Specialisation (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);
```

```sql
CREATE TABLE Cabinet (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Number NVARCHAR(50)
);
```

```sql
CREATE TABLE Patient (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Surname NVARCHAR(100),
    Fisrtname NVARCHAR(100),
    Patronymic NVARCHAR(100),
    Adress NVARCHAR(250),
    Birthday DATE,
    Sex NVARCHAR(10),
    SectorId INT FOREIGN KEY REFERENCES Sector(Id)
);
```

```sql
CREATE TABLE Doctor (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FIO NVARCHAR(250),
    CabinetId INT FOREIGN KEY REFERENCES Cabinet(Id),
    SpecialisationId INT FOREIGN KEY REFERENCES Specialisation(Id),
    SectorId INT FOREIGN KEY REFERENCES Sector(Id)
);
```
