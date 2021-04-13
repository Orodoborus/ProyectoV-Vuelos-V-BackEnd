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
    public class cards
    {
        #region propfulls
           private string _Num_Tarjeta;

        public string Num_Tarjeta
        {
            get { return _Num_Tarjeta; }
            set { _Num_Tarjeta = value; }
        }

        private string _mes_exp;

        public string Mes_Exp
        {
            get { return _mes_exp; }
            set { _mes_exp = value; }
        }

        private string _Ano_Exp;

        public string Ano_Exp
        {
            get { return _Ano_Exp; }
            set { _Ano_Exp = value; }
        }

        private string _CVV;

        public string CVV
        {
            get { return _CVV; }
            set { _CVV = value; }
        }

        private string _Monto;

        public string Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _card_type;

        public string Card_Type
        {
            get { return _card_type; }
            set { _card_type = value; }
        }

        private string  codbuy;

        public string  Codigo_Compras
        {
            get { return codbuy; }
            set { codbuy = value; }
        }

        private string _cod_user_fk;

        public string Cod_User_FK
        {
            get { return _cod_user_fk; }
            set { _cod_user_fk = value; }
        }

        private string _codigo_vuelo;

        public string Codigo_Vuelo_FK
        {
            get { return _codigo_vuelo; }
            set { _codigo_vuelo = value; }
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

        public List<cards> cargar_tarjeta(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_card";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return get_my_card(ds.Tables[0]);
                }
            }
        }

        public void add_card(ref string mensaje_error, ref int numero_error, string Numcard, string MonthExp, string YearExp, string CVV, string Monto, string Tipo, string Card_tpe)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            sql = "exec new_card  @NumTar = '" + Numcard + "', @Mes_Exp = '" + MonthExp + "', @Ano_Exp = '" + YearExp + "', @CVV = '" + CVV + "', @Monto = '"+Monto+"', @Tipo = '"+Tipo+"', @Card_Type = '"+Card_tpe+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void updatePayment(ref string mensaje_error, ref int numero_error, string Numcard, string MonthExp, string YearExp, string CVV, string Monto, string Tipo, string Card_tpe)
        {
            connection = cls_DAL.trae_conexion("Payment", ref mensaje_error, ref numero_error);
            sql = "exec success_payment @Num_Tarjeta = '" + Numcard + "', @Mes_Exp = '" + MonthExp + "', @Ano_Exp = '"+YearExp+"', @CVV = '"+CVV+"', @Monto = '"+Monto+"', @Tipo = '"+Tipo+"', @Card_Type = '"+ Card_tpe + "'";
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

        private List<cards> get_my_card(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new cards()
                    {
                        Num_Tarjeta = dr["Num_Tarjeta"].ToString(),
                        Mes_Exp = dr["Mes_Exp"].ToString(),
                        Ano_Exp = dr["Ano_Exp"].ToString(),
                        CVV = dr["CVV"].ToString(),
                        Monto = dr["Monto"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Card_Type = dr["Card_Type"].ToString()
                    }).ToList();
        }
        #endregion
    }
}
