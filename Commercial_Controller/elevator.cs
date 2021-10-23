using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int amountOfFloors;
        public int currentFloor;
        public string direction;
        public bool overweight;
        public List<int> floorRequestList;
        public Door door;
        public Elevator(string _id, string _status, int  _amountOfFloors, int _currentFloor)
        {
            //---------------------------------Initialization--------------------------------------------
            this.ID = _id;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.currentFloor = _currentFloor;
            this.door = new Door(int.Parse(ID), "closed");
            this.floorRequestList = new List<int>();
            this.direction = null;
            this.overweight = false;
            
        }
        public void move()
        { 
            while(floorRequestList.Count != 0) 
            {
                int destination = floorRequestList[0];
                this.status = "moving";
                if (this.currentFloor < destination)
                {
                    direction = "up";
                    sortFloorList();
                    while (this.currentFloor < destination)
                    {
                        currentFloor = currentFloor + 1;
                        //screenDisplay = currentFloor;
                    }
                }
                else if (this.currentFloor > destination)
                {
                    this.direction = "down";
                    sortFloorList();
                    while (this.currentFloor > destination)
                    {
                        currentFloor--;
                        //screenDisplay = currentFloor;
                    }
                }
                    this.status = "stopped";
                    this.operateDoors();
                    floorRequestList.RemoveAt(0);
            }
            this.status = "idle";
        }
        //---------------------------------Methods--------------------------------------------
        

        public void sortFloorList()
        {
            if (this.direction == "up")
            {
                floorRequestList.Sort();
            }
            else
            { 
                floorRequestList.Sort((a,b) => b.CompareTo(a)); //A voir
            }
        }

        public void operateDoors()
        {
            this.door.status = "opened";
            Thread.Sleep(5000);
            if (overweight == true){
                this.door.status = "closing";
                if (this.door.status != "obstructed")
                {
                    this.door.status = "closed";
                }
                else
                {
                    operateDoors();
                }    
            }     
            else
            {
                while (this.overweight)
                {
                    this.overweight = false;
                }
                operateDoors();
            }
        }

        public void addNewRequest(int requestedFloor)
        {
            if(!this.floorRequestList.Contains(requestedFloor))
            {
                this.floorRequestList.Add(requestedFloor);
            }

            if (this.currentFloor < requestedFloor)
            {
                this.direction = "up";
            }
            if (this.currentFloor > requestedFloor)
            {
                this.direction = "down";
            }
        }
        
    }
}