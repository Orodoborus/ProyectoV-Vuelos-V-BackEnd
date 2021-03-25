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

    public class Usuario
    {
        
        #region 
        private int _cod_user;

        public int Cod_User
        {
            get { return _cod_user; }
            set { _cod_user = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _rol;

        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _question;

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        private string _answer;

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        private string _Mensaje;

        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }

        private int _num_error;

        public int num_error
        {
            get { return _num_error; }
            set { _num_error = value; }
        }



        static int contadorID = 0;

        public static int GlobalValue
        {
            get
            {
                return contadorID;
            }
            set
            {
                contadorID = value;
            }
        }


        #region variables privadas
        SqlConnection connection;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        string time = DateTime.Now.ToString("H:mm");
        string date = DateTime.Now.ToString("dd-MM-yyyy");

        #endregion

        #endregion

        #region Methods
        public List<Usuario> cargar_lista_usuarios(ref string mensaje_error, ref int numero_error)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref  mensaje_error, ref  numero_error);
            if(connection == null)
            {
                return null;
            }
            else
            {
                sql = "exec select_all_users";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false,ref mensaje_error,ref numero_error);
                if(numero_error != 0)
                {
                    Errors e = new Errors();
                    e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
                    return null;
                }
                else
                {
                    return procesarUsuarios(ds.Tables[0]);
                }
            }
        }



        public void crearUser(ref string mensaje_error, ref int numero_error, int Cod_User,string Username, string Password, string Rol,string Email, string Question, string Answer)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec register_user @Cod_user = '"+Cod_User+"', @Username = '"+Username+"', @Pass = '"+Password+"', @Rol = '"+Rol+"', @Email = '"+Email+"', @Question = '"+Question+"', @Answer = '"+Answer+"'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), "1", bitacora.encrypt(date), bitacora.encrypt("Create"), bitacora.encrypt(time), Cod_User.ToString(), bitacora.encrypt("Creacion de nuevo usuario"), bitacora.encrypt("Codigo:" + Cod_User + "Nombre: " + Username + "Email: " + Email));
            }
        }

        public void updateUser(ref string mensaje_error, ref int numero_error, string Username, string Rol)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "exec update_user_rol @Username = '"+Username+"', @Rol = '"+Rol+"'";
            ds = cls_DAL.ejecuta_dataset(connection,sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), "1", bitacora.encrypt(date), bitacora.encrypt("Update"), bitacora.encrypt(time), Cod_User.ToString(), bitacora.encrypt("Update de rol"), bitacora.encrypt("Nombre de usuario:" + Username + "Rol: " +Rol));
            }
        }

        public void updateUserPassword(ref string mensaje_error, ref int numero_error, string Username, string Password)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            sql = "user_password_update @Username = '" + Username + "', @Password = '" + Password + "'";
            ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);
            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
            else
            {
                Bitacora bitacora = new Bitacora();
                bitacora.CreateBitacora(ref mensaje_error, ref numero_error, (Bitacora.GlobalValue = Bitacora.GlobalValue + 1).ToString(), "1", bitacora.encrypt(date), bitacora.encrypt("Update"), bitacora.encrypt(time), Cod_User.ToString(), bitacora.encrypt("Cambio de contraseña"), bitacora.encrypt("Nombre de usuario:" + (Username)));

            }
        }
        

        public void deleteUser(ref string mensaje_error, ref int numero_error, int id)
        {
            connection = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
                //sql = "DELETE FROM Usuario WHERE Cod_User = '"+id+"';";
                ds = cls_DAL.ejecuta_dataset(connection, sql, false, ref mensaje_error, ref numero_error);

            if (numero_error != 0)
            {
                Errors e = new Errors();
                e.crearErrorInterno(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue + 1, e.encrypt(mensaje_error), e.encrypt(time), e.encrypt(date), e.encrypt(numero_error.ToString()));
            }
        }

        private List<Usuario> procesarUsuarios(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Usuario()
                    {
                        Cod_User = Convert.ToInt32(dr["Cod_User"]),
                        Username = dr["Username"].ToString(),
                        Password = dr["Password"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Email = dr["Email"].ToString(),
                        Question = dr["Question"].ToString(),
                        Answer = dr["Answer"].ToString()
                    }).ToList();
        }

        private List<Usuario> procesarCod_User(DataTable dt)
        {
            return (from DataRow dr in dt.Rows
                    select new Usuario()
                    {
                        Cod_User = Convert.ToInt32(dr["Cod_User"])
                    }).ToList();
        }
        #endregion
    }
}
