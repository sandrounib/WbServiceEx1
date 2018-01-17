using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Controllers.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
        public class PrimeiraController:Controller    
    {
        
        
        //aqui vamos retornar apenas uma cidade
        //[HttpGet("{id}")]
        //primeiro fizemos o metodo abaixo comentado pois usa enumerable para voltar várias cidades
       /* public IEnumerable<string> Get(){
        [HttpGet]
        
            return new string[]{
                "Curitiba","Porto Alegre","Salvador","Belo Horizonte"
            };
        } */

        /*
         public string Get(int id){
            return new string[]{
                "Curitiba",
                "Porto Alegre",
                "Salvador",
                "Belo Horizonte"
            }[id];
        }  */

        
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();
        
        [HttpGet]
       // public string Get(){
            //return null;
       // }

       /*
       public IEnumerable<Cidades> GetCidades(){
           return cidade.Listar();
       } */
       
       //aqui as cidades estão dentro da DAO
       public IEnumerable<Cidades> GetCidades(){
           return dao.Listar();
       } 

       /*antes do post abaixo
       [HttpGet("{id}")]
       public Cidades Get(int id){
           return dao.Listar().Where(x => x.Id==id).FirstOrDefault();
       } */

       [HttpGet("{id}",Name="CidadeAtual")]
       public Cidades Get(int id){
           return dao.Listar().Where(x => x.Id==id).FirstOrDefault();
       } 

       [HttpPost]
        public IActionResult Post([FromBody] Cidades cidades){
            dao.Cadastro(cidades);
            
            return CreatedAtRoute("CidadeAtual",new{id=cidades.Id},cidades);
        }
        
    }
}