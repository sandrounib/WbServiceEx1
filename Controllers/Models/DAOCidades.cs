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
        public bool Cadastro(Cidades cidades){
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd= new SqlCommand();
                
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText ="Insert into Cidades(nome,estado,habitantes) values(@n,@e,@h)";
                cmd.Parameters.AddWithValue("@n",cidades.Nome);
                cmd.Parameters.AddWithValue("@e",cidades.Estado);
                cmd.Parameters.AddWithValue("@h",cidades.Habitantes);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se) 
            {
                
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception (ex.Message);

            }
            finally{
                con.Close();
            }
            return resultado;
        }

        public bool Atualizar(Cidades cidades){
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd= new SqlCommand();
                
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText ="Update Cidades set nome= @n,estado= @e,habitantes= @h where id=@id";               
                cmd.Parameters.AddWithValue("@i",cidades.Id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se) 
            {
                
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception (ex.Message);

            }
            finally{
                con.Close();
            }
            return resultado;
        }   

         public bool Apagar(Cidades cidades){
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd= new SqlCommand();
                
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText ="Delete Cidades where id=@id";               
                cmd.Parameters.AddWithValue("@i",cidades.Id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se) 
            {
                
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception (ex.Message);

            }
            finally{
                con.Close();
            }
            return resultado;
        }       
        
    }
}