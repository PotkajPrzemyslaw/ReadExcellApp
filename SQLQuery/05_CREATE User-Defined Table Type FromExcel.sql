-- ================================
-- Create User-defined Table Type
-- ================================
USE DacpolDB
GO

-- Create the data type
CREATE TYPE dbo.FromExcel AS TABLE 
(
	part_number VARCHAR(60) NOT NULL,
	threshold DECIMAL(10, 3) NOT NULL,
	price_net DECIMAL(10, 3) NOT NULL
)
GO
