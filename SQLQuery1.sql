USE StudentManagementDB;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Grade INT NOT NULL
);
GO

-- Optional: Add some initial test data
INSERT INTO Students (FirstName, LastName, BirthDate, Grade) VALUES
('Alice', 'Smith', '2005-03-15', 10),
('Bob', 'Johnson', '2006-07-22', 9),
('Charlie', 'Williams', '2005-11-01', 10),
('David', 'Brown', '2007-01-10', 8),
('Eve', 'Davis', '2006-05-30', 9),
('Frank', 'Miller', '2005-09-12', 10),
('Grace', 'Wilson', '2007-02-28', 8);
GO
