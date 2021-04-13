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
    public class Compras_details
    {

        #region propfulls
        private string _codigo_compra;

        public string Codigo_Compra
        {
            get { return _codigo_compra; }
            set { _codigo_compra = value; }
        }

        private string _codigo_user;

        public string Codigo_User
        {
            get { return _codigo_user; }
            set { _codigo_user = value; }
        }

        private string _codigo_vuelo;

        public string Codigo_Vuelo
        {
            get { return _codigo_vuelo; }
            set { _codigo_vuelo = value; }
        }

        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private string _price;

        public string Precio
        {
            get { return _price; }
            set { _price = value; }
        }

        static string user = "";

        public static string GlobalValueUSER
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        static string CompraCod = "";

        public static string GlobalValueBUYCODE
        {
            get
            {
                return CompraCod;
            }
            set
            {
                CompraCod = value;
            }
        }

        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        #endregion

        #region methods

        public List<Compras_details> cargar_compra_especifica(ref string mensaje_error, ref int numero_error, string Cod_Buy, string Cod_User)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_buying_details @Codigo_Compra = '"+Cod_Buy+ "', @Codigo_User = '"+Cod_User+"'";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return get_users_specific_buys(ds.Tables[0]);
                }
            }
        }

        public void add_new_detail(ref string mensaje_error, ref int numero_error, string Codigo_Compra, string Codigo_user , string Codigo_Vuelo, string Pais, string Precio)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec new_detail  @Codigo_Compra = '" + Codigo_Compra + "', @Codigo_User = '" + Codigo_user + "', @Codigo_Vuelo = '" + Codigo_Vuelo + "', @Pais = '" + Pais + "', @Precio = '"+Precio+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        private List<Compras_details> get_users_specific_buys(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Compras_details
                    {
                        Codigo_Compra = dr["Codigo_Compra"].ToString(),
                        Codigo_User = dr["Codigo_User"].ToString(),
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Precio = dr["Precio"].ToString()
                    }).ToList();
        }

        #endregion

    }
}
