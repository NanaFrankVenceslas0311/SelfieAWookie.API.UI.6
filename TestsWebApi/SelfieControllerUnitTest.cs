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
            // M�thode des 3A

            // Arrange (pour pr�parer les jeux de donn�es)
            // => c'est pour renvoyer des donn�es, on va juste faire une requ�te
            // car pas de donn�es � envoyer, on va pr�parer notre contr�leur

            // Pour les phases de test on va utiliser un MOCK

            var repositoryMock = new Mock<ISelfieRepository>(); // On moque notre ISelfieRepository et en faisant cela on va se pr�parer 
                                                                // de faire passer un repositoryMock.Object

            // Ici nous pouvons retourner ce que nous voulons
            object value = repositoryMock.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie(),
                new Selfie()
              
            });

            var controller = new SelfiesController(repositoryMock.Object); // ce repositoryMock.Object cr�e une instance � sa
                                                                           // fa�on et c'est une instance qui impl�mente une interface � sa fa�on 


            // ACT (les actions qu'on va faire : on va r�cup�rer un r�sultat
            // En simulant le fait qu'on trouve une URL qui s'appelle TestAMoi()


            var result = controller.TestAMoi(); //Au moment du d�bogage de mon programme je r�cup�re mon contr�leur
                                                // Et je lance TestMoi()

            // ASSERTION (Pour prouver que c'est vrai) : On veut s'assurer (assert) que le r�sultat 
            // est non null (NOTNULL) et que si le resultat est vrai (True), qu'il r�cup�re un �l�ment

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

                                                                 
            
            Assert.NotNull(okResult.Value);
            Assert.IsType<List<SelfieResumeDto>>(okResult.Value); // cr�er directement un OkResult.Value 
                                                                 // nous permet de cadrer ce qu'on va faire car il va
            List<SelfieResumeDto> list = okResult.Value as List<SelfieResumeDto>;
            Assert.True(list.Count == 2); // le 2 correspond au 2 instances du repositoryMock (les 2 new (Selfie))

            #endregion
        }
    }
}