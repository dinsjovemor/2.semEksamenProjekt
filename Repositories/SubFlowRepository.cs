using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace _2.semEksamenProjekt.Repositories
{
    public class SubFlowRepository
    {
        string connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}2.sem projekt.db"; //Angiver lokationen til databasen "2.sem projekt.db"

        // henter alle subflows for et bestemt flow
        public List<SubFlow> GetSubFlowsByFlowId(int flowId) //Funktion navngivet GetSubFlowsByFlowId, for at tildelee ID til flow fra SubFlow
        {
            List<SubFlow> subFlows = new List<SubFlow>(); //instantierer et nyt subflow 

            using SqliteConnection connection = new SqliteConnection(connectionString); //Skaber en forbindelse til databasen
            connection.Open();

            //Angiver en SQL kommando om SELECT, FROM og WHERE
            using SqliteCommand command = new SqliteCommand(
                "SELECT Id, FlowId, ParentId, Heading, Text, File FROM SubFlow WHERE FlowId = @flowId",
                connection);

            command.Parameters.AddWithValue("@flowId", flowId); //Tilføjer med "AddWithValue" flowid'et til klassen

            using SqliteDataReader reader = command.ExecuteReader(); //Funktion "ExecuteReader" for at udføre en reader 
            while (reader.Read()) //while-loop der læser 
            {
                subFlows.Add(new SubFlow //Tilføjer nedenstående id osv. til subflows
                {
                    id       = reader.GetInt32(0),
                    flowId   = reader.GetInt32(1),
                    parentId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                    heading  = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    text     = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    file     = reader.IsDBNull(5) ? null : reader.GetString(5)
                });
            }

            return subFlows; //returnerer værdien til subflows
        }
    }
}
