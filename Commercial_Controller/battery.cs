using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        int ID;
        int columnID = 1;
        public int floorRequestButtonID = 1;
        public int floor;
        public int buttonFloor = 1;
        public List<Column> columnsList;
        public List<int> servedFloors = new List<int>();
        public List<FloorRequestButton> floorButtonsList = new List<FloorRequestButton>();

        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            ID = _ID;
            columnsList = new List<Column>();
            if (_amountOfBasements > 0 )
            {
                this.createBasementFloorRequestButtons (_amountOfBasements);
                this.createBasementColumn (_amountOfBasements, _amountOfElevatorPerColumn);
                _amountOfColumns--;
            }   
            this.createFloorRequestButtons (_amountOfFloors);
            this.createColumns (_amountOfColumns, _amountOfFloors, _amountOfBasements, _amountOfElevatorPerColumn);

            
        }

        public Column findBestColumn(int _requestedFloor)
        {
            Column newcolumn = this.columnsList[0];
            foreach (Column column in this.columnsList)
            {
                if (column.servedFloorsList.Contains(_requestedFloor))
                {
                    newcolumn = column;
                }
            }
            return newcolumn; 
        }
        //Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            //int requestedFloor = Int32.Parse(_requestedFloor);
            Column column = this.findBestColumn(_requestedFloor); //A voir 
            Elevator bestElevator = column.findElevator(1, _direction); // The floor is always 1 because that request is always made from the lobby.
            bestElevator.addNewRequest(1);
            bestElevator.move();
            bestElevator.addNewRequest(_requestedFloor);
            bestElevator.move();  
            return (column, bestElevator); 
        }
        public void createBasementColumn (int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            floor = -1;
            for (int i = 0; i < _amountOfBasements; i++)
            {
                servedFloors.Add(floor);
                floor --;
            }
            string _columnID = columnID.ToString();
            Column column = new Column (_columnID, "online", _amountOfBasements, _amountOfElevatorPerColumn, servedFloors, true);
            columnsList.Add(column);
            columnID++ ;
        }
        public void createColumns (int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            int amountOfFloorsPerColumn = (int)Math.Ceiling(Convert.ToDecimal(_amountOfFloors / _amountOfColumns));
            floor = 1;
            for (int i = 0; i < _amountOfColumns; i++)
            {
                string _columnID = columnID.ToString();
                for (int j = 0; j < amountOfFloorsPerColumn; j++)
                {
                    if (floor <= _amountOfFloors)
                    {
                        servedFloors.Add(floor);
                        floor++ ;
                    }
                }
                Column column = new Column (_columnID, "online", _amountOfFloors, _amountOfElevatorPerColumn, servedFloors, false);
                columnsList.Add(column);
                columnID++ ;
            }
        }
        public void createFloorRequestButtons (int _amountOfFloors)
        {
            for (int i = 0; i <= _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton (floorRequestButtonID, "OFF", buttonFloor, "Up");
                floorButtonsList.Add(floorRequestButton);
                buttonFloor++ ;
                floorRequestButtonID++ ;
            }
        }
        public void createBasementFloorRequestButtons (int _amountOfBasements)
        {
            for (int i = 0; i < _amountOfBasements; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton (floorRequestButtonID, "OFF", buttonFloor, "Down");
                floorButtonsList.Add(floorRequestButton);
                buttonFloor-- ;
                floorRequestButtonID++ ;
            }
        }
    }
}

