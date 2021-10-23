namespace Commercial_Controller
{
    public class Door
    {
        public int  ID;
        public string status;
        public Door(int _id, string _status)
        {
            this.ID = _id;
            this.status = _status;
        }
    }
}