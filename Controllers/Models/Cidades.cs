using System.Collections.Generic;

namespace WebServicesCidades.Controllers.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }


        /* cometei pois iremos usar agora o banco de dados
        public List<Cidades> Listar(){
            return new List<Cidades>(){
                new Cidades{Id=10,Nome="Leme",Estado="SP",Habitantes=1234},
                new Cidades{Id=51,Nome="São Paulo",Estado="SP",Habitantes=3212},
                new Cidades{Id=13,Nome="Rio de Janeiro",Estado="RJ",Habitantes=5431},
                new Cidades{Id=22,Nome="Itu",Estado="SP",Habitantes=32567},
                new Cidades{Id=40,Nome="Ponte Nova",Estado="MG",Habitantes=232}
            };            
        } */

    }
}