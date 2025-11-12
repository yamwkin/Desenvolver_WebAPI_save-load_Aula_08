using Microsoft.AspNetCore.Mvc;

namespace API_Aula.Controllers
{
    public class AlunoController : ControllerBase
    {
        public static List<Model.Player> players = new()
        {
            new Model.Player { id = 1, Vida = 100, QuantidadeDeItens = 0, PosicaoX = 0, PosicaoY = 0, PosicaoZ = 0}
        };
        [HttpGet]
        [Route("api/player")]

        public IActionResult GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("api/player/{id}")]

        public IActionResult GetPlayer(int id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("api/player")]

        public IActionResult AddPlayer([FromBody] Model.Player novoPlayer)
        {
            players.Add(novoPlayer);
            return Ok(novoPlayer);
        }

        [HttpPut]
        [Route("api/player/{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] Model.Player playerAtualizado)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Vida = playerAtualizado.Vida;
            player.QuantidadeDeItens = playerAtualizado.QuantidadeDeItens;
            player.PosicaoX = playerAtualizado.PosicaoX;
            player.PosicaoY = playerAtualizado.PosicaoY;
            player.PosicaoZ = playerAtualizado.PosicaoZ;
            return Ok(player);
        }

        [HttpDelete]
        [Route("api/player/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            players.Remove(player);

            return Ok(player);
        }
    }
}
