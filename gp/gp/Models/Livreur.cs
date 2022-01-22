using Realms;

namespace gp.Models
{
    public class Livreur : RealmObject
    {
        [PrimaryKey]
        public int LivreurId { get; set; }
        public string LivreurName { get; set; }
        public string LivreurTel { get; set; }

        public string LivreurAdresse { get; set; }
    }
}
