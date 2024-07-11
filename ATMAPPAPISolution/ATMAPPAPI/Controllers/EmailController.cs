using ATMAPPAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATMAPPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendOTP")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonResult), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> SendOTP(string email)
        {
            try
            {
                var result = await _emailService.SendOTPMail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new JsonResult(new { 
                    Error_Message = ex.Message,
                    code = 422
                }));
            }
        }

        [HttpPost("VerifyOTP")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonResult), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> VerifyOTP(string toEmail, string otp)
        {
            try
            {
                var result = _emailService.VerifyOtp(toEmail, otp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new JsonResult(new
                {
                    Error_Message = ex.Message,
                    code = 422
                }));
            }
        }

    }
}
