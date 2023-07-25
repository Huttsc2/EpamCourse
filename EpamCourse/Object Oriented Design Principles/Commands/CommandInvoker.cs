namespace EpamCourse.Object_Oriented_Design_Principles.Commands
{
    public class CommandInvoker
    {
        private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public CommandInvoker(CarManager carManager)
        {
            _commands["count types"] = new CountTypesCommand(carManager);
            _commands["count all"] = new CountAllCommand(carManager);
            _commands["average price"] = new AveragePriceCommand(carManager);
            _commands["average price type"] = new AveragePriceTypeCommand(carManager);
            _commands["exit"] = new ExitCommand();
        }

        public void ExecuteCommand(string command, string argument = null)
        {
            if (!_commands.TryGetValue(command, out ICommand? cmd))
            {

                Console.WriteLine("Unknown command");
                return;
            }

            if (cmd is AveragePriceTypeCommand averagePriceTypeCommand)
            {
                averagePriceTypeCommand.SetArguments(argument);
            }

            cmd.Execute();
        }
    }
}
