using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UTC_Clock
{
    class Invoker
    {
        private List<CreateMacro> cmdMacros = new List<CreateMacro>();
        private List<Command> cmdHistory = new List<Command>();
        public void StoreAndExecute(string commandText)
        {
            //Input aus der Konsole
            string myCommandText = commandText;
            Command myCommand = null;

            //Erstellt Command vom überegeben Text
            myCommand = new Command(myCommandText);

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
                    #region undo
                    try
                    {
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
                    }
                    catch (NullReferenceException e)
                    {
                        MessageBox.Show("No more Undos");
                        Console.WriteLine(e);
                        return;
                    }
                   
                    break;
                    #endregion
                case "redo":
                    #region redo
                    //wiederholt den letzten Befehl
                    try
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
                                            myDisplay = new AnalogDisplay(cmdHistory[cmdHistory.Count - 1]);
                                            break;
                                        case "digital":
                                            myDisplay = new DigitalDisplay(cmdHistory[cmdHistory.Count - 1]);
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
                    catch (ArgumentOutOfRangeException e)
                    {
                        MessageBox.Show("There is no command to redo");
                        Console.WriteLine(e);
                    }
                    
                    return;
                    #endregion
                case "show":
                    #region show
                    try
                    {
                        //Erstellt ein Objekt BaseDisplay zum übergeben an CmdShow
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
                    }
                    catch (FormatException e)
                    {
                        MessageBox.Show("Wrong CmdShow paramters, please type Help");
                        Console.WriteLine(e);
                    }
                    break;
                    #endregion
                case "create":
                    #region create
                    //Erstellt neuen Macro Befehl
                    CreateMacro newCMD = new CreateMacro(myCommand.parameter);
                    cmdMacros.Add(newCMD);
                    return;
                    #endregion
                case "execute":
                    #region execute
                    foreach (var item in cmdMacros)
                    {   //Suche Befehl in der CmdMacroList der mit Eingabe übereinstimmt
                        if (item.commandType == myCommand.parameter[0])
                        {
                            /*
                            executeMacro = item.parameter;
                            macroIncoming = true;*/
                            StoreAndExecute(item.parameter);
                            return;
                        }
                    }
                    return;
                    #endregion
                case "help":
                #region help
                    Helpme helpcommand = new Helpme();
                    return;
                #endregion
                default:
                    break;
                #endregion
            }
            try
            {
                cmdHistory.Add(myCommand);
                myCommandObj.Execute(myCommand);
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Wrong Command, please type Help");
                Console.WriteLine(e);
            }
            
        }

    }
}

