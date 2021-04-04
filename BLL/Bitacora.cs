using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Globalization;

namespace BLL
{
    public class Bitacora
    {
        #region propfulls
        private string _cod_registro;

        public string Cod_Registro
        {
            get { return _cod_registro; }
            set { _cod_registro = value; }
        }

        private string _cod_user_fk;

        public string Cod_User_FK
        {
            get { return _cod_user_fk; }
            set { _cod_user_fk = value; }
        }

        private string _fechatime;

        public string FechaTime
        {
            get { return _fechatime; }
            set { _fechatime = value; }
        }

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string myTime;

        public string Time
        {
            get { return myTime; }
            set { myTime = value; }
        }

        private string myCodRegis;

        public string Cod_Regis
        {
            get { return myCodRegis; }
            set { myCodRegis = value; }
        }

        private string myDescripcion;

        public string Descripcion
        {
            get { return myDescripcion; }
            set { myDescripcion = value; }
        }

        private string myRegistroDetalle;

        public string RegistroDetalle
        {
            get { return myRegistroDetalle; }
            set { myRegistroDetalle = value; }
        }

        private string _userAct;

        public string UsernameC
        {
            get { return _userAct; }
            set { _userAct = value; }
        }

        private string _date1;

        public string date1
        {
            get { return _date1; }
            set { _date1 = value; }
        }

        private string _date2;

        public string date2
        {
            get { return _date2; }
            set { _date2 = value; }
        }


        static int contadorID = 15;

        public static int GlobalValue
        {
            get
            {
                return contadorID;
            }
            set
            {
                contadorID = value;
            }
        }

        static string UserFilter = "";

        public static string GlobalValueFilterUser
        {
            get
            {
                return UserFilter;
            }
            set
            {
                UserFilter = value;
            }
        }

        static string TypeFilter = "";

        public static string GlobalValueFilterType
        {
            get
            {
                return TypeFilter;
            }
            set
            {
                TypeFilter = value;
            }
        }

        static string dateIniFilter = "";

        public static string GlobalValueFilterDateIni
        {
            get
            {
                return dateIniFilter;
            }
            set
            {
                dateIniFilter = value;
            }
        }

        static string dateFinFilter = "";

        public static string GlobalValueFilterDateFin
        {
            get
            {
                return dateFinFilter;
            }
            set
            {
                dateFinFilter = value;
            }
        }

        #endregion



        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        DataSet ds;
        string sql;
        #endregion

        #region Methods

        public List<Bitacora> GetBitacoras(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {

                    return ProcesarBitacoras(ds.Tables[0]);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFiltered(ref string mensaje_error, ref int numero_error, string user)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByUser(ds.Tables[0],user);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyType(ref string mensaje_error, ref int numero_error, string type)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByType(ds.Tables[0], type);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyTypeAndUser(ref string mensaje_error, ref int numero_error,string user, string type)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByTypeAndUser(ds.Tables[0], user, type);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyDateRange(ref string mensaje_error, ref int numero_error, string date1, string date2)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByDateRange(ds.Tables[0], date1, date2);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyDateRangeAndTypeAndUser(ref string mensaje_error, ref int numero_error,string user, string type, string date1, string date2)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByDateRangeAndUserAndType(ds.Tables[0],user, type, date1, date2);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyDateRangeAndType(ref string mensaje_error, ref int numero_error, string type, string date1, string date2)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByDateRangeAndType(ds.Tables[0], type, date1, date2);
                }
            }
        }

        public List<Bitacora> GetBitacorasUserFilteredbyDateRangeAndUser(ref string mensaje_error, ref int numero_error, string user, string date1, string date2)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_bitacoras";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarBitacorasFilteredByDateRangeAndUser(ds.Tables[0], user, date1, date2);
                }
            }
        }


        public void CreateBitacora(ref string mensaje_error, ref int numero_error, string Cod_Registro, string Cod_User_FK, string FechaTime, string Tipo, string Time, string Cod_Regis, string Descripcion, string Registro_Detalle)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec create_new_bitacora @Cod_Registro = '" + Cod_Registro + "', @Cod_User_FK = '" + Cod_User_FK + "', @FechaTime = '" + FechaTime + "', @Tipo = '" + Tipo + "', @Time = '" + Time + "', @Cod_Regis = '" + Cod_Regis + "', @Descripcion = '" + Descripcion + "', @Registro_Detalle = '" + Registro_Detalle + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

        }
        private List<Bitacora> ProcesarBitacoras(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByUser(DataTable dt, string user)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(user).Equals(x.Cod_User_FK)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByType(DataTable dt, string type)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(type).Equals(x.Tipo)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByTypeAndUser(DataTable dt, string user, string type)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(user).Equals(x.Cod_User_FK) && x.encrypt(type).Equals(x.Tipo)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByDateRange(DataTable dt, string date1, string date2)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => DateTime.ParseExact(convertion(x.FechaTime),"dd-MM-yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByDateRangeAndUserAndType(DataTable dt, string user, string type, string date1, string date2)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(user).Equals(x.Cod_User_FK) && x.encrypt(type).Equals(x.Tipo) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByDateRangeAndUser(DataTable dt, string user, string date1, string date2)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(user).Equals(x.Cod_User_FK) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private List<Bitacora> ProcesarBitacorasFilteredByDateRangeAndType(DataTable dt, string type, string date1, string date2)
        {
            return (from DataRow dr in dt.Rows
                    select new Bitacora()
                    {
                        Cod_Registro = dr["Cod_Registro"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        FechaTime = dr["FechaTime"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Time = dr["Time"].ToString(),
                        Cod_Regis = dr["Cod_Regis"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RegistroDetalle = dr["Registro_Detalle"].ToString()
                    }).ToList().Where(x => x.encrypt(type).Equals(x.Tipo) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(convertion(x.FechaTime), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private string convertion(string v)
        {
            Bitacora b = new Bitacora();
            return b.decrypt(v);
        }

        public string encrypt(string text)
        {
            string encrypted = string.Empty;
            Byte[] encrypt = new UnicodeEncoding().GetBytes(text);
            encrypted = Convert.ToBase64String(encrypt);
            return encrypted;
        }
        public string decrypt(string text)
        {
            string decrypted = string.Empty;
            Byte[] decrypt = Convert.FromBase64String(text);
            decrypted = new UnicodeEncoding().GetString(decrypt);
            return decrypted;
        }
   

        #endregion
    }
}
