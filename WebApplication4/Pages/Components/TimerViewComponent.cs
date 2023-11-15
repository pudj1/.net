using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Components

{

    [ViewComponent]

    public class Timer

    {

        public string Invoke()

        {

            return $"Current time: {DateTime.Now.ToString("HH:mm:ss")}";

        }

    }

}