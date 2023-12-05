drop table Products
Create table Products
(
ProductID int primary key identity,
ProductName varchar(50),
Size char(3),
price decimal,
MfgDate date,
Category varchar(50)
)
insert into products values('Shirt','X',500,'12/10/2023','Standard'),
('Pant','32',1500,'12/1/2023','Premium'),
('T-Shirt','M',400,'11/11/2023','Economy')

select * from Products

alter PROCEDURE SearchProducts
    @ProductName VARCHAR(255) = NULL,
    @Size char(3) = NULL,
    @Price DECIMAL(10,2) = NULL,
    @MfgDate DATE = NULL,
    @Category VARCHAR(50) = NULL
AS
BEGIN
    SELECT *
    FROM Products
    WHERE
        (ProductName LIKE '%' + ISNULL(@ProductName, '') + '%')
        AND (Size = ISNULL(@Size, Size))
        AND (Price = ISNULL(@Price, Price))
        AND (MfgDate = ISNULL(@MfgDate, MfgDate))
        AND (Category LIKE '%' + ISNULL(@Category, '') + '%');
END
exec SearchProducts 'Shirt','X',500,'2023-12-10','standard'

alter PROCEDURE SearchProductsWithOR
    @ProductName VARCHAR(255) = NULL,
    @Size char(3) = NULL,
    @Price DECIMAL(10,2) = NULL,
    @MfgDate DATE = NULL,
    @Category VARCHAR(50) = NULL
AS
BEGIN
    SELECT *
    FROM Products
    WHERE
        (ProductName LIKE '%' + @ProductName + '%')
        or (Size = @Size)
        or (Price =@Price)
        or (MfgDate = @MfgDate)
        or (Category LIKE '%' + @Category+ '%');
END

exec SearchProductsWithOR @productname = 'Pant', @size ='M'
