using SocketIO;

public class Client : SocketIOComponent
{
    public override void Start()
    {
        base.Start();
        SetupEvents();
    }
    
    public override void Update()
    {
        base.Update();
    }

    private void SetupEvents()
    {
        // RECIEVING
        On("open", (data) => // -------------- when connected
        {
            print("Connection made to server ^^");
        });
        
        On("leaderboard", (data) => // -------------- when connected
        {
            print("LeaderBoard incoming");
        });
    }

    public void PostScore(string name, int score)
    {
        //Emit("newscore", );
    }
}
