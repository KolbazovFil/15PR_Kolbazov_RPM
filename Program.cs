using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace _15PR_Kolbazov_RPM
{
    public abstract class Command   // Абстрактный класс Command.
    {
        public abstract void Execute(); // Абстрактный метод Execute(), который будет выполнять команду.
    }
    public class LightOnCommand : Command   // Класс LightOnCommand который наследуется от Command.
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()  // Реализация метода Execute().

        {
            light.On();
        }
    }
    public class LightOffCommand : Command  // Класс LightOffCommand который наследуется от Command.
    {
        private Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            light.Off();
        }
    }
    public class LightSettingsCommand : Command // Класс LightSettingsCommand который наследуется от Command.
    {
        private Light light;
        public LightSettingsCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            light.Settings();
        }
    }
    public class AirConditionerOnCommand : Command  // Класс AirConditionerOnCommand который наследуется от Command.
    {
        private AirConditioner airConditioner;
        public AirConditionerOnCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            airConditioner.On();
        }
    }
    public class AirConditionerOffCommand : Command // Класс AirConditionerOffCommand который наследуется от Command.
    {
        private AirConditioner airConditioner;
        public AirConditionerOffCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            airConditioner.Off();
        }
    }
    public class AirConditionerSettingsCommand : Command    // Класс AirConditionerSettingsCommand который наследуется от Command.
    {
        private AirConditioner airConditioner;
        public AirConditionerSettingsCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            airConditioner.Settings();
        }
    }
    public class TVOnCommand : Command  // Класс TVOnCommand который наследуется от Command.
    {
        private TV tv;
        public TVOnCommand(TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            tv.On();
        }
    }
    public class TVOffCommand : Command // Класс TVOffCommand который наследуется от Command.
    {
        private TV tv;
        public TVOffCommand(TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            tv.Off();
        }
    }
    public class TVSettingsCommand : Command    // Класс TVSettingsCommand который наследуется от Command.
    {
        private TV tv;
        public TVSettingsCommand(TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()  // Реализация метода Execute().
        {
            tv.Settings();
        }

    }
    public class Light  // Класс Light
    {
        public void On()    // Метод для включения
        {
            Console.WriteLine("Свет включен!");
        }
        public void Off()   // Метод для выключения
        {
            Console.WriteLine("Свет выключен!");
        }
        public void Settings()  // Метод для изменения параметров
        {
            Console.WriteLine("Изменение параметров света!");
        }
    }
    public class AirConditioner // Класс AirConditioner
    {
        public void On()    // Метод для включения
        {
            Console.WriteLine("Кондиционер включен!");
        }
        public void Off()   // Метод для выключения
        {
            Console.WriteLine("Кондиционер выключен!");
        }
        public void Settings()  // Метод для изменения параметров
        {
            Console.WriteLine("Изменение параметров кондиционера!");
        }
    }
    public class TV // Класс TV
    {
        public void On()    // Метод для включения
        {
            Console.WriteLine("Телевизор включен!");
        }
        public void Off()   // Метод для выключения
        {
            Console.WriteLine("Телевизор выключен!");
        }
        public void Settings()  // Метод для изменения параметров
        {
            Console.WriteLine("Изменение параметров телевизора!");
        }
    }
    public class RemoteControl  // Класс RemoteControl
    {
        private Command command;    // Приватное поле command типа Command, которое будет хранить текущую команду.
        public void SetCommand(Command command) // Метод SetCommand(Command command), который будет устанавливать текущую команду.
        {
            this.command = command;
        }
        public void PressButton()   // Метод PressButton(), который будет выполнять текущую команду.
        {
            command.Execute();
        }
    }
    // --------------------------------------------------------------------------
    public abstract class TaxCalculationStrategy    // Абстрактный класс TaxCalculationStrategy
    {
        public abstract decimal CalculateTax(decimal income);   // Абстрактный метод CalculateTax(decimal income), который будет рассчитывать налог на доходы.
    }
    public class ProgressiveTaxCalculationStrategy : TaxCalculationStrategy // Класс ProgressiveTaxCalculationStrategy который наследуются от TaxCalculationStrategy
    {
        public override decimal CalculateTax(decimal income)    // Реализация метода CalculateTax(decimal income)
        {
            if (income <= 2400000)
            {
                return income * 0.13m;
            }
            else if (income > 2400000 && income <= 5000000)
            {
                return income * 0.15m;
            }
            else if (income > 5000000 && income <= 20000000)
            {
                return income * 0.18m;
            }
            else if (income > 20000000 && income <= 50000000)
            {
                return income * 0.20m;
            }
            else
            {
                return income * 0.22m;
            }
        }
    }
    public class FixedRateTaxCalculationStrategy : TaxCalculationStrategy   // Класс FixedRateTaxCalculationStrategy который наследуются от TaxCalculationStrategy
    {
        private decimal fixedRate;
        public FixedRateTaxCalculationStrategy(decimal fixedRate)
        {
            this.fixedRate = fixedRate;
        }
        public override decimal CalculateTax(decimal income)    // Реализация метода CalculateTax(decimal income)
        {
            return income * fixedRate;
        }
    }
    public class TaxCalculator  // Класс TaxCalculator
    {
        private TaxCalculationStrategy taxCalculationStrategy;  // Приватное поле taxCalculationStrategy типа TaxCalculationStrategy, которое будет хранить текущий алгоритм расчета налогов.
        public void SetTaxCalculationStrategy(TaxCalculationStrategy taxCalculationStrategy)    // Метод SetTaxCalculationStrategy(TaxCalculationStrategy taxCalculationStrategy), который будет устанавливать текущий алгоритм расчета налогов.
        {
            this.taxCalculationStrategy = taxCalculationStrategy;
        }
        public decimal CalculateTax(decimal income) // Метод CalculateTax(decimal income), который будет рассчитывать налог на доходы с использованием текущего алгоритма расчета налогов.
        {
            if (taxCalculationStrategy == null)
            {
                throw new Exception("Стратегия расчёта налогов не установлена!");
            }
            return taxCalculationStrategy.CalculateTax(income);
        }
    }
    // --------------------------------------------------------------------------
    public abstract class Observer  // Абстрактный класс Observer
    {
        public abstract void Update(string message);    // Абстрактный метод Update(string message), который будет вызываться при изменении состояния сервера.
    }
    public class Logger : Observer  // Класс Logger который наследуется от Observer
    {
        public override void Update(string message) // Реализация метода Update(string message) для каждого подписчика.
        {
            Console.WriteLine($"Логгер: {message}");
        }
    }
    public class EmailNotifier : Observer   // Класс EmailNotifier который наследуется от Observer
    {
        public override void Update(string message) // Реализация метода Update(string message) для каждого подписчика.
        {
            Console.WriteLine($"Уведомление по электронной почте: {message}");
        }
    }
    public class Server // Класс Server
    {
        private List<Observer> observers = new List<Observer>();    // Приватное поле observers типа List<Observer>, которое будет хранить список подписчиков.
        public void Attach(Observer observer)   // Метод Attach(Observer observer), который будет добавлять подписчика в список подписчиков.
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)   // Метод Detach(Observer observer), который будет удалять подписчика из списка подписчиков.
        {
            observers.Remove(observer);
        }
        public void Notify(string message)  // Метод Notify(string message), который будет уведомлять всех подписчиков об изменении состояния сервера.
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
    // --------------------------------------------------------------------------
    public abstract class DocumentState // Абстрактный класс DocumentState
    {
        public abstract void Open();    // Абстрактные метод Open(), который будет вызываться при соответствующих действиях пользователя.
        public abstract void Save();    // Абстрактные метод Save(), который будет вызываться при соответствующих действиях пользователя.
        public abstract void Close();   // Абстрактные метод Close(), который будет вызываться при соответствующих действиях пользователя.
        public abstract void Print();   // Абстрактные метод Print(), который будет вызываться при соответствующих действиях пользователя.
    }
    public class NewState : DocumentState   // Класс NewState, который наследуются от DocumentState
    {
        public override void Open() // Реализация метода Open()
        {
            Console.WriteLine("Документ открыт!");
        }
        public override void Save() // Реализация метода Save()
        {
            Console.WriteLine("Документ должен быть сначала открыт перед сохранением!");
        }
        public override void Close()    // Реализация метода Close()
        {
            Console.WriteLine("Новый документ не требует закрытия!");
        }
        public override void Print()    // Реализация метода Print()
        {
            Console.WriteLine("Невозможно распечатать новый документ!");
        }
    }
    public class OpenState : DocumentState  // Класс OpenState, который наследуются от DocumentState
    {
        public override void Open() // Реализация метода Open()
        {
            Console.WriteLine("Документ уже открыт!");
        }
        public override void Save() // Реализация метода Save()
        {
            Console.WriteLine("Документ сохранён!");
        }
        public override void Close()    // Реализация метода Close()
        {
            Console.WriteLine("Документ закрыт!");
        }
        public override void Print()    // Реализация метода Print()
        {
            Console.WriteLine("Документ распечатан!");
        }
    }
    public class SavedState : DocumentState // Класс SavedState, который наследуются от DocumentState
    {
        public override void Open() // Реализация метода Open()
        {
            Console.WriteLine("Документ открыт из сохраненного состояния!");
        }
        public override void Save() // Реализация метода Save()
        {
            Console.WriteLine("Документ уже сохранён!");
        }
        public override void Close()    // Реализация метода Close()
        {
            Console.WriteLine("Документ закрыт!");
        }
        public override void Print()    // Реализация метода Print()
        {
            Console.WriteLine("Документ распечатан!");
        }
    }
    public class ModifiedSate : DocumentState   // Класс ModifiedSate, который наследуются от DocumentState
    {
        public override void Open() // Реализация метода Open()
        {
            Console.WriteLine("Документ открыт с несохраненными изменениями!");
        }
        public override void Save() // Реализация метода Close()
        {
            Console.WriteLine("Изменения сохранены!");
        }
        public override void Close()    // Реализация метода Close()
        {
            Console.WriteLine("Документ закрыт. Изменения не были сохранены!");
        }
        public override void Print()    // Реализация метода Print()
        {
            Console.WriteLine("Документ распечатан с учётом изменений!");
        }
    }
    public class Document   // Класс Document
    {
        private DocumentState state;    // Приватное поле state типа DocumentState, которое будет хранить текущее состояние документа.
        public Document()
        {
            state = new NewState();
        }
        public void SetState(DocumentState state)   // Метод SetState(DocumentState state), который будет устанавливать текущее состояние документа.
        {
            this.state = state;
        }
        public void Open()  // Метод Open(), который будет вызывать соответствующие методы текущего состояния документа.
        {
            state.Open();
        }
        public void Save()  // Метод Save(), который будет вызывать соответствующие методы текущего состояния документа.
        {
            state.Save();
        }
        public void Close() // Метод Close(), который будет вызывать соответствующие методы текущего состояния документа.
        {
            state.Close();
        }
        public void Print() // Метод Print(), который будет вызывать соответствующие методы текущего состояния документа.
        {
            state.Print();
        }

    }
    // --------------------------------------------------------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();
            AirConditioner airConditioner = new AirConditioner();
            TV tv = new TV();
            RemoteControl remote = new RemoteControl();
            Console.WriteLine("Выберите устройство: (1) Свет, (2) Кондицинер, (3) Телевизор");
            int choiceDevice = Convert.ToInt32(Console.ReadLine());
            switch (choiceDevice)
            {
                case 1:
                    Console.WriteLine("Вы выбрали свет");
                    if (choiceDevice == 1)
                    {
                        Console.WriteLine("Выберите действие: (1) включить свет, (2) выключить свет, (3) параметры света");
                        int choiceLight = Convert.ToInt32(Console.ReadLine());
                        switch (choiceLight)
                        {
                            case 1:
                                Command lightOn = new LightOnCommand(light);
                                remote.SetCommand(lightOn);
                                remote.PressButton();
                                break;
                            case 2:
                                Command lightOff = new LightOffCommand(light);
                                remote.SetCommand(lightOff);
                                remote.PressButton();
                                break;
                            case 3:
                                Command lightSettings = new LightSettingsCommand(light);
                                remote.SetCommand(lightSettings);
                                remote.PressButton();
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор!");
                                break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Вы выбрали кондицинер");
                    if (choiceDevice == 2)
                    {
                        Console.WriteLine("Выберите действие: (1) включить кондицинер, (2) выключить кондицинер, (3) параметры кондицинера");
                        int choiceAirConditioner = Convert.ToInt32(Console.ReadLine());
                        switch (choiceAirConditioner)
                        {
                            case 1:
                                Command airConditionerOn = new AirConditionerOnCommand(airConditioner);
                                remote.SetCommand(airConditionerOn);
                                remote.PressButton();
                                break;
                            case 2:
                                Command airConditionerOff = new AirConditionerOffCommand(airConditioner);
                                remote.SetCommand(airConditionerOff);
                                remote.PressButton();
                                break;
                            case 3:
                                Command airConditionerSettings = new AirConditionerSettingsCommand(airConditioner);
                                remote.SetCommand(airConditionerSettings);
                                remote.PressButton();
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор!");
                                break;
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Вы выбрали телевизор");
                    if (choiceDevice == 3)
                    {
                        Console.WriteLine("Выберите действие: (1) включить телевизор, (2) выключить телевизор, (3) параметры телевизора");
                        int choiceTV = Convert.ToInt32(Console.ReadLine());
                        switch (choiceTV)
                        {
                            case 1:
                                Command tvOn = new TVOnCommand(tv);
                                remote.SetCommand(tvOn);
                                remote.PressButton();
                                break;
                            case 2:
                                Command tvOff = new TVSettingsCommand(tv);
                                remote.SetCommand(tvOff);
                                remote.PressButton();
                                break;
                            case 3:
                                Command tvSettings = new TVSettingsCommand(tv);
                                remote.SetCommand(tvSettings);
                                remote.PressButton();
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор!");
                                break;
                        }
                    }
                    break;
            }
            // --------------------------------------------------------------------------
            TaxCalculator taxCalculator = new TaxCalculator();
            Console.Write("\nВведите доход физическошо лица в российских рублях: ");
            decimal income = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\nВыберите систему налогообложения: (1) Прогрессивная ставка, (2) Фиксированная ставка");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ProgressiveTaxCalculationStrategy strategy = new ProgressiveTaxCalculationStrategy();
                    taxCalculator.SetTaxCalculationStrategy(strategy);
                    break;
                case 2:
                    Console.WriteLine("\nВведите фиксированную ставку (например, 0.13 для 13%): ");
                    decimal fixedRate = Convert.ToDecimal(Console.ReadLine());
                    FixedRateTaxCalculationStrategy fix = new FixedRateTaxCalculationStrategy(fixedRate);
                    taxCalculator.SetTaxCalculationStrategy(fix);
                    break;
                default:
                    Console.WriteLine("\nНекорректный выбор!");
                    break;
            }
            decimal tax = taxCalculator.CalculateTax(income);
            Console.WriteLine($"\nСумма налога: {tax}");
            // --------------------------------------------------------------------------
            Server server = new Server();
            Logger logger = new Logger();
            EmailNotifier emailNotifier = new EmailNotifier();
            server.Attach(logger);
            server.Attach(emailNotifier);
            while (true)
            {
                Console.Write("\nВведите сообщение для уведомления (или 'выход' для выхода): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "выход")
                    break;

                server.Notify(input);
            }
            // --------------------------------------------------------------------------
            Document doc = new Document(); // Создаем экземпляр документа
            string str;
            Console.Write("Введите команду (открыть, сохранить, закрыть, печать, выход): ");
            while ((str = Console.ReadLine()) != "выход")
            {
                switch (str.ToLower())
                {
                    case "открыть":
                        doc.Open();
                        break;
                    case "сохранить":
                        doc.Save();
                        break;
                    case "закрыть":
                        doc.Close();
                        break;
                    case "печать":
                        doc.Print();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
                Console.Write("Введите следующую команду (открыть, сохранить, закрыть, распечатать, выход): ");
            }
            Console.ReadLine();
        }
    }
}
