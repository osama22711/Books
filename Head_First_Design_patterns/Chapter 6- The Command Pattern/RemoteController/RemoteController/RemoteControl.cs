// See https://aka.ms/new-console-template for more information

using RemoteController.Commands;
using System.Text;

namespace RemoteController
{
    public class RemoteControl
    {
        public List<ICommand> onCommands;
        public List<ICommand> offCommands;
        private const int BUTTONS_COUNT = 7;

        public RemoteControl()
        {
            onCommands = new List<ICommand>(BUTTONS_COUNT);
            offCommands = new List<ICommand>(BUTTONS_COUNT);

            var noCommand = new NoCommand();
            for (int i = 0; i < BUTTONS_COUNT; i++)
            {
                onCommands.Add(noCommand);
                offCommands.Add(noCommand);
            }
        }

        public void setCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void pressOnButton(int slot)
        {
            onCommands[slot].Execute();
        }

        public void pressOffButton(int slot)
        {
            offCommands[slot].Execute();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("------ Remote Control ------");
            for (int i = 0; i < BUTTONS_COUNT; i++)
            {
                stringBuilder.AppendLine($"[slot {i}] - {onCommands[i].Name}");
            }
            return stringBuilder.ToString();
        }
    }
}