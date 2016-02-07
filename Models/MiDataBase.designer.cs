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
    partial void InsertMensaje(Mensaje instance);
    partial void UpdateMensaje(Mensaje instance);
    partial void DeleteMensaje(Mensaje instance);
    partial void InsertAnuncio(Anuncio instance);
    partial void UpdateAnuncio(Anuncio instance);
    partial void DeleteAnuncio(Anuncio instance);
    partial void InsertReserva(Reserva instance);
    partial void UpdateReserva(Reserva instance);
    partial void DeleteReserva(Reserva instance);
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
		
		public System.Data.Linq.Table<Anuncio> Anuncios
		{
			get
			{
				return this.GetTable<Anuncio>();
			}
		}
		
		public System.Data.Linq.Table<Reserva> Reservas
		{
			get
			{
				return this.GetTable<Reserva>();
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
		
		private EntitySet<Mensaje> _Mensajes;
		
		private EntitySet<Anuncio> _Anuncios;
		
		private EntityRef<Reserva> _Reserva;
		
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
			this._Mensajes = new EntitySet<Mensaje>(new Action<Mensaje>(this.attach_Mensajes), new Action<Mensaje>(this.detach_Mensajes));
			this._Anuncios = new EntitySet<Anuncio>(new Action<Anuncio>(this.attach_Anuncios), new Action<Anuncio>(this.detach_Anuncios));
			this._Reserva = default(EntityRef<Reserva>);
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
					if (this._Reserva.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Mensaje", Storage="_Mensajes", ThisKey="Id", OtherKey="Id_Destinatario")]
		public EntitySet<Mensaje> Mensajes
		{
			get
			{
				return this._Mensajes;
			}
			set
			{
				this._Mensajes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Anuncio", Storage="_Anuncios", ThisKey="Id", OtherKey="Id_Anfitrion")]
		public EntitySet<Anuncio> Anuncios
		{
			get
			{
				return this._Anuncios;
			}
			set
			{
				this._Anuncios.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reserva_Usuario", Storage="_Reserva", ThisKey="Id", OtherKey="Id_Huesped", IsForeignKey=true)]
		public Reserva Reserva
		{
			get
			{
				return this._Reserva.Entity;
			}
			set
			{
				Reserva previousValue = this._Reserva.Entity;
				if (((previousValue != value) 
							|| (this._Reserva.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Reserva.Entity = null;
						previousValue.Usuarios.Remove(this);
					}
					this._Reserva.Entity = value;
					if ((value != null))
					{
						value.Usuarios.Add(this);
						this._Id = value.Id_Huesped;
					}
					else
					{
						this._Id = default(string);
					}
					this.SendPropertyChanged("Reserva");
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
		
		private void attach_Mensajes(Mensaje entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Mensajes(Mensaje entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
		
		private void attach_Anuncios(Anuncio entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Anuncios(Anuncio entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Mensajes")]
	public partial class Mensaje : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id_Destinatario;
		
		private string _Id_Remitente;
		
		private string _Mensaje1;
		
		private System.Nullable<System.DateTime> _Fecha;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_DestinatarioChanging(string value);
    partial void OnId_DestinatarioChanged();
    partial void OnId_RemitenteChanging(string value);
    partial void OnId_RemitenteChanged();
    partial void OnMensaje1Changing(string value);
    partial void OnMensaje1Changed();
    partial void OnFechaChanging(System.Nullable<System.DateTime> value);
    partial void OnFechaChanged();
    #endregion
		
		public Mensaje()
		{
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Destinatario", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_DestinatarioChanging(value);
					this.SendPropertyChanging();
					this._Id_Destinatario = value;
					this.SendPropertyChanged("Id_Destinatario");
					this.OnId_DestinatarioChanged();
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
					this.OnId_RemitenteChanging(value);
					this.SendPropertyChanging();
					this._Id_Remitente = value;
					this.SendPropertyChanged("Id_Remitente");
					this.OnId_RemitenteChanged();
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
					this.OnMensaje1Changing(value);
					this.SendPropertyChanging();
					this._Mensaje1 = value;
					this.SendPropertyChanged("Mensaje1");
					this.OnMensaje1Changed();
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
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Mensaje", Storage="_Usuario", ThisKey="Id_Destinatario", OtherKey="Id", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Mensajes.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Mensajes.Add(this);
						this._Id_Destinatario = value.Id;
					}
					else
					{
						this._Id_Destinatario = default(string);
					}
					this.SendPropertyChanged("Usuario");
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
		
		private System.Nullable<int> _Id_Anuncio;
		
		private EntitySet<Reserva> _Reservas;
		
		private EntityRef<Usuario> _Usuario;
		
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
    partial void OnId_AnuncioChanging(System.Nullable<int> value);
    partial void OnId_AnuncioChanged();
    #endregion
		
		public Anuncio()
		{
			this._Reservas = new EntitySet<Reserva>(new Action<Reserva>(this.attach_Reservas), new Action<Reserva>(this.detach_Reservas));
			this._Usuario = default(EntityRef<Usuario>);
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
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_AnfitrionChanging(value);
					this.SendPropertyChanging();
					this._Id_Anfitrion = value;
					this.SendPropertyChanged("Id_Anfitrion");
					this.OnId_AnfitrionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Titulo", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pais", DbType="NVarChar(20)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Anuncio", DbType="Int", IsPrimaryKey=true, IsDbGenerated=true)]
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
					this.OnId_AnuncioChanging(value);
					this.SendPropertyChanging();
					this._Id_Anuncio = value;
					this.SendPropertyChanged("Id_Anuncio");
					this.OnId_AnuncioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Anuncio_Reserva", Storage="_Reservas", ThisKey="Id_Anuncio", OtherKey="Id_Anuncio")]
		public EntitySet<Reserva> Reservas
		{
			get
			{
				return this._Reservas;
			}
			set
			{
				this._Reservas.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Anuncio", Storage="_Usuario", ThisKey="Id_Anfitrion", OtherKey="Id", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Anuncios.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Anuncios.Add(this);
						this._Id_Anfitrion = value.Id;
					}
					else
					{
						this._Id_Anfitrion = default(string);
					}
					this.SendPropertyChanged("Usuario");
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
		
		private void attach_Reservas(Reserva entity)
		{
			this.SendPropertyChanging();
			entity.Anuncio = this;
		}
		
		private void detach_Reservas(Reserva entity)
		{
			this.SendPropertyChanging();
			entity.Anuncio = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reservas")]
	public partial class Reserva : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id_Huesped;
		
		private System.Nullable<int> _Id_Anuncio;
		
		private EntitySet<Usuario> _Usuarios;
		
		private EntityRef<Anuncio> _Anuncio;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_HuespedChanging(string value);
    partial void OnId_HuespedChanged();
    partial void OnId_AnuncioChanging(System.Nullable<int> value);
    partial void OnId_AnuncioChanged();
    #endregion
		
		public Reserva()
		{
			this._Usuarios = new EntitySet<Usuario>(new Action<Usuario>(this.attach_Usuarios), new Action<Usuario>(this.detach_Usuarios));
			this._Anuncio = default(EntityRef<Anuncio>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Huesped", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
					this.OnId_HuespedChanging(value);
					this.SendPropertyChanging();
					this._Id_Huesped = value;
					this.SendPropertyChanged("Id_Huesped");
					this.OnId_HuespedChanged();
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
					if (this._Anuncio.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_AnuncioChanging(value);
					this.SendPropertyChanging();
					this._Id_Anuncio = value;
					this.SendPropertyChanged("Id_Anuncio");
					this.OnId_AnuncioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reserva_Usuario", Storage="_Usuarios", ThisKey="Id_Huesped", OtherKey="Id")]
		public EntitySet<Usuario> Usuarios
		{
			get
			{
				return this._Usuarios;
			}
			set
			{
				this._Usuarios.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Anuncio_Reserva", Storage="_Anuncio", ThisKey="Id_Anuncio", OtherKey="Id_Anuncio", IsForeignKey=true)]
		public Anuncio Anuncio
		{
			get
			{
				return this._Anuncio.Entity;
			}
			set
			{
				Anuncio previousValue = this._Anuncio.Entity;
				if (((previousValue != value) 
							|| (this._Anuncio.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Anuncio.Entity = null;
						previousValue.Reservas.Remove(this);
					}
					this._Anuncio.Entity = value;
					if ((value != null))
					{
						value.Reservas.Add(this);
						this._Id_Anuncio = value.Id_Anuncio;
					}
					else
					{
						this._Id_Anuncio = default(Nullable<int>);
					}
					this.SendPropertyChanged("Anuncio");
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
		
		private void attach_Usuarios(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.Reserva = this;
		}
		
		private void detach_Usuarios(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.Reserva = null;
		}
	}
}
#pragma warning restore 1591
