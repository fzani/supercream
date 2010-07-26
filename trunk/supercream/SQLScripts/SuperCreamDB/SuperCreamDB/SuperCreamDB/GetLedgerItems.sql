use SuperCreamDB;

declare @StartDeliveryDate DateTime,
		@EndDeliveryDate DateTime;
		
set @StartDeliveryDate = '12/12/2008'
set @EndDeliveryDate = '12/12/2011';

with Vat(OrderDeliveryDate, VatAmount)
as
(
	select DeliveryDate, Round(Sum(NoOfUnits * UnitPrice) * (v.PercentageValue / 100),2) from orderheader oh
	inner join orderline ol on
		oh.ID = ol.orderid
	inner join Product p on
		ol.ProductID = p.ID
	inner join VatCode v on 
		oh.VatCodeID = v.ID
	where p.VatExempt = 0
	and oh.DeliveryDate >= @StartDeliveryDate and oh.DeliveryDate <= @EndDeliveryDate
	group by oh.DeliveryDate, v.PercentageValue
),
VatableAmount(OrderDeliveryDate, VatableAmount)
as
(
	select DeliveryDate, Round(Sum(NoOfUnits * UnitPrice),2) from orderheader oh
	inner join orderline ol on
		oh.ID = ol.orderid
	inner join Product p on
		ol.ProductID = p.ID
	inner join VatCode v on 
		oh.VatCodeID = v.ID
	where p.VatExempt = 0
	and oh.DeliveryDate >= @StartDeliveryDate and oh.DeliveryDate <= @EndDeliveryDate
	group by oh.DeliveryDate, v.PercentageValue
),
NonVatableAmount(OrderDeliveryDate, NonVatableAmount)
as
(
	select DeliveryDate, Round(Sum(NoOfUnits * UnitPrice),2) from orderheader oh
	inner join orderline ol on
		oh.ID = ol.orderid
	inner join Product p on
		ol.ProductID = p.ID
	inner join VatCode v on 
		oh.VatCodeID = v.ID
	where p.VatExempt = 1
	and oh.DeliveryDate >= @StartDeliveryDate and oh.DeliveryDate <= @EndDeliveryDate
	group by oh.DeliveryDate, v.PercentageValue
)
select vat.OrderDeliveryDate, vat.VatAmount Vat, 
		isnull(NonVatableAmount, 0) as NonVatableAmount, 
		isnull(va.VatableAmount, 0) VatableAmount,
		Round(isnull(vat.VatAmount,0) + isnull(NonVatableAmount, 0) + isnull(va.VatableAmount, 0),2) Total 
	from Vat vat
	left join NonVatableAmount nvv on
		vat.OrderDeliveryDate = nvv.OrderDeliveryDate
	left join VatableAmount va on
		vat.OrderDeliveryDate = va.OrderDeliveryDate	
order by vat.OrderDeliveryDate