CREATE DATABASE [5592];
use [5592];

CREATE TABLE Books
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    Description VARCHAR(500),
    Price DECIMAL(18,2) NOT NULL,
    Imageurl VARCHAR(500)
);

-- Insert data into the Books table
INSERT INTO Books (Title, Author, Price, Imageurl)
VALUES
       ('Reclaim Your Heart', 'Yasmin Mogahed', 1499.9, '/image/reclaim'),
       ('Rich Dad, Poor Dad', 'Robert Kiyosaki', 1999.9,'/image/richdad'),
       ('The Psychology of Money', 'Morgan Housel', 499.99, '/image/money'),
       ('As You Like it', 'William Shakespeare', 1199.9, '/image/youlikeit');


-- SELECT Command to view the inserted data
SELECT * FROM Books;


--Get Books
CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SELECT * FROM Books
END
GO

EXEC GetAllBooks

-- Get Books by Id
CREATE PROCEDURE GetBookById
    @Id INT 
AS
BEGIN
	SELECT * FROM Books WHERE Id = @Id
END
GO

EXEC GetBookById 1


-- Get Book by author
CREATE PROCEDURE GetBookByAuthor
	@Author VARCHAR(100)
AS
BEGIN
	SELECT * FROM Books WHERE Author = @Author;
END
GO

EXEC GetBookByAuthor 'Morgan Housel'

--Insert Books 
CREATE PROCEDURE AddBook
    @Title VARCHAR(100),
    @Author VARCHAR(100),
    @Description VARCHAR(500),
    @Price DECIMAL(18, 2),
    @Imageurl VARCHAR(500)
AS
BEGIN
    INSERT INTO Books (Title, Author, Description, Price, Imageurl)
    VALUES (@Title, @Author, @Description, @Price, @Imageurl)
END
GO

EXEC AddBook 'Five Truths', 'Morgan Housel', '', 1050.55, '/image/truths'


--Update Book
CREATE PROCEDURE UpdateBook
    @Id INT,
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Description NVARCHAR(500),
    @Price DECIMAL(18, 2),
    @Imageurl NVARCHAR(500)
AS
BEGIN
    UPDATE Books
    SET Title = @Title,
		Author = @Author,
        Description = @Description,
        Price = @Price,
        Imageurl = @Imageurl
    WHERE Id = @Id
END
GO

--Delete Book
CREATE PROCEDURE DeleteBook
    @Id INT
AS
BEGIN
    DELETE FROM Books WHERE Id = @Id
END
GO

EXEC DeleteBook 4