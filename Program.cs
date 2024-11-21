using System;
using System.Collections.Generic;

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
    public class LightSettingsCommand : Command
    {
        private Light light;
        public LightSettingsCommand(Light light)
        {
            this.light = light;
        }
        public override void Execute()
        {
            light.Settings();
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
    public class AirConditionerSettingsCommand : Command
    {
        private AirConditioner airConditioner;
        public AirConditionerSettingsCommand(AirConditioner airConditioner)
        {
            this.airConditioner = airConditioner;
        }
        public override void Execute()
        {
            airConditioner.Settings();
        }
    }
    public class TVOnCommand : Command
    {
        private TV tv;
        public TVOnCommand(TV tv)
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
    public class TVSettingsCommand : Command
    {
        private TV tv;
        public TVSettingsCommand(TV tv)
        {
            this.tv = tv;
        }
        public override void Execute()
        {
            tv.Settings();
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
            Console.WriteLine("Изменение параметров света!");
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
            Console.WriteLine("Изменение параметров кондиционера!");
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
            Console.WriteLine("Изменение параметров телевизора!");
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
    public abstract class TaxCalculationStrategy
    {
        public abstract decimal CalculateTax(decimal income);
    }
    public class ProgressiveTaxCalculationStrategy : TaxCalculationStrategy
    {
        public override decimal CalculateTax(decimal income)
        {
            if (income <= 10000)
            {
                return income * 0.1m; // 10% для дохода до 10,000
            }
            else if (income <= 30000)
            {
                return 1000 + (income - 10000) * 0.2m; // 20% для дохода от 10,001 до 30,000
            }
            else
            {
                return 5000 + (income - 30000) * 0.3m; // 30% для дохода свыше 30,000
            }
        }
    }
    public class FixedRateTaxCalculationStrategy : TaxCalculationStrategy
    {
        private decimal fixedRate;
        public FixedRateTaxCalculationStrategy(decimal fixedRate)
        {
            this.fixedRate = fixedRate;
        }
        // Реализация метода CalculateTax() для фиксированной ставки налога
        public override decimal CalculateTax(decimal income)
        {
            return income * fixedRate; // Расчет налога по фиксированной ставке
        }
    }
    public class TaxCalculator
    {
        private TaxCalculationStrategy taxCalculationStrategy;
        public void SetTaxCalculationStrategy(TaxCalculationStrategy taxCalculationStrategy)
        {
            this.taxCalculationStrategy = taxCalculationStrategy;
        }
        public decimal CalculateTax(decimal income)
        {
            if (taxCalculationStrategy == null)
            {
                throw new InvalidOperationException("Стратегия расчёта налогов не установлена!");
            }
            return taxCalculationStrategy.CalculateTax(income); // Выполнение расчета налога 
        }
    }
    // --------------------------------------------------------------------------
    public abstract class Observer
    {
        public abstract void Update(string message);
    }
    public class Logger : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
    public class EmailNotifier : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine($"[EMAIL NOTIFICATION] {message}");
        }
    }
    public class Server
    {
        private List<Observer> observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
    // --------------------------------------------------------------------------
    public abstract class DocumentState
    {
        public abstract void Open();
        public abstract void Save();
        public abstract void Close();
        public abstract void Print();
    }
    public class NewState : DocumentState
    {
        public override void Open()
        {
            Console.WriteLine("Документ открыт!");
        }
        public override void Save()
        {
            Console.WriteLine("Документ должен быть сначала открыт перед сохранением!");
        }
        public override void Close()
        {
            Console.WriteLine("Новый документ не требует закрытия!");
        }
        public override void Print()
        {
            Console.WriteLine("Невозможно распечатать новый документ!");
        }
    }
    public class OpenState : DocumentState
    {
        public override void Open()
        {
            Console.WriteLine("Документ уже открыт!");
        }
        public override void Save()
        {
            Console.WriteLine("Документ сохранён!");
        }
        public override void Close()
        {
            Console.WriteLine("Документ закрыт!");
        }
        public override void Print()
        {
            Console.WriteLine("Документ распечатан!");
        }
    }
    public class SavedState : DocumentState
    {
        public override void Open()
        {
            Console.WriteLine("Документ открыт из сохраненного состояния!");
        }
        public override void Save()
        {
            Console.WriteLine("Документ уже сохранён!");
        }
        public override void Close()
        {
            Console.WriteLine("Документ закрыт!");
        }
        public override void Print()
        {
            Console.WriteLine("Документ распечатан!");
        }
    }
    public class ModifiedSate : DocumentState
    {
        public override void Open()
        {
            Console.WriteLine("Документ открыт с несохраненными изменениями!");
        }
        public override void Save()
        {
            Console.WriteLine("Изменения сохранены!");
        }
        public override void Close()
        {
            Console.WriteLine("Документ закрыт. Изменения не были сохранены!");
        }
        public override void Print()
        {
            Console.WriteLine("Документ распечатан с учётом изменений!");
        }
    }
    public class Document
    {
        private DocumentState state;
        public Document()
        {
            state = new NewState();
        }
        public void SetState(DocumentState state)
        {
            this.state = state;
        }
        public void Open()
        {
            state.Open();
        }
        public void Save()
        {
            state.Save();
        }
        public void Close()
        {
            state.Close();
        }
        public void Print()
        {
            state.Print();
        }

    }
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
                        }
                    }
                    break;
            }
            // --------------------------------------------------------------------------

            TaxCalculator taxCalculator = new TaxCalculator();
            Console.WriteLine("Введите ваш доход: ");
            decimal income = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Выберите систему налогообложения: (1) Прогрессивная ставка, (2) Фиксированная ставка");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    taxCalculator.SetTaxCalculationStrategy(new ProgressiveTaxCalculationStrategy());
                    break;
                case 2:
                    Console.WriteLine("Введите фиксированную ставку (например, 0.15 для 15%): ");
                    decimal fixedRate = Convert.ToDecimal(Console.ReadLine());
                    taxCalculator.SetTaxCalculationStrategy(new FixedRateTaxCalculationStrategy(fixedRate));
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    return;
            }
            decimal tax = taxCalculator.CalculateTax(income); // Рассчитываем налог
            Console.WriteLine($"Сумма налога: {tax}");
            // --------------------------------------------------------------------------

            Server server = new Server(); // Создаем экземпляр сервера
            Logger logger = new Logger(); // Создаем экземпляр логгера
            EmailNotifier emailNotifier = new EmailNotifier(); // Создаем экземпляр EmailNotifer

            server.Attach(logger); // Добавляем логгер в список подписчиков
            server.Attach(emailNotifier); // Добавляем EmailNotifier в список подписчиков

            server.Notify("Работает");
            server.Notify("Ошибка 500");
            server.Notify("Восстановлен");
            // --------------------------------------------------------------------------

            Document doc = new Document(); // Создаем экземпляр документа

            doc.Open();  // Открываем новый документ
            doc.Save();  // Сохраняем документ 
            doc.Print(); // Печатаем документ 

            doc.Close(); // Закрываем документ 

            doc.Open();  // Открываем документ снова 
            doc.Save();  // Сохраняем его снова 




            Console.ReadLine();
        }
    }
}
