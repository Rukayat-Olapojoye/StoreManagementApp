-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

-- Stored procedures for inserting a new user.
CREATE PROCEDURE INSERTINTOCUSTOMERS
    -- Add the parameters for the stored procedure here

    @customerID VARCHAR(100),
    @customerFirstName VARCHAR(100),
    @customerLastName VARCHAR(100),
    @customerEmail VARCHAR(100),
    @customerPassword VARCHAR(50),
    @confirmPassword VARCHAR(50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.

    -- Insert statements for procedure here
    INSERT INTO Customer
    VALUES(@customerID, @customerFirstName, @customerLastName, @customerEmail, @customerPassword, @confirmPassword)
END
GO

-- Stored procedures for checking for registered.

CREATE PROCEDURE GETREGISTEREDCUSTOMER
    --Add the parameters
    --for the stored procedure here

    @customerEmail VARCHAR(100),
    @customerPassword VARCHAR(50)

AS
BEGIN
    SELECT *
    FROM Customer
    WHERE CustomerEmail = @customerEmail
        AND CustomerPassword = @customerPassword

END
GO

-- Stored procedures for inserting a new store.

CREATE PROCEDURE INSERTINTOSTORE
    -- Add the parameters for the stored procedure here

    @customerId VARCHAR(100),
    @storeID VARCHAR(100),
    @storeName VARCHAR(100),
    @storeType VARCHAR(100),
    @products VARCHAR(50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.

    -- Insert statements for procedure here
    INSERT INTO Store
    VALUES(@customerID, @storeID, @storeName, @storeType, @products)
END
GO

-- Stored procedures for updating store products.
CREATE PROCEDURE UPDATESTOREPRODUCTS
    -- Add the parameters for the stored procedure here

    @customerID VARCHAR(100),
    @storeID VARCHAR (100),
    @products VARCHAR (50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.

    -- Insert statements for procedure here
    UPDATE
    Store 
    SET Products = @products
    where StoreID = @storeID
        AND CustomerId = @customerID
END
GO

-- Stored procedures to get the numbers of product.

CREATE PROCEDURE GETNUMBEROFPRODUCTS
    --Add the parameters
    --for the stored procedure here

    @storeID VARCHAR (100)

AS
BEGIN
    SELECT Products
    FROM Store
    WHERE StoreID = @storeID

END
GO

-- Stored procedures to delete a store.

CREATE PROCEDURE DELETESTORE
    --Add the parameters
    --for the stored procedure here

    @storeID VARCHAR (100)

AS
BEGIN
    DELETE
    FROM Store
    WHERE StoreID = @storeID

END
GO

-- Stored procedures to get the stores for each customers.

CREATE PROCEDURE GETCUSTOMERSTORES
    --Add the parameters
    --for the stored procedure here

    @customerId VARCHAR (100)

AS
BEGIN
    SELECT *
    FROM Store
    WHERE CustomerId = @customerId

END
GO
