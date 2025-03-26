NotificationService notificationService = new NotificationService();

// Subscribe to events with appropriate notification methods
notificationService.UserRegistered += notificationService.SendEmail;
notificationService.UserRegistered += notificationService.SendSMS;
notificationService.PasswordReset += notificationService.SendEmail;
notificationService.PasswordReset += notificationService.SendPushNotification;

// Simulate user registration and password reset events
Thread thread = new Thread(() => notificationService.OnUserRegistered("ram"));
thread.Start();

/* ParameterizedThreadStart is useful for passing parameters to methods executed by separate threads, 
 * but it requires careful handling of type conversions.
Consider synchronization mechanisms (Join, Mutex, Monitor, etc.) to coordinate thread execution
and avoid race conditions when necessary.*/

//Thread thread1 = new Thread(new ParameterizedThreadStart(notificationService.OnUserRegistered));
//thread1.Start("ramya");
//thread1.Join();


//notificationService.OnUserRegistered("ramya");
notificationService.OnPasswordReset("ramya");

public class NotificationService
{
    public delegate void SendNotification(string recipient, string message);
    public event SendNotification? UserRegistered;
    public event SendNotification? PasswordReset;
    public void SendEmail(string recipient, string message)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
        // Code to send email...
    }

    public void SendSMS(string recipient, string message)
    {
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
        // Code to send SMS...
    }

    public void SendPushNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending push notification to {recipient}: {message}");
        // Code to send push notification...
    }

    public void OnUserRegistered(string username)
    {
        UserRegistered(username, "Welcome! You have successfully registered.");
        //  UserRegistered?.Invoke(username, "Welcome! You have successfully registered.");
    }
    //public void OnUserRegistered(object usr)
    //{
    //    string username = (string)usr;
    //    UserRegistered(username, "Welcome! You have successfully registered.");
    //  //  UserRegistered?.Invoke(username, "Welcome! You have successfully registered.");
    //}

    public void OnPasswordReset(string username)
    {
        PasswordReset?.Invoke(username, "Your password has been reset successfully.");
    }
}

