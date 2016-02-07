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

namespace Proyecto_AirBnb.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BaseAirBnb")]
	public partial class MiDataBaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertAnuncio(Anuncio instance);
    partial void UpdateAnuncio(Anuncio instance);
    partial void DeleteAnuncio(Anuncio instance);
    #endregion
		
		public MiDataBaseDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BaseAirBnbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MiDataBaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiDataBaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiDataBaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiDataBaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Mensaje> Mensajes
		{
			get
			{
				return this.GetTable<Mensaje>();
			}
		}
		
		public System.Data.Linq.Table<Reserva> Reservas
		{
			get
			{
				return this.GetTable<Reserva>();
			}
		}
		
		public System.Data.Linq.Table<Anuncio> Anuncios
		{
			get
			{
				return this.GetTable<Anuncio>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuarios")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id;
		
		private string _Nombre;
		
		private string _Apellido;
		
		private string _Correo;
		
		private System.Nullable<System.DateTime> _Nacimiento;
		
		private System.Nullable<bool> _Anfitrion;
		
		private string _Hash;
		
		private string _Foto;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(string value);
    partial void OnIdChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnApellidoChanging(string value);
    partial void OnApellidoChanged();
    partial void OnCorreoChanging(string value);
    partial void OnCorreoChanged();
    partial void OnNacimientoChanging(System.Nullable<System.DateTime> value);
    partial void OnNacimientoChanged();
    partial void OnAnfitrionChanging(System.Nullable<bool> value);
    partial void OnAnfitrionChanged();
    partial void OnHashChanging(string value);
    partial void OnHashChanged();
    partial void OnFotoChanging(string value);
    partial void OnFotoChanged();
    #endregion
		
		public Usuario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(50)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Apellido", DbType="NVarChar(50)")]
		public string Apellido
		{
			get
			{
				return this._Apellido;
			}
			set
			{
				if ((this._Apellido != value))
				{
					this.OnApellidoChanging(value);
					this.SendPropertyChanging();
					this._Apellido = value;
					this.SendPropertyChanged("Apellido");
					this.OnApellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Correo", DbType="NVarChar(MAX)")]
		public string Correo
		{
			get
			{
				return this._Correo;
			}
			set
			{
				if ((this._Correo != value))
				{
					this.OnCorreoChanging(value);
					this.SendPropertyChanging();
					this._Correo = value;
					this.SendPropertyChanged("Correo");
					this.OnCorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nacimiento", DbType="Date")]
		public System.Nullable<System.DateTime> Nacimiento
		{
			get
			{
				return this._Nacimiento;
			}
			set
			{
				if ((this._Nacimiento != value))
				{
					this.OnNacimientoChanging(value);
					this.SendPropertyChanging();
					this._Nacimiento = value;
					this.SendPropertyChanged("Nacimiento");
					this.OnNacimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Anfitrion", DbType="Bit")]
		public System.Nullable<bool> Anfitrion
		{
			get
			{
				return this._Anfitrion;
			}
			set
			{
				if ((this._Anfitrion != value))
				{
					this.OnAnfitrionChanging(value);
					this.SendPropertyChanging();
					this._Anfitrion = value;
					this.SendPropertyChanged("Anfitrion");
					this.OnAnfitrionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hash", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Hash
		{
			get
			{
				return this._Hash;
			}
			set
			{
				if ((this._Hash != value))
				{
					this.OnHashChanging(value);
					this.SendPropertyChanging();
					this._Hash = value;
					this.SendPropertyChanged("Hash");
					this.OnHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Foto", DbType="NVarChar(50)")]
		public string Foto
		{
			get
			{
				return this._Foto;
			}
			set
			{
				if ((this._Foto != value))
				{
					this.OnFotoChanging(value);
					this.SendPropertyChanging();
					this._Foto = value;
					this.SendPropertyChanged("Foto");
					this.OnFotoChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Mensajes")]
	public partial class Mensaje
	{
		
		private string _Id_Destinatario;
		
		private string _Id_Remitente;
		
		private string _Mensaje1;
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public Mensaje()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Destinatario", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Id_Destinatario
		{
			get
			{
				return this._Id_Destinatario;
			}
			set
			{
				if ((this._Id_Destinatario != value))
				{
					this._Id_Destinatario = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Remitente", DbType="NVarChar(50)")]
		public string Id_Remitente
		{
			get
			{
				return this._Id_Remitente;
			}
			set
			{
				if ((this._Id_Remitente != value))
				{
					this._Id_Remitente = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Mensaje", Storage="_Mensaje1", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Mensaje1
		{
			get
			{
				return this._Mensaje1;
			}
			set
			{
				if ((this._Mensaje1 != value))
				{
					this._Mensaje1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reservas")]
	public partial class Reserva
	{
		
		private string _Id_Huesped;
		
		private System.Nullable<int> _Id_Anuncio;
		
		public Reserva()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Huesped", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Id_Huesped
		{
			get
			{
				return this._Id_Huesped;
			}
			set
			{
				if ((this._Id_Huesped != value))
				{
					this._Id_Huesped = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Anuncio", DbType="Int")]
		public System.Nullable<int> Id_Anuncio
		{
			get
			{
				return this._Id_Anuncio;
			}
			set
			{
				if ((this._Id_Anuncio != value))
				{
					this._Id_Anuncio = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Anuncios")]
	public partial class Anuncio : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id_Anfitrion;
		
		private string _Titulo;
		
		private string _Descripcion;
		
		private string _Alojamiento;
		
		private string _Habitacion;
		
		private System.Nullable<int> _Capacidad;
		
		private string _Pais;
		
		private string _Localidad;
		
		private System.Nullable<int> _Precio;
		
		private string _Foto;
		
		private int _Id_Anuncio;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_AnfitrionChanging(string value);
    partial void OnId_AnfitrionChanged();
    partial void OnTituloChanging(string value);
    partial void OnTituloChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    partial void OnAlojamientoChanging(string value);
    partial void OnAlojamientoChanged();
    partial void OnHabitacionChanging(string value);
    partial void OnHabitacionChanged();
    partial void OnCapacidadChanging(System.Nullable<int> value);
    partial void OnCapacidadChanged();
    partial void OnPaisChanging(string value);
    partial void OnPaisChanged();
    partial void OnLocalidadChanging(string value);
    partial void OnLocalidadChanged();
    partial void OnPrecioChanging(System.Nullable<int> value);
    partial void OnPrecioChanged();
    partial void OnFotoChanging(string value);
    partial void OnFotoChanged();
    partial void OnId_AnuncioChanging(int value);
    partial void OnId_AnuncioChanged();
    #endregion
		
		public Anuncio()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Anfitrion", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Id_Anfitrion
		{
			get
			{
				return this._Id_Anfitrion;
			}
			set
			{
				if ((this._Id_Anfitrion != value))
				{
					this.OnId_AnfitrionChanging(value);
					this.SendPropertyChanging();
					this._Id_Anfitrion = value;
					this.SendPropertyChanged("Id_Anfitrion");
					this.OnId_AnfitrionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Titulo", DbType="NVarChar(MAX)")]
		public string Titulo
		{
			get
			{
				return this._Titulo;
			}
			set
			{
				if ((this._Titulo != value))
				{
					this.OnTituloChanging(value);
					this.SendPropertyChanging();
					this._Titulo = value;
					this.SendPropertyChanged("Titulo");
					this.OnTituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Alojamiento", DbType="NVarChar(50)")]
		public string Alojamiento
		{
			get
			{
				return this._Alojamiento;
			}
			set
			{
				if ((this._Alojamiento != value))
				{
					this.OnAlojamientoChanging(value);
					this.SendPropertyChanging();
					this._Alojamiento = value;
					this.SendPropertyChanged("Alojamiento");
					this.OnAlojamientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Habitacion", DbType="NVarChar(50)")]
		public string Habitacion
		{
			get
			{
				return this._Habitacion;
			}
			set
			{
				if ((this._Habitacion != value))
				{
					this.OnHabitacionChanging(value);
					this.SendPropertyChanging();
					this._Habitacion = value;
					this.SendPropertyChanged("Habitacion");
					this.OnHabitacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Capacidad", DbType="Int")]
		public System.Nullable<int> Capacidad
		{
			get
			{
				return this._Capacidad;
			}
			set
			{
				if ((this._Capacidad != value))
				{
					this.OnCapacidadChanging(value);
					this.SendPropertyChanging();
					this._Capacidad = value;
					this.SendPropertyChanged("Capacidad");
					this.OnCapacidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pais", DbType="NVarChar(50)")]
		public string Pais
		{
			get
			{
				return this._Pais;
			}
			set
			{
				if ((this._Pais != value))
				{
					this.OnPaisChanging(value);
					this.SendPropertyChanging();
					this._Pais = value;
					this.SendPropertyChanged("Pais");
					this.OnPaisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Localidad", DbType="NVarChar(50)")]
		public string Localidad
		{
			get
			{
				return this._Localidad;
			}
			set
			{
				if ((this._Localidad != value))
				{
					this.OnLocalidadChanging(value);
					this.SendPropertyChanging();
					this._Localidad = value;
					this.SendPropertyChanged("Localidad");
					this.OnLocalidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Precio", DbType="Int")]
		public System.Nullable<int> Precio
		{
			get
			{
				return this._Precio;
			}
			set
			{
				if ((this._Precio != value))
				{
					this.OnPrecioChanging(value);
					this.SendPropertyChanging();
					this._Precio = value;
					this.SendPropertyChanged("Precio");
					this.OnPrecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Foto", DbType="NVarChar(50)")]
		public string Foto
		{
			get
			{
				return this._Foto;
			}
			set
			{
				if ((this._Foto != value))
				{
					this.OnFotoChanging(value);
					this.SendPropertyChanging();
					this._Foto = value;
					this.SendPropertyChanged("Foto");
					this.OnFotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Anuncio", DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id_Anuncio
		{
			get
			{
				return this._Id_Anuncio;
			}
			set
			{
				if ((this._Id_Anuncio != value))
				{
					this.OnId_AnuncioChanging(value);
					this.SendPropertyChanging();
					this._Id_Anuncio = value;
					this.SendPropertyChanged("Id_Anuncio");
					this.OnId_AnuncioChanged();
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
