namespace SoalTes_FullStack_NET_V1.Model
{
    public class users
    {
        public string status { get; set; }

        public List<Data> data { get; set; }
        
    }

    public class Data 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }

    }

}
