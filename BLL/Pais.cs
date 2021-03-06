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
    public class Pais
    {
        #region propfulls
        private string _Cod_Pais;

        public string Cod_Pais
        {
            get { return _Cod_Pais; }
            set { _Cod_Pais = value; }
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
        #endregion

        #region Methods

        #endregion
    }
}
