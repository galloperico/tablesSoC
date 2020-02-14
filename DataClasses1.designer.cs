﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tablesSoC
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="displayGraphics")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertIcons2(Icons2 instance);
    partial void UpdateIcons2(Icons2 instance);
    partial void DeleteIcons2(Icons2 instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::tablesSoC.Properties.Settings.Default.displayGraphicsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Icons2> Icons2s
		{
			get
			{
				return this.GetTable<Icons2>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Icons2")]
	public partial class Icons2 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Not_Ready_to_Drive_Mode;
		
		private string _State_of_Charge_Icon;
		
		private string _State_of_Charge_Gauge_Fill_Color;
		
		private string _Ambient_theme;
		
		private string _Highway_Assist_Active;
		
		private string _Screenshot;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNot_Ready_to_Drive_ModeChanging(string value);
    partial void OnNot_Ready_to_Drive_ModeChanged();
    partial void OnState_of_Charge_IconChanging(string value);
    partial void OnState_of_Charge_IconChanged();
    partial void OnState_of_Charge_Gauge_Fill_ColorChanging(string value);
    partial void OnState_of_Charge_Gauge_Fill_ColorChanged();
    partial void OnAmbient_themeChanging(string value);
    partial void OnAmbient_themeChanged();
    partial void OnHighway_Assist_ActiveChanging(string value);
    partial void OnHighway_Assist_ActiveChanged();
    partial void OnScreenshotChanging(string value);
    partial void OnScreenshotChanged();
    #endregion
		
		public Icons2()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Not Ready to Drive Mode]", Storage="_Not_Ready_to_Drive_Mode", DbType="NVarChar(50)")]
		public string Not_Ready_to_Drive_Mode
		{
			get
			{
				return this._Not_Ready_to_Drive_Mode;
			}
			set
			{
				if ((this._Not_Ready_to_Drive_Mode != value))
				{
					this.OnNot_Ready_to_Drive_ModeChanging(value);
					this.SendPropertyChanging();
					this._Not_Ready_to_Drive_Mode = value;
					this.SendPropertyChanged("Not_Ready_to_Drive_Mode");
					this.OnNot_Ready_to_Drive_ModeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[State of Charge Icon]", Storage="_State_of_Charge_Icon", DbType="NVarChar(50)")]
		public string State_of_Charge_Icon
		{
			get
			{
				return this._State_of_Charge_Icon;
			}
			set
			{
				if ((this._State_of_Charge_Icon != value))
				{
					this.OnState_of_Charge_IconChanging(value);
					this.SendPropertyChanging();
					this._State_of_Charge_Icon = value;
					this.SendPropertyChanged("State_of_Charge_Icon");
					this.OnState_of_Charge_IconChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[State of Charge Gauge Fill Color]", Storage="_State_of_Charge_Gauge_Fill_Color", DbType="NVarChar(50)")]
		public string State_of_Charge_Gauge_Fill_Color
		{
			get
			{
				return this._State_of_Charge_Gauge_Fill_Color;
			}
			set
			{
				if ((this._State_of_Charge_Gauge_Fill_Color != value))
				{
					this.OnState_of_Charge_Gauge_Fill_ColorChanging(value);
					this.SendPropertyChanging();
					this._State_of_Charge_Gauge_Fill_Color = value;
					this.SendPropertyChanged("State_of_Charge_Gauge_Fill_Color");
					this.OnState_of_Charge_Gauge_Fill_ColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Ambient theme]", Storage="_Ambient_theme", DbType="NVarChar(50)")]
		public string Ambient_theme
		{
			get
			{
				return this._Ambient_theme;
			}
			set
			{
				if ((this._Ambient_theme != value))
				{
					this.OnAmbient_themeChanging(value);
					this.SendPropertyChanging();
					this._Ambient_theme = value;
					this.SendPropertyChanged("Ambient_theme");
					this.OnAmbient_themeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Highway Assist Active]", Storage="_Highway_Assist_Active", DbType="NVarChar(50)")]
		public string Highway_Assist_Active
		{
			get
			{
				return this._Highway_Assist_Active;
			}
			set
			{
				if ((this._Highway_Assist_Active != value))
				{
					this.OnHighway_Assist_ActiveChanging(value);
					this.SendPropertyChanging();
					this._Highway_Assist_Active = value;
					this.SendPropertyChanged("Highway_Assist_Active");
					this.OnHighway_Assist_ActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Screenshot", DbType="NVarChar(50)")]
		public string Screenshot
		{
			get
			{
				return this._Screenshot;
			}
			set
			{
				if ((this._Screenshot != value))
				{
					this.OnScreenshotChanging(value);
					this.SendPropertyChanging();
					this._Screenshot = value;
					this.SendPropertyChanged("Screenshot");
					this.OnScreenshotChanged();
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
