using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Invoker
    {
        private List<Command> cmdHistory = new List<Command>();

        public void StoreAndExecute(string commandText)
        {
            //Input aus der Konsole
            string myCommandText = commandText;

            //Erstellt aus Konsoleneingabe die Parameter für Command
            Command myCommand = new Command(myCommandText);
            //Objekt zum erstellen von Cmd
            BaseCommand myCommandObj = null;
            //Erstellt konkretes Cmd Objekt

            BaseDisplay myDisplay = null;
            switch (myCommand.commandType)
            {
                #region create myCommandObj
                case "set":
                    myCommandObj = new CmdSet(SingletonClock.Instance);
                    break;
                case "dec":
                    myCommandObj = new CmdDec(SingletonClock.Instance);
                    break;
                case "inc":
                    myCommandObj = new CmdInc(SingletonClock.Instance);
                    break;
                case "undo":
                    #region Undo
                    //Beginne am Ende der Liste zu suchen da Liste (FIFO)
                    for (int i = cmdHistory.Count; i != 0; i--)
                    {
                        //sofern der Cmd noch nicht undo´t wurde
                        if (cmdHistory[i - 1].undoBool == false)
                        {
                            switch (cmdHistory[i - 1].commandType)
                            {
                                case "set":
                                    myCommandObj = new CmdSet(SingletonClock.Instance);
                                    break;
                                case "dec":
                                    Console.WriteLine(cmdHistory[i - 1]);
                                    myCommandObj = new CmdDec(SingletonClock.Instance);
                                    break;
                                case "inc":
                                    Console.WriteLine(cmdHistory[i - 1]);
                                    myCommandObj = new CmdInc(SingletonClock.Instance);
                                    break;
                                case "show":
                                    myCommandObj = new CmdShow(SingletonClock.Instance.subscriberList[SingletonClock.Instance.subscriberList.Count - 1]);
                                    break; ;
                            }
                            //Command wurde undo´t
                            cmdHistory[i - 1].undoBool = true;
                            myCommandObj.Undo(cmdHistory[i - 1]);
                            return;
                        }
                    }
                    #endregion
                    break;
                case "redo":
                    #region redo
                    //wiederholt den letzten Befehl
                    if (cmdHistory[cmdHistory.Count - 1] != null)
                    {
                        switch (cmdHistory[cmdHistory.Count - 1].commandType)
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
                            case "show":
                                foreach (var item in cmdHistory[cmdHistory.Count - 1].parameter)
                                {
                                    switch (item)
                                    {
                                        case "analog":
                                            myDisplay = new AnalogDisplay(myCommand);

                                            break;
                                        case "digital":
                                            myDisplay = new DigitalDisplay(myCommand);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                myCommandObj = new CmdShow(myDisplay);
                                break;

                        }
                        //oder macht das letzte undo wieder rückgängig 
                        cmdHistory[cmdHistory.Count - 1].undoBool = false;
                        //klont den letzten cmd
                        Command redoCommand = (Command)cmdHistory[cmdHistory.Count - 1].Clone();
                        cmdHistory.Add(redoCommand);
                        myCommandObj.Execute(cmdHistory[cmdHistory.Count - 1]);
                    }
                    #endregion
                    return;
                case "show":
                    #region show
                    //erstellt ein Objekt BaseDisplay zum übergeben an CmdShow
                    foreach (var item in myCommand.parameter)
                    {
                        switch (item)
                        {
                            case "analog":
                                myDisplay = new AnalogDisplay(myCommand);

                                break;
                            case "digital":
                                myDisplay = new DigitalDisplay(myCommand);
                                break;
                            default:
                                break;
                        }
                    }
                    myCommandObj = new CmdShow(myDisplay);
                    break;
                    #endregion
                default:
                    break;
            }
                #endregion
            cmdHistory.Add(myCommand);
            myCommandObj.Execute(myCommand);
        }
    }
}

