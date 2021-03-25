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
    public class Puerta
    {
        #region propfulls
        private string _cod_puerta;

        public string Cod_Puerta
        {
            get { return _cod_puerta; }
            set { _cod_puerta = value; }
        }

        private string _cod_puerta2;

        public string Cod_Puerta2
        {
            get { return _cod_puerta2; }
            set { _cod_puerta2 = value; }
        }

        private string _numero_puerta;

        public string Numero_Puerta
        {
            get { return _numero_puerta; }
            set { _numero_puerta = value; }
        }

        private string _detalle;

        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
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

        public List<Puerta> getGates(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if(connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_gates";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {

                    return getAllGates(ds.Tables[0]);
                }
            }
        }

        public void createGate(ref string mensaje_error, ref int numero_error, string Cod_Puerta, string Numero_Puerta, string Detalle)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "create_new_gate @Cod_Puerta = '"+Cod_Puerta+"', @Numero_Puerta = '"+Numero_Puerta+"', @Detalle = '"+Detalle+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }
        public void updateGate(ref string mensaje_error, ref int numero_error, string Cod_Puerta, string Cod_Puerta2, string Numero_Puerta, string Detalle)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "update_ecist_gate @Cod_Puerta = '" + Cod_Puerta + "', @Cod_Puerta2 = '" +Cod_Puerta2+"' , @Numero_Puerta = '" + Numero_Puerta + "', @Detalle = '" + Detalle + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        public void delete_gate(ref string mensaje_error, ref int numero_error, string Cod_Puerta)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "delete_gate @Cod_Puerta = '"+Cod_Puerta+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }


        private List<Puerta> getAllGates(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Puerta()
                    {
                        Cod_Puerta = dr["Cod_Puerta"].ToString(),
                        Numero_Puerta = dr["Numero_Puerta"].ToString(),
                        Detalle = dr["Detalle"].ToString()
                    }).ToList();
        }

        #endregion
    }
}
