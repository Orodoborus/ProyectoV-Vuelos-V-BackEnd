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
    public class Vuelos
    {
        #region propfulls
        private string _codigo_Vuelo;

        public string  Codigo_Vuelo
        {
            get { return _codigo_Vuelo; }
            set { _codigo_Vuelo = value; }
        }

        private string _aerolinea;

        public string Aerolinea
        {
            get { return _aerolinea; }
            set { _aerolinea = value; }
        }

        private string _cod_pais_fk;

        public string Cod_Pais_FK
        {
            get { return _cod_pais_fk; }
            set { _cod_pais_fk = value; }
        }

        private string _fecha;

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _hora;

        public string Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _cod_puerta_fk;

        public string Cod_Puerta_FK
        {
            get { return _cod_puerta_fk; }
            set { _cod_puerta_fk = value; }
        }

        private string _cs;

        public string CS
        {
            get { return _cs; }
            set { _cs = value; }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _userAct;

        public string UsernameC
        {
            get { return _userAct; }
            set { _userAct = value; }
        }

        private string _cod2;

        public string Codigo_Vuelo2
        {
            get { return _cod2; }
            set { _cod2 = value; }
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

        public List<Vuelos> GetFlights(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlights(ds.Tables[0]);
                }
            }
        }
        public List<Vuelos> GetFlightsS(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlightsS(ds.Tables[0]);
                }
            }
        }
        public List<Vuelos> GetFlightsBUY(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlightsBUY(ds.Tables[0]);
                }
            }
        }

        public List<Vuelos> GetFlightsSArribo(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlightsSArribo(ds.Tables[0]);
                }
            }
        }

        public List<Vuelos> GetFlightsYArribo(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlightsYArribo(ds.Tables[0]);
                }
            }
        }

        public List<Vuelos> GetFlightsY(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_flights";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllFlightsY(ds.Tables[0]);
                }
            }
        }


        public void createFlight(ref string mensaje_error, ref int numero_error, string Codigo_Vuelo, string Aerolinea, string Cod_PaisFK, string Fecha, string Hora, string Estado, string Cod_Puerta_FK, string CS, string Price, string UsernameC)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec create_new_flight @Codigo_Vuelo = '" + Codigo_Vuelo + "', @Aerolinea = '" + Aerolinea + "', @Cod_Pais_FK = '" + Cod_PaisFK + "', @Fecha = '"+Fecha+ "', @Hora = '"+Hora+ "', @Estado = '"+Estado+"', " +
                "@Cod_Puerta_FK = '"+Cod_Puerta_FK+ "', @CS = '"+CS+ "', @Price = '" + Price + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            //else
            //{
            //    Bitacora bitacora = new Bitacora();
            //    bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Codigo_Vuelo, bitacora.encrypt("Creacion de nuevo vuelo"), bitacora.encrypt("-"));
            //}
        }

        public void UpdateFlight(ref string mensaje_error, ref int numero_error, string Codigo_Vuelo,string CodigoVuelo2, string Aerolinea, string Cod_PaisFK, string Fecha, string Hora, string Estado, string Cod_Puerta_FK, string CS,string Price, string UsernameC)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec update_flight @Codigo_Vuelo = '" + Codigo_Vuelo + "', @Codigo_Vuelo2 = '"+CodigoVuelo2+"', @Aerolinea = '" + Aerolinea + "', @Cod_Pais_FK = '" + Cod_PaisFK + "', @Fecha = '" + Fecha + "', @Hora = '" + Hora + "', @Estado = '" + Estado + "', " +
                "@Cod_Puerta_FK = '" + Cod_Puerta_FK + "', @CS = '" + CS + "', @Price = '"+Price+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            //else
            //{
            //    Bitacora bitacora = new Bitacora();
            //    bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Codigo_Vuelo, bitacora.encrypt("Creacion de nuevo vuelo"), bitacora.encrypt("-"));
            //}
        }


        private List<Vuelos> getAllFlights(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList();
        }

        private List<Vuelos> getAllFlightsBUY(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList().Where(x => x.CS.Equals("S") && DateTime.ParseExact(convertion(x.Fecha), "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(date.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList(); ;
        }

        private List<Vuelos> getAllFlightsS(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList().Where(x => x.CS.Equals("S") && DateTime.ParseExact(convertion(x.Fecha), "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(date.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private List<Vuelos> getAllFlightsYArribo(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList().Where(x => x.CS.Equals("Y") && x.Estado.Equals(encryption("Arribo")) && DateTime.ParseExact(convertion(x.Fecha), "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(date.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private List<Vuelos> getAllFlightsSArribo(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList().Where(x => x.CS.Equals("S") && x.Estado.Equals(encryption("Arribo")) && DateTime.ParseExact(convertion(x.Fecha), "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(date.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture)).ToList();
        }

        private string convertion(string v)
        {
            Bitacora b = new Bitacora();
            return b.decrypt(v);
        }

        private string encryption(string v)
        {
            Bitacora b = new Bitacora();
            return b.encrypt(v);
        }

        private List<Vuelos> getAllFlightsY(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Vuelos()
                    {
                        Codigo_Vuelo = dr["Codigo_Vuelo"].ToString(),
                        Aerolinea = dr["Aerolinea"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Fecha = dr["Fecha"].ToString(),
                        Hora = dr["Hora"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Cod_Puerta_FK = dr["Cod_Puerta_FK"].ToString(),
                        CS = dr["CS"].ToString(),
                        Price = dr["Price"].ToString()
                    }).ToList().Where(x => x.CS.Equals("Y")).ToList();
        }

        #endregion
    }
}
