namespace RunningProcessStop.Client
{
    public abstract class BaseClient
    {
        protected static string _token = "HSDhjzSyPMfOfeAeUwUkdZP7SXevFg1yjzK5HerlkDfWhW1ffDE8klHYZZFyPghmU1AvapTF9wzmz1XaQBtQTvxOIjIVOcdzIuBltby0Dtj2XvMk9xDP5LSDwTZ69LB5X99ROuTvAhXJZvIdv3PaMcJglEWIgYqpwBzBfs9elpwj1uQV0VsDZ5JABhWedqQ6zS3vMK3XpriRrOohqoyk5avFePLcf3BWA0kMZVBLhZspWjQM7lkMkpQFWVjXZtLfAjYPWv4ksUuw2LEs6yGEVFwBvFDQlOfD4jTVhB8vi3XZi34kJU3rzSqKgfqBXkDWxrEl83PfKOOa1vsVR33y8ThTB10EjZ1r86IzHa3wsGEH6IfWmLWMjv8jMhdAVVic5tws7jethQQMs4dYyFQXKulOGPlrwcfeylklQEMJAtVZ5MqCq9HviBodREGtxbgiQfPL5qyG8rTpI8iAvEtBXTxfkPqFLi9hkfEbTkTchQgox7cSMPlUdiXQROymR5ME";
        protected readonly HttpClient _httpClient = new HttpClient(); //{ BaseAddress = new Uri("") };
    }
}
