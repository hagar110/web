using bookListMVCWith_identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
//using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bookListMVCWith_identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger
            ) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        [HttpPost]
        public IActionResult Logout()
        {
            _ = signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnurl)
        {
            var redirectUrl = Url.Action("ExternalLoginBack", "Account", new { ReturnUrl = returnurl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginBackAsync(string returnurl, string remoteError=null)
        {
            returnurl = returnurl ?? Url.Content("~/");//checking if it is null or not , if it is then set url's content to the root folder of our project
            LoginViewModel loginviewModel= new LoginViewModel{
                ReturnUrl = returnurl,
                    ExternalLogin=(await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null) {// if there is an error then add it to model state and return to viewmodelview
                ModelState.AddModelError(string.Empty, $"Error from external provider: { remoteError}");
                return View("Login", loginviewModel);
            }
            var info = await signInManager.GetExternalLoginInfoAsync();//getting external login information of user from external login provider
            if (info == null)
            {// if there is an error then add it to model state and return to viewmodelview
                ModelState.AddModelError(string.Empty,  "error loading external login information");
                return View("Login", loginviewModel);
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);// searching for a local email = google email
            ApplicationUser user = null;

            if (email != null)
            {
                user = await userManager.FindByEmailAsync(email);
                // if we find the user then this external user has a local acount
                if (user!=null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login",loginviewModel);
                 
                }
            }

                var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {//if the email is recorded in the data base 
                return RedirectToAction("index","books");
            }
            else
            {
              
                if (email != null) {
                    
                    if (user == null) {// if user is not found then make a new account for him 
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        await userManager.CreateAsync(user);
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action("confirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
                        // Logger.Log(LogLevel.Warning, confirmationLink);
                        string subject = "Confirmation Mail";// sending actual email to user account
                                                             //   string body = "<html><body><a class=nav - link text - dark  asp-controller=Books asp-action=Index  >Please click on this link to confirm your email </a></body></html> ";
                        MailMessage message = new MailMessage();
                        message.To.Add(email);
                        message.Subject = "Confirmation Mail";
                        message.Body = confirmationLink;
                        message.From = new MailAddress("hagar.ehab999@gmail.com");
                        message.IsBodyHtml = true;
                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential("hagar.ehab999@gmail.com", "ydbsqgjvyfqtdbec"),
                            EnableSsl = true,
                        };

                        smtpClient.Send(message);
                        ViewBag.Title = "Registration successful";
                        ViewBag.Message = "Before you can login you must confirm your email by clicking on the confirmation link we have sent to your email";
                       
                        return View("confirmationPage");

                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnurl);
                }
                ViewBag.ErrorTitle = $"Email claim can't be recieved";// if email== null
                ViewBag.ErrorMessage = "please contact support on hagar.ehab999@gmail.com";
                return View("Error");

            }

        }



        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId,String Token) {
            if(userId==null || Token == null)
            {
                return RedirectToAction("index", "home");
            }
            var user = userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user id {userId} is invalid";
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(await user, Token);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","books");
            }
            ViewBag.ErrorTitle = "Email can not be confirmed";
            
            return View("Error");
        
        }




        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var user = new ApplicationUser { UserName = model.email, Email = model.email , city=model.City, FullName=model.FullName};
              var result = await userManager.CreateAsync(user, model.password);
                if (result.Succeeded) {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

              
                     
                    string subject = "Confirmation Mail";// sending actual email to user account
 
                    MailMessage message = new MailMessage();
                    message.To.Add(model.email);
                    message.Subject = "Confirmation Mail";
                    message.Body = confirmationLink;
                    message.From = new MailAddress("hagar.ehab999@gmail.com");
                    message.IsBodyHtml = true;
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("hagar.ehab999@gmail.com", "ydbsqgjvyfqtdbec"),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);
                    //return RedirectToAction("index", "books");///index action in books controller
                    ViewBag.Title = "Registration successful";
                    ViewBag.Message = "Before you can login you must confirm your email by clicking on the confirmation link we have sent to your email";
                  
                    return View("confirmationPage");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel {
                ReturnUrl = returnUrl,
                ExternalLogin = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,String ReturnUrl)
        {
            model.ExternalLogin = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList() ;//get all external login providers
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.email);
                if(user!=null && !user.EmailConfirmed && (await userManager.CheckPasswordAsync(user,model.password)))//password confirmation is to prevent account enumration and bruete force attacks(as the attacker may try various email till finding a correct email that ca be used to login so he maywait for the email to be validated by the owner and can try later to open the acount)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }
               //the false parameter is for not closing the account on failure and remember me to determine if itis a permanent cookie or session
                var result = await signInManager.PasswordSignInAsync(model.email, model.password,model.rememberme,false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "books");//index action in books controller
                }
               
                    ModelState.AddModelError("", "invalid login attempt");
                
            }
            return View(model);
        }


    }
}
