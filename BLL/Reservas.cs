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
    public class Reservas
    {
        #region propfulls
        private string _Cod_Reserva;

        public string Cod_Reserva
        {
            get { return _Cod_Reserva; }
            set { _Cod_Reserva = value; }
        }

        private string _numreservation;

        public string Numero_Reservacion
        {
            get { return _numreservation; }
            set { _numreservation = value; }
        }

        private string _booking_ID;

        public string Booking_ID
        {
            get { return _booking_ID; }
            set { _booking_ID = value; }
        }

        private string _cod_user_fk;

        public string Cod_User_FK
        {
            get { return _cod_user_fk; }
            set { _cod_user_fk = value; }
        }

        private string _codigo_vuelo_fk;

        public string Codigo_Vuelo_FK
        {
            get { return _codigo_vuelo_fk; }
            set { _codigo_vuelo_fk = value; }
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

        private string _state;

        public string Payment_Method
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _date;

        public string FechaReservation
        {
            get { return _date; }
            set { _date = value; }
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

        public List<Reservas> cargar_reserva_especifica(ref string mensaje_error, ref int numero_error, string user)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_reservations @Cod_User = '" + user+"'";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return getMyReservations(ds.Tables[0]);
                }
            }
        }

        public void new_reservation(ref string mensaje_error, ref int numero_error, string CodReserva, string Numeroreservacion, string BookingID,string Cod_User_FK, string cantidad, string Total, string PaymentMethod)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec new_reservation  @Cod_Reserva = '" + CodReserva + "', @Numero_Reservacion = '" + Numeroreservacion + "', @Booking_ID = '" + BookingID + "', @Cod_User_FK = '" + Cod_User_FK + "'," +
                " @Cantidad = '"+ cantidad + "', @Total = "+ Total + ", @Payment_Method = '"+ PaymentMethod + "', @FechaReservation = '"+date+"'";
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

        private List<Reservas> getMyReservations(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Reservas()
                    {
                        Cod_Reserva = dr["Cod_Reserva"].ToString(),
                        Numero_Reservacion = dr["Numero_Reservacion"].ToString(),
                        Booking_ID = dr["Booking_ID"].ToString(),
                        Cod_User_FK = dr["Cod_User_FK"].ToString(),
                        Cantidad = dr["Cantidad"].ToString(),
                        Total = dr["Total"].ToString(),
                        Payment_Method = dr["Payment_Method"].ToString(),
                        FechaReservation = dr["FechaReservation"].ToString()
                    }).ToList();
        }
        #endregion
    }
}
