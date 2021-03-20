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
        //das
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

        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        string numero_error;
        DataSet ds;
        string sql;
        #endregion

        #region Methods

        public List<Agencia> getAgencias(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb",ref mensaje_error, ref numero_error);
            if (connection == null)
            {
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

        public void createAirline(ref string mensaje_error, ref int numero_error, int Cod_Agencia, string Nombre_Agencia, string Imagen, string Cod_Pais_FK, string Cod_Aerolinea)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "create_new_airline @Cod_Agencia= '"+Cod_Agencia+"', @Nombre_Agencia = '"+Nombre_Agencia+"', @Imagen = '"+Imagen+"', @Cod_Pais_FK = '"+Cod_Pais_FK+"', @Cod_Aerolinea = '"+Cod_Aerolinea+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
        }

        public void update_airline(ref string mensaje_error, ref int numero_error, string Cod_Agencia, string Nombre_Agencia, string Imagen, string Cod_Pais_FK, string Cod_Aerolinea)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "update_exist_airline @Cod_Agencia= '" + Cod_Agencia + "', @Nombre_Agencia = '" + Nombre_Agencia + "', @Imagen = '" + Imagen + "', @Cod_Pais_FK = '" + Cod_Pais_FK + "', @Cod_Aerolinea = '" + Cod_Aerolinea + "'"; ;
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
        }

        public void delete_airline(ref string mensaje_error, ref int numero_error, string Cod_Aerolinea)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "delete_airline @Cod_Aerolinea = '" + Cod_Aerolinea + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
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

        #endregion

    }
}
