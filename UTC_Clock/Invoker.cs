using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Invoker
    {
        private List<Command> _commandParamterHistory = new List<Command>();
        public Invoker()
        {
        }


        public void StoreAndExecute(string commandText)
        {
            string myCommandText = commandText;
            BaseCommand myCommandObj = null;
            Command myCommand = new Command(myCommandText);
            switch (myCommand.commandType)
            {
                case "set":
                    myCommandObj = new CmdSet(SingletonClock.Instance);
                    _commandParamterHistory.Add(myCommand);
                    myCommandObj.Execute(myCommand);
                    break;
                case "dec":
                    myCommandObj = new CmdDec(SingletonClock.Instance);
                    _commandParamterHistory.Add(myCommand);
                    myCommandObj.Execute(myCommand);
                    break;
                case "inc":
                    myCommandObj = new CmdInc(SingletonClock.Instance);
                    _commandParamterHistory.Add(myCommand);
                    myCommandObj.Execute(myCommand);
                    break;
                case "undo":
                    foreach (var item in _commandParamterHistory)
                    {
                        if (item.undoBool == false)
                        {
                            switch (item.commandType)
                            {
                                case "set":
                                    myCommandObj = new CmdSet(SingletonClock.Instance);
                                    break;
                                case "dec":
                                    Console.WriteLine(item);
                                    myCommandObj = new CmdDec(SingletonClock.Instance);
                                    break;
                                case "inc":
                                    Console.WriteLine(item);
                                    myCommandObj = new CmdInc(SingletonClock.Instance);
                                    break;
                                case "show":
                                   //not implemented yet
                                case "undo":
                                    break;
                            }
                            item.undoBool = true;
                            myCommandObj.Undo(item);
                            break;
                        }
                    }
                    break;
                case "redo":
                    if (_commandParamterHistory[0] != null)
                    {
                        switch (_commandParamterHistory[0].commandType)
                        {
                            case "set":
                                myCommandObj = new CmdSet(SingletonClock.Instance);
                                break;
                            case "dec":
                                myCommandObj = new CmdInc(SingletonClock.Instance);
                                break;
                            case "inc":
                                myCommandObj = new CmdInc(SingletonClock.Instance);
                                break;
                        }
                        _commandParamterHistory[0].undoBool = false;
                        myCommandObj.Execute(_commandParamterHistory[0]);
                    }
                    break;
                case "show":
                    BaseDisplay myDisplay = null;
                    foreach (var item in myCommand.parameter)
                    {
                        switch (item)
                        {
                            case "analog":
                                myDisplay = new AnalogDisplay();
                                break;
                            case "digital":
                                myDisplay = new DigitalDisplay();
                                break;
                            default:
                                break;
                        }
                    }
                    myCommandObj = new CmdShow(myDisplay);
                    _commandParamterHistory.Add(myCommand);
                    myCommandObj.Execute(myCommand);
                    break;
                default:
                    break;
            }
        }
    }
}

