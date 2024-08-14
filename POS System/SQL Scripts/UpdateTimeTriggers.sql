use POS_System
GO
		
CREATE TRIGGER trg_UpdateTimeSupermarket
ON Supermarket
AFTER UPDATE
AS
BEGIN

	Update SuperMarket
	SET UpdatedAt = GETDATE()
	Where SupermarketId IN (SELECT SupermarketId From inserted)

END;
GO
		--------------------------------------------------------------------------------------------------------------------------
CREATE TRIGGER trg_UpdateTimeEmployee
ON Employee
AFTER UPDATE
AS
BEGIN

	Update Employee
	SET UpdatedAt = GETDATE()
	Where EmployeeId IN (SELECT EmployeeId From inserted)

END;
GO
		--------------------------------------------------------------------------------------------------------------------------
CREATE TRIGGER trg_UpdateTimeStock
ON Stock
AFTER UPDATE
AS
BEGIN

	Update Stock
	SET UpdatedAt = GETDATE()
	Where StockId IN (SELECT StockId From inserted)

END;
GO
		--------------------------------------------------------------------------------------------------------------------------

