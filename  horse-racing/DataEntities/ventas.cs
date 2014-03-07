//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace DataEntities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(usuario))]
    public partial class ventas: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private System.Guid _id;
    
        [DataMember]
        public System.Guid Usuario_Id
        {
            get { return _usuario_Id; }
            set
            {
                if (_usuario_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Usuario_Id", _usuario_Id);
                    if (!IsDeserializing)
                    {
                        if (usuario != null && usuario.Id != value)
                        {
                            usuario = null;
                        }
                    }
                    _usuario_Id = value;
                    OnPropertyChanged("Usuario_Id");
                }
            }
        }
        private System.Guid _usuario_Id;
    
        [DataMember]
        public Nullable<decimal> Valor
        {
            get { return _valor; }
            set
            {
                if (_valor != value)
                {
                    _valor = value;
                    OnPropertyChanged("Valor");
                }
            }
        }
        private Nullable<decimal> _valor;
    
        [DataMember]
        public Nullable<System.DateTime> Fecha
        {
            get { return _fecha; }
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    OnPropertyChanged("Fecha");
                }
            }
        }
        private Nullable<System.DateTime> _fecha;
    
        [DataMember]
        public string NumTicket
        {
            get { return _numTicket; }
            set
            {
                if (_numTicket != value)
                {
                    _numTicket = value;
                    OnPropertyChanged("NumTicket");
                }
            }
        }
        private string _numTicket;
    
        [DataMember]
        public Nullable<decimal> ValorCop
        {
            get { return _valorCop; }
            set
            {
                if (_valorCop != value)
                {
                    _valorCop = value;
                    OnPropertyChanged("ValorCop");
                }
            }
        }
        private Nullable<decimal> _valorCop;
    
        [DataMember]
        public Nullable<decimal> IVA
        {
            get { return _iVA; }
            set
            {
                if (_iVA != value)
                {
                    _iVA = value;
                    OnPropertyChanged("IVA");
                }
            }
        }
        private Nullable<decimal> _iVA;
    
        [DataMember]
        public Nullable<decimal> ValorAdm
        {
            get { return _valorAdm; }
            set
            {
                if (_valorAdm != value)
                {
                    _valorAdm = value;
                    OnPropertyChanged("ValorAdm");
                }
            }
        }
        private Nullable<decimal> _valorAdm;
    
        [DataMember]
        public string Seleccion
        {
            get { return _seleccion; }
            set
            {
                if (_seleccion != value)
                {
                    _seleccion = value;
                    OnPropertyChanged("Seleccion");
                }
            }
        }
        private string _seleccion;
    
        [DataMember]
        public string TipoApuesta
        {
            get { return _tipoApuesta; }
            set
            {
                if (_tipoApuesta != value)
                {
                    _tipoApuesta = value;
                    OnPropertyChanged("TipoApuesta");
                }
            }
        }
        private string _tipoApuesta;
    
        [DataMember]
        public string Carrera
        {
            get { return _carrera; }
            set
            {
                if (_carrera != value)
                {
                    _carrera = value;
                    OnPropertyChanged("Carrera");
                }
            }
        }
        private string _carrera;
    
        [DataMember]
        public Nullable<int> NroFactura
        {
            get { return _nroFactura; }
            set
            {
                if (_nroFactura != value)
                {
                    _nroFactura = value;
                    OnPropertyChanged("NroFactura");
                }
            }
        }
        private Nullable<int> _nroFactura;
    
        [DataMember]
        public Nullable<decimal> ValorPagado
        {
            get { return _valorPagado; }
            set
            {
                if (_valorPagado != value)
                {
                    _valorPagado = value;
                    OnPropertyChanged("ValorPagado");
                }
            }
        }
        private Nullable<decimal> _valorPagado;
    
        [DataMember]
        public Nullable<System.DateTime> FechaPago
        {
            get { return _fechaPago; }
            set
            {
                if (_fechaPago != value)
                {
                    _fechaPago = value;
                    OnPropertyChanged("FechaPago");
                }
            }
        }
        private Nullable<System.DateTime> _fechaPago;
    
        [DataMember]
        public string Estado
        {
            get { return _estado; }
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    OnPropertyChanged("Estado");
                }
            }
        }
        private string _estado;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public usuario usuario
        {
            get { return _usuario; }
            set
            {
                if (!ReferenceEquals(_usuario, value))
                {
                    var previousValue = _usuario;
                    _usuario = value;
                    Fixupusuario(previousValue);
                    OnNavigationPropertyChanged("usuario");
                }
            }
        }
        private usuario _usuario;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            usuario = null;
        }

        #endregion
        #region Association Fixup
    
        private void Fixupusuario(usuario previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ventas.Contains(this))
            {
                previousValue.ventas.Remove(this);
            }
    
            if (usuario != null)
            {
                if (!usuario.ventas.Contains(this))
                {
                    usuario.ventas.Add(this);
                }
    
                Usuario_Id = usuario.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("usuario")
                    && (ChangeTracker.OriginalValues["usuario"] == usuario))
                {
                    ChangeTracker.OriginalValues.Remove("usuario");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("usuario", previousValue);
                }
                if (usuario != null && !usuario.ChangeTracker.ChangeTrackingEnabled)
                {
                    usuario.StartTracking();
                }
            }
        }

        #endregion
    }
}
