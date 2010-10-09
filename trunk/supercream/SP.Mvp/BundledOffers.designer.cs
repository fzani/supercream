﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SP.Mvp
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="SuperCreamDB")]
	public partial class BundledOffersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertOffer(Offer instance);
    partial void UpdateOffer(Offer instance);
    partial void DeleteOffer(Offer instance);
    partial void InsertOfferItem(OfferItem instance);
    partial void UpdateOfferItem(OfferItem instance);
    partial void DeleteOfferItem(OfferItem instance);
    partial void InsertOfferQualificationItem(OfferQualificationItem instance);
    partial void UpdateOfferQualificationItem(OfferQualificationItem instance);
    partial void DeleteOfferQualificationItem(OfferQualificationItem instance);
    #endregion
		
		public BundledOffersDataContext() : 
				base(global::SP.Mvp.Properties.Settings.Default.SuperCreamDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BundledOffersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BundledOffersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BundledOffersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BundledOffersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Offer> Offers
		{
			get
			{
				return this.GetTable<Offer>();
			}
		}
		
		public System.Data.Linq.Table<OfferItem> OfferItems
		{
			get
			{
				return this.GetTable<OfferItem>();
			}
		}
		
		public System.Data.Linq.Table<OfferQualificationItem> OfferQualificationItems
		{
			get
			{
				return this.GetTable<OfferQualificationItem>();
			}
		}
	}
	
	[Table(Name="dbo.Offer")]
	public partial class Offer : BaseEntity, INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);				
		
		private string _Name;
		
		private System.Nullable<System.DateTime> _ValidFrom;
		
		private System.Nullable<System.DateTime> _ValidTo;
		
		private EntitySet<OfferItem> _OfferItems;
		
		private EntitySet<OfferQualificationItem> _OfferQualificationItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnValidFromChanging(System.Nullable<System.DateTime> value);
    partial void OnValidFromChanged();
    partial void OnValidToChanging(System.Nullable<System.DateTime> value);
    partial void OnValidToChanged();
    #endregion
		
		public Offer()
		{
			this._OfferItems = new EntitySet<OfferItem>(new Action<OfferItem>(this.attach_OfferItems), new Action<OfferItem>(this.detach_OfferItems));
			this._OfferQualificationItems = new EntitySet<OfferQualificationItem>(new Action<OfferQualificationItem>(this.attach_OfferQualificationItems), new Action<OfferQualificationItem>(this.detach_OfferQualificationItems));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return base.ID;
			}
			set
			{
                if ((base.ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
                    base.ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_ValidFrom", DbType="DateTime")]
		public System.Nullable<System.DateTime> ValidFrom
		{
			get
			{
				return this._ValidFrom;
			}
			set
			{
				if ((this._ValidFrom != value))
				{
					this.OnValidFromChanging(value);
					this.SendPropertyChanging();
					this._ValidFrom = value;
					this.SendPropertyChanged("ValidFrom");
					this.OnValidFromChanged();
				}
			}
		}
		
		[Column(Storage="_ValidTo", DbType="DateTime")]
		public System.Nullable<System.DateTime> ValidTo
		{
			get
			{
				return this._ValidTo;
			}
			set
			{
				if ((this._ValidTo != value))
				{
					this.OnValidToChanging(value);
					this.SendPropertyChanging();
					this._ValidTo = value;
					this.SendPropertyChanged("ValidTo");
					this.OnValidToChanged();
				}
			}
		}
		
		[Association(Name="Offer_OfferItem", Storage="_OfferItems", ThisKey="ID", OtherKey="OfferId")]
		public EntitySet<OfferItem> OfferItems
		{
			get
			{
				return this._OfferItems;
			}
			set
			{
				this._OfferItems.Assign(value);
			}
		}
		
		[Association(Name="Offer_OfferQualificationItem", Storage="_OfferQualificationItems", ThisKey="ID", OtherKey="OfferId")]
		public EntitySet<OfferQualificationItem> OfferQualificationItems
		{
			get
			{
				return this._OfferQualificationItems;
			}
			set
			{
				this._OfferQualificationItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_OfferItems(OfferItem entity)
		{
			this.SendPropertyChanging();
			entity.Offer = this;
		}
		
		private void detach_OfferItems(OfferItem entity)
		{
			this.SendPropertyChanging();
			entity.Offer = null;
		}
		
		private void attach_OfferQualificationItems(OfferQualificationItem entity)
		{
			this.SendPropertyChanging();
			entity.Offer = this;
		}
		
		private void detach_OfferQualificationItems(OfferQualificationItem entity)
		{
			this.SendPropertyChanging();
			entity.Offer = null;
		}
	}
	
	[Table(Name="dbo.OfferItem")]
    public partial class OfferItem : BaseEntity, INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);				
		
		private System.Nullable<int> _OfferId;
		
		private System.Nullable<int> _ProductId;
		
		private System.Nullable<int> _VatCodeId;
		
		private System.Nullable<decimal> _UnitPrice;
		
		private System.Nullable<int> _NoOfUnits;
		
		private System.Nullable<decimal> _Discount;
		
		private System.Nullable<bool> _VatExempt;
		
		private EntityRef<Offer> _Offer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnOfferIdChanging(System.Nullable<int> value);
    partial void OnOfferIdChanged();
    partial void OnProductIdChanging(System.Nullable<int> value);
    partial void OnProductIdChanged();
    partial void OnVatCodeIdChanging(System.Nullable<int> value);
    partial void OnVatCodeIdChanged();
    partial void OnUnitPriceChanging(System.Nullable<decimal> value);
    partial void OnUnitPriceChanged();
    partial void OnNoOfUnitsChanging(System.Nullable<int> value);
    partial void OnNoOfUnitsChanged();
    partial void OnDiscountChanging(System.Nullable<decimal> value);
    partial void OnDiscountChanged();
    partial void OnVatExemptChanging(System.Nullable<bool> value);
    partial void OnVatExemptChanged();
    #endregion
		
		public OfferItem()
		{
			this._Offer = default(EntityRef<Offer>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return base.ID;
			}
			set
			{
				if ((base.ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					base.ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_OfferId", DbType="Int")]
		public System.Nullable<int> OfferId
		{
			get
			{
				return this._OfferId;
			}
			set
			{
				if ((this._OfferId != value))
				{
					if (this._Offer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOfferIdChanging(value);
					this.SendPropertyChanging();
					this._OfferId = value;
					this.SendPropertyChanged("OfferId");
					this.OnOfferIdChanged();
				}
			}
		}
		
		[Column(Storage="_ProductId", DbType="Int")]
		public System.Nullable<int> ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				if ((this._ProductId != value))
				{
					this.OnProductIdChanging(value);
					this.SendPropertyChanging();
					this._ProductId = value;
					this.SendPropertyChanged("ProductId");
					this.OnProductIdChanged();
				}
			}
		}
		
		[Column(Storage="_VatCodeId", DbType="Int")]
		public System.Nullable<int> VatCodeId
		{
			get
			{
				return this._VatCodeId;
			}
			set
			{
				if ((this._VatCodeId != value))
				{
					this.OnVatCodeIdChanging(value);
					this.SendPropertyChanging();
					this._VatCodeId = value;
					this.SendPropertyChanged("VatCodeId");
					this.OnVatCodeIdChanged();
				}
			}
		}
		
		[Column(Storage="_UnitPrice", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> UnitPrice
		{
			get
			{
				return this._UnitPrice;
			}
			set
			{
				if ((this._UnitPrice != value))
				{
					this.OnUnitPriceChanging(value);
					this.SendPropertyChanging();
					this._UnitPrice = value;
					this.SendPropertyChanged("UnitPrice");
					this.OnUnitPriceChanged();
				}
			}
		}
		
		[Column(Storage="_NoOfUnits", DbType="Int")]
		public System.Nullable<int> NoOfUnits
		{
			get
			{
				return this._NoOfUnits;
			}
			set
			{
				if ((this._NoOfUnits != value))
				{
					this.OnNoOfUnitsChanging(value);
					this.SendPropertyChanging();
					this._NoOfUnits = value;
					this.SendPropertyChanged("NoOfUnits");
					this.OnNoOfUnitsChanged();
				}
			}
		}
		
		[Column(Storage="_Discount", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> Discount
		{
			get
			{
				return this._Discount;
			}
			set
			{
				if ((this._Discount != value))
				{
					this.OnDiscountChanging(value);
					this.SendPropertyChanging();
					this._Discount = value;
					this.SendPropertyChanged("Discount");
					this.OnDiscountChanged();
				}
			}
		}
		
		[Column(Storage="_VatExempt", DbType="Bit")]
		public System.Nullable<bool> VatExempt
		{
			get
			{
				return this._VatExempt;
			}
			set
			{
				if ((this._VatExempt != value))
				{
					this.OnVatExemptChanging(value);
					this.SendPropertyChanging();
					this._VatExempt = value;
					this.SendPropertyChanged("VatExempt");
					this.OnVatExemptChanged();
				}
			}
		}
		
		[Association(Name="Offer_OfferItem", Storage="_Offer", ThisKey="OfferId", OtherKey="ID", IsForeignKey=true, DeleteRule="CASCADE")]
		public Offer Offer
		{
			get
			{
				return this._Offer.Entity;
			}
			set
			{
				Offer previousValue = this._Offer.Entity;
				if (((previousValue != value) 
							|| (this._Offer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Offer.Entity = null;
						previousValue.OfferItems.Remove(this);
					}
					this._Offer.Entity = value;
					if ((value != null))
					{
						value.OfferItems.Add(this);
						this._OfferId = value.ID;
					}
					else
					{
						this._OfferId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Offer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.OfferQualificationItem")]
	public partial class OfferQualificationItem : BaseEntity, INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);				
		
		private System.Nullable<int> _OfferId;
		
		private System.Nullable<int> _ProductId;
		
		private System.Nullable<int> _Qty;
		
		private EntityRef<Offer> _Offer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnOfferIdChanging(System.Nullable<int> value);
    partial void OnOfferIdChanged();
    partial void OnProductIdChanging(System.Nullable<int> value);
    partial void OnProductIdChanged();
    partial void OnQtyChanging(System.Nullable<int> value);
    partial void OnQtyChanged();
    #endregion
		
		public OfferQualificationItem()
		{
			this._Offer = default(EntityRef<Offer>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return base.ID;
			}
			set
			{
                if ((base.ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
                    base.ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_OfferId", DbType="Int")]
		public System.Nullable<int> OfferId
		{
			get
			{
				return this._OfferId;
			}
			set
			{
				if ((this._OfferId != value))
				{
					if (this._Offer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOfferIdChanging(value);
					this.SendPropertyChanging();
					this._OfferId = value;
					this.SendPropertyChanged("OfferId");
					this.OnOfferIdChanged();
				}
			}
		}
		
		[Column(Storage="_ProductId", DbType="Int")]
		public System.Nullable<int> ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				if ((this._ProductId != value))
				{
					this.OnProductIdChanging(value);
					this.SendPropertyChanging();
					this._ProductId = value;
					this.SendPropertyChanged("ProductId");
					this.OnProductIdChanged();
				}
			}
		}
		
		[Column(Storage="_Qty", DbType="Int")]
		public System.Nullable<int> Qty
		{
			get
			{
				return this._Qty;
			}
			set
			{
				if ((this._Qty != value))
				{
					this.OnQtyChanging(value);
					this.SendPropertyChanging();
					this._Qty = value;
					this.SendPropertyChanged("Qty");
					this.OnQtyChanged();
				}
			}
		}
		
		[Association(Name="Offer_OfferQualificationItem", Storage="_Offer", ThisKey="OfferId", OtherKey="ID", IsForeignKey=true)]
		public Offer Offer
		{
			get
			{
				return this._Offer.Entity;
			}
			set
			{
				Offer previousValue = this._Offer.Entity;
				if (((previousValue != value) 
							|| (this._Offer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Offer.Entity = null;
						previousValue.OfferQualificationItems.Remove(this);
					}
					this._Offer.Entity = value;
					if ((value != null))
					{
						value.OfferQualificationItems.Add(this);
						this._OfferId = value.ID;
					}
					else
					{
						this._OfferId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Offer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
