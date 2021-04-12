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
    class reservation_details
    {
        #region propfulls
        private string _booking_ID;

        public string Booking_ID
        {
            get { return _booking_ID; }
            set { _booking_ID = value; }
        }

        private string _cod_user;

        public string Cod_User
        {
            get { return _cod_user; }
            set { _cod_user = value; }
        }

        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; }
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

        public List<reservation_details> cargar_compra_especifica(ref string mensaje_error, ref int numero_error, string BookingID, string Cod_User)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_reservation_details @Booking_ID  = '" + BookingID + "', @Cod_User  = '" + Cod_User + "'";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return get_all_reservation_details(ds.Tables[0]);
                }
            }
        }

        private List<reservation_details> get_all_reservation_details(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new reservation_details()
                    {
                        Booking_ID = dr["Booking_ID"].ToString(),
                        Cod_User = dr["Cod_User"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Price = dr["Precio"].ToString()
                    }).ToList();

        }
        #endregion
    }
}
