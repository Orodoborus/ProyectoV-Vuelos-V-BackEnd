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
    public class Errors
    {
        #region propfulls
        private string _error_id;

        public string Error_ID
        {
            get { return _error_id; }
            set { _error_id = value; }
        }

        private string _error_message;

        public string Error_Message
        {
            get { return _error_message; }
            set { _error_message = value; }
        }

        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
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
