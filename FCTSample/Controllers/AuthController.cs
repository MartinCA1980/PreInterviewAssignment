using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FCTSample;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using Service;

namespace FCTSample.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(ICustomerService customerService, IJwtTokenService jwtTokenService)
        {
            _customerService = customerService;
            _jwtTokenService = jwtTokenService;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] LoginViewModel model)
        {

            if (!ModelState.IsValid) return BadRequest("Invalid input");

            CustomerModel customer = _customerService.SignIn(model.Email, model.Password);
                        
            if (customer == null) return Unauthorized();

            JWTToken token =  _jwtTokenService.GenerateToken(customer);
            
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([FromBody] CustomerModel model)
        {

            if (!ModelState.IsValid) return BadRequest("Invalid input");

            try
            {
                CustomerModel customer = _customerService.Add(model);
                if (customer == null) return BadRequest();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }            
                        
            return Ok();
        }
    }
}