//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PimpYourCharacter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class personnage_tatouage_position
    {
        public int id_personnage { get; set; }
        public int id_position { get; set; }
        public int id_tatouage { get; set; }
    
        public virtual personnage personnage { get; set; }
        public virtual position position { get; set; }
        public virtual tatouage tatouage { get; set; }
    }
}
