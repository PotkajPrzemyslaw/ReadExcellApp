USE [DacpolDB]
GO

CREATE PROCEDURE [dbo].[Part_GetDataToDGV]

	AS

	SELECT 
		part.part_number,
		part.[weight],
		price_list.threshold,
		price_list.price_net
	FROM part
	INNER JOIN price_list ON part.id = price_list.part_id
GO




