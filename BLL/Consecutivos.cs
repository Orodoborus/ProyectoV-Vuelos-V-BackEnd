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
    public class Consecutivos
    {
        #region propfulls
        private int _codigo_consecutivo;

        public int Codigo_Consecutivo
        {
            get { return _codigo_consecutivo; }
            set { _codigo_consecutivo = value; }
        }

        private string _description;

        public string Descripcion
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _prefijo;

        public string Prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private string _rango_ini;

        public string Rango_Ini
        {
            get { return _rango_ini; }
            set { _rango_ini = value; }
        }

        private string _rango_fin;

        public string Rango_Fin
        {
            get { return _rango_fin; }
            set { _rango_fin = value; }
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

        static int consID = 5;

        public static int GlobalValue
        {
            get
            {
                return consID;
            }
            set
            {
                consID = value;
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

        public List<Consecutivos> getAllCons(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec get_all_consecutivos";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));

                    return null;
                }
                else
                {
                    return procesarConsecutivos(ds.Tables[0]);
                }
            }
        }

        public void createCons(ref string mensaje_error, ref int numero_error, int Codigo_Consecutivo, string Descripcion,string Valor, string prefijo, string Rango_ini, string Rango_Fin, string UsernameC)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec create_new_consecutive @Codigo_Consecutivo = "+Codigo_Consecutivo+", @Descripcion = '"+ Descripcion +
                "', @Valor = '"+Valor+"', @Prefijo = '"+ prefijo + "', @Rango_Ini = '"+ Rango_ini + "', @Rango_Fin = '"+ Rango_Fin + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Codigo_Consecutivo.ToString(), bitacora.encrypt("Creacion de consecutivo"), bitacora.encrypt("Codigo:" + Codigo_Consecutivo.ToString() + "Descripcion: " + Descripcion + "Valor: " + Valor));
            }
        }

        public void updateCons(ref string mensaje_error, ref int numero_error, string Descripcion, string Valor, string prefijo, string Rango_ini, string Rango_fin, string UsernameC, string ConsCod)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec consecutive_update_cambios @Descripcion = '" + Descripcion + "', @Valor = '" + Valor + "', @Prefijo = '" + prefijo + "', @Rango_ini = '" + Rango_ini + "', @Rango_fin = '" + Rango_fin + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Update"), bitacora.encrypt(time), ConsCod, bitacora.encrypt("Update de un consecutivo"), bitacora.encrypt("Descripcion:" + (Descripcion) + "Valor: " + (Valor) + "Prefijo: " + (Prefijo)));
            }
        }

        public void updateSpecificCons(ref string mensaje_error, ref int numero_error, string Descripcion, string Valor, string Rango_Ini, string UsernameC)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec update_cons_ID @Description = '" + Descripcion + "', @Valor = '" + Valor + "', @Rango_Ini = '"+Rango_Ini+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            //else
            //{
            //    Bitacora bitacora = new Bitacora();
            //    bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), bitacora.encrypt(UsernameC), bitacora.encrypt(date), bitacora.encrypt("Update"), bitacora.encrypt(time), "5", bitacora.encrypt("Update de un consecutivo especifico"), bitacora.encrypt("Descripcion:" + (Descripcion) + "Valor: " + (Valor) + "Rango Ini: " + (Rango_Ini)));
            //}
        }

        private List<Consecutivos> procesarConsecutivos(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Consecutivos()
                    {
                        Codigo_Consecutivo = Convert.ToInt32(dr["Codigo_Consecutivo"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Valor = dr["Valor"].ToString(),
                        Prefijo = dr["Prefijo"].ToString(),
                        Rango_Ini = dr["Rango_Ini"].ToString(),
                        Rango_Fin = dr["Rango_Fin"].ToString()
                    }).ToList();
        }



        #endregion
    }
}
