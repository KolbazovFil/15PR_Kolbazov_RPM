using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PR_Kolbazov_RPM
{
    public abstract class Command
    {
        public abstract void Execute();
    }
    public class LightOnCommand : Command
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()
        {
            light.On();
        }
    }
    public class LightOffCommand : Command
    {
        private Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()
        {
            light.Off();
        }
    }
    public class AirConditionerOnCommand : Command
    {
        private AirConditioner airConditioner;
        public AirConditionerOnCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()
        {
            airConditioner.On();
        }
    }
    public class AirConditionerOffCommand : Command
    {
        private AirConditioner airConditioner;
        public AirConditionerOffCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()
        {
            airConditioner.Off();
        }
    }
    public class TVOnCommand : Command
    {
        private TV tv;
        public TVOnCommand (TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()
        {
            tv.On();
        }
    }
    public class TVOffCommand : Command
    {
        private TV tv;
        public TVOffCommand(TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()
        {
            tv.Off();
        }
    }
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Свет включен!");
        }
        public void Off()
        {
            Console.WriteLine("Свет выключен!");
        }
        public void Settings()
        {
            Console.WriteLine("Изменение параметров!");
        }
    }
    public class AirConditioner
    {
        public void On()
        {
            Console.WriteLine("Кондиционер включен!");
        }
        public void Off()
        {
            Console.WriteLine("Кондиционер выключен!");
        }
        public void Settings()
        {
            Console.WriteLine("Изменение параметров!");
        }
    }
    public class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }
        public void Off()
        {
            Console.WriteLine("Телевизор выключен!");
        }
        public void Settings()
        {
            Console.WriteLine("Изменение параметров!");
        }
    }
    public class RemoteControl
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        public void PressButton()
        {
            command.Execute();
        }
    }
    // --------------------------------------------------------------------------

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем устройства
            Light light = new Light();
            AirConditioner airConditioner = new AirConditioner();
            TV tv = new TV();

            // Создаем команды
            Command lightOn = new LightOnCommand(light);
            Command lightOff = new LightOffCommand(light);
            Command airConditionerOn = new AirConditionerOnCommand(airConditioner);
            Command airConditionerOff = new AirConditionerOffCommand(airConditioner);
            Command tvOn = new TVOnCommand(tv);
            Command tvOff = new TVOffCommand(tv);

            // Создаем пульт управления
            RemoteControl remote = new RemoteControl();

            // Включаем свет
            remote.SetCommand(lightOn);
            remote.PressButton();

            // Выключаем свет
            remote.SetCommand(lightOff);
            remote.PressButton();

            // Включаем кондиционер
            remote.SetCommand(airConditionerOn);
            remote.PressButton();

            // Выключаем кондиционер
            remote.SetCommand(airConditionerOff);
            remote.PressButton();

            // Включаем телевизор
            remote.SetCommand(tvOn);
            remote.PressButton();

            // Выключаем телевизор
            remote.SetCommand(tvOff);
            remote.PressButton();
            Console.ReadLine();
        }
    }
}
