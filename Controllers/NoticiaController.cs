using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eplayes_AspCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Eplayes_AspCore.Controllers
{
    public class NoticiaController : Controller
    {
        Noticia noticiaModel = new Noticia();


        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        [Route("CadastrarNoticia")]
        public IActionResult Cadastrar(IFormCollection form)
        {            
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            Noticia novaNoticia = new Noticia();
            novaNoticia.IdNoticia = Int32.Parse( form["IdNoticia"] );
            novaNoticia.Titulo = form["Titulo"];
            novaNoticia.Texto = form["Texto"];

            if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;                
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiaModel.Create(novaNoticia);

            ViewBag.Noticias = noticiaModel.ReadAll();
            return LocalRedirect("~/");
        }

         [Route("Noticia/{id}")]
        public IActionResult Excluir(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticia");
        }

    }
}