update OrderLine
	set RRPPerItem = p.RRPPerItem
from OrderLine ol inner join Product p
on ol.ProductID = p.ID
--where ol.ID in
--(
--	select ol.ID from OrderLine ol
--	inner join Product p on
--		p.ID = ol.ProductID
--	);


  select * from OrderLine





--update OrderLine as ol
--inner join Product as p on
--	ol.ProductId = p.Id	
--set RRPPerItem = RPPerItem
----where ID in
----(
----	select ol.ID from OrderLine ol
----	inner join Product p on
----		p.ID = ol.ProductID
----	);
	
	
