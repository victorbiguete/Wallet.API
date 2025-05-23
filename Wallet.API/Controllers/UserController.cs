using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Services.Contracts.Request.Users;
using Wallet.Services.Service.Interfaces;


namespace Wallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var result = await _userService.CreateAsync(request);

            if (!result)
                return BadRequest("Ocorreu um erro durante a Criação do Usuario");

            return Ok("Criação do Usuario Concluida com Sucesso");
        }

        [HttpDelete("/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result)
                return BadRequest("Ocorreu um Erro durante a remoção do Usuario, verifique o Saldo da conta pois ela deve estar zerada");

            return Ok("Remoção do Usuario Concluida com Sucesso");
        }

        [HttpGet("/GetUser/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result == null)
                return NotFound("Não foi possivel encontrar esse usuario");

            return Ok(result);
        }

        [HttpGet("/GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAll();

            if (result == null)
                return NotFound("Não foi possivel encontrar nenhum usuario");

            return Ok(result);
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var result = await _userService.UpdateAsync(request);

            if (!result)
                return BadRequest("Ocorreu um Erro na Atualização, verifique as informações");

            return Ok("Atualização do Usuario Concluida com Sucesso");
        }
    }
}
