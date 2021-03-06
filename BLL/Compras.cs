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
    public class Compras
    {

        #region propfulls
        private string _Codigo_Compras;

        public string Codigo_Compras
        {
            get { return _Codigo_Compras; }
            set { _Codigo_Compras = value; }
        }

        private string _cod_user_fk;

        public string Cod_User_FK
        {
            get { return _cod_user_fk; }
            set { _cod_user_fk = value; }
        }

        private string _cod_vuelo_fk;

        public string Codigo_Vuelo_FK
        {
            get { return _cod_vuelo_fk; }
            set { _cod_vuelo_fk = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private double _total;

        public double Total
        {
            get { return _total; }
            set { _total = value; }
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
