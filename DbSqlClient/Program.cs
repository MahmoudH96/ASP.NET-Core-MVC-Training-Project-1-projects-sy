using DbSqlClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbSqlClient
{
    /// <summary>
    /// This program aims to show how to create a database using the 
    /// traditional method via scripts (inside scripts Folder) and query
    /// this database using the tradition sql client
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Change the connection string based on your device
             */
            var connectionString = "Data Source=.;Initial Catalog=Institute;Integrated Security=True";
            var sqlConnection = OpenConnection(connectionString);
            var rooms = GetAllRooms(sqlConnection);
            sqlConnection.Close();
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room Id:{room.RoomId}, Room code:{room.RoomCode}");
            }
        }
        public static SqlConnection OpenConnection(string connectionString)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection opened");
            return sqlConnection;
        }

        public static List<Room> GetAllRooms(SqlConnection sqlConnection)
        {
            SqlCommand getAllRoomsCommand;
            SqlDataReader dataReader;
            List<Room> rooms = new List<Room>();
            Room currentRoom;
            string sql = "select * from Rooms";
            getAllRoomsCommand = new SqlCommand(sql, sqlConnection);
            dataReader = getAllRoomsCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentRoom = new Room()
                {
                    RoomId = int.Parse(dataReader.GetValue(0).ToString()),
                    RoomCode = dataReader.GetValue(1).ToString()
                };
                rooms.Add(currentRoom);
            }
            return rooms;
        }
    }
}
