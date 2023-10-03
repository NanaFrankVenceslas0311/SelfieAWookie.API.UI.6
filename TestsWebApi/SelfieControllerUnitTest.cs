using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Frameworks;
using SelfieAWookie.API.UI._6;
using SelfieAWookie.API.UI._6.Application.DTOs;
using SelfieAWookie.API.UI._6.Controllers;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Domain;
using System;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace TestsWebApi
{
    public class SelfieControllerUnitTest
    {
        #region Public methods
        [Fact]
        public void ShouldreturnListOfSelfies()
        {
            // Méthode des 3A

            // Arrange (pour préparer les jeux de données)
            // => c'est pour renvoyer des données, on va juste faire une requête
            // car pas de données à envoyer, on va préparer notre contrôleur

            // Pour les phases de test on va utiliser un MOCK

            var repositoryMock = new Mock<ISelfieRepository>(); // On moque notre ISelfieRepository et en faisant cela on va se préparer 
                                                                // de faire passer un repositoryMock.Object

            // Ici nous pouvons retourner ce que nous voulons
            object value = repositoryMock.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie(),
                new Selfie()
              
            });

            var controller = new SelfiesController(repositoryMock.Object); // ce repositoryMock.Object crée une instance à sa
                                                                           // façon et c'est une instance qui implémente une interface à sa façon 


            // ACT (les actions qu'on va faire : on va récupérer un résultat
            // En simulant le fait qu'on trouve une URL qui s'appelle TestAMoi()


            var result = controller.TestAMoi(); //Au moment du débogage de mon programme je récupère mon contrôleur
                                                // Et je lance TestMoi()

            // ASSERTION (Pour prouver que c'est vrai) : On veut s'assurer (assert) que le résultat 
            // est non null (NOTNULL) et que si le resultat est vrai (True), qu'il récupère un élément

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

                                                                 
            
            Assert.NotNull(okResult.Value);
            Assert.IsType<List<SelfieResumeDto>>(okResult.Value); // créer directement un OkResult.Value 
                                                                 // nous permet de cadrer ce qu'on va faire car il va
            List<SelfieResumeDto> list = okResult.Value as List<SelfieResumeDto>;
            Assert.True(list.Count == 2); // le 2 correspond au 2 instances du repositoryMock (les 2 new (Selfie))

            #endregion
        }
    }
}