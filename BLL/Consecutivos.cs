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
        private string _codigo_consecutivo;

        public string Codigo_Consecutivo
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

        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Methods

        #endregion
    }
}
