public class Raund {

    public int Time { get; set; }
    public bool IsCurrentRaund { get; set; }

    public Raund(int time) {
        this.Time = time;
        IsCurrentRaund = false;
    }

    public void ActiveRaund() {
        IsCurrentRaund = true;
    }

    public void DeactiveRaund() {
        IsCurrentRaund = false;
    }

}
