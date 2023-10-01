// See https://aka.ms/new-console-template for more information

using RemoteController;
using RemoteController.Commands;
using RemoteController.Models;

var remoteControl = new RemoteControl();

var livingRoomLight = new Light(RoomsEnum.LivingRoom);
var kitchenLight = new Light(RoomsEnum.Kitchen);
var livingRoomCeilingFan = new CeilingFan(RoomsEnum.LivingRoom);
var garageDoor = new Door(RoomsEnum.Garage);
var livingRoomStereo = new Stereo(RoomsEnum.LivingRoom);

var livingRoomLightOn = new LightOnCommand(livingRoomLight);
var livingRoomLightOff = new LightOffCommand(livingRoomLight);

var kitchenLightOn = new LightOnCommand(kitchenLight);
var kitchenLightOff = new LightOffCommand(kitchenLight);

var ceilingFanOn = new CeilingFanOnCommand(livingRoomCeilingFan);
var ceilingFanOff = new CeilingFanOffCommand(livingRoomCeilingFan);

var garageDoorUpCommand = new DoorUpCommand(garageDoor);
var garageDoorDownCommand = new DoorDownCommand(garageDoor);

var stereoOnWithCD = new StereoOnWithCDCommand(livingRoomStereo);
var stereoOffWithCD = new StereoOffWithCDCommand(livingRoomStereo);

var partyOnCommands = new List<ICommand> { new LightOnCommand(livingRoomLight), new CeilingFanOnCommand(livingRoomCeilingFan), new StereoOnWithCDCommand(livingRoomStereo) };
var partyOffCommands = new List<ICommand> { new LightOffCommand(livingRoomLight), new CeilingFanOffCommand(livingRoomCeilingFan), new StereoOffWithCDCommand(livingRoomStereo) };
var macroPartyOnCommand = new MacroCommand(partyOnCommands);
var macroPartyOffCommand = new MacroCommand(partyOffCommands);

remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
remoteControl.SetCommand(2, ceilingFanOn, ceilingFanOff);
remoteControl.SetCommand(3, stereoOnWithCD, stereoOffWithCD);
remoteControl.SetCommand(4, garageDoorUpCommand, garageDoorDownCommand);
remoteControl.SetCommand(5, macroPartyOnCommand, macroPartyOffCommand);

Console.WriteLine(remoteControl);

Console.WriteLine("------ Commands ------");
//remoteControl.PressOnButton(0);
//remoteControl.PressOffButton(0);
//remoteControl.PressOnButton(1);
//remoteControl.PressUndoButton();
//remoteControl.PressOnButton(2);
//remoteControl.PressOffButton(2);
//remoteControl.PressOnButton(3);
//remoteControl.PressUndoButton();
//remoteControl.PressOnButton(4);
//remoteControl.PressOffButton(4);
remoteControl.PressOnButton(5);
remoteControl.PressUndoButton();