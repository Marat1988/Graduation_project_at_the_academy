namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcedure4 : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE up_sel_OrderDelails
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
                 ORDER BY 1");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE up_sel_OrderDelails");
        }
    }
}
