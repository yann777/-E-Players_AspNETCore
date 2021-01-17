using System;
using System.IO;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNetCore.Controllers
{
    [Route("Equipe")]

    
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
    
    [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Equipes = equipeModel.ReadAll();

            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form){
            
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome =  form["Nome"];
            
            if(form.Files.Count > 0){
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using(var stream = new FileStream(path, FileMode.Create)){
                    file.CopyTo(stream);
                }
                novaEquipe.Imagem = file.FileName;
            }

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}