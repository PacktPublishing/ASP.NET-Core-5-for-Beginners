namespace Chapter_03_QuickStart.DataManager
{
    public class Notifier : INotifier
    {
        public bool SendMessage(string message)
        {
            //some logic here to publish the message
            return true;
        }
    }
}
