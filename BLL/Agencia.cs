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
        #endregion

        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        string numero_error;
        DataSet ds;
        string sql;
        #endregion

        #region Methods

        #endregion

    }
}
