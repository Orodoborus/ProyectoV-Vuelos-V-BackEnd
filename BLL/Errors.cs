using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Methods

        public List<Errors> cargar_lista_errores(ref string mensaje_error, ref int numero_error)
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
                    return procesarErrores(ds.Tables[0]);
                }
            }
        }

        public void crearError(ref string mensaje_error, ref int numero_error, int Error_ID, string Error_Message, string Time, string Date, string Error_Number)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec register_error @Error_ID = '" + Error_ID + "', @Error_Message = '" + Error_Message + "', @Time = '" + Time + "', @Date = '" + Date + "', @Error_Number = '" + Error_Number + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
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

        #endregion
    }
}
