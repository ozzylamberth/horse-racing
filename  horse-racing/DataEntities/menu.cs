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
    [KnownType(typeof(menu))]
    [KnownType(typeof(perfiles))]
    [KnownType(typeof(usuario))]
    public partial class menu: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
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
        private int _id;
    
        [DataMember]
        public string MenuName
        {
            get { return _menuName; }
            set
            {
                if (_menuName != value)
                {
                    _menuName = value;
                    OnPropertyChanged("MenuName");
                }
            }
        }
        private string _menuName;
    
        [DataMember]
        public string NombreForm
        {
            get { return _nombreForm; }
            set
            {
                if (_nombreForm != value)
                {
                    _nombreForm = value;
                    OnPropertyChanged("NombreForm");
                }
            }
        }
        private string _nombreForm;
    
        [DataMember]
        public Nullable<int> PadreId
        {
            get { return _padreId; }
            set
            {
                if (_padreId != value)
                {
                    ChangeTracker.RecordOriginalValue("PadreId", _padreId);
                    if (!IsDeserializing)
                    {
                        if (menu2 != null && menu2.Id != value)
                        {
                            menu2 = null;
                        }
                    }
                    _padreId = value;
                    OnPropertyChanged("PadreId");
                }
            }
        }
        private Nullable<int> _padreId;
    
        [DataMember]
        public string MenuText
        {
            get { return _menuText; }
            set
            {
                if (_menuText != value)
                {
                    _menuText = value;
                    OnPropertyChanged("MenuText");
                }
            }
        }
        private string _menuText;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<menu> menu1
        {
            get
            {
                if (_menu1 == null)
                {
                    _menu1 = new TrackableCollection<menu>();
                    _menu1.CollectionChanged += Fixupmenu1;
                }
                return _menu1;
            }
            set
            {
                if (!ReferenceEquals(_menu1, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_menu1 != null)
                    {
                        _menu1.CollectionChanged -= Fixupmenu1;
                    }
                    _menu1 = value;
                    if (_menu1 != null)
                    {
                        _menu1.CollectionChanged += Fixupmenu1;
                    }
                    OnNavigationPropertyChanged("menu1");
                }
            }
        }
        private TrackableCollection<menu> _menu1;
    
        [DataMember]
        public menu menu2
        {
            get { return _menu2; }
            set
            {
                if (!ReferenceEquals(_menu2, value))
                {
                    var previousValue = _menu2;
                    _menu2 = value;
                    Fixupmenu2(previousValue);
                    OnNavigationPropertyChanged("menu2");
                }
            }
        }
        private menu _menu2;
    
        [DataMember]
        public TrackableCollection<perfiles> perfiles
        {
            get
            {
                if (_perfiles == null)
                {
                    _perfiles = new TrackableCollection<perfiles>();
                    _perfiles.CollectionChanged += Fixupperfiles;
                }
                return _perfiles;
            }
            set
            {
                if (!ReferenceEquals(_perfiles, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_perfiles != null)
                    {
                        _perfiles.CollectionChanged -= Fixupperfiles;
                    }
                    _perfiles = value;
                    if (_perfiles != null)
                    {
                        _perfiles.CollectionChanged += Fixupperfiles;
                    }
                    OnNavigationPropertyChanged("perfiles");
                }
            }
        }
        private TrackableCollection<perfiles> _perfiles;
    
        [DataMember]
        public TrackableCollection<usuario> usuario
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new TrackableCollection<usuario>();
                    _usuario.CollectionChanged += Fixupusuario;
                }
                return _usuario;
            }
            set
            {
                if (!ReferenceEquals(_usuario, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_usuario != null)
                    {
                        _usuario.CollectionChanged -= Fixupusuario;
                    }
                    _usuario = value;
                    if (_usuario != null)
                    {
                        _usuario.CollectionChanged += Fixupusuario;
                    }
                    OnNavigationPropertyChanged("usuario");
                }
            }
        }
        private TrackableCollection<usuario> _usuario;

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
            menu1.Clear();
            menu2 = null;
            perfiles.Clear();
            usuario.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void Fixupmenu2(menu previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.menu1.Contains(this))
            {
                previousValue.menu1.Remove(this);
            }
    
            if (menu2 != null)
            {
                if (!menu2.menu1.Contains(this))
                {
                    menu2.menu1.Add(this);
                }
    
                PadreId = menu2.Id;
            }
            else if (!skipKeys)
            {
                PadreId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("menu2")
                    && (ChangeTracker.OriginalValues["menu2"] == menu2))
                {
                    ChangeTracker.OriginalValues.Remove("menu2");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("menu2", previousValue);
                }
                if (menu2 != null && !menu2.ChangeTracker.ChangeTrackingEnabled)
                {
                    menu2.StartTracking();
                }
            }
        }
    
        private void Fixupmenu1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (menu item in e.NewItems)
                {
                    item.menu2 = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("menu1", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (menu item in e.OldItems)
                {
                    if (ReferenceEquals(item.menu2, this))
                    {
                        item.menu2 = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("menu1", item);
                    }
                }
            }
        }
    
        private void Fixupperfiles(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (perfiles item in e.NewItems)
                {
                    if (!item.menu.Contains(this))
                    {
                        item.menu.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("perfiles", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (perfiles item in e.OldItems)
                {
                    if (item.menu.Contains(this))
                    {
                        item.menu.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("perfiles", item);
                    }
                }
            }
        }
    
        private void Fixupusuario(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (usuario item in e.NewItems)
                {
                    if (!item.menu.Contains(this))
                    {
                        item.menu.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("usuario", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (usuario item in e.OldItems)
                {
                    if (item.menu.Contains(this))
                    {
                        item.menu.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("usuario", item);
                    }
                }
            }
        }

        #endregion
    }
}
