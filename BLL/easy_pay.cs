using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class easy_pay
    {
        #region propfulls
        private string _numcuenta;

        public string Num_Cuenta
        {
            get { return _numcuenta; }
            set { _numcuenta = value; }
        }

        private string _CodSeguridad;

        public string Codigo_Seguridad
        {
            get { return _CodSeguridad; }
            set { _CodSeguridad = value; }
        }

        private string _password;

        public string Constrasena
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _fondos;

        public string Fondos
        {
            get { return _fondos; }
            set { _fondos = value; }
        }

        #endregion

        #region private variables
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        #endregion

        #region methods

        public List<easy_pay> cargar_easypay(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_easypay";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return getMyEasyPay(ds.Tables[0]);
                }
            }
        }

        public void add_account(ref string mensaje_error, ref int numero_error, string NumCuenta, string CodSeguridad, string Contrasena, string Fondos)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            sql = "exec newEasyPayAccount  @Num_Cuenta = '" + NumCuenta + "', @Codigo_Seguridad  = '" + CodSeguridad + "', @Contrasena  = '" + Contrasena + "', @Fondos  = '" + Fondos + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void updatePayment(ref string mensaje_error, ref int numero_error, string NumCuenta, string CodSeguridad, string Contrasena, string Fondos)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            sql = "exec update_easypay  @Num_Cuenta = '" + NumCuenta + "', @Codigo_Seguridad  = '" + CodSeguridad + "', @Contrasena  = '" + Contrasena + "', @Fondos  = " + Fondos + "";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
            }
        }

        private List<easy_pay> getMyEasyPay(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new easy_pay
                    {
                        Num_Cuenta = dr["Num_Cuenta"].ToString(),
                        Codigo_Seguridad = dr["Codigo_Seguridad"].ToString(),
                        Constrasena = dr["Constrasena"].ToString(),
                        Fondos = dr["Fondos"].ToString()
                    }).ToList();
        }
        #endregion
    }
}
