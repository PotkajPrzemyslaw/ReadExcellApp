CREATE TABLE part (
	id INT NOT NULL IDENTITY(1,1),
	part_number VARCHAR(60) NOT NULL,
	[weight] DECIMAL(10, 3) NOT NULL,
	PRIMARY KEY(id)
)
