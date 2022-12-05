/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[Price_List_InsertFromExcel]
	@Table FromExcel READONLY
	AS

	Delete from price_list

	CREATE table table_all (part_number varchar(60), threshold decimal (10,3), price_net decimal (10,3), id int)

	insert into table_all(part_number, threshold, price_net)
	select part_number, threshold, price_net
	from @Table

	merge table_all as target
	using part as source
	on source.part_number = target.part_number
	when matched then update set target.id = source.id;
	
	INSERT INTO 
		[dbo].[price_list]
        ([part_id]
        ,[threshold]
        ,[price_net])
     select
           id,
           threshold,
           price_net
		   from table_all

	drop table table_all
GO






