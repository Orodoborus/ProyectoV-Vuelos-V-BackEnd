using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;




/*
 4.6.2. Errores
Consiste en mostrar una lista con los errores que se han registrado en la aplicación. La 
consulta tendrá la opción de filtrar por rango de fecha. Se presenta la fecha y hora, numero 
de error y el mensaje de error correspondiente.

 */

namespace BLL
{

    public class Errors
    {
        #region propfulls
        private string _error_id;

        public string Error_ID
        {
            get { return _error_id; }
            set { _error_id = value; }
        }

        private string _error_message;

        public string Error_Message
        {
            get { return _error_message; }
            set { _error_message = value; }
        }

        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _error_number;

        public string Error_Number
        {
            get { return _error_number; }
            set { _error_number = value; }
        }

        private string _userAct;

        public string UsernameC
        {
            get { return _userAct; }
            set { _userAct = value; }
        }

        static int contadorID = 0;

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



        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        string sql;
        DataSet ds;
        #endregion

        #region Methods

        public List<Errors> cargar_lista_errores(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;// Imposible registrar este error porque no tiene conexion con la base.
            }
            else
            {
                sql = "exec get_all_errors";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, encrypt(mensaje_error), encrypt(time), encrypt(date), encrypt(numero_error.ToString()));


                    return null;
                }
                else
                {
                    
                    return procesarErrores(ds.Tables[0]);
                }
            }
        }

        public void crearError(ref string mensaje_error, ref int numero_error, int Error_ID, string Error_Message, string Time, string Date, string Error_Number)
        {
            
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec register_error @Error_ID = '" + Error_ID + "', @Error_Message = '" + Error_Message + "', @Time = '" + Time + "', @Date = '" + encrypt(date) + "', @Error_Number = '" + Error_Number + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, encrypt(mensaje_error), encrypt(time), encrypt(date), encrypt(numero_error.ToString()));
            }

        }

        public void crearErrorInterno(ref string mensaje_error, ref int numero_error, int Error_ID, string Error_Message, string Time, string Date, string Error_Number)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec register_error @Error_ID = '" + Error_ID + "', @Error_Message = '" + Error_Message + "', @Time = '" + Time + "', @Date = '" + Date + "', @Error_Number = '" + Error_Number + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
        }

        public List<Errors> GetErrorsUserFilteredbyDateRange(ref string mensaje_error, ref int numero_error, string date1, string date2)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_errors";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ProcesarErrorsFilteredByDateRange(ds.Tables[0], date1, date2);
                }
            }
        }

        private List<Errors> ProcesarErrorsFilteredByDateRange(DataTable dt, string date1, string date2)
        {
            return (from DataRow dr in dt.Rows
                    select new Errors()
                    {
                        Error_ID = dr["Error_ID"].ToString(),
                        Error_Message = dr["Error_Message"].ToString(),
                        Time = dr["Time"].ToString(),
                        Date = dr["Date"].ToString(),
                        Error_Number = dr["Error_Number"].ToString()
                    }).ToList().Where(x => DateTime.ParseExact(convertion(x.Date), "dd-MM-yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(convertion(x.Date), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }


        private string convertion(string v)
        {
            Errors b = new Errors();
            return b.decrypt(v);
        }






        private List<Errors> procesarErrores(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Errors()
                    {
                        //ojete ojete aca
                        Error_ID = (string)dr["Error_ID"],
                        Error_Message = dr["Error_Message"].ToString(),
                        Time = dr["Time"].ToString(),
                        Date = dr["Date"].ToString(),
                        Error_Number = dr["Error_Number"].ToString()
                    }).ToList();
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
