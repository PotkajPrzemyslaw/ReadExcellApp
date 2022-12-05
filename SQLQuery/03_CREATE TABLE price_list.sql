CREATE TABLE price_list (
	id INT NOT NULL IDENTITY(1,1),
	part_id INT NOT NULL,
	threshold DECIMAL(10, 3) NOT NULL,
	price_net MONEY NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(part_id) REFERENCES part(id)
)