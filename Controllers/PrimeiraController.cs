using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
        public class PrimeiraController:Controller    
    {
        
        //aqui vamos retornar apenas uma cidade
        [HttpGet("{id}")]
        //primeiro fizemos o metodo abaixo comentado pois usa enumerable para voltar várias cidades
       /* public IEnumerable<string> Get(){
        [HttpGet]
        
            return new string[]{
                "Curitiba","Porto Alegre","Salvador","Belo Horizonte"
            };
        } */

         public string Get(int id){
            return new string[]{
                "Curitiba",
                "Porto Alegre",
                "Salvador",
                "Belo Horizonte"
            }[id];
        }        
        
    }
}