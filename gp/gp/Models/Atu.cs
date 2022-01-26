using Realms;
using System;

namespace gp.Models
{

    public class Atu : RealmObject
    {

        [PrimaryKey]
        public string ColisId { get; set; } = Guid.NewGuid().ToString();

        public string Nom { get; set; }

        public string Type { get; set; }
        public int Reference { get; set; }


        public Reserver Livraison { get; set; }
    }
}