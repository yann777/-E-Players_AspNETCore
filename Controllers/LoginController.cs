using Eplayes_AspCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Eplayes_AspCore.Controllers
{

    [Route("Login")]

    public class LoginController : Controller
    {     

        [TempData]
        public string Mensagem { get; set; }

        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]

        public IActionResult Logar(IFormCollection form)
        {
          
            // Lemos todos os arquivos do CSV

            Jogador jogador = new Jogador();
            List<string> csv = jogador.ReadAllLinesCSV("Database/Jogador.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && 
                x.Split(";")[3] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/");
            } else
            {
                Mensagem = "Dados incorretos, tente novamente...";
                return LocalRedirect("~/Login");
            }
     
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}