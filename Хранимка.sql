USE [Store]
GO

/****** Object:  StoredProcedure [dbo].[up_sel_OrderDelails]    Script Date: 17.05.24 23:57:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_sel_OrderDelails]
@NumberOrder INT
AS
SELECT p.Name AS Product, lo.Amount AS Amount, lo.DisplayPrice AS DisplayPrice,
	lo.ShippingPrice AS ShippingPrice,
        CASE WHEN DisplayPrice>=ShippingPrice
	     THEN ROUND(100.0-(lo.ShippingPrice*100.0/lo.DisplayPrice), 2)
        ELSE -ROUND(100.0-(lo.ShippingPrice*100.0/lo.DisplayPrice), 2) END AS Discount,
ROUND(Amount * DisplayPrice, 2) AS DisplayCaseAmount,
ROUND(Amount * ShippingPrice, 2) AS [AmountBasedOnShippingPrice],
u.UserName AS UserName, u.FirstName + ' ' + u.LastName AS UserFullName,
o.DateTimeCreate AS DateOrder, o.PhoneNumber AS Phone
FROM LineOrders lo
INNER JOIN Orders o ON lo.OrderId=o.Id
INNER JOIN AspNetUsers u ON o.UserId=u.Id
INNER JOIN Products p ON lo.ProductId=p.Id
INNER JOIN Groups g ON p.GroupId=g.Id
WHERE o.Id=@NumberOrder
ORDER BY 1
GO


