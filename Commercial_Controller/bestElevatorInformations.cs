namespace Commercial_Controller
{
    public class BestElevatorInformations
    {
        public Elevator bestElevator;
        public int bestScore;
        public int referenceGap;
        public BestElevatorInformations(Elevator _bestElevator, int _bestScore, int _referenceGap)
        {
            this.bestElevator = _bestElevator;
            this.bestScore = _bestScore;
            this.referenceGap = _referenceGap;
        }
        /*public Elevator bestElevator(oneElevator){
            this.bestElevator1 = oneElevator;
            return bestElevator1;
        }
        public bestScore(){  
            return bestScore;
        }
        public referenceGap(){
            return referenceGap;
        }*/
    }
}