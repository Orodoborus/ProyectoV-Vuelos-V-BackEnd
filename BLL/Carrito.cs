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
    public class Carrito
    {

        #region propfulls
        private string _cod_item;

        public string Cod_Item
        {
            get { return _cod_item; }
            set { _cod_item = value; }
        }

        private string _codigo_vuelo;

        public string Codigo_Vuelo
        {
            get { return _codigo_vuelo; }
            set { _codigo_vuelo = value; }
        }

        private string _pais;

        public string  Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private string _precio;

        public string Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        static int contadorIDCART = 1;

        public static int GlobalValueIDCART
        {
            get
            {
                return contadorIDCART;
            }
            set
            {
                contadorIDCART = value;
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
        public List<Carrito> cargar_carrito(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_items_cart";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return getAllCartItems(ds.Tables[0]);
                }
            }
        }

        public void add_cartItem(ref string mensaje_error, ref int numero_error, int Cod_Item, string Codigo_Vuelo, string Pais, string Precio)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec add_to_Cart  @Cod_Item = '" + Cod_Item + "', @Codigo_Vuelo = '" + Codigo_Vuelo + "', @Pais = '" + Pais + "', @Precio = '" + Precio + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            //else
            //{
            //    Bitacora bitacora = new Bitacora();
            //    bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Cod_User.ToString(), bitacora.encrypt("Creacion de nuevo usuario"), bitacora.encrypt("Codigo: " + Cod_User + " | Nombre: " + bitacora.decrypt(Username) + " | Email: " + bitacora.decrypt(Email)));
            //}
        }

        public void deleteCartItem(ref string mensaje_error, ref int numero_error, int Cod_Item)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = " exec delete_selected_cart_item @Cod_item = '"+Cod_Item+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void deleteCartItems(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = " exec logout_or_successfullbuy";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        private List<Carrito> getAllCartItems(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Carrito()
                    {
                        Cod_Item = dr["Cod_Item"].ToString(),
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Precio = dr["Precio"].ToString()
                    }).ToList();
        }


        #endregion

    }
}
