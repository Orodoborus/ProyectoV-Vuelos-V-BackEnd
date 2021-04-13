using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Compras
    {

        #region propfulls
        private string _Codigo_Compras;

        public string Codigo_Compras
        {
            get { return _Codigo_Compras; }
            set { _Codigo_Compras = value; }
        }

        private string _cod_user_fk;

        public string Cod_User_FK
        {
            get { return _cod_user_fk; }
            set { _cod_user_fk = value; }
        }

        private string _cod_vuelo_fk;

        public string Codigo_Vuelo_FK
        {
            get { return _cod_vuelo_fk; }
            set { _cod_vuelo_fk = value; }
        }

        private string _cantidad;

        public string Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _total;

        public string Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _datebuy;

        public string DateBuy
        {
            get { return _datebuy; }
            set { _datebuy = value; }
        }

        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
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

        #region Methods
        public List<Compras> cargar_compras(ref string mensaje_error, ref int numero_error, string user)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_buys";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return get_all_current_buys(ds.Tables[0], user);
                }
            }
        }

        public void new_buy(ref string mensaje_error, ref int numero_error, string CocBuy, string Coduser, string Cant, string total)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec new_buy  @Codigo_Compras = '" + CocBuy + "', @Cod_User_FK = '" + Coduser + "', @Cantidad = '" + Cant + "', @Total = '"+ total + "', @DateBuy = '"+date+"'";
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

        private List<Compras> get_all_current_buys(DataTable dt, string user)
        {
            return (from DataRow dr in dt.Rows
                    select new Compras()
                    {
                        Codigo_Compras = dr["Codigo_Compras"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        Cantidad = dr["Cantidad"].ToString(),
                        Total = dr["Total"].ToString(),
                        DateBuy = dr["DateBuy"].ToString()
                    }).ToList().Where(x => x.Cod_User_FK.Equals(user)).ToList();
        }
        #endregion

    }
}
