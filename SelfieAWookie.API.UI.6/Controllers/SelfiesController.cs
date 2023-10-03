using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.API.UI._6.Application.DTOs;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System.Reflection;

namespace SelfieAWookie.API.UI._6.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        // On la met en readonly parce qu'on ne le chargera qu'au moment du constructor
        private readonly ISelfieRepository _repository = null;

        #endregion

        #region Constructors
        // Récupération de notre constructeur SelfiesContext qu'on appelle context
        public SelfiesController(ISelfieRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        //#region Public methods
        //[HttpGet]
        //public IEnumerable<Selfie> TestAMoi()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

        //    #endregion
        //}

        #region Public methods
        [HttpGet]
        public IActionResult TestAMoi() {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            //var model = this._context.Selfies.ToList(); // pour récupérer la liste des selfies
            //var query = from Selfie in this ._context.Selfies // Méthode avec le Linq
            //            join Wookie in this._context.Wookies on Selfie.WookieId equals Wookie.Id
            //            select Selfie;

            var selfiesList = this._repository.GetAll();

            //var model = selfiesList.Select(item => new { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

            return this.Ok(model);

            // }                                                     

            #endregion
        }
    }
}
