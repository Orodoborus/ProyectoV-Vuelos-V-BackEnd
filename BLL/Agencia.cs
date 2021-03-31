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
    public class Agencia
        {

        #region propfulls
        private string _cod_agencia;

        public string Cod_Agencia
        {
            get { return _cod_agencia; }
            set { _cod_agencia = value; }
        }

        private string _nombre_agencia;

        public string Nombre_Agencia
        {
            get { return _nombre_agencia; }
            set { _nombre_agencia = value; }
        }

        private string _image;

        public string Imagen
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _cod_pais_fk;

        public string Cod_Pais_FK
        {
            get { return _cod_pais_fk; }
            set { _cod_pais_fk = value; }
        }

        private string _cod_aerolinea;

        public string Cod_Aerolinea
        {
            get { return _cod_aerolinea; }
            set { _cod_aerolinea = value; }
        }

        private string _userAct;

        public string UsernameC
        {
            get { return _userAct; }
            set { _userAct = value; }
        }

        private string _userCod;

        public string UserCod
        {
            get { return _userCod; }
            set { _userCod = value; }
        }

        static int airlineID = 0;

        public static int GlobalValue
        {
            get
            {
                return airlineID;
            }
            set
            {
                airlineID = value;
            }
        }

        static string Cod_Country = "";

        public static string GlobalValueCountry
        {
            get
            {
                return Cod_Country;
            }
            set
            {
                Cod_Country = value;
            }
        }



        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        string numero_error;
        DataSet ds;
        string sql;
        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        #endregion

        #region Methods

        public List<Agencia> getAgencias(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb",ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                return null;
            }
            else
            {
                sql = "exec get_all_agencias";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getAllAirlines(ds.Tables[0]);
                }
            }
        }

        public List<Agencia> getFilteredAgencias(ref string mensaje_error, ref int numero_error, string Cod_Pais_FK)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                return null;
            }
            else
            {
                sql = "exec get_filtered_agency @Cod_Pais_FK = '"+Cod_Pais_FK+"'";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return getFilteredAirlines(ds.Tables[0], Cod_Pais_FK);
                }
            }
        }

        public void createAirline(ref string mensaje_error, ref int numero_error, int Cod_Agencia, string Nombre_Agencia, string Imagen, string Cod_Pais_FK, string Cod_Aerolinea, string UsernameC)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec create_new_airline @Cod_Agencia= '"+Cod_Agencia+"', @Nombre_Agencia = '"+Nombre_Agencia+"', @Imagen = '"+Imagen+"', @Cod_Pais_FK = '"+Cod_Pais_FK+"', @Cod_Aerolinea = '"+Cod_Aerolinea+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC.ToString()), bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Cod_Agencia.ToString(), bitacora.encrypt("Creacion de una aerolinea"), bitacora.encrypt("Codigo: " + Cod_Agencia + " | Nombre: " + bitacora.decrypt(Nombre_Agencia) + " | Imagen: " + bitacora.decrypt(Imagen)));
        }

        }

        public void update_airline(ref string mensaje_error, ref int numero_error, string Cod_Agencia, string Nombre_Agencia, string Imagen, string Cod_Pais_FK, string Cod_Aerolinea, string UsernameC, string Cod_Agency)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec update_exist_airline @Cod_Agencia= '" + Cod_Agencia + "', @Nombre_Agencia = '" + Nombre_Agencia + "', @Imagen = '" + Imagen + "', @Cod_Pais_FK = '" + Cod_Pais_FK + "', @Cod_Aerolinea = '" + Cod_Aerolinea + "'"; 
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Update"), bitacora.encrypt(time), Cod_Agency, bitacora.encrypt("Update de agencia/aerolinea"), bitacora.encrypt("Codigo: " + Cod_Agencia + " | Nombre: " + bitacora.decrypt(Nombre_Agencia) + " | Imagen: " + bitacora.decrypt(Imagen)));
            }
        }

        public void delete_airline(ref string mensaje_error, ref int numero_error, string Cod_Aerolinea, string UsernameC, string Cod_Agency)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec delete_airline @Cod_Aerolinea = '" + Cod_Aerolinea + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Delete"), bitacora.encrypt(time), Cod_Agency, bitacora.encrypt("Eliminacion de Agencia/Aerolinea"), bitacora.encrypt("-"));
            }
        
        }

        private List<Agencia> getAllAirlines(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Agencia()
                    {
                        Cod_Agencia = dr["Cod_Agencia"].ToString(),
                        Nombre_Agencia = dr["Nombre_Agencia"].ToString(),
                        Imagen = dr["Imagen"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Cod_Aerolinea = dr["Cod_Aerolinea"].ToString()
                    }).ToList();
        }

        private List<Agencia> getFilteredAirlines(DataTable dt, string cod_pais_fk)
        {
            return (from DataRow dr in dt.Rows
                    select new Agencia()
                    {
                        Cod_Agencia = dr["Cod_Agencia"].ToString(),
                        Nombre_Agencia = dr["Nombre_Agencia"].ToString(),
                        Imagen = dr["Imagen"].ToString(),
                        Cod_Pais_FK = dr["Cod_Pais_FK"].ToString(),
                        Cod_Aerolinea = dr["Cod_Aerolinea"].ToString()
                    }).ToList().Where(x => x.Cod_Pais_FK.Equals(cod_pais_fk)).ToList();
        }

        #endregion

    }
}
