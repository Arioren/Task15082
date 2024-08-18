namespace Task15082.Model
{
    public class MyObject
    {
        private object dataObj;

        public MyObject(object dataObj)
        {
            this.dataObj = dataObj;
        }

        public int Id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }

    }
    public class Rating
    {
        public float rate { get; set; }
        public float count { get; set; }

    }

  

}
