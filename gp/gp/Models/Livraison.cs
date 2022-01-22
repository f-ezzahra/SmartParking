using Realms;
using System;
using System.Collections.Generic;

namespace gp.Models
{

    public class Livraison : RealmObject
    {

        [PrimaryKey]
        public string LivraisonId { get; set; } = Guid.NewGuid().ToString();

        public string NomEmetteur { get; set; }

        public string CINEmetteur { get; set; }

        public string Tel { get; set; }
        public string Adresse1 { get; set; }

        public string NomCollecteur { get; set; }

        public string CINCollecteur { get; set; }

        public string Adresse2 { get; set; }

        public IList<Colis> Coliss { get; }
    }
}