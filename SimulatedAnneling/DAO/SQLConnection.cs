using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using SimulatedAnneling.Model.TravelerSalesmanProblem;

namespace SimulatedAnneling.DAO
{
    public class SQLConnection
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        /// <summary>
        /// Contiene información establecer la conexión con la base de datos
        /// </summary>
        private MySqlConnectionStringBuilder builder;
        /// <summary>
        /// Objeto establece conexión con la base de datos
        /// </summary>
        private MySqlConnection connection;

        /**-------------------------------------------------------------------------------------------
         * Metodos
         *--------------------------------------------------------------------------------------------
         **/

        public SQLConnection(String server, String userId, String password, String database)
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userId;
            builder.Password = password;
            builder.Database = database;
            connection = new MySqlConnection(builder.ToString());
            connection.Open();
        }

        public MySqlDataReader execute(String sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql,connection);
            return cmd.ExecuteReader();
        }
        
    }
}
