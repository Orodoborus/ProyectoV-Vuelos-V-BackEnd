using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace BLL
{
    public class Pais
    {
        #region propfulls
        private string _Cod_Pais;

        public string Cod_Pais
        {
            get { return _Cod_Pais; }
            set { _Cod_Pais = value; }
        }


        private string _Cod_Pais2;

        public string Cod_Pais2
        {
            get { return _Cod_Pais2; }
            set { _Cod_Pais2 = value; }
        }


        private string _Nombre_Pais;

        public string Nombre_Pais
        {
            get { return _Nombre_Pais; }
            set { _Nombre_Pais = value; }
        }

        private string _image;

        public string Imagen
        {
            get { return _image; }
            set { _image = value; }
        }
        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        DataSet ds;
        string sql;
        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        #endregion

        #region Methods

        public List<Pais> getAllCountries(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_countries";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));

                    return null;
                }
                else
                {
                    return getPaises(ds.Tables[0]);
                }
            }
        }


        public void create_country(ref string mensaje_error, ref int numero_error, string Cod_Pais, string Nombre_Pais, string Imagen)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec create_new_country @Cod_Pais = '" + Cod_Pais + "', @Nombre_Pais = '" + Nombre_Pais + "', @Imagen = '" + Imagen + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();                
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void update_country(ref string mensaje_error, ref int numero_error, string Cod_Pais1, string Cod_Pais2, string Nombre_Pais, string Imagen)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec update_country @Cod_Pais = '" + Cod_Pais1 + "', @Cod_Pais2 = '"+ Cod_Pais2 + "',  @Nombre_Pais = '" + Nombre_Pais + "', @Imagen = '" + Imagen + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void delete_country(ref string mensaje_error, ref int numero_error, string Cod_Pais)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec delete_conutry @Cod_Pais = '"+ Cod_Pais+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }

        }


        private List<Pais> getPaises(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Pais()
                    {
                        Cod_Pais = dr["Cod_Pais"].ToString(),
                        Nombre_Pais = dr["Nombre_Pais"].ToString(),
                        Imagen = dr["Imagen"].ToString()
                    }).ToList();
        }



        #endregion
    }
}
