namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class CallButton
    {
        int ID;
        string status;
        int floor;
        string direction;
        public CallButton(int _id, string _status, int _floor, string _direction)
        {
            this.ID = _id;
            this.status = _status;
            this.floor = _floor;
            this.direction = _direction;
            
        }
    }
}