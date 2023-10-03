using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.UI._6
{
   /// <summary>
   /// Représente un Selfie avec un Wookie lié
   /// </summary>
    public class Selfie
    {
        #region Properties
        public int Id { get; set; }
        public string  Title { get; set; }
        public string ImagePath { get; set; }
        public int WookieId { get; set; }// En faisant ceci il va chercher le Wookie directement (et faire le lien)
        public Wookie Wookie { get; set; } //Je mets cette propriété par relationnel
                                          //entre un Wookie et un Selfie: Il faut un wookie pour un ou +sieurs Selfie(s)

        #endregion
    }
}
