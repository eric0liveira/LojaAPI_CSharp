using LojaAPI.DAO;
using LojaAPI.Models;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public Carrinho Get(int id)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.Busca(id);
            return carrinho;
        }

        public string Post([FromBody] Carrinho carrinho)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);
            return "suceso";
        }
    }
}
