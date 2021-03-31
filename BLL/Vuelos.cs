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
    public class Vuelos
    {
        #region propfulls
        private string _codigo_Vuelo;

        public string  Codigo_Vuelo
        {
            get { return _codigo_Vuelo; }
            set { _codigo_Vuelo = value; }
        }

        private string _aerolinea;

        public string Aerolinea
        {
            get { return _aerolinea; }
            set { _aerolinea = value; }
        }

        private string _cod_pais_fk;

        public string Cod_Pais_FK
        {
            get { return _cod_pais_fk; }
            set { _cod_pais_fk = value; }
        }

        private string _fecha;

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _hora;

        public string Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _cod_puerta_fk;

        public string Cod_Puerta_FK
        {
            get { return _cod_puerta_fk; }
            set { _cod_puerta_fk = value; }
        }

        private string _cs;

        public string CS
        {
            get { return _cs; }
            set { _cs = value; }
        }

        private string _userAct;

        public string UsernameC
        {
            get { return _userAct; }
            set { _userAct = value; }
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
