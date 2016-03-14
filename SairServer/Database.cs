using System;
using System.Net;
using MySql.Data.MySqlClient;

namespace SairServer
{
    public class Database
    {
        private MySqlConnection mSQLConnection;

        public Database(IPAddress aIpAdress, string aDatabasename, string aUser, string aPassword)
        {
            string connectionString = "SERVER=" + "localhost" + ";DATABASE=" + aDatabasename + ";UID=" + aUser + ";PASSWORD=" + aPassword + ";";
            //string connectionString = "SERVER=" + aIpAdress.ToString() + ";DATABASE=" + aDatabasename + ";UID=" + aUser + ";PASSWORD=" + aPassword + ";";

            mSQLConnection = new MySqlConnection(connectionString);
        }

        public Container getMap(int aMapID)
        {
            Container container = new Container(Enums.type.mapchange);

            MySqlCommand command = mSQLConnection.CreateCommand();
            command.CommandText = "SELECT * FROM maptiles WHERE mapid = '" + aMapID + "'";

            mSQLConnection.Open();

            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                container.add(new engineObject(null, Reader.GetValue(2).ToString(), new position(Convert.ToDouble(Reader.GetValue(3)), Convert.ToDouble(Reader.GetValue(4)), Convert.ToDouble(Reader.GetValue(5))), new rotation(null, Convert.ToDouble(Reader.GetValue(6)), null)));
                //container.add(new Model(Reader.GetValue(2).ToString(), (int)Reader.GetValue(3), (int)Reader.GetValue(4), (int)Reader.GetValue(5), Convert.ToDouble(Reader.GetValue(6).ToString())));
            }

            mSQLConnection.Close();

            return container;
        }

        //public void InsertMaptile(int aMapID, string aName, int aX, int aY, int aZ, double aRotation)
        //{
        //    string insertQuery = "INSERT INTO maptiles (mapid, model, x, y, z, rotation) Values(" + aMapID.ToString() + ", '" + aName + "', " + aX.ToString() + ", " + aY.ToString() + ", " + aZ.ToString() + ", '" + aRotation.ToString() + "')";
        //    MySqlCommand command = new MySqlCommand(insertQuery);
        //    command.Connection = mSQLConnection;

        //    mSQLConnection.Open();
        //    command.ExecuteNonQuery();

        //    mSQLConnection.Close();
        //}
    }
}
