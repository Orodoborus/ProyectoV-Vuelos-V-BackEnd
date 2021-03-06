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
        #endregion

        #region Methods

        #endregion
    }
}
