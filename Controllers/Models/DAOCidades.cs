using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace WebServicesCidades.Controllers.Models
{
    public class DAOCidades
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\SqlExpress;Initial Catalog=projetocidades;user id=sa;password=senai@123";
        
        public List<Cidades> Listar(){
            List<Cidades> cidades = new List<Cidades>();
            try{
                con = new SqlConnection();
                con.ConnectionString=conexao;
                con.Open();
                
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType= CommandType.Text;
                cmd.CommandText = "Select * from Cidades";
                rd = cmd.ExecuteReader();
                while(rd.Read()){
                    cidades.Add(new Cidades(){
                        Id = rd.GetInt32(0),
                        Nome= rd.GetString(1),
                        Estado = rd.GetString(2),
                        Habitantes = rd.GetInt32(3)
                    });
                }
            }
            catch(SqlException se){
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }
            return cidades;
            
        }
        
    }
}