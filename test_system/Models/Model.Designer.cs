﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace test_system.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class DatabaseEntities : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект DatabaseEntities, используя строку соединения из раздела "DatabaseEntities" файла конфигурации приложения.
        /// </summary>
        public DatabaseEntities() : base("name=DatabaseEntities", "DatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта DatabaseEntities.
        /// </summary>
        public DatabaseEntities(string connectionString) : base(connectionString, "DatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта DatabaseEntities.
        /// </summary>
        public DatabaseEntities(EntityConnection connection) : base(connection, "DatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Glava> Glava
        {
            get
            {
                if ((_Glava == null))
                {
                    _Glava = base.CreateObjectSet<Glava>("Glava");
                }
                return _Glava;
            }
        }
        private ObjectSet<Glava> _Glava;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Otv> Otv
        {
            get
            {
                if ((_Otv == null))
                {
                    _Otv = base.CreateObjectSet<Otv>("Otv");
                }
                return _Otv;
            }
        }
        private ObjectSet<Otv> _Otv;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Stat> Stat
        {
            get
            {
                if ((_Stat == null))
                {
                    _Stat = base.CreateObjectSet<Stat>("Stat");
                }
                return _Stat;
            }
        }
        private ObjectSet<Stat> _Stat;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Vopr> Vopr
        {
            get
            {
                if ((_Vopr == null))
                {
                    _Vopr = base.CreateObjectSet<Vopr>("Vopr");
                }
                return _Vopr;
            }
        }
        private ObjectSet<Vopr> _Vopr;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Glava. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToGlava(Glava glava)
        {
            base.AddObject("Glava", glava);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Otv. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToOtv(Otv otv)
        {
            base.AddObject("Otv", otv);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Stat. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToStat(Stat stat)
        {
            base.AddObject("Stat", stat);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Vopr. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToVopr(Vopr vopr)
        {
            base.AddObject("Vopr", vopr);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DatabaseModel", Name="Glava")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Glava : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Glava.
        /// </summary>
        /// <param name="iD_glav">Исходное значение свойства ID_glav.</param>
        public static Glava CreateGlava(global::System.Guid iD_glav)
        {
            Glava glava = new Glava();
            glava.ID_glav = iD_glav;
            return glava;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID_glav
        {
            get
            {
                return _ID_glav;
            }
            set
            {
                if (_ID_glav != value)
                {
                    OnID_glavChanging(value);
                    ReportPropertyChanging("ID_glav");
                    _ID_glav = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_glav");
                    OnID_glavChanged();
                }
            }
        }
        private global::System.Guid _ID_glav;
        partial void OnID_glavChanging(global::System.Guid value);
        partial void OnID_glavChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String name_glav
        {
            get
            {
                return _name_glav;
            }
            set
            {
                Onname_glavChanging(value);
                ReportPropertyChanging("name_glav");
                _name_glav = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("name_glav");
                Onname_glavChanged();
            }
        }
        private global::System.String _name_glav;
        partial void Onname_glavChanging(global::System.String value);
        partial void Onname_glavChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String name_file
        {
            get
            {
                return _name_file;
            }
            set
            {
                Onname_fileChanging(value);
                ReportPropertyChanging("name_file");
                _name_file = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("name_file");
                Onname_fileChanged();
            }
        }
        private global::System.String _name_file;
        partial void Onname_fileChanging(global::System.String value);
        partial void Onname_fileChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DatabaseModel", Name="Otv")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Otv : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Otv.
        /// </summary>
        /// <param name="iD_otv">Исходное значение свойства ID_otv.</param>
        public static Otv CreateOtv(global::System.Guid iD_otv)
        {
            Otv otv = new Otv();
            otv.ID_otv = iD_otv;
            return otv;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> ID_vopr
        {
            get
            {
                return _ID_vopr;
            }
            set
            {
                OnID_voprChanging(value);
                ReportPropertyChanging("ID_vopr");
                _ID_vopr = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_vopr");
                OnID_voprChanged();
            }
        }
        private Nullable<global::System.Guid> _ID_vopr;
        partial void OnID_voprChanging(Nullable<global::System.Guid> value);
        partial void OnID_voprChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID_otv
        {
            get
            {
                return _ID_otv;
            }
            set
            {
                if (_ID_otv != value)
                {
                    OnID_otvChanging(value);
                    ReportPropertyChanging("ID_otv");
                    _ID_otv = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_otv");
                    OnID_otvChanged();
                }
            }
        }
        private global::System.Guid _ID_otv;
        partial void OnID_otvChanging(global::System.Guid value);
        partial void OnID_otvChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Otv1
        {
            get
            {
                return _Otv1;
            }
            set
            {
                OnOtv1Changing(value);
                ReportPropertyChanging("Otv1");
                _Otv1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Otv1");
                OnOtv1Changed();
            }
        }
        private global::System.String _Otv1;
        partial void OnOtv1Changing(global::System.String value);
        partial void OnOtv1Changed();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Bool
        {
            get
            {
                return _Bool;
            }
            set
            {
                OnBoolChanging(value);
                ReportPropertyChanging("Bool");
                _Bool = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Bool");
                OnBoolChanged();
            }
        }
        private Nullable<global::System.Int32> _Bool;
        partial void OnBoolChanging(Nullable<global::System.Int32> value);
        partial void OnBoolChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DatabaseModel", Name="Stat")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Stat : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Stat.
        /// </summary>
        /// <param name="id">Исходное значение свойства ID.</param>
        public static Stat CreateStat(global::System.Guid id)
        {
            Stat stat = new Stat();
            stat.ID = id;
            return stat;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Data
        {
            get
            {
                return _Data;
            }
            set
            {
                OnDataChanging(value);
                ReportPropertyChanging("Data");
                _Data = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Data");
                OnDataChanged();
            }
        }
        private global::System.String _Data;
        partial void OnDataChanging(global::System.String value);
        partial void OnDataChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Time
        {
            get
            {
                return _Time;
            }
            set
            {
                OnTimeChanging(value);
                ReportPropertyChanging("Time");
                _Time = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Time");
                OnTimeChanged();
            }
        }
        private global::System.String _Time;
        partial void OnTimeChanging(global::System.String value);
        partial void OnTimeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Computer
        {
            get
            {
                return _Computer;
            }
            set
            {
                OnComputerChanging(value);
                ReportPropertyChanging("Computer");
                _Computer = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Computer");
                OnComputerChanged();
            }
        }
        private global::System.String _Computer;
        partial void OnComputerChanging(global::System.String value);
        partial void OnComputerChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String IP_address
        {
            get
            {
                return _IP_address;
            }
            set
            {
                OnIP_addressChanging(value);
                ReportPropertyChanging("IP_address");
                _IP_address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IP_address");
                OnIP_addressChanged();
            }
        }
        private global::System.String _IP_address;
        partial void OnIP_addressChanging(global::System.String value);
        partial void OnIP_addressChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Balls
        {
            get
            {
                return _Balls;
            }
            set
            {
                OnBallsChanging(value);
                ReportPropertyChanging("Balls");
                _Balls = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Balls");
                OnBallsChanged();
            }
        }
        private Nullable<global::System.Int32> _Balls;
        partial void OnBallsChanging(Nullable<global::System.Int32> value);
        partial void OnBallsChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Tasks
        {
            get
            {
                return _Tasks;
            }
            set
            {
                OnTasksChanging(value);
                ReportPropertyChanging("Tasks");
                _Tasks = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Tasks");
                OnTasksChanged();
            }
        }
        private Nullable<global::System.Int32> _Tasks;
        partial void OnTasksChanging(Nullable<global::System.Int32> value);
        partial void OnTasksChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Answerd
        {
            get
            {
                return _Answerd;
            }
            set
            {
                OnAnswerdChanging(value);
                ReportPropertyChanging("Answerd");
                _Answerd = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Answerd");
                OnAnswerdChanged();
            }
        }
        private Nullable<global::System.Int32> _Answerd;
        partial void OnAnswerdChanging(Nullable<global::System.Int32> value);
        partial void OnAnswerdChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Glava
        {
            get
            {
                return _Glava;
            }
            set
            {
                OnGlavaChanging(value);
                ReportPropertyChanging("Glava");
                _Glava = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Glava");
                OnGlavaChanged();
            }
        }
        private global::System.String _Glava;
        partial void OnGlavaChanging(global::System.String value);
        partial void OnGlavaChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DatabaseModel", Name="Vopr")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Vopr : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Vopr.
        /// </summary>
        /// <param name="iD_vopr">Исходное значение свойства ID_vopr.</param>
        public static Vopr CreateVopr(global::System.Guid iD_vopr)
        {
            Vopr vopr = new Vopr();
            vopr.ID_vopr = iD_vopr;
            return vopr;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID_vopr
        {
            get
            {
                return _ID_vopr;
            }
            set
            {
                if (_ID_vopr != value)
                {
                    OnID_voprChanging(value);
                    ReportPropertyChanging("ID_vopr");
                    _ID_vopr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_vopr");
                    OnID_voprChanged();
                }
            }
        }
        private global::System.Guid _ID_vopr;
        partial void OnID_voprChanging(global::System.Guid value);
        partial void OnID_voprChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> ID_glav
        {
            get
            {
                return _ID_glav;
            }
            set
            {
                OnID_glavChanging(value);
                ReportPropertyChanging("ID_glav");
                _ID_glav = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_glav");
                OnID_glavChanged();
            }
        }
        private Nullable<global::System.Guid> _ID_glav;
        partial void OnID_glavChanging(Nullable<global::System.Guid> value);
        partial void OnID_glavChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Vopr1
        {
            get
            {
                return _Vopr1;
            }
            set
            {
                OnVopr1Changing(value);
                ReportPropertyChanging("Vopr1");
                _Vopr1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Vopr1");
                OnVopr1Changed();
            }
        }
        private global::System.String _Vopr1;
        partial void OnVopr1Changing(global::System.String value);
        partial void OnVopr1Changed();

        #endregion
    
    }

    #endregion
    
}
